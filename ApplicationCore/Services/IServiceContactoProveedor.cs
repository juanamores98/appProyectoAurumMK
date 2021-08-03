using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceContactoProveedor
    {
        ContactoProveedor GetContactoProveedorByID(int id);
        IEnumerable<ContactoProveedor> GetContactoProveedor();
        IEnumerable<ContactoProveedor> GetContactoProveedorByNombre(string nombre);
        IEnumerable<ContactoProveedor> GetContactoProveedorByProveedorID(int id);
        IEnumerable<ContactoProveedor> GetContactoProveedorByEstadoSistemaID(int id);
        ContactoProveedor Save(ContactoProveedor contactoProveedor, int idEstadoSistema);
    }
}
