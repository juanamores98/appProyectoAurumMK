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
    public class RepositoryTipoMovimiento : IRepositoryTipoMovimiento
    {
        public IEnumerable<TipoMovimiento> GetTipoMovimiento()
        {
            try
            {
                IEnumerable<TipoMovimiento> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.TipoMovimiento
                        .Include(x => x.RegistroMovimiento)
                        .ToList<TipoMovimiento>();
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

        public TipoMovimiento GetTipoMovimientoByID(int id)
        {
            try
            {
                TipoMovimiento oTipoMovimiento = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oTipoMovimiento = ctx.TipoMovimiento
                            .Where(p => p.IdTipoMovimiento == id)
                            .Include(x => x.RegistroMovimiento)
                            .FirstOrDefault();
                }
                return oTipoMovimiento;
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
    }
}
