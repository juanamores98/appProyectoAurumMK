using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CategoriaProductoController : Controller
    {
        // GET: CategoriaProducto
        public ActionResult Index()
        {
            IEnumerable<CategoriaProducto> lista = null;
            try
            {
                IServiceCategoriaProducto _ServiceCategoria = new ServiceCategoriaProducto();
                lista = _ServiceCategoria.GetCategoriaProducto();
                ViewBag.title = "Lista CategoriaProducto";
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

        public ActionResult Save(CategoriaProducto categoriaP)
        {
            try
            {
                IServiceCategoriaProducto _ServiceCategoria = new ServiceCategoriaProducto();
                CategoriaProducto oCategoria = _ServiceCategoria.GetCategoriaProductoByID(categoriaP.IdCategoriaProducto);

                if (ModelState.IsValid) 
                {   
                    //crea una nueva categoria
                    CategoriaProducto categoria = _ServiceCategoria.Save(categoriaP);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", categoriaP);
                }
                //lo devuelve al index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "CategoriaProducto";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            ServiceCategoriaProducto _ServiceCategoriaProducto = new ServiceCategoriaProducto();
            CategoriaProducto categoria = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                categoria = _ServiceCategoriaProducto.GetCategoriaProductoByID(id);

                if (categoria == null)
                {
                    TempData["Message"] = "No existe la categoría solicitada";
                    TempData["Redirect"] = "CategoriaProducto";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(categoria);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Color";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Delete(int? id)
        {
            return View();
        }

    }
}


