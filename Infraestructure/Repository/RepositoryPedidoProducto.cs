using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryPedidoProducto : IRepositoryPedidoProducto
    {
        public IEnumerable<PedidoProducto> GetPedidoProducto()
        {
            try
            {
                IEnumerable<PedidoProducto> lista = null;

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    lista = ctx.PedidoProducto
                        .Include(x => x.Pedido)
                        .Include(x => x.Producto)
                        .ToList<PedidoProducto>();
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

        public PedidoProducto GetPedidoProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public PedidoProducto Save(PedidoProducto pProducto)
        {
            throw new NotImplementedException();
        }
    }
}
