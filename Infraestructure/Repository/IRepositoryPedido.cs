using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryPedido
    {
        Pedido GetPedidoByID(int id);
        IEnumerable<Pedido> GetPedido();
        Pedido Save(Pedido pedido);

    }
}
