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
    public class RepositoryContactoProveedor : IRepositoryContactoProveedor
    {
        public void DeleteContactoProveedorByID(int id)
        {
            int returno;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    /* La carga diferida retrasa la carga de datos relacionados,
                     * hasta que lo solicite específicamente.*/
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ContactoProveedor contactoProveedor = new ContactoProveedor()
                    {
                        IdContactoProveedor = id
                    };
                    ctx.Entry(contactoProveedor).State = EntityState.Deleted;
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

        public IEnumerable<ContactoProveedor> GetContactoProveedor()
        {
            try
            {
                IEnumerable<ContactoProveedor> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.ContactoProveedor
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .ToList<ContactoProveedor>();
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

        public IEnumerable<ContactoProveedor> GetContactoProveedorByEstadoSistemaID(int id)
        {
            try
            {
                IEnumerable<ContactoProveedor> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.ContactoProveedor
                        .Where(x => x.IdEstadoSistema == id)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .ToList<ContactoProveedor>();
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

        public ContactoProveedor GetContactoProveedorByID(int id)
        {
            ContactoProveedor oContactoProveedor = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oContactoProveedor = ctx.ContactoProveedor
                        .Where(p => p.IdContactoProveedor == id)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .FirstOrDefault();
            }
            return oContactoProveedor;
        }

        public IEnumerable<ContactoProveedor> GetContactoProveedorByNombre(string nombre)
        {
            try
            {
                IEnumerable<ContactoProveedor> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.ContactoProveedor
                        .Where(x => x.Nombre == nombre)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .ToList<ContactoProveedor>();
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

        public IEnumerable<ContactoProveedor> GetContactoProveedorByProveedorID(int id)
        {
            IEnumerable<ContactoProveedor> lista = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                lista = ctx.ContactoProveedor
                    .Where(p => p.Proveedor.IdProveedor == id)
                    .Include(x => x.Proveedor)
                    .Include(x => x.EstadoSistema)
                    .ToList<ContactoProveedor>();
            }
            return lista;
        }
        //El metodo save  es usado para insertar , actualizar y desactivar Contactos
        public ContactoProveedor Save(ContactoProveedor contactoProveedor, int idEstadoSistema)
        {
            int retorno = 0;//Contabiliza las cantidad de lineas afectadas
            ContactoProveedor oContactoProveedor = null;
            //Si  idEstadoSistema corresponde a 1, entonces se procede a insertar/actualizar el Contactos
            if (idEstadoSistema != 0)
            {
                using (MyContext ctx = new MyContext())
                {
                    contactoProveedor.IdEstadoSistema = idEstadoSistema;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oContactoProveedor = GetContactoProveedorByID((int)contactoProveedor.IdContactoProveedor);
                    if (oContactoProveedor == null)//Si es null se crea un contacto
                    {
                        //Insercion del contacto
                        ctx.ContactoProveedor.Add(contactoProveedor);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Actualizar contacto
                        ctx.ContactoProveedor.Add(contactoProveedor);
                        ctx.Entry(contactoProveedor).State = EntityState.Modified;//El Add anterior sirve para los dos funciones, insertar o actualizar si se usa el entitystate en modified
                        retorno = ctx.SaveChanges();
                    }
                }
            }
            else
            {
                //Si idEstadoSistema corresponde a  0, se asigna al idEstadoSistema del contacto y se actualiza en la BD
                using (MyContext ctx = new MyContext())// se usa una instancia nueva del context para esta desactivacion
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    contactoProveedor = ctx.ContactoProveedor.Find(contactoProveedor.IdContactoProveedor);
                    contactoProveedor.IdEstadoSistema = idEstadoSistema;
                    ctx.SaveChanges();
                }
            }
            if (retorno >= 0)
                oContactoProveedor = GetContactoProveedorByID((int)contactoProveedor.IdContactoProveedor);

            return oContactoProveedor;
        }
    }
}
