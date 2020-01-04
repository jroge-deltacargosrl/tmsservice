using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;


namespace TMS_Services.Models.DAL
{
    public class CarrierDAL
    {

        private readonly ICarrierRepository carrierRepository;
        
        private readonly ICarrierRouteRepository carrierRouteRepository;
        private readonly ICarrierMembershipRepository carrierMembershipRepository; // relacion 
        private readonly IRouteRepository routeRepository;

        public CarrierDAL(ICarrierRepository carrierRepository, ICarrierRouteRepository carrierRouteRepository, ICarrierMembershipRepository carrierMembershipRepository, IRouteRepository routeRepository)
        {
            this.carrierRepository = carrierRepository;
            this.carrierRouteRepository = carrierRouteRepository;
            this.carrierMembershipRepository = carrierMembershipRepository;
            this.routeRepository = routeRepository;
        }

        public CarrierDTO create(CarrierDTO carrier)
        {
            CarrierDTO result = default;
            Transportista newCarrier = carrierRepository.create((Transportista)carrier);
            if (!isNull(newCarrier)) // transportista registrado
            {
                List<CarrierRouteDTO> carrierRoutes = new List<CarrierRouteDTO>();
                // agrega las rutas seleccionadas por el tranasportista
                carrier.ids_Route
                    .ForEach(cr =>
                    {
                        if (cr.marked)
                        {
                            // llamar al otro repositorio
                            var carrierRoute = (CarrierRouteDTO)carrierRouteRepository.create(new CarrierRouteDTO
                            {
                                id_route = cr.id,
                                id_carrier = newCarrier.id,
                                state = 1
                            });
                            if (!isNull(carrierRoute))
                            {
                                carrierRoutes.Add(carrierRoute);
                            }
                        }
                    });
                CarrierMembershipDTO carrierMemberShip = (CarrierMembershipDTO)carrierMembershipRepository.create(new CarrierMembershipDTO
                {
                    id_membership = carrier.id_membership,
                    id_carrier = newCarrier.id
                });
                carrier.ids_Route.Clear(); // reutilizar ese objeto
                // incluir las rutas tambien para poder visualizarlas en pantalla
                // obtener el listado de rutas, definir los datos que
                List<RouteDTO> routesSelect = carrierRouteRepository.getRoutesAvailables(newCarrier.id).ToList();

                result = (CarrierDTO)carrierRepository.getById(newCarrier.id);
                result.ids_Route = routesSelect;
            }
            return result;
        }

        // obtener la lista de Transportistas con las rutas indicadas
        public IEnumerable<Transportista_Ruta> getAll()
        {
            IEnumerable<Transportista_Ruta> routes = carrierRouteRepository.get();
            return routes;
        }

        public CarrierDTO getById(long id)
        {
            return (CarrierDTO)carrierRepository.getById(id);
        }

        public CarrierDTO delete(int id)
        {
            return (CarrierDTO)carrierRepository.remove(id);
        }

        public IEnumerable<CarrierDTO> deleteAll()
        {
            return carrierRepository.removeAll()
                .ToList()
                .ConvertAll(c => (CarrierDTO)c);
        }




    }
}