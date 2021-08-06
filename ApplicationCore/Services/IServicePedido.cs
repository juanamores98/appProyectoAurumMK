using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicePedido
    {
        Pedido GetPedidoByID(int id);
        IEnumerable<Pedido> GetPedido();
        Pedido Save(Pedido pedido);
    }
}
