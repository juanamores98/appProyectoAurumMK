using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryProveedor
    {
        Proveedor GetProveedorByID(int id);
        IEnumerable<Proveedor> GetProveedor();
        IEnumerable<Proveedor> GetProveedorByNombre(String nombre);
        IEnumerable<Proveedor> GetProveedorByProductoID(int id);
        IEnumerable<Proveedor> GetProveedorByEstadoSistema(int IdEstadoSistema);
        void DeleteProveedor(int id);
        Proveedor Save();
    }
}
