using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceProveedor : IServiceProveedor
    {
        public void DeleteProveedor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> GetProveedor()
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedor();
        }

        public IEnumerable<Proveedor> GetProveedorByEstadoSistema(int IdEstadoSistema)
        {
            throw new NotImplementedException();
        }

        public Proveedor GetProveedorByID(int id)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedorByID(id);
        }

        public IEnumerable<Proveedor> GetProveedorByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> GetProveedorByProductoID(int id)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedorByProductoID(id);
        }

        public Proveedor Save()
        {
            throw new NotImplementedException();
        }
    }
}
