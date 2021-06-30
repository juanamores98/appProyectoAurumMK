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
    public class RepositoryInventarioProducto : IRepositoryInventarioProducto
    {
        public void DeleteInventarioProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventarioProducto> GetInventarioProducto()
        {
            try
            {
                IEnumerable<InventarioProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.InventarioProducto
                        .Include(x=>x.Producto)
                        .Include(x => x.Inventario.Sucursal)
                        .ToList<InventarioProducto>();
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
        public InventarioProducto GetInventarioProductoByID(int idInventario,int idProducto)
        {
            InventarioProducto oInventarioProducto = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oInventarioProducto = ctx.InventarioProducto
                        .Where(x => x.IdInventario == idInventario && x.IdProducto == idProducto)
                        .Include(x => x.Producto)
                        .Include(x => x.Inventario.Sucursal)
                        .FirstOrDefault();
            }
            return oInventarioProducto;
        }
        public IEnumerable<InventarioProducto> GetInventarioProductoByInventarioID(int id)
        {
            try
            {
                IEnumerable<InventarioProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.InventarioProducto
                        .Where(x=>x.IdInventario==id)
                        .Include(x => x.Producto)
                        .Include(x => x.Inventario.Sucursal)
                        .ToList<InventarioProducto>();
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

        public IEnumerable<InventarioProducto> GetInventarioProductoByProductoID(int id)
        {
            try
            {
                IEnumerable<InventarioProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.InventarioProducto
                        .Where(x=>x.IdProducto==id)
                        .Include(x => x.Producto)
                        .Include(x => x.Inventario.Sucursal)
                        .ToList<InventarioProducto>();
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

        public InventarioProducto Save()
        {
            throw new NotImplementedException();
        }
    }
}
