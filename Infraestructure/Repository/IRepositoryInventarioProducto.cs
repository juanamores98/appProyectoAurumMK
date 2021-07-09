using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryInventarioProducto
    {
        IEnumerable<InventarioProducto> GetInventarioProducto();
        IEnumerable<InventarioProducto> GetInventarioProductoByEstadoSistemaID(int id);
        InventarioProducto GetInventarioProductoByID(int idInventario, int idProducto);
        IEnumerable<InventarioProducto> GetInventarioProductoByInventarioID(int id);
        IEnumerable<InventarioProducto> GetInventarioProductoByProductoID(int id);
        void DeleteInventarioProductoByID(int id);
        InventarioProducto Save(InventarioProducto inventarioProducto, int idEstadoSistema);
        void DeactivateInventarioProductoByInventarioID(int idInventario);
    }
}
