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
    public class RepositoryProveedor : IRepositoryProveedor
    {
        public void DeleteProveedor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> GetProveedor()
        {
            try
            {
                IEnumerable<Proveedor> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Proveedor
                        .Include(x => x.ContactoProveedor)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Producto)
                        .ToList<Proveedor>();
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

        public IEnumerable<Proveedor> GetProveedorByEstadoSistema(int IdEstadoSistema)
        {
            throw new NotImplementedException();
        }

        public Proveedor GetProveedorByID(int id)
        {
            Proveedor oProveedor = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oProveedor = ctx.Proveedor
                        .Where(p => p.IdProveedor == id)
                        .Include(x => x.ContactoProveedor)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Producto)
                        .FirstOrDefault();
            }
            return oProveedor;
        }

        public IEnumerable<Proveedor> GetProveedorByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> GetProveedorByProductoID(int id)
        {
            IEnumerable<Proveedor> lista = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                lista = ctx.Proveedor
                    .Where(p => p.Producto.Any(x=>x.IdProducto==id)) 
                    .Include(x => x.ContactoProveedor)
                    .Include(x => x.EstadoSistema)
                    .Include(x => x.Producto)
                    .ToList<Proveedor>();
            }
            return lista;
        }

        public Proveedor Save()
        {
            throw new NotImplementedException();
        }
        
    }
}
