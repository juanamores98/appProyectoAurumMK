using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            IEnumerable<InventarioProducto> lista= null;
            try
            {
                IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();
                lista = _ServiceInventarioProducto.GetInventarioProducto();
                ViewBag.registroEntradas = _ServiceRegistroMovimiento.GetRegistroMovimiento().Where(r => r.IdTipoMovimiento == 1).Count();
                ViewBag.registroSalidas = _ServiceRegistroMovimiento.GetRegistroMovimiento().Where(m => m.IdTipoMovimiento == 2).Count();
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
        // GET: RegistroMovimientos/List/5
        public ActionResult ReporteMovimientos()
        {
            IEnumerable<RegistroMovimiento> lista = null;
            try
            {
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();
                lista = _ServiceRegistroMovimiento.GetRegistroMovimiento();
  
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
    }
}