using Infraestructure.Models;
using Infraestructure.Repository;
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
            IRepositoryPedido repository = new RepositoryPedido();
            return repository.GetPedido();
        }

        public Pedido GetPedidoByID(int id)
        {
            IRepositoryPedido repository = new RepositoryPedido();
            return repository.GetPedidoByID(id);
        }

        public Pedido Save(Pedido pedido)
        {
            IRepositoryPedido repository = new RepositoryPedido();
            return repository.Save(pedido);
        }
    }
}
