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

        // GET: Inventario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
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

        // POST: Inventario/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdInventario,IdSucursal")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", inventario.IdSucursal);
            return View(inventario);
        }

        // GET: Inventario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
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
