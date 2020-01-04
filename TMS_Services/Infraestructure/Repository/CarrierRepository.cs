using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Repository
{
    public class CarrierRepository : Repository<Transportista>, ICarrierRepository
    {
        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;

        public CarrierRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository) : base(dbContext)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
        }



        /*public IEnumerable<TransportRouteDTO> addBusyRoutes(CarrierDTO carrier)
        {
            List<TransportRouteDTO> routes = new List<TransportRouteDTO>();
            carrier.ids_Route
                .ForEach(rc =>
                {
                    if (rc.marked)
                    {
                        var rowCarrierRoute = (TransportRouteDTO)
                            repCarrierRoute
                                .create(
                                    new Transportista_Ruta
                                    {
                                        id_ruta = rc.id,
                                        id_transportista = carrier.id,
                                        estado = 1
                                    }
                                );
                        // persistencia de datos (transportista_Ruta)
                        int rowAffect = repCarrierRoute.save();
                        if (rowAffect > 0)
                        {
                            routes.Add(rowCarrierRoute);
                        }
                    }
                });
            return routes;


            // guardar al transportista en la afiliacion que corresponda
            repCarrierMembership.create(new Transportista_Afiliacion
            {
                id_afilacion = carrier.id_afiliacion,
                id_transportista = carrier.id
            });
            int rowAffectMembership = repCarrierMembership.save();
            if (rowAffectMembership > 0)
            {

            }

        }*/

    }
}