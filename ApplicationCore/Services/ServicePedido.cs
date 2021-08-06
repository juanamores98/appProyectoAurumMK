using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePedido : IServicePedido
    {
        public IEnumerable<Pedido> GetPedido()
        {
            IRepositoryPedido
        }

        public Pedido GetPedidoByID(int id)
        {
            throw new NotImplementedException();
        }

        public Pedido Save(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
