using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class RegistroMovimientoController : Controller
    {
        // GET: RegistroMovimiento
        public ActionResult Index()
        {
            IEnumerable<Inventario> lista = null;
            try
            {
                IServiceInventario _ServiceInventario = new ServiceInventario();
                lista = _ServiceInventario.GetInventarioByEstadoSistemaID(1);
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
        // GET: RegistroMovimiento/InventoryProductsEntry/5
        public ActionResult InventoryProductsEntry(int? id)
        {
            try
            {
                IServiceInventario _ServiceInventario = new ServiceInventario();
                IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();
                IServiceProducto _ServiceProducto = new ServiceProducto();
                ViewBag.listaSeleccionMotivo = listaSeleccionMotivo();
                ViewBag.listaProductos = _ServiceProducto.GetProductoNonIncludeInventarioID(id.Value);
                ViewBag.inventarioProducto = _ServiceInventarioProducto.GetInventarioProductoByInventarioID(1);
                return View(_ServiceInventario.GetInventarioByID(id.Value));
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult InventoryProductsEntry_Select()
        {
            IServiceProducto _ServiceProducto = new ServiceProducto();
            return View(_ServiceProducto.GetProductoNonIncludeInventarioID(1));
        }
        // GET: RegistroMovimiento/test/5
        public ActionResult test()
        {
            IServiceProducto _ServiceProducto = new ServiceProducto();
            return View(_ServiceProducto.GetProductoNonIncludeInventarioID(1));
        }
        // POST: RegistroMovimiento/testForm/5
        [HttpPost]
        public ActionResult testForm(string[] lista)
        {
            return RedirectToAction("test");
        }
        //METODOS AUXILIARES
        private SelectList listaSeleccionMotivo()
        {
            //Lista de motivos de registro
            IServiceMotivoMovimiento _ServiceMotivoMovimiento = new ServiceMotivoMovimiento();
            IEnumerable<MotivoMovimiento> listaMotivoMovimiento = _ServiceMotivoMovimiento.GetMotivoMovimiento();
            return new SelectList(listaMotivoMovimiento, "IdMotivoMovimiento", "Descripcion");
        }
    }
}