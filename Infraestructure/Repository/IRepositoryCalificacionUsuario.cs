using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryCalificacionUsuario
    {
        CalificacionUsuario GetCalificacionUsuarioByID(int id);
        IEnumerable<CalificacionUsuario> GetCalificacionUsuario();
        IEnumerable<CalificacionUsuario> GetCalificacionUsuarioByUsuarioID(int id);
        IEnumerable<CalificacionUsuario> GetCalificacionUsuarioByEstadoSistemaID(int id);
        void DeleteCalificacionUsuarioByID(int id);
        CalificacionUsuario Save(CalificacionUsuario calificacionUsuario, int idEstadoSistema);
    }
}
