using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryMotivoMovimiento: IRepositoryMotivoMovimiento
    {
        public IEnumerable<MotivoMovimiento> GetMotivoMovimiento()
        {
            try
            {
                IEnumerable<MotivoMovimiento> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.MotivoMovimiento
                        .Include(x => x.RegistroMovimiento)
                        .ToList<MotivoMovimiento>();
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

        public MotivoMovimiento GetMotivoMovimientoByID(int id)
        {
            try
            {
                MotivoMovimiento oMotivoMovimiento = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oMotivoMovimiento = ctx.MotivoMovimiento
                            .Where(p => p.IdMotivoMovimiento == id)
                            .Include(x => x.RegistroMovimiento)
                            .FirstOrDefault();
                }
                return oMotivoMovimiento;
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
