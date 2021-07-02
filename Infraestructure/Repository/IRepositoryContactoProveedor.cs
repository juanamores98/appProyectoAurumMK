using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryContactoProveedor
    {
        ContactoProveedor GetContactoProveedorByID(int id);
        IEnumerable<ContactoProveedor> GetContactoProveedor();
        IEnumerable<ContactoProveedor> GetContactoProveedorByNombre(string nombre);
        IEnumerable<ContactoProveedor> GetContactoProveedorByProveedorID(int id);
        IEnumerable<ContactoProveedor> GetContactoProveedorByEstadoSistemaID(int id);
        void DeleteContactoProveedorByID(int id);
        ContactoProveedor Save(ContactoProveedor contactoProveedor, int idEstadoSistema);
    }
}
