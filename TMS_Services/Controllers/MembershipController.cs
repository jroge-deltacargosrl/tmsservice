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
    [RoutePrefix(RESOURCE_MEMBERSHIP)]
    public class MembershipController : ApiController
    {
        private readonly MembershipDAL membershipDAL;
        public MembershipController(MembershipDAL membershipDAL)
        {
            this.membershipDAL = membershipDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<MembershipDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<MembershipDTO>>(HttpStatusCode.OK,membershipDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<MembershipDTO> getById(int id)
        {
            return new ActionResultApi<MembershipDTO>(HttpStatusCode.OK, membershipDAL.getById(id), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<MembershipDTO> create([FromBody] MembershipDTO model)
        { 
            return new ActionResultApi<MembershipDTO>(HttpStatusCode.OK, membershipDAL.create(model), Request);
        }

        [HttpPut]
        [Route(ROOT)]
        public ActionResultApi<MembershipDTO> update([FromBody] MembershipDTO model)
        {
            return new ActionResultApi<MembershipDTO>(HttpStatusCode.OK, membershipDAL.update(model), Request);
        }

        [HttpDelete]
        [Route(FIELD_ID)]
        public ActionResultApi<MembershipDTO> remove(int id)
        {
            return new ActionResultApi<MembershipDTO>(HttpStatusCode.OK, membershipDAL.delete(id), Request);
        }

    }
}
