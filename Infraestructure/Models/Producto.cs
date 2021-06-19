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
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Inventario = new HashSet<Inventario>();
            this.PedidoProducto = new HashSet<PedidoProducto>();
            this.Color = new HashSet<Color>();
            this.Proveedor = new HashSet<Proveedor>();
            this.RegistroMovimiento = new HashSet<RegistroMovimiento>();
        }
    
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public Nullable<double> CostoU { get; set; }
        public Nullable<int> IdEstadoSistema { get; set; }
        public Nullable<int> IdCategoriaProducto { get; set; }
    
        public virtual CategoriaProducto CategoriaProducto { get; set; }
        public virtual EstadoSistema EstadoSistema { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventario> Inventario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Color> Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroMovimiento> RegistroMovimiento { get; set; }
    }
}
