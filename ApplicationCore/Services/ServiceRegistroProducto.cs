using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceRegistroProducto : IServiceRegistroProducto
    {
        public void DeleteRegistroProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroProducto> GetRegistroProducto()
        {
            IRepositoryRegistroProducto repository = new RepositoryRegistroProducto();
            return repository.GetRegistroProducto();
        }

        public RegistroProducto GetRegistroProductoByID(int idProducto, int idRegistroMovimiento)
        {
            IRepositoryRegistroProducto repository = new RepositoryRegistroProducto();
            return repository.GetRegistroProductoByID(idProducto, idRegistroMovimiento);
        }

        public IEnumerable<RegistroProducto> GetRegistroProductoByProductoID(int id)
        {
            IRepositoryRegistroProducto repository = new RepositoryRegistroProducto();
            return repository.GetRegistroProductoByProductoID(id);
        }

        public IEnumerable<RegistroProducto> GetRegistroProductoByRegistroMovimientoID(int id)
        {
            IRepositoryRegistroProducto repository = new RepositoryRegistroProducto();
            return repository.GetRegistroProductoByRegistroMovimientoID(id);
        }

        public RegistroProducto Save(RegistroProducto registroProducto)
        {
            IRepositoryRegistroProducto repository = new RepositoryRegistroProducto();
            return repository.Save(registroProducto);
        }
    }
}
