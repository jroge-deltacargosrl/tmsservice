using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;

namespace TMS_Services.Models.DAL
{
    public class RouteDAL
    {

        /*private static OdooAPI odooApi = new OdooAPI(new OdooConnectionCredentials("https://deltacargo-deltaqa-646890.dev.odoo.com", "deltacargo-deltaqa-646890", "deltacargomanuel2019@gmail.com", "delta011235813"));*/

        private readonly IRouteRepository routeRepository;

        public RouteDAL(IRouteRepository routeRepository)
        {
            this.routeRepository = routeRepository;
        }

        public IEnumerable<RouteDTO> getAll(Expression<Func<Ruta, bool>> filter = null, Func<IQueryable<Ruta>, IOrderedQueryable<Ruta>> orderBy = null)
        {
            return routeRepository.get(filter,orderBy)
                .ToList()
                .ConvertAll(r => (RouteDTO)r);
        }

        public RouteDTO getBydId(int id)
        {
            return (RouteDTO)routeRepository.getById(id);
        }

        public RouteDTO create(RouteDTO model)
        {
            return (RouteDTO)routeRepository.create((Ruta)model);
        }

        public RouteDTO delete(int id)
        {
            return (RouteDTO)routeRepository.remove(id);
        }


      



    }
}