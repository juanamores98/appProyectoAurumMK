using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryRegistroMovimiento
    {
        RegistroMovimiento GetRegistroMovimientoByID(int id);
        IEnumerable<RegistroMovimiento> GetRegistroMovimiento();
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByTipoMovimientoID(int id);
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByMotivoMovimientoID(int id);
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByProductoID(int id);
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByUsuarioID(int id);
        void DeleteRegistroMovimientoByID(int id);
        RegistroMovimiento Save();
    }
}
