using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositorySucursal : IRepositorySucursal
    {
        public IEnumerable<Sucursal> GetSucursal()
        {
            try
            {
                IEnumerable<Sucursal> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Sucursal
                        .Include(x => x.Inventario)
                        .Include(x => x.EstadoSistema)
                        .ToList<Sucursal>();
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

        public IEnumerable<Sucursal> GetSucursalByEstadoSistemaID(int id)
        {
            try
            {
                IEnumerable<Sucursal> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Sucursal
                        .Where(x => x.IdEstadoSistema == id)
                        .Include(x => x.Inventario)
                        .Include(x => x.EstadoSistema)
                        .ToList<Sucursal>();
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

        public Sucursal GetSucursalByID(int id)
        {
            Sucursal oSucursal = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oSucursal = ctx.Sucursal
                        .Where(p => p.IdSucursal == id)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Inventario)
                        .FirstOrDefault();
            }
            return oSucursal;
        }

        public IEnumerable<Sucursal> GetSucursalByInventarioID(int id)
        {
            throw new NotImplementedException();
        }

        public Sucursal GetSucursalByNombre(string nombre)
        {
            Sucursal oSucursal = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oSucursal = ctx.Sucursal
                        .Where(p => p.Nombre == nombre)
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Inventario)
                        .FirstOrDefault();
            }
            return oSucursal;
        }

        public Sucursal Save(Sucursal sucursal, int idEstadoSistema)
        {
            throw new NotImplementedException();
        }
    }
}
