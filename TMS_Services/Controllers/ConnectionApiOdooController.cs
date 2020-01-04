using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS_Services.Infraestructure.API;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Controllers
{
    [RoutePrefix(RESOURCE_CONNECTION_API_ODOO)]
    public class ConnectionApiOdooController : ApiController
    {

        private readonly ConnectionApiOdooDAL connectionApiOdooDAL;

        public ConnectionApiOdooController(ConnectionApiOdooDAL connectionApiOdooDAL)
        {
            this.connectionApiOdooDAL = connectionApiOdooDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<ConnectionApiOdooDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<ConnectionApiOdooDTO>>(HttpStatusCode.OK, connectionApiOdooDAL.getAll(), Request);

        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<ConnectionApiOdooDTO> getById(int id)
        {
            return new ActionResultApi<ConnectionApiOdooDTO>(HttpStatusCode.OK, connectionApiOdooDAL.getById(id), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<ConnectionApiOdooDTO> create([FromBody] ConnectionApiOdooDTO model)
        {
            return new ActionResultApi<ConnectionApiOdooDTO>(HttpStatusCode.OK, connectionApiOdooDAL.create(model), Request);
        }

        [HttpPut]
        [Route(ROOT)]
        public ActionResultApi<ConnectionApiOdooDTO> edit([FromBody] ConnectionApiOdooDTO model)
        {
            return new ActionResultApi<ConnectionApiOdooDTO>(HttpStatusCode.OK, connectionApiOdooDAL.edit(model), Request);
        }


        [HttpDelete]
        [Route(FIELD_ID)]
        public ActionResultApi<ConnectionApiOdooDTO> remove(int id)
        {
            return new ActionResultApi<ConnectionApiOdooDTO>(HttpStatusCode.OK, connectionApiOdooDAL.remove(id), Request);
        }

        [HttpDelete]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<ConnectionApiOdooDTO>> removeAll()
        {
            return new ActionResultApi<IEnumerable<ConnectionApiOdooDTO>>(HttpStatusCode.OK, connectionApiOdooDAL.removeAll(), Request);
        }


        [HttpPut]
        [Route(FIELD_CONNECTION_API_ODOO_ID)]
        public ActionResultApi<ConnectionApiOdooDTO> updateConnectionDefault(int connectionApiOdooId)
        {
            return new ActionResultApi<ConnectionApiOdooDTO>(HttpStatusCode.OK, connectionApiOdooDAL.updateConnectionDefault(connectionApiOdooId), Request);
        }

        

    }
}
