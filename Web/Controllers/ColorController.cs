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
    public class ColorController : Controller
    {

        private MyContext db = new MyContext();

        // GET: Color
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
        public ActionResult Create()
        {
            return View();
        }
        

        // GET: Color/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Color/Save/5
        [HttpPost]
        public ActionResult Save(Color color, String codigoColor)
        {
            try
            {
                IServiceColor _ServiceColor = new ServiceColor();

                if (ModelState.IsValid)
                {
                    Color oColorI = _ServiceColor.Save(color);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", color);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Color";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Color/Deactivate/5
        public ActionResult Deactivate(int id)
        {
            return View();
        }
    }
}
