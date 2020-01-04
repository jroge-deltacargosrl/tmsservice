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
    [RoutePrefix(RESOURCE_TRUCK_TYPE)]
    public class TruckTypeController : ApiController
    {

        private readonly TruckTypeDAL truckTypeDAL;


        public TruckTypeController(TruckTypeDAL truckTypeDAL)
        {
            this.truckTypeDAL = truckTypeDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<TruckTypeDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<TruckTypeDTO>>(HttpStatusCode.OK, truckTypeDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<TruckTypeDTO> getById(int id)
        {
            return new ActionResultApi<TruckTypeDTO>(HttpStatusCode.OK, truckTypeDAL.getById(id), Request);
        }





    }
}