using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models
{
    public class RolModel
    {
        public long id { get; set; }
        public string nombre { get; set; }

        public RolModel() : this(default, string.Empty) { }
        
        public RolModel(long id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public RolModel(RolModel objCopy)
        {
            if (!isNull(objCopy))
            {
                id = objCopy.id;
                nombre = objCopy.nombre;
            }
        }
    }
}