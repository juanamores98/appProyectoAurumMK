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
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdTipoMovimiento(int IdTipoMovimiento);
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdMotivoMovimiento(int IdMotivoMovimiento);
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdProducto(int IdProducto);
        IEnumerable<RegistroMovimiento> GetRegistroMovimientoByIdUsuario(int IdUsuario);
        void DeleteRegistroMovimiento(int id);
        RegistroMovimiento Save();
    }
}
