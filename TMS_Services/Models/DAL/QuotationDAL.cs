using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;
using TMS_Services.Models.DTO.ViewModels;
using TMS_Services.Models.ViewModels;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DAL
{
    public class QuotationDAL
    {
        // reemplazar por el patron Unit Of Work
        private readonly ITruckTypeRepository truckTypeRepository;
        private readonly IServiceTypeMembershipRepository serviceTypeMembershipRepository;
        private readonly IRouteRepository routeRepository;
        private readonly IUnitMeasurementRepository unitMeasurementRepository;
        private readonly IMembershipRepository membershipRepository;
        private readonly IQuotationRepository quotationRepository;

        

        //private readonly IClientRepository clientRepository;

        public QuotationDAL(ITruckTypeRepository truckTypeRepository, IServiceTypeMembershipRepository serviceTypeMembershipRepository, IRouteRepository routeRepository, IUnitMeasurementRepository unitMeasurementRepository, IMembershipRepository membershipRepository, IQuotationRepository quotationRepository)
        {
            this.truckTypeRepository = truckTypeRepository;
            this.serviceTypeMembershipRepository = serviceTypeMembershipRepository;
            this.routeRepository = routeRepository;
            this.unitMeasurementRepository = unitMeasurementRepository;
            this.membershipRepository = membershipRepository;
            this.quotationRepository = quotationRepository;
            
        }

        // adecuar la logica para obtener los servicios de acuerdo al [Id_Membership]o [Company_Name]
        public QuotationViewDTO getAllServices(int companyId)
           =>
            // modificar esta seccion para recibir los datos por cada recurso u objetos
            new QuotationViewDTO
            {
                servicesTypes = serviceTypeMembershipRepository.getAllByCompanyId(companyId),

                macroRoutes = routeRepository.get().ToList().ConvertAll(r => (RouteDTO)r),
                trucksTypes = truckTypeRepository.get().ToList().ConvertAll(t => (TruckTypeDTO)t),

                // unidades de medida
                umsStorageCapacity =  unitMeasurementRepository.getUnitsMeasurementFiltered("storage_capacity"), 
                umsStorageTime = unitMeasurementRepository.getUnitsMeasurementFiltered("storage_time"),
            };


        public QuotationDetailsViewDTO create(QuotationDTO quotation)
        {
            // registrar solicitud de cotizacion en azure db
            var quotationCreated = (QuotationDTO)quotationRepository.create(quotation);
            // obtener la afiliacion origen de la cotizacion
            var associatedAffiliation = (MembershipDTO)membershipRepository.getById(quotation.id_membership.GetValueOrDefault());

            QuotationDetailsViewDTO quotationDetails = default;

            quotationDetails = new QuotationDetailsViewDTO
            {
                name = quotation.name,
                company = quotation.company_name,
                phone = quotation.phone,
                email = quotation.email_from,
                serviceType = serviceTypeMembershipRepository.getById(quotation.idServiceType, includes: "TipoServicio").TipoServicio.servicio,
                comment = quotation.comment
            };
            switch (quotationDetails.serviceType)
            {
                case "Transporte Urbano en SCZ":
                    // sin campo en particular
                    break;
                case "Almacenamiento de Carga en SCZ":
                    quotationDetails.storageCapacity = $"{quotation.storageCapacity} {((UnitMeasurementDTO)unitMeasurementRepository.getById(quotation.idUmStorageCapacity.GetValueOrDefault())).abbreviation}.";
                    
                    quotationDetails.storageTime = $"{quotation.storageTime} {((UnitMeasurementDTO)unitMeasurementRepository.getById(quotation.idUmStorageTime.GetValueOrDefault())).abbreviation}."; ;
                    break;
                case "Transporte Nacional":
                    quotationDetails.cityOrigin = quotation.routeCityOrigin;
                    quotationDetails.cityDestination = quotation.routeCityDestination;
                    break;
                case "Transporte Internacional":
                    quotationDetails.countryOrigin = ((RouteDTO)routeRepository.getById(quotation.idMacroRouteOrigin.GetValueOrDefault())).name;
                    quotationDetails.cityOrigin = quotation.routeCityOrigin;
                    quotationDetails.countryDestination = ((RouteDTO)routeRepository.getById(quotation.idMacroRouteDestination.GetValueOrDefault())).name;
                    quotationDetails.cityDestination = quotation.routeCityDestination;
                    break;
                case "Ruta Urbana SCZ":
                    quotationDetails.street = quotation.street;
                    break;
                default:
                    break;
            }
            if (!quotationDetails.serviceType.Equals("Almacenamiento de Carga en SCZ"))
            {
                quotationDetails.loadWeight = $"{quotation.loadWeight} Tn.";
                quotationDetails.loadVolume = $"{quotation.loadVolume} m3";
            }
            switch (associatedAffiliation.company)
            {
                case "Delta Cargo SRL": // registrar solicitud de cotizacion en ERP Odoo
                    
                    quotation.kanban_state = "grey";
                    quotation.type = "lead";

                    // Crear el View Model para registrar el campo "internal notes" en oodo
                    quotation.description = getDescriptionQuotationWithFormat(quotationDetails);
                    quotationRepository.createInERP(quotation);
                    break;
                case "Delta Express": // solo se debe registrar en DeltaDB
                    
                    break;
                default:
                    break;
            }
            return quotationDetails;
        }


    }
}