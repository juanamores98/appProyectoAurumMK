using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryProducto
    {
        Producto GetProductoByID(int id);
        IEnumerable<Producto> GetProducto();
        IEnumerable<Producto> GetProductoByNombre(String nombre);
        IEnumerable<Producto> GetProductoByEstadoSistema(int IdEstadoSistema);
        IEnumerable<Producto> GetProductoByColor(int IdColor);
        IEnumerable<Producto> GetProductoByProveedor(int IdProveedor);
        void DeleteProducto(int id);
        Producto Save();
    }
}
