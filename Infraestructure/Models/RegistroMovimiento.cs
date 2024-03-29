//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(RegistroMovimientoMetadata))]
    public partial class RegistroMovimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistroMovimiento()
        {
            this.RegistroProducto = new HashSet<RegistroProducto>();
        }
    
        public int IdMovimiento { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string FechaHora { get; set; }
        public string Comentario { get; set; }
        public Nullable<int> IdTipoMovimiento { get; set; }
        public Nullable<int> IdMotivoMovimiento { get; set; }
        public Nullable<int> IdInventario { get; set; }
    
        public virtual Inventario Inventario { get; set; }
        public virtual MotivoMovimiento MotivoMovimiento { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroProducto> RegistroProducto { get; set; }
    }
}
