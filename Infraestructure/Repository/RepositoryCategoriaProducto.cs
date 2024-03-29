﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryCategoriaProducto : IRepositoryCategoriaProducto
    {
        public void DeleteCategoriaProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaProducto> GetCategoriaProducto()
        {
            try
            {
                IEnumerable<CategoriaProducto> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.CategoriaProducto
                        .Include(x => x.Producto)
                        .ToList<CategoriaProducto>();
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

        public CategoriaProducto GetCategoriaProductoByID(int id)
        {
            CategoriaProducto oCategoriaProducto = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oCategoriaProducto = ctx.CategoriaProducto
                        .Where(p => p.IdCategoriaProducto == id)
                        .Include(x => x.Producto)
                        .FirstOrDefault();
            }
            return oCategoriaProducto;
        }

        public IEnumerable<CategoriaProducto> GetCategoriaProductoByProductoID(int id)
        {
            throw new NotImplementedException();
        }

        public CategoriaProducto Save(CategoriaProducto categoriaProducto)
        {
            int retorno = 0; //Contabiliza la cantidad de líneas afectadas
            CategoriaProducto categoria = null;

            //Si idEstadoSistema corresponde a 1, entonces se procede a insertar/actualizar el color
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    categoria = GetCategoriaProductoByID(categoriaProducto.IdCategoriaProducto); 

                    if (categoria == null )//Si es nulo se crea una categoria
                    {
                        ctx.CategoriaProducto.Add(categoriaProducto);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Si el color no es nulo, lo actualiza
                        ctx.CategoriaProducto.Add(categoriaProducto);
                        ctx.Entry(categoriaProducto).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();

                    }

                    if (retorno >= 0)
                    {
                        categoria = GetCategoriaProductoByID((int)categoriaProducto.IdCategoriaProducto);
                    }
                }
         
            return categoria;
        }
    }
}
