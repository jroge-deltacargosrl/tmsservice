using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface IQuotationRepository :  IRepository<SolicitudCotizacion>
    {
        // metodos adicionales
        bool createInERP(QuotationDTO quotation);
        
    }
}