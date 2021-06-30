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
    public class RepositoryColor : IRepositoryColor
    {
        public void DeleteColorByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Color> GetColor()
        {
            try
            {
                IEnumerable<Color> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Color
                        .Include(x => x.EstadoSistema)
                        .Include(x => x.Producto)
                        .ToList<Color>();
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

        public IEnumerable<Color> GetColorByEstadoSistemaID(int id)
        {
            throw new NotImplementedException();
        }

        public Color GetColorByID(int id)
        {
            Color oColor = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oColor = ctx.Color
                        .Where(p => p.IdColor == id)
                        .Include(x => x.Producto)
                        .Include(x => x.EstadoSistema)
                        .FirstOrDefault();
            }
            return oColor;
        }

        public IEnumerable<Color> GetColorByProductoID(int id)
        {
            IEnumerable<Color> lista = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                lista = ctx.Color
                    .Where(p => p.Producto.Any(x => x.IdProducto == id))
                    .Include(x => x.EstadoSistema)
                    .Include(x => x.Producto)
                    .ToList<Color>();
            }
            return lista;
        }

        public Color Save()
        {
            throw new NotImplementedException();
        }
    }
}
