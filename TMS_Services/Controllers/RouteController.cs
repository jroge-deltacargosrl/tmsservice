using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.API;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Controllers
{
    [RoutePrefix(RESOURCE_ROUTE)]
    public class RouteController : ApiController
    {

        private readonly RouteDAL routeDAL;

        public RouteController(RouteDAL routeDAL)
        {
            this.routeDAL = routeDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<RouteDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<RouteDTO>>(HttpStatusCode.OK, routeDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<RouteDTO> getById(int id)
        {
            return new ActionResultApi<RouteDTO>(HttpStatusCode.OK, routeDAL.getBydId(id), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<RouteDTO> create([FromBody] RouteDTO model)
        {
            return new ActionResultApi<RouteDTO>(HttpStatusCode.OK, routeDAL.create(model), Request);
        }

        [HttpDelete]
        [Route(ROOT)]
        public ActionResultApi<RouteDTO> delete(int id)
        {
            return new ActionResultApi<RouteDTO>(HttpStatusCode.OK, routeDAL.delete(id), Request);
        }


        /*// GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }*/
    }
}