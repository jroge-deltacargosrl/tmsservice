using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO.ViewModels
{
    public class AccesoApiViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public long relationTipoCredencialid { get; set; }

    }
}