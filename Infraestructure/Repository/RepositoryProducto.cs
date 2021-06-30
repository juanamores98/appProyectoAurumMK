using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity;

namespace Infraestructure.Repository
{
    public class RepositoryProducto : IRepositoryProducto
    {
        public void DeleteProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetProducto()
        {
            try
            {
                IEnumerable<Producto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Producto
                        .Include(x=>x.InventarioProducto)
                        .Include(x => x.CategoriaProducto)
                        .Include(x => x.Color)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .Include("RegistroProducto.RegistroMovimiento")
                        .ToList<Producto>();
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

        public IEnumerable<Producto> GetProductoByColorID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetProductoByEstadoSistemaID(int id)
        {
            try
            {
                IEnumerable<Producto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Producto
                        .Where(x=>x.IdEstadoSistema==id)
                        .Include(x => x.InventarioProducto)
                        .Include(x => x.CategoriaProducto)
                        .Include(x => x.Color)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .Include("RegistroProducto.RegistroMovimiento")
                        .ToList<Producto>();
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

        public Producto GetProductoByID(int id)
        {
            Producto oProducto = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oProducto = ctx.Producto
                        .Where(p => p.IdProducto == id)
                        .Include("InventarioProducto.Inventario")
                        .Include(x => x.CategoriaProducto)
                        .Include(x => x.Color)
                        .Include(x => x.Proveedor)
                        .Include(x => x.EstadoSistema)
                        .Include("RegistroProducto.RegistroMovimiento")
                        .FirstOrDefault();
            }
            return oProducto;
        }
        public IEnumerable<Producto> GetProductoByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetProductoByProveedorID(int id)
        {
            throw new NotImplementedException();
        }

        public Producto Save(Producto producto, string[] seleccionInventarios,string[] seleccionProveedores,string[] seleccionColores,int idEstadoSistema)
        {
            int retorno = 0;
            Producto oProducto = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oProducto = GetProductoByID((int)producto.IdProducto);
                IRepositoryInventarioProducto _RepositoryInventarioProducto = new RepositoryInventarioProducto();
                IRepositoryInventario _RepositoryInventario = new RepositoryInventario();
                IRepositoryProveedor _RepositoryProveedor = new RepositoryProveedor();
                IRepositoryColor _RepositoryColor = new RepositoryColor();
                if (oProducto == null)
                {
                    //Estado del sistema
                    producto.IdEstadoSistema = idEstadoSistema;
                    //Insertar Producto en Inventarios con valores basicos
                    if (seleccionInventarios != null)
                    {
                        foreach (var inventario in seleccionInventarios)
                        {
                            InventarioProducto oInventarioProducto = new InventarioProducto();
                            oInventarioProducto.IdInventario = int.Parse(inventario);
                            oInventarioProducto.IdProducto = producto.IdProducto;
                            oInventarioProducto.StockMinimo = 1;
                            oInventarioProducto.Stock = 1;
                            ctx.InventarioProducto.Add(oInventarioProducto);
                        }
                    }
                    ctx.Producto.Add(producto);
                    retorno = ctx.SaveChanges();
                    //Actualizar o Insertar Proveedor
                    var seleccionProveedoresID = new HashSet<string>(seleccionProveedores);
                    if (seleccionProveedores != null)
                    {
                        ctx.Entry(producto).Collection(p => p.Proveedor).Load();
                        var newProveedorForProducto = ctx.Proveedor
                         .Where(x => seleccionProveedoresID.Contains(x.IdProveedor.ToString())).ToList();
                        producto.Proveedor = newProveedorForProducto;

                        ctx.Entry(producto).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                    //Actualizar o Insertar Color
                    var seleccionColoresID = new HashSet<string>(seleccionColores);
                    if (seleccionColores != null)
                    {
                        ctx.Entry(producto).Collection(p => p.Color).Load();
                        var newColorForProducto = ctx.Color
                         .Where(x => seleccionColoresID.Contains(x.IdColor.ToString())).ToList();
                        producto.Color = newColorForProducto;

                        ctx.Entry(producto).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }
                else
                {
                    //Estado del sistema
                    producto.IdEstadoSistema = idEstadoSistema;
                    //Actualizar producto
                    ctx.Producto.Add(producto);
                    ctx.Entry(producto).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                    if (idEstadoSistema != 0)
                    {
                        //Mantener inventario seleccionados y borrar inventarios borrados
                        var seleccionInventariosID = new HashSet<string>(seleccionInventarios);
                        if (seleccionInventarios != null)
                        {
                            ctx.Entry(producto).Collection(p => p.InventarioProducto).Load();

                            List<InventarioProducto> newInventarioProductoForProducto = new List<InventarioProducto>();

                            foreach (InventarioProducto item in _RepositoryInventarioProducto.GetInventarioProducto())
                            {
                                if (seleccionInventarios.Contains(item.IdInventario.ToString()) && item.IdProducto == producto.IdProducto)
                                {
                                    newInventarioProductoForProducto.Add(item);
                                }
                            }
                            producto.InventarioProducto = newInventarioProductoForProducto;
                            ctx.Entry(producto).State = EntityState.Modified;
                            retorno = ctx.SaveChanges();
                            //Se añade los inventarios nuevos que contendran el producto
                            foreach (var inventario in seleccionInventarios)
                            {
                                bool existeInventarioP = _RepositoryInventarioProducto.GetInventarioProductoByID(int.Parse(inventario), producto.IdProducto) != null;
                                if (!existeInventarioP)
                                {
                                    InventarioProducto oInventarioProducto = new InventarioProducto();
                                    oInventarioProducto.IdInventario = int.Parse(inventario);
                                    oInventarioProducto.IdProducto = producto.IdProducto;
                                    oInventarioProducto.StockMinimo = 1;
                                    oInventarioProducto.Stock = 1;
                                    ctx.InventarioProducto.Add(oInventarioProducto);
                                }
                            }
                        }
                        //Actualizar o Insertar Proveedor
                        var seleccionProveedoresID = new HashSet<string>(seleccionProveedores);
                        if (seleccionProveedores != null)
                        {
                            ctx.Entry(producto).Collection(p => p.Proveedor).Load();
                            var newProveedorForProducto = ctx.Proveedor
                             .Where(x => seleccionProveedoresID.Contains(x.IdProveedor.ToString())).ToList();
                            producto.Proveedor = newProveedorForProducto;

                            ctx.Entry(producto).State = EntityState.Modified;
                            retorno = ctx.SaveChanges();
                        }
                        //Actualizar o Insertar Color
                        var seleccionColoresID = new HashSet<string>(seleccionColores);
                        if (seleccionColores != null) 
                        {
                            ctx.Entry(producto).Collection(p => p.Color).Load();
                            var newColorForProducto = ctx.Color
                             .Where(x => seleccionColoresID.Contains(x.IdColor.ToString())).ToList();
                            producto.Color = newColorForProducto;

                            ctx.Entry(producto).State = EntityState.Modified;
                            retorno = ctx.SaveChanges();
                        }
                    }

                }
            }

            if (retorno >= 0)
                oProducto = GetProductoByID((int)producto.IdProducto);

            return oProducto;
        }
    }
    
}
