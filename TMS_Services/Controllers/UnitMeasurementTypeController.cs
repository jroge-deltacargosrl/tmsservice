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
    [RoutePrefix(RESOURCE_UNIT_MEASUREMENT_TYPE)]
    public class UnitMeasurementTypeController : ApiController
    {

        private readonly UnitMeasurementTypeDAL unitMeasurementTypeDAL;

        public UnitMeasurementTypeController(UnitMeasurementTypeDAL unitMeasurementTypeDAL)
        {
            this.unitMeasurementTypeDAL = unitMeasurementTypeDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<UnitMeasurementTypeDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<UnitMeasurementTypeDTO>>(HttpStatusCode.OK, unitMeasurementTypeDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<UnitMeasurementTypeDTO> getById(int id)
        {
            return new ActionResultApi<UnitMeasurementTypeDTO>(HttpStatusCode.OK, unitMeasurementTypeDAL.getById(id), Request);
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<UnitMeasurementTypeDTO> create([FromBody]UnitMeasurementTypeDTO model)
        {
            return new ActionResultApi<UnitMeasurementTypeDTO>(HttpStatusCode.OK,unitMeasurementTypeDAL.create(model),Request);
        }

        [HttpDelete]
        [Route(ROOT)]
        public ActionResultApi<UnitMeasurementTypeDTO> delete(int id)
        {
            return new ActionResultApi<UnitMeasurementTypeDTO>(HttpStatusCode.OK, unitMeasurementTypeDAL.delete(id), Request);
        }







    }
}
