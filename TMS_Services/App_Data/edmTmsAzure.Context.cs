﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DeltaDBEntities : DbContext
    {
        public DeltaDBEntities()
            : base("name=DeltaDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<TipoCamion> TipoCamion { get; set; }
        public virtual DbSet<TipoServicio> TipoServicio { get; set; }
        public virtual DbSet<Afiliacion> Afiliacion { get; set; }
        public virtual DbSet<TipoUnidadMedida> TipoUnidadMedida { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<Transportista> Transportista { get; set; }
        public virtual DbSet<Transportista_Ruta> Transportista_Ruta { get; set; }
        public virtual DbSet<TipoServicio_Afiliacion> TipoServicio_Afiliacion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transportista_Afiliacion> Transportista_Afiliacion { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<SolicitudCotizacion> SolicitudCotizacion { get; set; }
        public virtual DbSet<ConfiguracionTarea> ConfiguracionTarea { get; set; }
        public virtual DbSet<InfoArchivo> InfoArchivo { get; set; }
        public virtual DbSet<ConfiguracionAPI> ConfiguracionAPI { get; set; }
        public virtual DbSet<EntornoAPI> EntornoAPI { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    
        public virtual ObjectResult<sp_getTask_Result> sp_getTask(Nullable<int> state)
        {
            var stateParameter = state.HasValue ?
                new ObjectParameter("state", state) :
                new ObjectParameter("state", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getTask_Result>("sp_getTask", stateParameter);
        }
    }
}
