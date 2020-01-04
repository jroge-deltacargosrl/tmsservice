using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class ModelFilterDTO
    {

        public string modelName { get; set; }
        public List<KeyValuePair<string, string>> fields { get; set; } = new List<KeyValuePair<string, string>>();
    }
}