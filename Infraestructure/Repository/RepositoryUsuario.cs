using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infraestructure.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public Usuario GetUsuarioByID(int id)
        {
            Usuario usuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario
                        .Include(x => x.CalificacionUsuario)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Pedido)
                        .Include(x => x.RegistroMovimiento)
                        .Include(x => x.TipoUsuario)
                        .Where(p => p.IdUsuario == id).FirstOrDefault<Usuario>();
                }
                return usuario;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Usuario Save(Usuario usuario)
        {
            int retorno = 0;
            Usuario oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = GetUsuarioByID(usuario.IdUsuario);
                    if (oUsuario == null)
                    {
                        ctx.Usuario.Add(usuario);
                    }
                    else
                    {
                        ctx.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    }
                    retorno = ctx.SaveChanges();
                }
                if (retorno >= 0)
                {
                    oUsuario = GetUsuarioByID(usuario.IdUsuario);
                }

                return oUsuario;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Usuario GetUsuario(string email, string password)
        {
            Usuario oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = ctx.Usuario.Where(p => p.Correo.Equals(email) && p.Contra.Equals(password)).FirstOrDefault<Usuario>();
                }
                if (oUsuario != null)
                {
                    oUsuario = GetUsuarioByID(oUsuario.IdUsuario);
                }

                return oUsuario;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<Usuario> GetAllUsers()
        {
            try
            {
                IEnumerable<Usuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    lista = ctx.Usuario
                        .Include(x => x.CalificacionUsuario)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.RegistroMovimiento)
                        .Include(x => x.Pedido)
                        .ToList<Usuario>();
                }
                return lista;

            }
            catch (DbUpdateException dbEx)
            {

                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<Usuario> GetAllUsersEstadoSistemaId(int id)
        {
            try
            {
                IEnumerable<Usuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    lista = ctx.Usuario
                        .Where(x => x.IdEstadoSistema == id)
                        .Include(x => x.CalificacionUsuario)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.RegistroMovimiento)
                        .Include(x => x.Pedido)
                        .ToList<Usuario>();
                }
                return lista;

            }
            catch (DbUpdateException dbEx)
            {

                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
    
}


