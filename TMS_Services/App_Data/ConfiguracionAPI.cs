//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMS_Services.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConfiguracionAPI
    {
        public int id { get; set; }
        public string urlApi { get; set; }
        public string nombreDb { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public int estado { get; set; }
        public int id_entornoApi { get; set; }
        public System.DateTime create_at { get; set; }
    
        public virtual EntornoAPI EntornoAPI { get; set; }
    }
}
