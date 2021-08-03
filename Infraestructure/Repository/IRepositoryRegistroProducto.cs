using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryRegistroProducto
    {
        RegistroProducto GetRegistroProductoByID(int idProducto, int idRegistroMovimiento);
        IEnumerable<RegistroProducto> GetRegistroProducto();
        IEnumerable<RegistroProducto> GetRegistroProductoByProductoID(int id);
        IEnumerable<RegistroProducto> GetRegistroProductoByRegistroMovimientoID(int id);
        void DeleteRegistroProductoByID(int id);
        RegistroProducto Save(RegistroProducto registroProducto);
    }
}
