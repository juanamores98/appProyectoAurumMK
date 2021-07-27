using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCalificacionUsuario : IServiceCalificacionUsuario
    {
        public void DeleteCalificacionUsuarioByID(int id)
        {
            IRepositoryCalificacionUsuario repository = new RepositoryCalificacionUsuario();
            repository.DeleteCalificacionUsuarioByID(id);
        }

        public IEnumerable<CalificacionUsuario> GetCalificacionUsuario()
        {
            IRepositoryCalificacionUsuario repository = new RepositoryCalificacionUsuario();
            return repository.GetCalificacionUsuario();
        }

        public IEnumerable<CalificacionUsuario> GetCalificacionUsuarioByEstadoSistemaID(int id)
        {
            IRepositoryCalificacionUsuario repository = new RepositoryCalificacionUsuario();
            return repository.GetCalificacionUsuarioByEstadoSistemaID(id);
        }

        public CalificacionUsuario GetCalificacionUsuarioByID(int id)
        {
            IRepositoryCalificacionUsuario repository = new RepositoryCalificacionUsuario();
            return repository.GetCalificacionUsuarioByID(id);
        }

        public IEnumerable<CalificacionUsuario> GetCalificacionUsuarioByUsuarioID(int id)
        {
            IRepositoryCalificacionUsuario repository = new RepositoryCalificacionUsuario();
            return repository.GetCalificacionUsuarioByUsuarioID(id);
        }

        public CalificacionUsuario Save(CalificacionUsuario calificacionUsuario, int idEstadoSistema)
        {
            IRepositoryCalificacionUsuario repository = new RepositoryCalificacionUsuario();
            return repository.Save(calificacionUsuario, idEstadoSistema);
        }
    }
}
