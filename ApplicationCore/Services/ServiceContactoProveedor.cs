using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceContactoProveedor : IServiceContactoProveedor
    {

        public IEnumerable<ContactoProveedor> GetContactoProveedor()
        {
            IRepositoryContactoProveedor repository = new RepositoryContactoProveedor();
            return repository.GetContactoProveedor();
        }

        public IEnumerable<ContactoProveedor> GetContactoProveedorByEstadoSistemaID(int id)
        {
            IRepositoryContactoProveedor repository = new RepositoryContactoProveedor();
            return repository.GetContactoProveedorByEstadoSistemaID(id);
        }

        public ContactoProveedor GetContactoProveedorByID(int id)
        {
            IRepositoryContactoProveedor repository = new RepositoryContactoProveedor();
            return repository.GetContactoProveedorByID(id);
        }

        public IEnumerable<ContactoProveedor> GetContactoProveedorByNombre(string nombre)
        {
            IRepositoryContactoProveedor repository = new RepositoryContactoProveedor();
            return repository.GetContactoProveedorByNombre(nombre);
        }

        public IEnumerable<ContactoProveedor> GetContactoProveedorByProveedorID(int id)
        {
            IRepositoryContactoProveedor repository = new RepositoryContactoProveedor();
            return repository.GetContactoProveedorByProveedorID(id);
        }

        public ContactoProveedor Save(ContactoProveedor contactoProveedor, int idEstadoSistema)
        {
            IRepositoryContactoProveedor repository = new RepositoryContactoProveedor();
            return repository.Save(contactoProveedor, idEstadoSistema);
        }
    }
}
