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
    
    public partial class Transportista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transportista()
        {
            this.Transportista_Ruta = new HashSet<Transportista_Ruta>();
            this.Transportista_Afiliacion = new HashSet<Transportista_Afiliacion>();
        }
    
        public int id { get; set; }
        public long nroLicencia { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string empresa { get; set; }
        public string celular { get; set; }
        public int id_tipoCamion { get; set; }
        public System.DateTime create_at { get; set; }
        public string correoElectronico { get; set; }
    
        public virtual TipoCamion TipoCamion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportista_Ruta> Transportista_Ruta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportista_Afiliacion> Transportista_Afiliacion { get; set; }
    }
}
