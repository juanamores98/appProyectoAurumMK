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
        public void DeleteRegistroMovimiento(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimiento()
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimiento();
        }

        public RegistroMovimiento GetRegistroMovimientoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdMotivoMovimiento(int IdMotivoMovimiento)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByIdMotivoMovimiento(IdMotivoMovimiento);
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdProducto(int IdProducto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdTipoMovimiento(int IdTipoMovimiento)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByIdTipoMovimiento(IdTipoMovimiento);
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdUsuario(int IdUsuario)
        {
            IRepositoryRegistroMovimiento repository = new RepositoryRegistroMovimiento();
            return repository.GetRegistroMovimientoByIdUsuario(IdUsuario);
        }

        public RegistroMovimiento Save()
        {
            throw new NotImplementedException();
        }
    }
}
