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
    public class RepositoryRegistroProducto : IRepositoryRegistroProducto
    {
        public void DeleteRegistroProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroProducto> GetRegistroProducto()
        {
            try
            {
                IEnumerable<RegistroProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RegistroProducto
                        .Include(x => x.Producto)
                        .Include(x => x.RegistroMovimiento)
                        .ToList<RegistroProducto>();
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

        public RegistroProducto GetRegistroProductoByID(int idProducto, int idRegistroMovimiento)
        {
            try
            {
                RegistroProducto oRegistroProducto = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oRegistroProducto = ctx.RegistroProducto
                            .Where(x => x.IdMovimiento == idRegistroMovimiento && x.IdProducto == idProducto)
                            .Include(x => x.Producto)
                            .Include(x => x.RegistroMovimiento)
                            .FirstOrDefault();
                }
                return oRegistroProducto;
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

        public IEnumerable<RegistroProducto> GetRegistroProductoByProductoID(int id)
        {
            try
            {
                IEnumerable<RegistroProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RegistroProducto
                        .Where(x=>x.IdProducto==id)
                        .Include(x => x.Producto)
                        .Include(x => x.RegistroMovimiento)
                        .ToList<RegistroProducto>();
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

        public IEnumerable<RegistroProducto> GetRegistroProductoByRegistroMovimientoID(int id)
        {
            try
            {
                IEnumerable<RegistroProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RegistroProducto
                        .Where(x => x.IdMovimiento == id)
                        .Include(x => x.Producto)
                        .Include(x => x.RegistroMovimiento)
                        .ToList<RegistroProducto>();
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

        public RegistroProducto Save(RegistroProducto registroProducto)
        {
            int retorno = 0; //Contabiliza la cantidad de líneas afectadas
            RegistroProducto oRegistroProducto = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oRegistroProducto = GetRegistroProductoByID(registroProducto.IdProducto, registroProducto.IdMovimiento);
                    if (oRegistroProducto == null)
                    {
                        //Insercion 
                        ctx.RegistroProducto.Add(registroProducto);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Actualizacion
                        ctx.RegistroProducto.Add(registroProducto);
                        ctx.Entry(registroProducto).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }


                }
            if (retorno >= 0)
            {
                oRegistroProducto = GetRegistroProductoByID(registroProducto.IdProducto, registroProducto.IdMovimiento);
            }
            return oRegistroProducto;
        }
    }
}
