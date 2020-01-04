using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Repository
{
    public class CarrierRouteRepository : Repository<Transportista_Ruta>, ICarrierRouteRepository
    {
        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;

        public CarrierRouteRepository(DeltaDBEntities dbContext, IConnectionApiOdooRepository connectionApiOdooRepository) : base(dbContext)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
        }

        public IEnumerable<CarrierDTO> getCarrieresInRoute(int idRoute)
        {
            List<CarrierDTO> result = new List<CarrierDTO>();
            dbContext.Transportista_Ruta
                .Include("Transportista")
                .Where(t => t.id_ruta == idRoute)
                .ToList()
                .ForEach(cr => result.Add((CarrierDTO)cr.Transportista));
            return result;
        }

        public IEnumerable<RouteDTO> getRoutesAvailables(int idCarrier)
        {
            List<RouteDTO> result = new List<RouteDTO>();
            dbContext.Transportista_Ruta
                .Include("Ruta")
                .Where(t => t.id_transportista == idCarrier)
                .ToList()
                .ForEach(cr => result.Add((RouteDTO)cr.Ruta));
            return result;
        }

        // aun sin metodos fuera de los usuales del CRUD de la base de datos
    }
}