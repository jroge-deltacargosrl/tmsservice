using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class ChangePasswordDTO
    {

        public int id { get; set; }
        public DateTime create_date { get; set; }
        public string user_login { get; set; }
        public string new_passwd { get; set; }



    }
}