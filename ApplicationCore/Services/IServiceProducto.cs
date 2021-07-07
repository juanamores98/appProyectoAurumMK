using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceProducto
    {
        Producto GetProductoByID(int id);
        IEnumerable<Producto> GetProducto();
        IEnumerable<Producto> GetProductoByNombre(String nombre);
        IEnumerable<Producto> GetProductoByEstadoSistemaID(int id);
        IEnumerable<Producto> GetProductoByColorID(int id);
        IEnumerable<Producto> GetProductoByProveedorID(int id);
        IEnumerable<Producto> GetProductoByCategoriaProductoID(int id);
        void SetNullIdCategoriaProductoInProductoByCategotegoriaID(int idCategoriaProducto);
        void DeleteProductoByID(int id);
        Producto Save(Producto producto, string[] seleccionInventarios, string[] seleccionProveedores, string[] seleccionColores, int idEstadoSistema);
    }
}
