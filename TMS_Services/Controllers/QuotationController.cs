using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TMS_Services.Infraestructure.API;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using TMS_Services.Models.DTO.ViewModels;
using TMS_Services.Models.ViewModels;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Controllers
{
    [RoutePrefix(RESOURCE_QUOTATION)]
    public class QuotationController : ApiController
    {
        
        private readonly QuotationDAL quotationDAL;

        public QuotationController(QuotationDAL quotationDAL)
        {
            this.quotationDAL = quotationDAL;
        }

        [Route(GET_VIEW_MODELS)]
        [HttpGet]
        public ActionResultApi<QuotationViewDTO> getDataForQuotation(int companyId)
        {
            return new ActionResultApi<QuotationViewDTO>(HttpStatusCode.OK, quotationDAL.getAllServices(companyId), Request);
        }

        // Refactorizar este metodo para una futura version del proceso
        [Route(ROOT)]
        [HttpPost]
        public ActionResultApi<QuotationDetailsViewDTO> create([FromBody] QuotationDTO quotation)
        {
            return new ActionResultApi<QuotationDetailsViewDTO>(HttpStatusCode.OK, quotationDAL.create(quotation), Request);
        }

        




    }
}
