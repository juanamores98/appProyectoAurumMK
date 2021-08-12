﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using System.Data.Entity;

namespace Web.ViewModel
{
    public class Carrito
    {
        public List<ViewModelPedidoProducto> Items { get; private set; }

        //Implementación Singleton
        //Las propiedades de solo lectura solo se pueden establecer en la inicialización o en constructor
        public static readonly Carrito Instancia;

        //Se llama al constructor estátito tan pronto como la clase se carga en la memoria

        static Carrito()
        {
            //Si el carrito no estpa en la sesión, se rea uno y se guarda los ítems.
            if (HttpContext.Current.Session["carrito"] == null)
            {
                Instancia = new Carrito();
                //Instancia.Items = new List<ViewModelPedidoProducto>();
                HttpContext.Current.Session["carrito"] = Instancia;
            }
            else
            {
                //De lo contratio, se obtiene de la sesión.
                Instancia = (Carrito)HttpContext.Current.Session["carrito"];
            }
        }


        //Un constructor protegido asegura que un objeto no se puede crear desde el exterior
        protected Carrito()
        {

        }

        /**
         * AgregarItem (): agrega un artículo a la compra
         */

        public String AgregarItem(int idproducto)
        {
            String mensaje = "";

            //Crear un nuevo artículo para agregar al carrito
            ViewModelPedidoProducto nuevoItem = new ViewModelPedidoProducto(idproducto);

            ////Si este artículo ya existe en lista de libros, aumente la cantidad
            ////De lo contrario, agregue el nuevo elemento a la lista.

            if (nuevoItem != null)
            {
                if (Items.Exists(x => x.IdProducto == idproducto))
                {
                    ViewModelPedidoProducto item = Items.Find(x => x.IdProducto == idproducto);
                    item.Cantidad++;
                }
                else
                {
                    nuevoItem.Cantidad = 1;
                    Items.Add(nuevoItem);
                }
            }
            else
            {
                
            }
            return "";
        }

        public void SetItemCantidad(int idProducto, int cantidad)
        {
            //Si estamos configurando la cantidad a 0, elimine el artículo por completo
            if (cantidad == 0)
            {
                EliminarItem(idProducto);
            }
            else
            {
                //Encuentra el artículo y actualiza la cantidad
                ViewModelPedidoProducto actualizarItem = new ViewModelPedidoProducto(idProducto);

                if (Items.Exists(x => x.IdProducto == idProducto))
                {
                    ViewModelPedidoProducto item = Items.Find(x => x.IdProducto == idProducto);
                    item.Cantidad = cantidad;
                }
            }
        }

        public void EliminarItem(int idProducto)
        {
            if (Items.Exists(x => x.IdProducto == idProducto))
            {
                var itemEliminar = Items.Single(x => x.IdProducto == idProducto);
                Items.Remove(itemEliminar);
            }
        }

        public float GetTotal()
        {
            float total = 0;
            total = Items.Sum(x => x.Costo);
            return total;
        }

        public int GetCountItems()
        {
            int total = 0;
            total = (int)Items.Sum(x => x.Cantidad);
            return total;
        }

        public void EliminarCarrito()
        {
            Items.Clear();
        }
    }
}