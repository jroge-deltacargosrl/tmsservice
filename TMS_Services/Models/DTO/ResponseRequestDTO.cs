using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class ResponseRequestDTO<T> where T : class
    {

        public int code { get; set; }
        public T modelResponse { get; set; }
        public string message { get; set; }
        public DateTime dateResponse { get; set; }

    }

}