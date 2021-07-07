using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceSucursal
    {
        Sucursal GetSucursalByID(int id);
        Sucursal GetSucursalByNombre(string nombre);
        IEnumerable<Sucursal> GetSucursal();
        IEnumerable<Sucursal> GetSucursalByInventarioID(int id);
        IEnumerable<Sucursal> GetSucursalByEstadoSistemaID(int id);
        Sucursal Save(Sucursal sucursal, int idEstadoSistema);
    }
}
