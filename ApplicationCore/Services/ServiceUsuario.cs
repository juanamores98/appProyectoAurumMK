using ApplicationCore.Utils;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public Usuario GetUsuarioByID(int id)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            Usuario oUsuario = repository.GetUsuarioByID(id);
            oUsuario.Contra = Cryptography.DecrypthAES(oUsuario.Contra);
            return oUsuario;
        }

        public Usuario Save(Usuario usuario)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            usuario.Contra = Cryptography.EncrypthAES(usuario.Contra);
            return repository.Save(usuario);
        }

        public Usuario GetUsuario(string email, string password)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();

            //Encriptar la contraseña para poder compararlo
            string crytpPasswd = Cryptography.DecrypthAES(password);
            return repository.GetUsuario(email, crytpPasswd);
        }

        public IEnumerable<Usuario> GetAllUsers()
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetAllUsers();
        }

        public IEnumerable<Usuario> GetAllUsersEstadoSistemaId(int id)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetAllUsersEstadoSistemaId(id);
        }


    }
}
