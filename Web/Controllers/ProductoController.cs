using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infraestructure.Models;
using ApplicationCore.Services;
using System.IO;
using System.Reflection;

namespace Web.Controllers
{
    public class ProductoController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Producto
        public ActionResult Index()
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
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
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
                    TempData["Redirect"] = "Producto";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                
                ViewBag.listaProveedorProducto = _ServiceProveedor.GetProveedorByProductoID(id.Value);
                ViewBag.listaInventarioProducto = _ServiceInventario.GetInventarioByProductoID(id.Value);
                
                return View(producto);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Producto";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.listaSeleccionCategoriaProducto = listaSeleccionCategoriaProducto();
            ViewBag.listaSeleccionInventario = listaSeleccionInventario(null);
            ViewBag.listaSeleccionProveedor = listaSeleccionProveedor(null);
            ViewBag.listaSeleccionColor = listaSeleccionColor(null);
            return View();
        }


        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
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
                    TempData["Redirect"] = "Producto";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.listaCategoriaProducto = listaSeleccionCategoriaProducto(producto.IdCategoriaProducto.Value);
                ViewBag.listaInventario = listaSeleccionInventario(producto.Inventario);
                ViewBag.listaProveedor = listaSeleccionProveedor(producto.Proveedor);
                ViewBag.listaColor = listaSeleccionColor(producto.Color);
                return View(producto);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Producto";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // POST: Producto/Save/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "IdProducto,Nombre,Imagen,CostoU,IdEstadoSistema,IdCategoriaProducto")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoriaProducto = new SelectList(db.CategoriaProducto, "IdCategoriaProducto", "Descripcion", producto.IdCategoriaProducto);
            ViewBag.IdEstadoSistema = new SelectList(db.EstadoSistema, "IdEstadoSistema", "Descripcion", producto.IdEstadoSistema);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //METODOS AUXILIARES
        private SelectList listaSeleccionCategoriaProducto(int idCategoriaProducto = 0)
        {
            //Lista de categorias de producto
            IServiceCategoriaProducto _ServiceCategoriaProducto = new ServiceCategoriaProducto();
            IEnumerable<CategoriaProducto> listaCategoriaProducto = _ServiceCategoriaProducto.GetCategoriaProducto();
            return new SelectList(listaCategoriaProducto, "IdCategoriaProducto", "Descripcion", idCategoriaProducto);
        }
        private MultiSelectList listaSeleccionInventario(ICollection<Inventario> inventarios)
        {
            //Lista de Inventario
            IServiceInventario _ServiceInventario = new ServiceInventario();
            IEnumerable<Inventario> listaInventario = _ServiceInventario.GetInventario();
            int[] listaInventarioSelect = null;

            if (inventarios != null)
            {

                listaInventarioSelect = inventarios.Select(c => c.IdInventario).ToArray();
            }

            return new MultiSelectList(listaInventario, "IdInventario", "IdInventario", listaInventarioSelect);

        }
        private MultiSelectList listaSeleccionProveedor(ICollection<Proveedor> proveedores)
        {
            //Lista de Proveedor
            IServiceProveedor _ServiceProveedor = new ServiceProveedor();
            IEnumerable<Proveedor> listaProveedor = _ServiceProveedor.GetProveedor();
            int[] listaProveedorSelect = null;

            if (proveedores != null)
            {

                listaProveedorSelect = proveedores.Select(c => c.IdProveedor).ToArray();
            }

            return new MultiSelectList(listaProveedor, "IdProveedor", "Nombre", listaProveedorSelect);

        }
        private MultiSelectList listaSeleccionColor(ICollection<Color> colores)
        {
            //Lista de Color
            IServiceColor _Servicecolores = new ServiceColor();
            IEnumerable<Color> listaColor = _Servicecolores.GetColor();
            int[] listaColorSelect = null;

            if (colores != null)
            {

                listaColorSelect = colores.Select(c => c.IdColor).ToArray();
            }

            return new MultiSelectList(listaColor, "IdColor", "Descripcion", listaColorSelect);

        }
    }
}
