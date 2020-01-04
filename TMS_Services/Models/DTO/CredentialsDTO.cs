using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class CredentialsDTO
    {

        public string url { get; set; }
        public string dbName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}