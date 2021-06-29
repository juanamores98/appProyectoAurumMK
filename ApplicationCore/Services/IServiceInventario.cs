using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceInventario
    {
        Inventario GetInventarioByID(int id);
        IEnumerable<Inventario> GetInventario();
        IEnumerable<Inventario> GetInventarioBySucursalID(int id);
        IEnumerable<Inventario> GetInventarioByEstadoSistemaID(int id);
        void DeleteInventarioByID(int id);
        Inventario Save();
    }
}
