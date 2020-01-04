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
    [RoutePrefix(RESOURCE_CLIENT)]
    public class ClientController : ApiController
    {

        private readonly ClientDAL clientDAL;

        public ClientController(ClientDAL clientDAL)
        {
            this.clientDAL = clientDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<ClientDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<ClientDTO>>(HttpStatusCode.OK, clientDAL.getAll(), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<ClientDTO> create([FromBody] ClientDTO model)
        {
            return new ActionResultApi<ClientDTO>(HttpStatusCode.OK, clientDAL.create(model), Request);
        }
        
        [HttpDelete]
        [Route(ROOT)]
        public ActionResultApi<ClientDTO> delete(int id)
        {
            return new ActionResultApi<ClientDTO>(HttpStatusCode.OK, clientDAL.remove(id), Request);
        }
    }
}
