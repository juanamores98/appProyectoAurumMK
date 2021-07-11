using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceInventario : IServiceInventario
    {
        public void DeleteInventarioByID(int id)
        {
            IRepositoryInventario repository = new RepositoryInventario();
            repository.DeleteInventarioByID(id);
        }

        public IEnumerable<Inventario> GetInventario()
        {
            IRepositoryInventario repository = new RepositoryInventario();
            return repository.GetInventario();
        }
        public IEnumerable<Inventario> GetInventarioByEstadoSistemaID(int id)
        {
            IRepositoryInventario repository = new RepositoryInventario();
            return repository.GetInventarioByEstadoSistemaID(id);
        }
        public IEnumerable<Inventario> GetInventarioBySucursalID(int id)
        {
            IRepositoryInventario repository = new RepositoryInventario();
            return repository.GetInventarioBySucursalID(id);
        }

        public Inventario GetInventarioByID(int id)
        {
            IRepositoryInventario repository = new RepositoryInventario();
            return repository.GetInventarioByID(id);
        }

        public Inventario Save(Inventario inventario, int idEstadoSistema)
        {
            IRepositoryInventario repository = new RepositoryInventario();
            return repository.Save(inventario, idEstadoSistema);
        }
    }
}
