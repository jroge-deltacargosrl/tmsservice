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
    
    public partial class tblUsuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public Nullable<int> id_persona { get; set; }
        public int id_rol { get; set; }
        public Nullable<int> id_credencialApi { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    
        public virtual tblCredencialApiOdoo tblCredencialApiOdoo { get; set; }
        public virtual tblPersona tblPersona { get; set; }
        public virtual tblRol tblRol { get; set; }
    }
}
