using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace web.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        [CustomAuthorize((int)Roles.Administrador)]
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
        // GET: CalificacionUsuario
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult CalificacionesIndex()
        {
            IServiceCalificacionUsuario _service = new ServiceCalificacionUsuario();
            return View(_service.GetCalificacionUsuarioByEstadoSistemaID(1));
        }
        // GET: Reports/ReporteMovimientosIndex/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult ReporteMovimientosIndex()
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
        // GET: Reports/ReporteMovimientoDetails/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult ReporteMovimientoDetails(int? id)
        {
            IEnumerable<RegistroMovimiento> lista = null;
            try
            {
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();
                RegistroMovimiento oRegistroMovimiento = _ServiceRegistroMovimiento.GetRegistroMovimientoByID(id.Value);
                return View(oRegistroMovimiento);
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