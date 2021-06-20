using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance Index
        public ActionResult Index()
        {
            return View();
        }
        /*
         * USUARIOS
         */
        /*
         * PRODUCTOS
         */
        // GET: Producto/List/5
        public ActionResult MantenimientoProducto()
        {
            IEnumerable<Producto> lista = null;
            try
            {
                IServiceProducto _ServiceProducto = new ServiceProducto();
                lista = _ServiceProducto.GetProducto();
                ViewBag.title = "Lista Producto";
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
            return View();
        }
        // GET: Producto/Details/5
        public ActionResult DetalleProducto(int? id)
        {
            ServiceProducto _ServiceProducto = new ServiceProducto();
            Producto producto = null;
            IServiceProveedor _ServiceProveedor = new ServiceProveedor();
            IServiceInventario _ServiceInventario = new ServiceInventario();
            
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                producto = _ServiceProducto.GetProductoByID(id.Value);
                if (producto == null)
                {
                    TempData["Message"] = "No existe el producto solicitado";
                    TempData["Redirect"] = "producto";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.proveedorProducto = _ServiceProveedor.GetProveedorByProductoID(id.Value);
                ViewBag.inventarioProducto = _ServiceInventario.GetInventarioByProductoID(id.Value);
                return View(producto);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        /*
         * COLORES
         */
        /*
         * Proveedor
         */
        // GET: Proveedor/Details/5
        public ActionResult MantenimientoProveedor()
        {
            IEnumerable<Proveedor> lista = null;
            try
            {
                IServiceProveedor _ServiceProveedor = new ServiceProveedor();
                lista = _ServiceProveedor.GetProveedor();
                ViewBag.title = "Lista Proveedor";
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
            return View();
        }
        // GET: Proveedor/Details/5
        public ActionResult DetalleProveedor(int? id)
        {
            ServiceProveedor _ServiceProveedor = new ServiceProveedor();
            Proveedor proveedor = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                proveedor = _ServiceProveedor.GetProveedorByID(id.Value);
                if (proveedor == null)
                {
                    TempData["Message"] = "No existe el producto solicitado";
                    TempData["Redirect"] = "producto";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(proveedor);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
    }
}