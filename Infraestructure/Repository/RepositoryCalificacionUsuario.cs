using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Infraestructure.Repository
{
    public class RepositoryCalificacionUsuario : IRepositoryCalificacionUsuario
    {
        public void DeleteCalificacionUsuarioByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CalificacionUsuario> GetCalificacionUsuario()
        {
            try
            {
                IEnumerable<CalificacionUsuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.CalificacionUsuario
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Usuario)
                        .ToList<CalificacionUsuario>();
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

        public IEnumerable<CalificacionUsuario> GetCalificacionUsuarioByEstadoSistemaID(int id)
        {
            try
            {
                IEnumerable<CalificacionUsuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.CalificacionUsuario
                        .Where(x=>x.IdEstadoSistema==id)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Usuario)
                        .ToList<CalificacionUsuario>();
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

        public CalificacionUsuario GetCalificacionUsuarioByID(int id)
        {
            CalificacionUsuario oCalificacionUsuario = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oCalificacionUsuario = ctx.CalificacionUsuario
                        .Where(p => p.IdCalificacion == id)
                        .Include(x => x.Usuario)
                        .Include(x => x.EstadoSistema)
                        .FirstOrDefault();
            }
            return oCalificacionUsuario;
        }

        public IEnumerable<CalificacionUsuario> GetCalificacionUsuarioByUsuarioID(int id)
        {
            try
            {
                IEnumerable<CalificacionUsuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.CalificacionUsuario
                        .Where(x=>x.IdUsuario==id)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Usuario)
                        .ToList<CalificacionUsuario>();
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

        public CalificacionUsuario Save(CalificacionUsuario calificacionUsuario, int idEstadoSistema)
        {
            int retorno = 0; //Contabiliza la cantidad de líneas afectadas
            CalificacionUsuario oCalificacionUsuario = null;

            //Si idEstadoSistema corresponde a 1, entonces se procede a insertar/actualizar la Calificacion de Usuario
            if (idEstadoSistema != 0)
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oCalificacionUsuario = GetCalificacionUsuarioByID(calificacionUsuario.IdCalificacion);

                    calificacionUsuario.IdEstadoSistema = 1; //Para crear o editar un calificacion el estado siempre será 1 (Activo)

                    if (oCalificacionUsuario == null)//Si es nulo se crea una calificacion
                    {
                        ctx.CalificacionUsuario.Add(calificacionUsuario);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Si el calificacion no es nulo, lo actualiza
                        ctx.CalificacionUsuario.Add(calificacionUsuario);
                        ctx.Entry(calificacionUsuario).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();

                    }

                }
            }
            else
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    calificacionUsuario = ctx.CalificacionUsuario.Find(calificacionUsuario.IdCalificacion);
                    calificacionUsuario.IdEstadoSistema = idEstadoSistema;
                    ctx.SaveChanges();
                }
            }

            return oCalificacionUsuario;
        }
    }
}
