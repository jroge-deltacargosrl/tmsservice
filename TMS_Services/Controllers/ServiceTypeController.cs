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

    [RoutePrefix(RESOURCE_SERVICE_TYPE)]
    public class ServiceTypeController : ApiController
    {

        private readonly ServiceTypeDAL serviceTypeDAL;

        public ServiceTypeController(ServiceTypeDAL serviceTypeDAL)
        {
            this.serviceTypeDAL = serviceTypeDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<ServiceTypeDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<ServiceTypeDTO>>(HttpStatusCode.OK, serviceTypeDAL.getAll(), Request);
        }


        /*// Metodo pendiente de analisis para la reubicacion
        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<IEnumerable<ServiceTypeDTO>> getAllByCompany(int companyId)
        {
            return new ActionResultApi<IEnumerable<ServiceTypeDTO>>(HttpStatusCode.OK, serviceTypeDAL.getAllByCompanyId(companyId), Request);
        }
        */
    }
}
