using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IServiceMotivoMovimiento
    {
        MotivoMovimiento GetMotivoMovimientoByID(int id);
        IEnumerable<MotivoMovimiento> GetMotivoMovimiento();
    }
}
