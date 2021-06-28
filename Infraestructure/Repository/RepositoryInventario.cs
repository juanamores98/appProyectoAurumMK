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
            throw new NotImplementedException();
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
                        .Include(x => x.Producto)
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

        public IEnumerable<Inventario> GetInventarioByEstadoSistemaID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventario> GetInventarioByProductoID(int id)
        {
            try
            {
                IEnumerable<Inventario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Inventario
                        .Where(x=>x.IdProducto==id)
                        .Include(x => x.Producto)
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
            throw new NotImplementedException();
        }

        public Inventario Save()
        {
            throw new NotImplementedException();
        }
    }
}
