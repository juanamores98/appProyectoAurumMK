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
        public void DeleteInventario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventario> GetInventario()
        {
            IRepositoryInventario repository = new RepositoryInventario();
            return repository.GetInventario();
        }

        public IEnumerable<Inventario> GetInventarioByEstadoSistema(int IdEstadoSistema)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Inventario> GetInventarioByProductoID(int IdProducto)
        {
            IRepositoryInventario repository = new RepositoryInventario();
            return repository.GetInventarioByProductoID(IdProducto);
        }

        public Inventario GetInventarioByID(int id)
        {
            throw new NotImplementedException();
        }

        public Inventario Save()
        {
            throw new NotImplementedException();
        }
    }
}
