using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS_Services.Infraestructure.API;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Controllers
{
    [RoutePrefix(RESOURCE_ENVIRONMENT_API_ODOO)]
    public class EnvironmentApiOdooController : ApiController
    {
        
        private readonly EnvironmentApiOdooDAL environmentApiOdooDAL;

        public EnvironmentApiOdooController(EnvironmentApiOdooDAL environmentApiOdooDAL)
        {
            this.environmentApiOdooDAL = environmentApiOdooDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<EnvironmentApiOdooDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<EnvironmentApiOdooDTO>>(HttpStatusCode.OK, environmentApiOdooDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<EnvironmentApiOdooDTO> getById(int id)
        {
            return new ActionResultApi<EnvironmentApiOdooDTO>(HttpStatusCode.OK, environmentApiOdooDAL.getById(id), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<EnvironmentApiOdooDTO> create([FromBody] EnvironmentApiOdooDTO model)
        {
            return new ActionResultApi<EnvironmentApiOdooDTO>(HttpStatusCode.OK, environmentApiOdooDAL.create(model), Request);
        }

        [HttpDelete]
        [Route(FIELD_ID)]
        public ActionResultApi<EnvironmentApiOdooDTO> remove(int id)
        {
            return new ActionResultApi<EnvironmentApiOdooDTO>(HttpStatusCode.OK, environmentApiOdooDAL.remove(id), Request);
        }
    }
}
