using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceSucursal : IServiceSucursal
    {
        public IEnumerable<Sucursal> GetSucursal()
        {
            IRepositorySucursal repository = new RepositorySucursal();
            return repository.GetSucursal();
        }

        public IEnumerable<Sucursal> GetSucursalByEstadoSistemaID(int id)
        {
            IRepositorySucursal repository = new RepositorySucursal();
            return repository.GetSucursalByEstadoSistemaID(id);
        }

        public Sucursal GetSucursalByID(int id)
        {
            IRepositorySucursal repository = new RepositorySucursal();
            return repository.GetSucursalByID(id);
        }

        public IEnumerable<Sucursal> GetSucursalByInventarioID(int id)
        {
            IRepositorySucursal repository = new RepositorySucursal();
            return repository.GetSucursalByInventarioID(id);
        }

        public Sucursal GetSucursalByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Sucursal Save(Sucursal sucursal, int idEstadoSistema)
        {
            throw new NotImplementedException();
        }
    }
}
