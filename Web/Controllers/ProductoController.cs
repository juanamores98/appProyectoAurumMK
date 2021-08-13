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
using Web.Security;

namespace Web.Controllers
{
    public class ProductoController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Producto
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index()
        {
            IEnumerable<Producto> lista = null;
            try
            {
                IServiceProducto _ServiceProducto = new ServiceProducto();
                lista = _ServiceProducto.GetProductoByEstadoSistemaID(1);
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
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Details(int? id)
        {
            ServiceProducto _ServiceProducto = new ServiceProducto();
            Producto producto = null;
            IServiceProveedor _ServiceProveedor = new ServiceProveedor();
            IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();
            IServiceColor _Servicecolores = new ServiceColor();
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
                
                ViewBag.listaProveedor = _ServiceProveedor.GetProveedorByProductoID(id.Value);
                ViewBag.listaInventarioProducto = _ServiceInventarioProducto.GetInventarioProductoByProductoID(id.Value);
                ViewBag.listaColor = _Servicecolores.GetColorByProductoID(id.Value);
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
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.listaSeleccionCategoriaProducto = listaSeleccionCategoriaProducto();
            ViewBag.listaSeleccionInventario = listaSeleccionInventario(null);
            ViewBag.listaSeleccionProveedor = listaSeleccionProveedor(null);
            ViewBag.listaSeleccionColor = listaSeleccionColor(null);
            return View();
        }

        // GET: Producto/CreateByUser/5
        public ActionResult CreateByUser()
        {
            return View();
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            ServiceProducto _ServiceProducto = new ServiceProducto();
            Producto producto = null;

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
                ViewBag.listaSeleccionCategoriaProducto = listaSeleccionCategoriaProducto(producto.IdCategoriaProducto.Value);
                ViewBag.listaSeleccionInventario = listaSeleccionInventario(producto.InventarioProducto);
                ViewBag.listaSeleccionProveedor = listaSeleccionProveedor(producto.Proveedor);
                ViewBag.listaSeleccionColor = listaSeleccionColor(producto.Color);
                ViewBag.IdEstadoSistema = new SelectList(db.EstadoSistema, "IdEstadoSistema", "Descripcion", producto.IdEstadoSistema);
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
        [CustomAuthorize((int)Roles.Administrador)]
        [HttpPost]
        public ActionResult Save(Producto producto, HttpPostedFileBase ImageFile, string[] seleccionInventarios, string[] seleccionProveedores, string[] seleccionColores,int idEstadoSistema=1)
        {
            MemoryStream target = new MemoryStream();
            IServiceProducto _ServiceProducto = new ServiceProducto();
            try
            {
                // Cuando es Insert Image viene en null porque se pasa diferente
                if (producto.Imagen == null)
                {
                    if (ImageFile != null)
                    {
                        ImageFile.InputStream.CopyTo(target);
                        producto.Imagen = target.ToArray();
                        ModelState.Remove("Imagen");
                    }

                }
                if (ModelState.IsValid || idEstadoSistema==0)
                //En caso de que el idEstadoSistema sea 0 significa que es una desactivacion del producto
                //,por cual no se comprueban las validaciones de campos
                {
                    Producto oProducto = _ServiceProducto.Save(producto, seleccionInventarios, seleccionProveedores, seleccionColores,idEstadoSistema);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Util.Util.ValidateErrors(this);
                    ViewBag.listaSeleccionCategoriaProducto = listaSeleccionCategoriaProducto(producto.IdCategoriaProducto.Value);
                    ViewBag.listaSeleccionInventario = listaSeleccionInventario(producto.InventarioProducto);
                    ViewBag.listaSeleccionProveedor = listaSeleccionProveedor(producto.Proveedor);
                    ViewBag.listaSeleccionColor = listaSeleccionColor(producto.Color);
                    return View("Create", producto);
                }

                //SweetAlert
                TempData["AlertMessageTitle"] = "Operacion Exitosa";
                TempData["AlertMessageBody"] = "-";
                TempData["AlertMessageType"] = "success";

                return RedirectToAction("Index");
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
        // POST: Producto/ProductoRequest/5
        [HttpPost]
        public ActionResult ProductoRequest(string ImagenFile)
        {
            MemoryStream target = new MemoryStream();
            IServiceProducto _ServiceProducto = new ServiceProducto();
            try
            {
                //Creacion de propuesta
                Producto producto = new Producto();
                producto.Nombre = "Propuesta Producto - "+DateTime.Now;
                producto.CostoU = 4500;
                producto.IdCategoriaProducto=1;
                producto.IdEstadoSistema = 0;
                producto.Imagen = Convert.FromBase64String(ImagenFile);

                //Guardado de producto propuesta
                Producto oProducto = _ServiceProducto.Save(producto, null, null, null, 0);


                //SweetAlert
                TempData["AlertMessageTitle"] = "Operacion Exitosa";
                TempData["AlertMessageBody"] = "-";
                TempData["AlertMessageType"] = "success";

                return RedirectToAction("Index");
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

        // GET: Producto/Deactivate/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Deactivate(int? id)
        {
            ServiceProducto _ServiceProducto = new ServiceProducto();
            Producto producto = null;
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
        //METODOS AUXILIARES
        private SelectList listaSeleccionCategoriaProducto(int idCategoriaProducto = 0)
        {
            //Lista de categorias de producto
            IServiceCategoriaProducto _ServiceCategoriaProducto = new ServiceCategoriaProducto();
            IEnumerable<CategoriaProducto> listaCategoriaProducto = _ServiceCategoriaProducto.GetCategoriaProducto();
            return new SelectList(listaCategoriaProducto, "IdCategoriaProducto", "Descripcion", idCategoriaProducto);
        }
        private MultiSelectList listaSeleccionInventario(ICollection<InventarioProducto> inventarios)
        {
            //Lista de Inventario
            IServiceInventario _ServiceInventario = new ServiceInventario();
            IEnumerable<Inventario> listaInventario = _ServiceInventario.GetInventarioByEstadoSistemaID(1);
            //Inventarios donde se encuentra el producto
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
            IEnumerable<Proveedor> listaProveedor = _ServiceProveedor.GetProveedorByEstadoSistemaID(1);
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
            IEnumerable<Color> listaColor = _Servicecolores.GetColorByEstadoSistemaID(1);
            int[] listaColorSelect = null;

            if (colores != null)
            {

                listaColorSelect = colores.Select(c => c.IdColor).ToArray();
            }

            return new MultiSelectList(listaColor, "IdColor", "Descripcion", listaColorSelect);

        }
    }
}
