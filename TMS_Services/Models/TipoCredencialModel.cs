using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models
{
    public class TipoCredencialModel
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        public string observacion { get; set; }

        public TipoCredencialModel() : this(default, string.Empty, string.Empty) { }
        
        public TipoCredencialModel(long id, string descripcion, string observacion)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.observacion = observacion; 
        }



    }
}