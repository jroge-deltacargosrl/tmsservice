using OdooRpcWrapper;
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
    [RoutePrefix(RESOURCE_CONTACT)]
    public class ContactController : ApiController
    {

        //private static OdooAPI odooApi = new OdooAPI()
        private readonly ContactDAL contactDAL;

        public ContactController(ContactDAL contactDAL)
        {
            this.contactDAL = contactDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<ContactDTO>> getAllContactsErp()
        {
            return new ActionResultApi<IEnumerable<ContactDTO>>(HttpStatusCode.OK, contactDAL.getAllContactsErp(), Request);
        }

        /*[Route("api/v1/passwords/")]
        [HttpGet]
        public ActionResultApi<List<ContactDTO>> getPasswords()
        {  
            return new ActionResultApi<List<ContactDTO>>(HttpStatusCode.OK, CustomerDAL.getPasswords(), Request);
        }*/


        [HttpPost]
        [Route(SYNC_CONTACT)]
        public ActionResultApi<IEnumerable<ContactDTO>> syncContacts()
        {
            return new ActionResultApi<IEnumerable<ContactDTO>>(HttpStatusCode.OK, contactDAL.syncWithErp(), Request);
        }
        

    }
}
