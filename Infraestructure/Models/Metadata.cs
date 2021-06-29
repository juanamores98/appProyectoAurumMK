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
    internal partial class InventarioMetadata
    {
        [Display(Name = "ID")]
        public int IdInventario { get; set; }
        [Display(Name = "ID Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "Cantidad Minima")]
        public Nullable<int> StockMinimo { get; set; }
        [Display(Name = "Cantidad")]
        public Nullable<int> Stock { get; set; }
        [Display(Name = "Estante")]
        public string Estante { get; set; }
        [Display(Name = "ID Sucursal")]
        public Nullable<int> IdSucursal { get; set; }
        [Display(Name = "Producto")]
        public virtual Producto Producto { get; set; }
        [Display(Name = "Sucursal")]
        public virtual Sucursal Sucursal { get; set; }
    }
    internal partial class ProveedorMetadata
    {
        [Display(Name = "ID")]
        public int IdProveedor { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Telefono")]
        public Nullable<int> Telefono { get; set; }
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Display(Name = "País")]
        public string Pais { get; set; }
        [Display(Name = "ID del Estado en el Sistema")]
        public Nullable<int> IdEstadoSistema { get; set; }
        [Display(Name = "Contacto")]
        public virtual ICollection<ContactoProveedor> ContactoProveedor { get; set; }
        [Display(Name = "Estado en el Sistema")]
        public virtual EstadoSistema EstadoSistema { get; set; }
        [Display(Name = "Producto")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
    internal partial class RegistroMovimientoMetadata
    {
        [Display(Name = "ID")]
        public int IdMovimiento { get; set; }
        [Display(Name = "ID Usuario")]
        public Nullable<int> IdUsuario { get; set; }
        [Display(Name = "Fecha y hora")]
        public string FechaHora { get; set; }
        [Display(Name = "Comentario")]
        public string Comentario { get; set; }
        [Display(Name = "ID Tipo Movimiento")]
        public Nullable<int> IdTipoMovimiento { get; set; }
        [Display(Name = "ID Motivo Movimiento")]
        public Nullable<int> IdMotivoMovimiento { get; set; }
        [Display(Name = "Tipo Movimiento")]
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
        [Display(Name = "Producto")]
        public virtual ICollection<Producto> Producto { get; set; }
    }


}