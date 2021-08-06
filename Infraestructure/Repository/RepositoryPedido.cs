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
    public class RepositoryPedido : IRepositoryPedido
    {
        public Pedido GetOrdenByID(int id)
        {
            Pedido pedido = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    pedido = ctx.Pedido
                        .Include(x => x.PedidoProducto)
                        .Include(x => x.Usuario)
                        .Where(x => x.IdPedido == id)
                        .FirstOrDefault<Pedido>();
                }
                return pedido;
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

        public IEnumerable<Pedido> GetPedido()
        {
            List<Pedido> pedidos = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    pedidos = ctx.Pedido
                        .Include(x => x.Usuario)
                        .ToList<Pedido>();
                }
                return pedidos;
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

        public Pedido Save(Pedido pPedido)
        {
            int resultado = 0;
            Pedido pedido = null;
            try
            {
                //Se usa transacción porque son 2 tablas
                //1- Pedido
                //2- PedidoDetalle
                using (MyContext ctx = new MyContext())
                {
                    using (var transaccion = ctx.Database.BeginTransaction())
                    {
                        ctx.Pedido.Add(pPedido);
                        resultado = ctx.SaveChanges();
                        foreach (var pedidoProducto in pPedido.PedidoProducto)
                        {
                            pedidoProducto.IdPedido = pPedido.IdPedido;
                        }
                        foreach (var item in pPedido.PedidoProducto)
                        {
                            //Se busca el producto que está en el detalle por IdProducto
                            Producto oProducto = ctx.Producto.Find(item.IdProducto);

                            //Se indica qué se alteró
                            ctx.Entry(oProducto).State = EntityState.Modified;

                            //Se guarda
                            resultado = ctx.SaveChanges();
                        }

                        //Commit
                        transaccion.Commit();
                    }

                    //Se busca la orden que se salvó y se reenvía
                    if (resultado >= 0)
                    {
                        pedido = GetOrdenByID(pPedido.IdPedido);
                    }
                }
                return pedido;
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
