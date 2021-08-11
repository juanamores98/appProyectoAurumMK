using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePedidoProducto : IServicePedidoProducto
    {
        public IEnumerable<PedidoProducto> GetPedidoProducto()
        {
            IRepositoryPedidoProducto repository = new RepositoryPedidoProducto();
            return repository.GetPedidoProducto();
        }

        public PedidoProducto GetPedidoProductoByID(int id)
        {
            IRepositoryPedidoProducto repository = new RepositoryPedidoProducto();
            return repository.GetPedidoProductoByID(id);
        }

        public PedidoProducto Save(PedidoProducto pProducto)
        {
            IRepositoryPedidoProducto repository = new RepositoryPedidoProducto();
            return repository.Save(pProducto);
        }
    }
}
