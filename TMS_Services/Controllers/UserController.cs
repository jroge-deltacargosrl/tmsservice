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
    [RoutePrefix(RESOURCE_USER)]
    public class UserController : ApiController
    {

        private readonly UserDAL userDAL;

        public UserController(UserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        [HttpPost]
        [Route(ACCESS_USER)]
        public ActionResultApi<UserResponseDTO> accessClient([FromBody] UserDTO request)
        {
            return new ActionResultApi<UserResponseDTO>(HttpStatusCode.OK, userDAL.logIn(request), Request);
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<UserDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<UserDTO>>(HttpStatusCode.OK, userDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<UserDTO> getById(int id)
        {
            return new ActionResultApi<UserDTO>(HttpStatusCode.OK, userDAL.getById(id), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<UserDTO> create([FromBody] UserDTO model)
        {
            return new ActionResultApi<UserDTO>(HttpStatusCode.OK, userDAL.create(model), Request);
        }

        [HttpPut]
        [Route(ROOT)]
        public ActionResultApi<UserDTO> update([FromBody] UserDTO model)
        {
            return new ActionResultApi<UserDTO>(HttpStatusCode.OK, userDAL.update(model), Request);
        }

        [HttpPut]
        [Route(UPDATE_PRIVILEGES_USER)]
        public ActionResultApi<UserDTO> uodatePrivileges([FromBody] UserDTO model)
        {
            return new ActionResultApi<UserDTO>(HttpStatusCode.OK, userDAL.updatePrivileges(model), Request);
        }

        [HttpDelete]
        [Route(FIELD_ID)]
        public ActionResultApi<UserDTO> delete(int id)
        {
            return new ActionResultApi<UserDTO>(HttpStatusCode.OK, userDAL.delete(id), Request);
        }


        [HttpPut]
        [Route(GENERATE_FIRST_PASSWORD_USER)]
        public ActionResultApi<UserDTO> generateFirstPassword(int userId)
        {
            return new ActionResultApi<UserDTO>(HttpStatusCode.OK, userDAL.generateFirstPassword(userId), Request);
        }

    }
}
