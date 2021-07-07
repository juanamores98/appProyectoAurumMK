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

    [MetadataType(typeof(PedidoMetadata))]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.PedidoProducto = new HashSet<PedidoProducto>();
        }
    
        public int IdPedido { get; set; }
        public Nullable<double> Impuesto { get; set; }
        public Nullable<double> Descuento { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<int> IdCostoEnvio { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string FechaHora { get; set; }
    
        public virtual CostoEnvio CostoEnvio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
