using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class ListaRegistro
    {
        //Attributes
        public static List<Producto> productosList { get;  set; }
        public static List<InventarioProducto> inventarioProductoList { get;  set; }

        //Singleton
        private ListaRegistro() {
            productosList = new List<Producto>();
            inventarioProductoList = new List<InventarioProducto>();
        }
        private static ListaRegistro _instance;
        public static ListaRegistro GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaRegistro();
            }
            return _instance;
        }

        public static void addProducto(int id)
        {
            IServiceProducto _ServiceProducto = new ServiceProducto();
            if (!(productosList.Exists(x => x.IdProducto == id)))
            {
                productosList.Add(_ServiceProducto.GetProductoByID(id));
            }
        }
        public static void removeProducto(int id)
        {
            if (productosList.Exists(x=>x.IdProducto==id))
            {
                var itemEliminar = productosList.Single(x => x.IdProducto == id);
                productosList.Remove(itemEliminar);
            }
        }
        public static List<Producto> listProducto()
        {
            return productosList.ToList<Producto>();
        }
    }
}