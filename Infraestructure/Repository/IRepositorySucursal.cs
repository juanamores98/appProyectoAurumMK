using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositorySucursal
    {
        Sucursal GetSucursalByID(int id);
        Sucursal GetSucursalByNombre(string nombre);
        IEnumerable<Sucursal> GetSucursal();
        IEnumerable<Sucursal> GetSucursalByInventarioID(int id);
        IEnumerable<Sucursal> GetSucursalByEstadoSistemaID(int id);
        Sucursal Save(Sucursal sucursal, int idEstadoSistema);
    }
}
