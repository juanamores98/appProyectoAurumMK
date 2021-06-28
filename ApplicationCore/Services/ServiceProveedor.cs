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
        public void DeleteProveedorByID(int id)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
             repository.DeleteProveedorByID(id);
        }

        public IEnumerable<Proveedor> GetProveedor()
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedor();
        }

        public IEnumerable<Proveedor> GetProveedorByEstadoSistemaID(int id)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedorByEstadoSistemaID(id);
        }

        public Proveedor GetProveedorByID(int id)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedorByID(id);
        }

        public IEnumerable<Proveedor> GetProveedorByNombre(string nombre)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedorByNombre(nombre);
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
