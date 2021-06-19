using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    internal partial class ProductoMetadata
    {

        [Display(Name = "ID")]
        public int IdProducto { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Imagen del Producto")]
        public byte[] Imagen { get; set; }
        [Display(Name = "Costo")]
        public Nullable<double> CostoU { get; set; }
        [Display(Name = "ID del estado en el sistema")]
        public Nullable<int> IdEstadoSistema { get; set; }
        [Display(Name = "ID Categoria")]
        public Nullable<int> IdCategoriaProducto { get; set; }
        [Display(Name = "Categoria")]
        public virtual CategoriaProducto CategoriaProducto { get; set; }
        [Display(Name = "Estado en el sistema")]
        public virtual EstadoSistema EstadoSistema { get; set; }
        [Display(Name = "Inventario")]
        public virtual ICollection<Inventario> Inventario { get; set; }
        [Display(Name = "Pedido")]
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
        [Display(Name = "Color")]
        public virtual ICollection<Color> Color { get; set; }
        [Display(Name = "Proveedor")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        [Display(Name = "Movimiento")]
        public virtual ICollection<RegistroMovimiento> RegistroMovimiento { get; set; }
    }
}
