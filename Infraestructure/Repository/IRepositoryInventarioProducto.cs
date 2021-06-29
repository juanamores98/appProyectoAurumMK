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
        IEnumerable<InventarioProducto> GetInventarioProductoByInventarioID(int id);
        IEnumerable<InventarioProducto> GetInventarioProductoByProductoID(int id);
        void DeleteInventarioProductoByID(int id);
        InventarioProducto Save();
    }
}
