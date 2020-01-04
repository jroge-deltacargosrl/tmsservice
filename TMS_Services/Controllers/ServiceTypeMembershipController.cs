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
    [RoutePrefix(RESOURCE_SERVICE_TYPE_MEMBERSHIP)]
    public class ServiceTypeMembershipController : ApiController
    {

        private readonly ServiceTypeMembershipDAL serviceTypeMembershipDAL;

        public ServiceTypeMembershipController(ServiceTypeMembershipDAL serviceTypeMembershipDAL)
        {
            this.serviceTypeMembershipDAL = serviceTypeMembershipDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<ServiceTypeMembershipDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<ServiceTypeMembershipDTO>>(HttpStatusCode.OK, serviceTypeMembershipDAL.getAll(), Request);
        }

        // Pendientes de analisis (incluir todo los datos extraidos de las relaciones en las tablas
        [HttpGet]
        [Route(FIELD_COMPANY_ID)]
        public ActionResultApi<IEnumerable<ServiceTypeDTO>> getAllByCompanyId(int companyId)
        {
            return new ActionResultApi<IEnumerable<ServiceTypeDTO>>(HttpStatusCode.OK, serviceTypeMembershipDAL.getAllByCompanyId(companyId), Request);
        }

        [HttpGet]
        [Route(FIELD_SERVICE_TYPE_ID)]
        public ActionResultApi<IEnumerable<ServiceTypeDTO>> getAllByServiceTypeId(int serviceTypeId)
        {
            return new ActionResultApi<IEnumerable<ServiceTypeDTO>>(HttpStatusCode.OK, serviceTypeMembershipDAL.getAllByCompanyId(serviceTypeId), Request);
        }


    }



}
