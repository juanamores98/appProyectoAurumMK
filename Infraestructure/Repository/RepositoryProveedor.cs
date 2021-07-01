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
        public void DeleteProveedorByID(int id)
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

        public IEnumerable<Proveedor> GetProveedorByEstadoSistemaID(int id)
        {
            try
            {
                IEnumerable<Proveedor> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Proveedor
                        .Where(x=>x.IdEstadoSistema==id)
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
        //El metodo save  es usado para insertar , actualizar y desactivar proveedores
        public Proveedor Save(Proveedor proveedor, int idEstadoSistema)
        {
            int retorno = 0;//Contabiliza las cantidad de lineas afectadas
            Proveedor oProveedor = null;
            //Si  idEstadoSistema corresponde a 1, entonces se procede a insertar/actualizar el proveedor 
            if (idEstadoSistema != 0)
            {
                using (MyContext ctx = new MyContext())
                {
                    proveedor.IdEstadoSistema = idEstadoSistema;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oProveedor = GetProveedorByID((int)proveedor.IdProveedor);
                    if (oProveedor == null)//Si es null se crea un proveedor
                    {
                        //Insercion del producto
                        ctx.Proveedor.Add(proveedor);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Actualizar producto
                        ctx.Proveedor.Add(proveedor);
                        ctx.Entry(proveedor).State = EntityState.Modified;//El Add anterior sirve para los dos funciones, insertar o actualizar si se usa el entitystate en modified
                        retorno = ctx.SaveChanges();
                    }
                }
            }
            else
            {
                //Si idEstadoSistema corresponde a  0, se asigna al idEstadoSistema del proveedor y se actualiza en la BD
                using (MyContext ctx = new MyContext())// se usa una instancia nueva del context para esta desactivacion
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    proveedor = ctx.Proveedor.Find(proveedor.IdProveedor);
                    proveedor.IdEstadoSistema = idEstadoSistema;
                    ctx.SaveChanges();
                }
            }
            if (retorno >= 0)
                oProveedor = GetProveedorByID((int)proveedor.IdProveedor);

            return oProveedor;
        }
        
    }
}
