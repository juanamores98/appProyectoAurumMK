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
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");
            return View();
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", inventario.IdSucursal);
            return View(inventario);
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
        private SelectList listaSeleccionCategoriaProducto(int idCategoriaProducto = 0)
        {
            //Lista de categorias de producto
            IServiceCategoriaProducto _ServiceCategoriaProducto = new ServiceCategoriaProducto();
            IEnumerable<CategoriaProducto> listaCategoriaProducto = _ServiceCategoriaProducto.GetCategoriaProducto();
            return new SelectList(listaCategoriaProducto, "IdCategoriaProducto", "Descripcion", idCategoriaProducto);
        }
    }
}
