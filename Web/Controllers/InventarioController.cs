using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructure.Models;

namespace Web.Controllers
{
    public class InventarioController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Inventario
        public ActionResult Index()
        {
            IEnumerable<Inventario> lista = null;
            try
            {
                IServiceInventario _ServiceInventario = new ServiceInventario();
                lista = _ServiceInventario.GetInventario();
                ViewBag.title = "Lista Inventarios";
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {
            ViewBag.listaSeleccionSucursal = listaSeleccionSucursal();
            return View();
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit(int? id)
        {
            ServiceInventario _ServiceInventario = new ServiceInventario();
            Inventario inventario = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                inventario = _ServiceInventario.GetInventarioByID(id.Value);
                if (inventario == null)
                {
                    TempData["Message"] = "No existe el producto solicitado";
                    TempData["Redirect"] = "Inventario";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.listaSeleccionSucursal = listaSeleccionSucursal(inventario.IdSucursal);
                return View(inventario);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Inventario";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // POST: Inventario/Save/5
        [HttpPost]
        public ActionResult Save(Inventario inventario)
        {
            try
            {
                IServiceInventario _ServiceInventario = new ServiceInventario();
                if (ModelState.IsValid)
                {
                    Inventario oInventario = _ServiceInventario.Save(inventario);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", inventario);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Inventario";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Inventario/Delete/5
        public ActionResult Delete(int? id)
        {
            ServiceInventario _ServiceInventario = new ServiceInventario();
            Inventario inventario = null;
            IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                inventario = _ServiceInventario.GetInventarioByID(id.Value);
                if (inventario == null)
                {
                    TempData["Message"] = "No existe el inventario solicitado";
                    TempData["Redirect"] = "Inventario";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.listaProductosPorInventario = _ServiceInventarioProducto.GetInventarioProductoByProductoID(id.Value);

                return View(inventario);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Inventario";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        //METODOS AUXILIARES
        private SelectList listaSeleccionSucursal(int idSucursal = 0)
        {
            //Lista de Sucursales
            IServiceSucursal _ServiceSucursal = new ServiceSucursal();
            IEnumerable<Sucursal> listaSucursal = _ServiceSucursal.GetSucursalByEstadoSistemaID(1);
            return new SelectList(listaSucursal, "IdSurursal", "Nombre", idSucursal);
        }
    }
}
