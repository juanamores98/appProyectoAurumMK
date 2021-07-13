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
        // GET: RegistroMovimiento/InventoryEntry/5
        public ActionResult InventoryEntry(int? id)
        {
            try
            {
                IServiceInventario _ServiceInventario = new ServiceInventario();
                IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();
                IServiceProducto _ServiceProducto = new ServiceProducto();
                ViewBag.listaSeleccionUsuarios = listaSeleccionUsuarios();
                ViewBag.listaSeleccionMotivo = listaSeleccionMotivo();
                ViewBag.listaProductos = _ServiceProducto.GetProductoNonIncludeInventarioID(1);
                ViewBag.inventarioProducto = _ServiceInventarioProducto.GetInventarioProductoByInventarioID(id.Value);
                Inventario inventario = _ServiceInventario.GetInventarioByID(id.Value);
                return View(inventario);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Registro Movimiento";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        //POST: RegistroMovimiento/InventoryEntryConfirm/5
        [HttpPost]
        public ActionResult InventoryEntryConfirm(string idUsuario, string fechaHora, string comentario, string idMotivoMovimiento, string[] ProductosId, string[] stockMinimo,string[] stock, string[] estante)
        {
            try
            {
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Registro Movimiento";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        

        //METODOS AUXILIARES
        private SelectList listaSeleccionMotivo()
        {
            //Lista de motivos de registro
            IServiceMotivoMovimiento _ServiceMotivoMovimiento = new ServiceMotivoMovimiento();
            IEnumerable<MotivoMovimiento> listaMotivoMovimiento = _ServiceMotivoMovimiento.GetMotivoMovimiento();
            return new SelectList(listaMotivoMovimiento, "IdMotivoMovimiento", "Descripcion");
        }
        private SelectList listaSeleccionUsuarios()
        {
            //Lista de Usuarios
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            IEnumerable<Usuario> listaUsuario = _ServiceUsuario.GetAllUsersEstadoSistemaId(1);
            return new SelectList(listaUsuario, "IdUsuario", "Nombre");
        }
    }
}