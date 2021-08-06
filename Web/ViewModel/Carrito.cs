using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                Instancia.Items = new List<ViewModelPedidoProducto>();
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

            //Si este artículo ya existe en lista de libros, aumente la cantidad
            //De lo contrario, agregue el nuevo elemento a la lista.

            if (nuevoItem != null)
            {
                if (Items.Exists(x => ))
                {

                }
            }
        }
    }
}