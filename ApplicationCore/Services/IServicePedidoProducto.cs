using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicePedidoProducto
    {
        PedidoProducto GetPedidoProductoByID(int id);
        IEnumerable<PedidoProducto> GetPedidoProducto();
        PedidoProducto Save(PedidoProducto pProducto);
    }
}
