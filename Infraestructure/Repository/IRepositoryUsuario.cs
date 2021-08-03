﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryUsuario
    {
        Usuario GetUsuarioByID(int id);

        Usuario Save(Usuario usuario);
        Usuario GetUsuarioByEmail(string email);

        Usuario GetUsuario(string email, string password);

        IEnumerable<Usuario> GetAllUsers();

        IEnumerable<Usuario> GetAllUsersEstadoSistemaId(int id);
    }
}
