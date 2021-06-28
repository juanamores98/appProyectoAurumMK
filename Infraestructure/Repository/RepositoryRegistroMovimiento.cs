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
    public class RepositoryRegistroMovimiento : IRepositoryRegistroMovimiento
    {
        public void DeleteRegistroMovimientoByID(int id) //queda asi
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimiento()
        {
            try
            {
                IEnumerable<RegistroMovimiento> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RegistroMovimiento
                        .Include("RegistroProducto.Producto")
                        .Include(x => x.Usuario)
                        .Include(x => x.TipoMovimiento)
                        .Include(x => x.MotivoMovimiento)
                        .ToList<RegistroMovimiento>();
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

        public RegistroMovimiento GetRegistroMovimientoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByMotivoMovimientoID(int id)
        {
            try
            {
                IEnumerable<RegistroMovimiento> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RegistroMovimiento
                        .Where(x => x.IdMotivoMovimiento == id)
                        .Include("RegistroProducto.Producto")
                        .Include(x => x.Usuario)
                        .Include(x => x.TipoMovimiento)
                        //.Include(x => x.MotivoMovimiento)
                        .ToList<RegistroMovimiento>();
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
    

       public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByProductoID(int id)
        {
            /* try
             {
                 IEnumerable<RegistroMovimiento> lista = null;
                 using (MyContext ctx = new MyContext())
                 {
                     ctx.Configuration.LazyLoadingEnabled = false;
                     lista = ctx.RegistroMovimiento
                         .Where(p => p.RegistroProducto.Select(x=>x.Producto.Any(x => x.IdProducto == IdProducto)))
                         .Include(x => x.Producto)
                         .Include(x => x.Usuario)
                         .Include(x => x.TipoMovimiento)
                         //.Include(x => x.MotivoMovimiento)
                         .ToList<RegistroMovimiento>();
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
             }*/
            throw new NotImplementedException();

        }


        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByTipoMovimientoID(int id)
        {
            try
            {
                IEnumerable<RegistroMovimiento> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RegistroMovimiento
                        .Where(x => x.IdTipoMovimiento == id)
                        .Include("RegistroProducto.Producto")
                        .Include(x => x.Usuario)
                        .Include(x => x.TipoMovimiento)
                        //.Include(x => x.MotivoMovimiento)
                        .ToList<RegistroMovimiento>();
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

        public IEnumerable<RegistroMovimiento> GetRegistroMovimientoByUsuarioID(int id)
        {
            try
            {
                IEnumerable<RegistroMovimiento> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RegistroMovimiento
                        .Where(x => x.IdUsuario == id)
                        .Include("RegistroProducto.Producto")
                        .Include(x => x.Usuario)
                        .Include(x => x.TipoMovimiento)
                        //.Include(x => x.MotivoMovimiento)
                        .ToList<RegistroMovimiento>();
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

        public RegistroMovimiento Save() //este queda asi
        {
            throw new NotImplementedException();
        }
    }
}
