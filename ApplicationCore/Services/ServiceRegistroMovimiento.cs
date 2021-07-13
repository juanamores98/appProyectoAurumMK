using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceRegistroMovimiento : IServiceRegistroMovimiento
    {
        public void DeleteRegistroMovimientoByID(int id)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
             repository.DeleteRegistroMovimientoByID(id);
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimiento()
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimiento();
        }

        public RegistroMovimiento GetRegistroMovimientoByID(int id)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByID(id);
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByMotivoMovimientoID(int id)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByMotivoMovimientoID(id);
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByProductoID(int id)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByProductoID(id);
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByTipoMovimientoID(int id)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByTipoMovimientoID(id);
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByUsuarioID(int id)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByUsuarioID(id);
        }

        public RegistroMovimiento Save(RegistroMovimiento registroMovimiento)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.Save(registroMovimiento);
        }
    }
}
