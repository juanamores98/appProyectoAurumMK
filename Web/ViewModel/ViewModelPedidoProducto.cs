using Infraestructure.Models;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.ViewModel
{
    public class ViewModelPedidoProducto
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public byte[] Imagen { get; set; }
        public float Cantidad { get; set; }
        public float Descuento { get; set; }
        public int Envio { get; set; }
        public float Costo
        {
            get { return (float)Producto.CostoU; }
        }

        public virtual Producto Producto { get; set; }

        public float subTotal
        {
            get
            {
                return this.calculoSubTotal();
            }
        }

        private float calculoSubTotal()
        {
            return this.Costo * this.Cantidad;
        }

        public ViewModelPedidoProducto(int idProducto)
        {
            IServiceProducto _ServiceProducto = new ServiceProducto();
            this.IdProducto = idProducto;
            this.Producto = _ServiceProducto.GetProductoByID(idProducto);
        }

    }
}