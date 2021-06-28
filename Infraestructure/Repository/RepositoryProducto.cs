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
    public class RepositoryProducto : IRepositoryProducto
    {
        public void DeleteProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetProducto()
        {
            try
            {
                IEnumerable<Producto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Producto
                        .Include(x => x.Inventario)
                        .Include(x => x.CategoriaProducto)
                        .Include(x => x.Color)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .Include("RegistroProducto.RegistroMovimiento")
                        .ToList<Producto>();
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

        public IEnumerable<Producto> GetProductoByColorID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetProductoByEstadoSistemaID(int id)
        {
            throw new NotImplementedException();
        }

        public Producto GetProductoByID(int id)
        {
            Producto oProducto = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oProducto = ctx.Producto
                        .Where(p => p.IdProducto == id)
                        .Include(x => x.Inventario)
                        .Include(x => x.CategoriaProducto)
                        .Include(x => x.Color)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .Include("RegistroProducto.RegistroMovimiento")
                        .FirstOrDefault();
            }
            return oProducto;
        }
        public IEnumerable<Producto> GetProductoByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetProductoByProveedorID(int id)
        {
            throw new NotImplementedException();
        }

        public Producto Save()
        {
            throw new NotImplementedException();
        }
    }
}
