﻿using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class OrdenController : Controller
    {
        // GET: Orden
        public ActionResult Index()
        {
            if (TempData.ContainsKey("NotificationMessage"))
            {
                ViewBag.NotificationMessage = TempData["NotificationMessage"];
            }

            return View();
        }

        //Actualizar Vista parcial detalle carrito
        private ActionResult _DetalleOrden()
        {
            return PartialView("_DetalleOrden", Carrito.Instancia.Items);
        }

        //Actualizar cantidad de pulseras en el carrito
        public ActionResult actualizarCantidad(int idProducto, int cantidad)
        {
            ViewBag.DetalleOrden = Carrito.Instancia.Items;

            TempData["AlertMessageTitle"] = "Mensaje";
            TempData["AlertMessageBody"] = Carrito.Instancia.SetItemCantidad(idProducto, cantidad);
            TempData["AlertMessageType"] = "success";
            TempData.Keep();
            return PartialView("_DetalleOrden", Carrito.Instancia.Items);
        }

        //Ordenar una pulsera y agregarla al carrito
        public ActionResult ordenarPulsera(int? idProducto)
        {
            int cantidadLibros = Carrito.Instancia.Items.Count();
            ViewBag.NotiCarrito = Carrito.Instancia.AgregarItem((int)idProducto);
            return PartialView("_OrdenCantidad");
            
        }

        //Actualizar solo la cantidad de libros que se muestra en el menú
        public ActionResult actualizarOrdenCantidad()
        {
            if (TempData.ContainsKey("NotiCarrito"))
            {
                ViewBag.NotiCarrito = TempData["NotiCarrito"];
            }
            int cantidadPulseras = Carrito.Instancia.Items.Count();
            return PartialView("_OrdenCantidad");
        }

        public ActionResult eliminarPulsera(int? idProducto)
        {
            TempData["AlertMessageTitle"] = "Mensaje";
            TempData["AlertMessageBody"] = Carrito.Instancia.EliminarItem((int)idProducto);
            TempData["AlertMessageType"] = "success";

            return PartialView("_DetalleOrden", Carrito.Instancia.Items);
        }

        public ActionResult Save(Pedido pedido)
        {
            try
            {
                //Si no existe la sesión no hay nada
                if (Carrito.Instancia.Items.Count() <= 0)
                {
                    //validaciones de datos requeridos.
                    TempData["AlertMessageTitle"] = "Mensaje";
                    TempData["AlertMessageBody"] = "Selecciones las pulseras a ordenar";
                    TempData["AlertMessageType"] = "success";

                    return RedirectToAction("Index");
                }
                else
                {
                    var listaDetalle = Carrito.Instancia.Items;

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
