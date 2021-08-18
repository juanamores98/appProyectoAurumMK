using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace Web.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        [CustomAuthorize((int)Roles.Administrador, (int)Roles.Cliente)]
        public ActionResult Index()
        {
            IEnumerable<Producto> lista = null;
            try
            {
                IServiceProducto _ServiceProducto = new ServiceProducto();
                lista = _ServiceProducto.GetProductoByEstadoSistemaID(1);
                ViewBag.listaProductos = lista;
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                //Redirección a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public PartialViewResult pulserasxNombre(int? id)
        {
            IEnumerable<Producto> lista = null;

            IServiceProducto _ServiceProducto = new ServiceProducto();

            if (id != null)
            {
                lista = _ServiceProducto.GetProductoByIDCatalogo((int)id);
            }
            return PartialView("_PartialViewProducto", lista);
        }

        public ActionResult buscarPulseraxNombre(string filtro)
        {
            IEnumerable<Producto> lista = null;
            IServiceProducto _ServiceProducto = new ServiceProducto();

            //Error porque viene en blanco
            if (string.IsNullOrEmpty(filtro))
            {
                lista = _ServiceProducto.GetProducto();
            }
            else
            {
                lista = _ServiceProducto.GetProductoByNombre(filtro);
            }

            //Retorna un partial view
            return PartialView("_PartialViewProductoAdmin", lista);
        }

        // GET: Catalogo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Catalogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogo/Create
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

        // GET: Catalogo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catalogo/Edit/5
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

        // GET: Catalogo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catalogo/Delete/5
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
