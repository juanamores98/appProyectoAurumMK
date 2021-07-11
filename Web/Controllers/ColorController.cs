using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace Web.Controllers
{
    public class ColorController : Controller
    {

        private MyContext db = new MyContext();

        // GET: Color
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index()
        {
            IEnumerable<Color> lista = null;
            try
            {  
                IServiceColor _ServiceColor = new ServiceColor();
                lista = _ServiceColor.GetColorByEstadoSistemaID(1);
                ViewBag.title = "Lista Color";
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

        // GET: Color/Create/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            return View();
        }


        // GET: Color/Edit/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int? id)
        {
            ServiceColor _ServiceColor = new ServiceColor();
            Color color = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                color = _ServiceColor.GetColorByID(id.Value);
                if (color == null)
                {
                    TempData["Message"] = "No existe el producto solicitado";
                    TempData["Redirect"] = "Color";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(color);
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

        // POST: Color/Save/5
        [HttpPost]
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Save(Color color, string codigoColor, int idEstadoSistema = 1)
        {
            try
            {
                IServiceColor _ServiceColor = new ServiceColor();
                if (ModelState.IsValid || idEstadoSistema == 0)
                {
                    color.Codigo = codigoColor;
                    Color oColor = _ServiceColor.Save(color, idEstadoSistema);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", color);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Color";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // POST: Color/Deactivate/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Deactivate(int? id)
        {
            try
            {
                ServiceColor _ServiceColor = new ServiceColor();
                Color color = null;
                color = _ServiceColor.GetColorByID(id.Value);
                Save(color, null, 0);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Color";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
    }
}
