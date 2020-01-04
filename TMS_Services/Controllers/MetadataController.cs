using CookComputing.XmlRpc;
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
    public class MetadataController : ApiController
    {

            
        [Route(GET_LIST_TABLE)]
        [HttpGet]
        public ActionResultApi<List<MetadataDTO>> tablesOdoo()
        {
            return new ActionResultApi<List<MetadataDTO>>(HttpStatusCode.OK, MetadataDAL.getTablesOdoo(), Request);
        }


        [Route(GET_TABLE)]
        [HttpGet]
        public ActionResultApi<MetadataDTO> tableOdooByName(string name)
        {
            return new ActionResultApi<MetadataDTO>(HttpStatusCode.OK, MetadataDAL.getTableOdoo(name), Request);
        }


        [Route(GET_MODEL)]
        [HttpPost]
        public ActionResultApi<XmlRpcStruct> modelOdoo([FromBody] ModelFilterDTO modelFilter)
        {
            return new ActionResultApi<XmlRpcStruct>(HttpStatusCode.OK, MetadataDAL.getModelOdoo(modelFilter), Request);
        }



    }
}