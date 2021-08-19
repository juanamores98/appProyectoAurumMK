using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;
using Web.ViewModel;

namespace Web.Controllers
{
    public class OrdenController : Controller
    {
        // GET: Orden
        [CustomAuthorize((int)Roles.Administrador, (int)Roles.Cliente)]
        public ActionResult Index()
        {
            if (TempData.ContainsKey("NotificationMessage"))
            {
                ViewBag.NotificationMessage = TempData["NotificationMessage"];
            }

            ViewBag.CostoEnvio = listaEnvios();

            ViewBag.DetalleOrden = Carrito.Instancia.Items;

            return View();
        }

        private SelectList listaEnvios()
        {
            //Lista de envíos
            IServiceCostoEnvio _ServiceCostoEnvio = new ServiceCostoEnvio();
            IEnumerable<CostoEnvio> listaCostoEnvio = _ServiceCostoEnvio.GetCostoEnvio();
            return new SelectList(listaCostoEnvio, "IdCostoEnvio", "Monto");
        }

        //Actualizar Vista parcial detalle carrito
        [CustomAuthorize((int)Roles.Administrador, (int)Roles.Cliente)]
        private ActionResult DetalleCarrito()
        {
            return PartialView("_DetalleOrden", Carrito.Instancia.Items);
        }

        //Actualizar cantidad de pulseras en el carrito
        public ActionResult actualizarCantidad(int idProducto, int cantidad)
        {
            ViewBag.DetalleOrden = Carrito.Instancia.Items;

            TempData["NotiCarrito"] = Carrito.Instancia.SetItemCantidad(idProducto, cantidad);
            TempData.Keep();
            return PartialView("_DetalleOrden", Carrito.Instancia.Items);
        }

        //Ordenar una pulsera y agregarla al carrito
        public ActionResult ordenarPulsera(int? idProducto)
        {
            int cantidadPulseras = Carrito.Instancia.Items.Count();
            ViewBag.NotiCarrito = Carrito.Instancia.AgregarItem((int)idProducto);

            TempData["AlertMessageTitle"] = "Mensaje";
            TempData["AlertMessageBody"] = "Pulsera agregada al carrito";
            TempData["AlertMessageType"] = "success";

            //return PartialView("_OrdenCantidad");
            return RedirectToAction("Index", "Catalogo");

        }

        //Actualizar solo la cantidad de libros que se muestra en el menú
        public ActionResult actualizarOrdenCantidad()
        {
            if (TempData.ContainsKey("NotiCarrito"))
            {
                ViewBag.NotiCarrito = TempData["NotiCarrito"];
            }
            int cantidadPulseras = Carrito.Instancia.Items.Count();

            return RedirectToAction("_DetalleOrden", "Orden");
        }

        public ActionResult eliminarPulsera(int? idProducto)
        {
            TempData["AlertMessageTitle"] = "Mensaje";
            TempData["AlertMessageBody"] = Carrito.Instancia.EliminarItem((int)idProducto);
            TempData["AlertMessageType"] = "success";

            return RedirectToAction("Index", "Orden");
        }

        public ActionResult Save(Pedido pedido, int SeleccionCostoEnvio = 1)
        {

            try
            {
                //Si no existe la sesión no hay nada
                if (Carrito.Instancia.Items.Count() <= 0)
                {
                    //validaciones de datos requeridos.
                    TempData["AlertMessageTitle"] = "Mensaje";
                    TempData["AlertMessageBody"] = "Seleccione las pulseras a ordenar";
                    TempData["AlertMessageType"] = "success";

                    return RedirectToAction("Index");
                }
                else
                {
                    var listaDetalle = Carrito.Instancia.Items;
                    pedido.Total = Carrito.Instancia.GetTotal();
                    pedido.SubTotal = Carrito.Instancia.GetSubTotal();
                    pedido.Descuento = Carrito.Instancia.GetDescuento();
                    pedido.Impuesto = Carrito.Instancia.GetImpuesto();
                    pedido.IdCostoEnvio = SeleccionCostoEnvio;

                    foreach (var item in listaDetalle)
                    {
                        PedidoProducto pedidoProducto = new PedidoProducto();
                        pedidoProducto.IdProducto = item.IdProducto;
                        pedidoProducto.Cantidad = (int?)item.Cantidad;
                        pedido.PedidoProducto.Add(pedidoProducto);
                    }
                }

                IServicePedido _ServicePedido = new ServicePedido();
                Pedido pedidoSave = _ServicePedido.Save(pedido);

                //Limpia el carrito de compras
                Carrito.Instancia.EliminarCarrito();

                TempData["AlertMessageTitle"] = "Mensaje";
                TempData["AlertMessageBody"] = "Pedido realizado satisfactoriamente";
                TempData["AlertMessageType"] = "success";

                //Reporte Pedido
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                // Salvar el error  
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Orden";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Orden/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orden/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orden/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
