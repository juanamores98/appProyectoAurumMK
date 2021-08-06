using Infraestructure.Models;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class ViewModelPedidoProducto
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public byte[] Imagen { get; set; }
        public float Cantidad { get; set; }
        public float Costo
        {
            get { return Producto.CostoU}
        }
        
        public virtual
    }
}