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
    
    public partial class tblCredencialApiOdoo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCredencialApiOdoo()
        {
            this.tblUsuario = new HashSet<tblUsuario>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public string urlAcceso { get; set; }
        public string dbNombre { get; set; }
        public int id_tipoCredencial { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    
        public virtual tblTipoCredencial tblTipoCredencial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuario> tblUsuario { get; set; }
    }
}
