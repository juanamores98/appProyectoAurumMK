using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceMotivoMovimiento : IServiceMotivoMovimiento
    {
        public IEnumerable<MotivoMovimiento> GetMotivoMovimiento()
        {
            IRepositoryMotivoMovimiento repository = new RepositoryMotivoMovimiento();
            return repository.GetMotivoMovimiento();
        }

        public MotivoMovimiento GetMotivoMovimientoByID(int id)
        {
            IRepositoryMotivoMovimiento repository = new RepositoryMotivoMovimiento();
            return repository.GetMotivoMovimientoByID(id);
        }
    }
}
