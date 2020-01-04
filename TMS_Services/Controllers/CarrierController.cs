using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.API;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Controllers
{
    [RoutePrefix(RESOURCE_CARRIER)]
    public class CarrierController : ApiController
    {
        // eliminar el CarrierDAL original al terminar la refactorizacion, de la Class CarrierDAL2
        private readonly CarrierDAL carrierDAL; 
        public CarrierController(CarrierDAL carrierDAL)
        {
            this.carrierDAL = carrierDAL;
        }

        [HttpPost]
        [Route(ROOT)]
        public ActionResultApi<CarrierDTO> create([FromBody] CarrierDTO model)
        {
            return new ActionResultApi<CarrierDTO>(HttpStatusCode.OK,carrierDAL.create(model),Request); 
        }

        // metodo que obtiene los datos de la tabla [Transportista_Ruta]
        [HttpGet]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<Transportista_Ruta>> getAll()
        {
            // cambiar al anterior response (CarrierDTO)
            return new ActionResultApi<IEnumerable<Transportista_Ruta>>(HttpStatusCode.OK, carrierDAL.getAll(), Request);
        }

        [HttpGet]
        [Route(FIELD_ID)]
        public ActionResultApi<CarrierDTO> getById(long id)
        {
            return new ActionResultApi<CarrierDTO>(HttpStatusCode.OK,carrierDAL.getById(id), Request);
        }


        [HttpPut]
        [Route(ROOT)]
        public ActionResultApi<CarrierDTO> update([FromBody] CarrierDTO model)
        {
            return null;
            /*return new ActionResultTms<CarrierDTO>(HttpStatusCode.OK, (CarrierDTO)carrierRepository.update((Transportista)model), Request);*/
        }

        [HttpDelete]
        [Route(ROOT)]
        public ActionResultApi<CarrierDTO> delete(int id)
        {
            return new ActionResultApi<CarrierDTO>(HttpStatusCode.OK,carrierDAL.delete(id),Request);
            /*return new ActionResultTms<CarrierDTO>(HttpStatusCode.OK,(CarrierDTO)carrierRepository.delete(id), Request);*/
        }


        [HttpDelete]
        [Route(ROOT)]
        public ActionResultApi<IEnumerable<CarrierDTO>> deleteAll()
        {
            return new ActionResultApi<IEnumerable<CarrierDTO>>(HttpStatusCode.OK, carrierDAL.deleteAll(), Request);
        }





    }
}
