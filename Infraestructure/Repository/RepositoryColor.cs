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
            try
            {
                IEnumerable<Color> lista = null;
                using (MyContext ctx = new MyContext())
                {

                    lista = ctx.Color
                        .Where(x => x.IdEstadoSistema == id)
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
        public Color GetColorByCodigo(string codigo)
        {
            Color oColor = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oColor = ctx.Color
                        .Where(p => p.Codigo == codigo)
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
        

        public Color Save(Color color,int idEstadoSistema)
        {
            int retorno = 0; //Contabiliza la cantidad de líneas afectadas
            Color oColor = null;

            //Si idEstadoSistema corresponde a 1, entonces se procede a insertar/actualizar el color
            if (idEstadoSistema != 0)
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oColor = GetColorByID(color.IdColor);
                    
                    color.IdEstadoSistema = 1; //Para crear o editar un color el estado siempre será 1 (Activo)

                    if (oColor == null && GetColorByCodigo(color.Codigo)==null)//Si es nulo se crea un color
                    {
                        ctx.Color.Add(color);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Si el color no es nulo, lo actualiza
                        ctx.Color.Add(color);
                        ctx.Entry(color).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();

                        // Si el estado en el sistema es "0" quiere decir que es una desactivación del color

                    }

                    if (retorno >= 0)
                    {
                        oColor = GetColorByID((int)color.IdColor);
                    }

                }
            }
            else
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    color = ctx.Color.Find(color.IdColor);
                    color.IdEstadoSistema = idEstadoSistema;
                    ctx.SaveChanges();
                }
            }

            return oColor;
        }
    }
}
