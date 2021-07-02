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
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Imagen del Producto")]
        public byte[] Imagen { get; set; }
        [Display(Name = "Costo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<double> CostoU { get; set; }
        [Display(Name = "ID del estado en el sistema")]
        public Nullable<int> IdEstadoSistema { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<int> IdCategoriaProducto { get; set; }
        [Display(Name = "Categoria")]
        public virtual CategoriaProducto CategoriaProducto { get; set; }
        [Display(Name = "Estado en el sistema")]
        public virtual EstadoSistema EstadoSistema { get; set; }
        [Display(Name = "Inventarios")]
        public virtual ICollection<InventarioProducto> InventarioProducto { get; set; }
        [Display(Name = "Pedido")]
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
        [Display(Name = "Colores")]
        public virtual ICollection<Color> Color { get; set; }
        [Display(Name = "Proveedores")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        
    }
    internal partial class InventarioMetadata
    {
        [Display(Name = "ID")]
        public int IdInventario { get; set; } 
        [Display(Name = "ID Sucursal")]
        public Nullable<int> IdSucursal { get; set; }
        [Display(Name = "Sucursal")]
        public virtual Sucursal Sucursal { get; set; }
    }
    internal partial class ProveedorMetadata
    {
        
        [Display(Name = "ID")]
        public int IdProveedor { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "No se admiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Teléfono requerido")]
        //[StringLength(8, MinimumLength = 8, ErrorMessage = "El formato válido es 88888888")]
        [Display(Name = "Teléfono")]
        public Nullable<int> Telefono { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Dirección requerida")]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "No se admiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "País requerido")]
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Código movimiento requerido")]
        [Display(Name = "ID")]
        public int IdMovimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Usuario requerido")]
        [Display(Name = "ID Usuario")]
        public Nullable<int> IdUsuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha y hora requeridas")]
        [Display(Name = "Fecha y hora")]
        public string FechaHora { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Comentario requerido")]
        [Display(Name = "Comentario")]
        public string Comentario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tipo movimiento requerido")]
        [Display(Name = "ID Tipo Movimiento")]
        public Nullable<int> IdTipoMovimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Motivo movimiento requerido")]
        [Display(Name = "ID Motivo Movimiento")]
        public Nullable<int> IdMotivoMovimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tipo movimiento requerido")]
        [Display(Name = "Tipo Movimiento")]
        public virtual TipoMovimiento TipoMovimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Usuario requerido")]
        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }

        
    }

    internal partial class CalificacionUsuarioMetadata
    {
        [Display(Name = "Código calificación")]
        public int IdCalificacion { get; set; }

        [Display(Name = "Identificación usuario")]
        public Nullable<int> IdUsuario { get; set; }

        [Display(Name = "Calificación")]
        public Nullable<int> Calificacion { get; set; }

        [Display(Name = "Comentario")]
        public string Comentario { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
    }

    internal partial class CategoriaProductoMetadata
    {
        [Display(Name = "Código categoría producto")]
        public int IdCategoriaProducto { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Producto")]
        public virtual ICollection<Producto> Producto { get; set; }
    }

    internal partial class ColorMetadata
    {
        [Display(Name = "Código color")]
        public int IdColor { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Código estado en sistema")]
        public Nullable<int> IdEstadoSistema { get; set; }

        [Display(Name = "Estado en sistema")]
        public virtual EstadoSistema EstadoSistema { get; set; }

        [Display(Name = "Producto")]
        public virtual ICollection<Producto> Producto { get; set; }
    }

    internal partial class ContactoProveedorMetadata
    {
        [Display(Name = "ID")]
        public int IdContactoProveedor { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Télefono")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<int> Telefono { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Correo { get; set; }

        [Display(Name = "Código estado en sistema")]
        public Nullable<int> IdEstadoSistema { get; set; }

        [Display(Name = "Código proveedor")]
        public Nullable<int> IdProveedor { get; set; }
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<int> Cedula { get; set; }

        [Display(Name = "Estado en sistema")]
        public virtual EstadoSistema EstadoSistema { get; set; }

        [Display(Name = "Proveedor")]
        public virtual Proveedor Proveedor { get; set; }
    }

    internal partial class CostoEnvioMetadata
    {
        [Display(Name = "Código costo envio")]
        public int IdCostoEnvio { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Monto")]
        public Nullable<double> Monto { get; set; }

        [Display(Name = "Pedido")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }

    internal partial class EstadoSistemaMetadata
    {
        [Display(Name = "Código estado sistema")]
        public int IdEstadoSistema { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Color")]
        public virtual ICollection<Color> Color { get; set; }

        [Display(Name = "Contacto proveedor")]
        public virtual ICollection<ContactoProveedor> ContactoProveedor { get; set; }

        [Display(Name = "Usuario")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        [Display(Name = "Producto")]
        public virtual ICollection<Producto> Producto { get; set; }

        [Display(Name = "Proveedor")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }

        [Display(Name = "Sucursal")]
        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }

    internal partial class InventarioProductoMetadata
    {
        [Display(Name = "Inventario")]
        public int IdInventario { get; set; }

        [Display(Name = "Código producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Cantidad en stock")]
        public Nullable<int> Stock { get; set; }

        [Display(Name = "Stock mínimo")]
        public Nullable<int> StockMinimo { get; set; }

        [Display(Name = "Estante")]
        public string Estante { get; set; }

        [Display(Name = "Inventario")]
        public virtual Inventario Inventario { get; set; }

        [Display(Name = "Producto")]
        public virtual Producto Producto { get; set; }
    }

    internal partial class MotivoMovimientoMetadata
    {
        [Display(Name = "Motivo del Movimiento")]
        public int IdMotivoMovimiento { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Registro de Movimiento")]
        public virtual RegistroMovimiento RegistroMovimiento { get; set; }
    }

    internal partial class PedidoMetadata
    {
        [Display(Name = "Código pedido")]
        public int IdPedido { get; set; }

        [Display(Name = "Impuesto")]
        public Nullable<double> Impuesto { get; set; }

        [Display(Name = "Descuento")]
        public Nullable<double> Descuento { get; set; }

        [Display(Name = "SubTotal")]
        public Nullable<double> SubTotal { get; set; }

        [Display(Name = "Total")]
        public Nullable<double> Total { get; set; }

        [Display(Name = "Costo de envío")]
        public Nullable<int> IdCostoEnvio { get; set; }

        [Display(Name = "Código usuario")]
        public Nullable<int> IdUsuario { get; set; }

        [Display(Name = "Fecha y hora")]
        public string FechaHora { get; set; }

        [Display(Name = "Costo del envío")]
        public virtual CostoEnvio CostoEnvio { get; set; }

        [Display(Name = "Pedido y productos")]
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
    }

    internal partial class PedidoProductoMetadata
    {

        [Display(Name = "Código pedido")]
        public int IdPedido { get; set; }

        [Display(Name = "Código producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Cantidad")]
        public Nullable<int> Cantidad { get; set; }

        [Display(Name = "Pedido")]
        public virtual Pedido Pedido { get; set; }

        [Display(Name = "Producto")]
        public virtual Producto Producto { get; set; }
    }

    internal partial class RegistroProductoMetadata
    {
        [Display(Name = "Código producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Código movimiento")]
        public int IdMovimiento { get; set; }

        [Display(Name = "Cantidad")]
        public Nullable<int> Cantidad { get; set; }

        [Display(Name = "Producto")]
        public virtual Producto Producto { get; set; }

        [Display(Name = "Registro movimiento")]
        public virtual RegistroMovimiento RegistroMovimiento { get; set; }
    }

    internal partial class SucursalMetadata
    {
        [Display(Name = "Código sucursal")]
        public int IdSucursal { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Teléfono")]
        public Nullable<int> Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Código estado en sistema")]
        public Nullable<int> IdEstadoSistema { get; set; }

        [Display(Name = "Estado en sistema")]
        public virtual EstadoSistema EstadoSistema { get; set; }

        [Display(Name = "Inventario")]
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
    internal partial class TipoMovimientoMetadata
    {
        [Display(Name = "Código tipo movimiento")]
        public int IdTipoMovimiento { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Registro de movimiento")]
        public virtual ICollection<RegistroMovimiento> RegistroMovimiento { get; set; }
    }

    internal partial class TipoUsuarioMetadata
    {
        [Display(Name = "Código tipo usuario")]
        public int IdTipoUsuario { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Usuario")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
    internal partial class UsuarioMetadata
    {
        [Display(Name = "Código usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Display(Name = "Contraseña")]
        public string Contra { get; set; }

        [Display(Name = "Teléfono")]
        public Nullable<int> Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Código estado en sistema")]
        public Nullable<int> IdEstadoSistema { get; set; }

        [Display(Name = "Código tipo de usuario")]
        public Nullable<int> IdTipoUsuario { get; set; }

        [Display(Name = "Calificación usuario")]
        public virtual ICollection<CalificacionUsuario> CalificacionUsuario { get; set; }
        [Display(Name = "Estado en sistema")]
        public virtual EstadoSistema EstadoSistema { get; set; }

        [Display(Name = "Pedido")]
        public virtual ICollection<Pedido> Pedido { get; set; }

        [Display(Name = "Registro de movimiento")]
        public virtual ICollection<RegistroMovimiento> RegistroMovimiento { get; set; }

        [Display(Name = "Tipo de usuario")]
        public virtual TipoUsuario TipoUsuario { get; set; }
    }

}