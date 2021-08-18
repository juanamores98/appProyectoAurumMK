using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCostoEnvio : IServiceCostoEnvio
    {
        public IEnumerable<CostoEnvio> GetCostoEnvio()
        {
            IRepositoryCostoEnvio repository = new RepositoryCostoEnvio();
            return repository.GetCostoEnvio();
        }
    }
}
