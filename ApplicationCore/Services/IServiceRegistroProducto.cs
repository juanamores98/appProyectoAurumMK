using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceRegistroProducto
    {
        RegistroProducto GetRegistroProductoByID(int idProducto, int idRegistroMovimiento);
        IEnumerable<RegistroProducto> GetRegistroProducto();
        IEnumerable<RegistroProducto> GetRegistroProductoByProductoID(int id);
        IEnumerable<RegistroProducto> GetRegistroProductoByRegistroMovimientoID(int id);
        void DeleteRegistroProductoByID(int id);
        RegistroProducto Save(RegistroProducto registroProducto);
    }
    
}
