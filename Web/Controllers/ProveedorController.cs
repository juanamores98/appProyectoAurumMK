using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProveedorController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Proveedor
        public ActionResult Index()
        {
            IEnumerable<Proveedor> lista = null;
            try
            {
                IServiceProveedor _ServiceProveedor = new ServiceProveedor();
                lista = _ServiceProveedor.GetProveedorByEstadoSistemaID(1);
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
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
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
                    TempData["Message"] = "No existe el proveedor solicitado";
                    TempData["Redirect"] = "Proveedor";
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
                TempData["Redirect"] = "Proveedor";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
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
                    TempData["Message"] = "No existe el proveedor solicitado";
                    TempData["Redirect"] = "Proveedor";
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
                TempData["Redirect"] = "Proveedor";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // POST: Proveedor/Save/5
        [HttpPost]
        public ActionResult Save(Proveedor proveedor, int idEstadoSistema=1)
        {
            try
            {
                ServiceProveedor _ServiceProveedor = new ServiceProveedor();
                if (ModelState.IsValid || idEstadoSistema == 0)
                //En caso de que el idEstadoSistema sea 0 significa que es una desactivacion del proveedor
                //,por cual no se comprueban las validaciones de campos
                {
                    Proveedor oProveedor = _ServiceProveedor.Save(proveedor, idEstadoSistema);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", proveedor);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Proveedor";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Proveedor/Deactivate/5
        public ActionResult Deactivate(int? id)
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
                    TempData["Message"] = "No existe el proveedor solicitado";
                    TempData["Redirect"] = "Proveedor";
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
                TempData["Redirect"] = "Proveedor";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        // GET: Proveedor/Contacto/5
        public ActionResult Contacto(int? idProveedor)
        {
            ServiceProveedor _ServiceProveedor = new ServiceProveedor();
            Proveedor proveedorVista = _ServiceProveedor.GetProveedorByID(idProveedor.Value);
            ViewBag.proveedor = proveedorVista;
            return View();
        }
        // POST: Proveedor/SaveContacto/5
        [HttpPost]
        public ActionResult SaveContacto(ContactoProveedor contactoProveedor, int idProveedor=0,int idEstadoSistema=1)
        {
            try
            {
                ServiceContactoProveedor _ServiceContactoProveedor = new ServiceContactoProveedor();
                if (ModelState.IsValid || idEstadoSistema == 0)
                //En caso de que el idEstadoSistema sea 0 significa que es una desactivacion del proveedor
                //,por cual no se comprueban las validaciones de campos
                {
                    contactoProveedor.IdProveedor = idProveedor;
                    ContactoProveedor oContactoProveedor = _ServiceContactoProveedor.Save(contactoProveedor, idEstadoSistema);
                }
                return RedirectToAction("Edit", new { id = idProveedor });
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Proveedor";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

    }
}
