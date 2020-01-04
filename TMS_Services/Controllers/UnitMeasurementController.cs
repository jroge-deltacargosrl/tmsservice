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
    [RoutePrefix(RESOURCE_UNIT_MEASUREMENT)]
    public class UnitMeasurementController : ApiController
    {

        private readonly UnitMeasurementDAL unitMeasurementDAL;

        public UnitMeasurementController(UnitMeasurementDAL unitMeasurementDAL)
        {
            this.unitMeasurementDAL = unitMeasurementDAL;
        }

        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<UnitMeasurementDTO>> getAll()
        {
            return new ActionResultApi<IEnumerable<UnitMeasurementDTO>>(HttpStatusCode.OK, unitMeasurementDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<UnitMeasurementDTO> getById(int id)
        {
            return new ActionResultApi<UnitMeasurementDTO>(HttpStatusCode.OK, unitMeasurementDAL.getById(id), Request);
        }

        [HttpGet]
        //[Route("type/{id}")] // provisional
        [Route(FIELD_ID_BY_TYPE)]
        public ActionResultApi<IEnumerable<UnitMeasurementDTO>> getByType(int idUnitMeasurementType)
        {
            return new ActionResultApi<IEnumerable<UnitMeasurementDTO>>(HttpStatusCode.OK, unitMeasurementDAL.getByType(idUnitMeasurementType), Request);
        }

        [HttpGet]
        //[Route("typeName/{name}")]
        [Route(FIELD_NAME_BY_TYPE)]
        public ActionResultApi<IEnumerable<UnitMeasurementDTO>> getByNameTypeFiltered(string name)
        {
            return new ActionResultApi<IEnumerable<UnitMeasurementDTO>>(HttpStatusCode.OK, unitMeasurementDAL.getUnitsMeasurementFiltered(name), Request);
        }


        /*[Route(GET_LIST_UNIT_MEASUREMENT_TYPES)]
        [HttpGet]
        public ActionResultApi<List<UnitMeasurementTypeDTO>> getTypesUnitMeasurement()
        {
            return new ActionResultApi<List<UnitMeasurementTypeDTO>>(HttpStatusCode.OK, UnitMeasurementTypeDAL.getAll(), Request);
        }*/
    }
}
