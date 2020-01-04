using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class UserResponseDTO
    {

        public int id { get; set; }
        public string email { get; set; } // aqui ira el rol para el Portal TMS 
        public int responseType { get; set; }


    }
}