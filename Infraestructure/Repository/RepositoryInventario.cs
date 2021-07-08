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
    public class RepositoryInventario : IRepositoryInventario
    {
        public void DeleteInventarioByID(int id)
        {
            IRepositoryInventarioProducto repositoryInventarioProducto = new RepositoryInventarioProducto();
            int returno;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    //Primero Borramos todos los productos en este inventario
                    foreach (InventarioProducto inventarioProducto in repositoryInventarioProducto.GetInventarioProductoByInventarioID(id))
                    {
                        ctx.Entry(inventarioProducto).State = EntityState.Deleted;
                        returno = ctx.SaveChanges();
                    }
                    /* La carga diferida retrasa la carga de datos relacionados,
                     * hasta que lo solicite específicamente.*/
                    ctx.Configuration.LazyLoadingEnabled = false;
                    Inventario inventario = new Inventario()
                    {
                        IdInventario = id
                    };
                    ctx.Entry(inventario).State = EntityState.Deleted;
                    returno = ctx.SaveChanges();
                }
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

        public IEnumerable<Inventario> GetInventario()
        {
            try
            {
                IEnumerable<Inventario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Inventario
                        .Include("InventarioProducto.Producto")
                        .Include(x => x.Sucursal)
                        .ToList<Inventario>();
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

        

        public IEnumerable<Inventario> GetInventarioBySucursalID(int id)
        {
            try
            {
                IEnumerable<Inventario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Inventario
                        .Where(x => x.IdSucursal == id)
                        .Include(x => x.InventarioProducto)
                        .Include(x => x.Sucursal)
                        .ToList<Inventario>();
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

        public Inventario GetInventarioByID(int id)
        {
            Inventario oInventario = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oInventario = ctx.Inventario
                        .Where(p => p.IdInventario == id)
                        .Include(x => x.InventarioProducto)
                        .Include(x => x.Sucursal)
                        .FirstOrDefault();
            }
            return oInventario;
        }

        public Inventario Save(Inventario inventario)
        {
            int retorno = 0; //Contabiliza la cantidad de líneas afectadas
            Inventario oInventario = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oInventario = GetInventarioByID(inventario.IdInventario);

                if (oInventario == null )
                {
                    //Insercion
                    ctx.Inventario.Add(inventario);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    //Actualizacion
                    ctx.Inventario.Add(inventario);
                    ctx.Entry(inventario).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();

                }

                if (retorno >= 0)
                {
                    oInventario = GetInventarioByID(inventario.IdInventario);
                }

            }

            return oInventario;
        }
    }
}
