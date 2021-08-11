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
                        .Where(x => x.IdInventario == idInventario && x.IdProducto == idProducto )
                        .Include(x => x.Producto)
                        .Include(x => x.Inventario.Sucursal)
                        .FirstOrDefault();
            }
            return oInventarioProducto;
        }
        public IEnumerable<InventarioProducto> GetInventarioProductoByEstadoSistemaID(int id)
        {
            try
            {
                IEnumerable<InventarioProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {

                    lista = ctx.InventarioProducto
                        .Where(x => x.IdEstadoSistema == id)
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
        public void DeleteAllSotckZeroInventarioProducto()
        {
            foreach (InventarioProducto item in GetInventarioProducto())
            {
                if (item.Stock==0)
                {
                    using (MyContext ctx = new MyContext())
                    {
                        ctx.Entry(item).State = EntityState.Deleted;
                        ctx.SaveChanges();
                    }
                }
            }
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
                        .Where(x=>x.IdInventario==id&& x.IdEstadoSistema == 1)
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
                        .Where(x=>x.IdProducto==id && x.IdEstadoSistema == 1)
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

        public InventarioProducto Save(InventarioProducto inventarioProducto, int idEstadoSistema)
        {
            int retorno = 0; //Contabiliza la cantidad de líneas afectadas
            InventarioProducto oInventarioProducto = null;
            if (idEstadoSistema!=0)//Si idEstadoSistema corresponde a 1, entonces se procede a insertar/actualizar el InventarioProducto
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oInventarioProducto = GetInventarioProductoByID(inventarioProducto.IdInventario, inventarioProducto.IdProducto);
                    inventarioProducto.IdEstadoSistema = idEstadoSistema;
                    if (oInventarioProducto == null)
                    {
                        //Insercion 
                        ctx.InventarioProducto.Add(inventarioProducto);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Actualizacion
                        ctx.InventarioProducto.Add(inventarioProducto);
                        ctx.Entry(inventarioProducto).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }

                    
                }
            }
            else
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    inventarioProducto = GetInventarioProductoByID(inventarioProducto.IdInventario,inventarioProducto.IdProducto);
                    inventarioProducto.IdEstadoSistema = idEstadoSistema;
                    ctx.SaveChanges();
                }
            }
            if (retorno >= 0)
            {
                oInventarioProducto = GetInventarioProductoByID(inventarioProducto.IdInventario, inventarioProducto.IdProducto);
            }
            return oInventarioProducto;
        }
        public void DeactivateInventarioProductoByInventarioID(int idInventario)
        {
            foreach (InventarioProducto inventarioProductoItem in GetInventarioProductoByInventarioID(idInventario))
            {
                using (MyContext ctx = new MyContext())
                {
                    inventarioProductoItem.IdEstadoSistema = 0;
                    ctx.Entry(inventarioProductoItem).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
