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
    
    public partial class usuario
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public byte tipo_c { get; set; }
        public byte tipo_s { get; set; }
        public byte tipo_e { get; set; }
        public Nullable<int> id_afiliacion { get; set; }
        public System.DateTime create_at { get; set; }
        public int enviar_password { get; set; }
    
        public virtual Afiliacion Afiliacion { get; set; }
    }
}
