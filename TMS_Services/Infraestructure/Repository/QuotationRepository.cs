using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Infraestructure.Repository
{
    public class QuotationRepository : Repository<SolicitudCotizacion>, IQuotationRepository
    {
        // provisionalmente mandar estos parametros
        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;
        private readonly IRouteRepository routeRepository;
        
        private readonly OdooAPI odooApi; // not dependency injection

        public QuotationRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository, IRouteRepository routeRepository) : base(dbContext)
        {
            this.routeRepository = routeRepository;
            this.connectionApiOdooRepository = connectionApiOdooRepository;

            var modelApiOdoo = this.connectionApiOdooRepository.getConnectionCurrentApiOdoo();
            odooApi = getConnectionDefault(modelApiOdoo);
        }

        // Rediseñar el algoritmo para enviar el modelo de cotizacion de acuerdo a los parametros de Odoo
        public bool createInERP(QuotationDTO quotation)
        {
            //var odooCredentials = new OdooConnectionCredentials("https://deltacargo-deltaqa-646890.dev.odoo.com", "deltacargo-deltaqa-646890", "deltacargomanuel2019@gmail.com", "delta011235813");
            //var odooApi = new OdooAPI(odooCredentials);
            
            var modelXML = new XmlRpcStruct();
            modelXML["name"] = quotation.company_name;
            modelXML["contact_name"] = quotation.name;
            modelXML["email_from"] = quotation.email_from;
            modelXML["phone"] = quotation.phone;
            modelXML["city"] = quotation.routeCityOrigin;

            var routeOriginModel = (RouteDTO)routeRepository.getById(quotation.idMacroRouteOrigin.GetValueOrDefault());

            if (!isNull(routeOriginModel))
            {
                int[] ids = odooApi.Search("res.country", new object[1] { new object[] { "name", "=", routeOriginModel.name } });
                List<XmlRpcStruct> countriesTuples = odooApi.Read("res.country", ids, new object[] { })
                    .ToList()
                    .Cast<XmlRpcStruct>()
                    .ToList();
                if (countriesTuples.Count > 0)
                {
                    modelXML["country_id"] = countriesTuples[0]["id"];
                    /*modelXML["country_id"] = new object[1] { new object[] { countriesTuples[0]["id"], countriesTuples[0]["name"]} };*/
                }
            }
            // arreglar para obtener el nombre del pais
            modelXML["street"] = quotation.street;
            modelXML["kanban_state"] = quotation.kanban_state; //"grey"; // [grey, red]
            modelXML["type"] = quotation.type; //"lead";
            modelXML["description"] = quotation.description;

            int idObjCreated = odooApi.Create("crm.lead", modelXML);

            return idObjCreated > 0; // analizar la respuesta 
        }
    }
}