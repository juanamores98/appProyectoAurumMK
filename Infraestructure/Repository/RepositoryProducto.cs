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
            throw new NotImplementedException();
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

        public Producto Save(/*Producto producto, string[] seleccionInventarios,string[] seleccionProveedores,string[] seleccionColores*/)
        {
            /*int retorno = 0;
            Producto oProducto = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oProducto = GetProductoByID((int)producto.IdProducto);
                IRepositoryInventario _RepositoryInventario = new RepositoryInventario();

                if (oProducto == null)
                {

                    //Insertar Producto en Inventarios
                    if (seleccionInventario != null)
                    {
                        foreach (var inventario in seleccionInventario)
                        {
                            var categoriaToAdd = _RepositoryInventario.GetCategoriaByID(int.Parse(categoria));
                            ctx.Categoria.Attach(categoriaToAdd); //sin esto, EF intentará crear una categoría
                            libro.Categoria.Add(categoriaToAdd);// asociar a la categoría existente con el libro


                        }
                    }
                    ctx.Libro.Add(libro);
                    //SaveChanges
                    //guarda todos los cambios realizados en el contexto de la base de datos.
                    retorno = ctx.SaveChanges();
                    //retorna número de filas afectadas
                }
                else
                {
                    //Registradas: 1,2,3
                    //Actualizar: 1,3,4

                    //Actualizar Libro
                    ctx.Libro.Add(libro);
                    ctx.Entry(libro).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                    //Actualizar Categorias
                    var selectedCategoriasID = new HashSet<string>(selectedCategorias);
                    if (selectedCategorias != null)
                    {
                        ctx.Entry(libro).Collection(p => p.Categoria).Load();
                        var newCategoriaForLibro = ctx.Categoria
                         .Where(x => selectedCategoriasID.Contains(x.IdCategoria.ToString())).ToList();
                        libro.Categoria = newCategoriaForLibro;

                        ctx.Entry(libro).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }
            }

            if (retorno >= 0)
                oProducto = GetLibroByID((int)libro.IdLibro);*/

            return null;
        }
    }
}
