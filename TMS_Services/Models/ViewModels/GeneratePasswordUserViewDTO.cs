using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.ViewModels
{
    public class GeneratePasswordUserViewDTO
    {
        public string email { get; set; }
        public string password { get; set; }
        public string url { get; set; }

    }
}