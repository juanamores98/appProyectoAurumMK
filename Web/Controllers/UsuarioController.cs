using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructure.Models;
using Web.Security;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Usuario
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.EstadoSistema).Include(u => u.TipoUsuario);
            return View(usuario.ToList());
        }

        public ActionResult Activate()
        {
            IEnumerable<Usuario> lista = null;
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                lista = _ServiceUsuario.GetAllUsersEstadoSistemaId(0);
                ViewBag.title = "Lista Usuarios Desactivados";
                ViewBag.listaUsuariosDesactivados = _ServiceUsuario.GetAllUsersEstadoSistemaId(0);
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

        public ActionResult Deactivate()
        {
            IEnumerable<Usuario> lista = null;
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                lista = _ServiceUsuario.GetAllUsersEstadoSistemaId(1);
                ViewBag.title = "Lista Usuarios Activos ";
                ViewBag.listaUsuariosActivos = _ServiceUsuario.GetAllUsersEstadoSistemaId(1);
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


        // GET: Usuario/Details/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.IdEstadoSistema = new SelectList(db.EstadoSistema, "IdEstadoSistema", "Descripcion");
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario, "IdTipoUsuario", "Descripcion");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create([Bind(Include = "IdUsuario,Nombre,Correo,Contra,Telefono,Direccion,IdEstadoSistema,IdTipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstadoSistema = new SelectList(db.EstadoSistema, "IdEstadoSistema", "Descripcion", usuario.IdEstadoSistema);
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario, "IdTipoUsuario", "Descripcion", usuario.IdTipoUsuario);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstadoSistema = new SelectList(db.EstadoSistema, "IdEstadoSistema", "Descripcion", usuario.IdEstadoSistema);
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario, "IdTipoUsuario", "Descripcion", usuario.IdTipoUsuario);
            return View(usuario);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int idUsuario)
        {
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                Usuario oUsuario = _ServiceUsuario.GetUsuarioByID(idUsuario);

                //Revisa id 
                if (ModelState.IsValid)
                {
                    oUsuario.IdEstadoSistema = 1;
                    _ServiceUsuario.Save(oUsuario);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", oUsuario);
                }

                //SweetAlert
                TempData["AlertMessageTitle"] = "Operacion Exitosa";
                TempData["AlertMessageBody"] = "-";
                TempData["AlertMessageType"] = "success";

                //lo devuelve al index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "CategoriaProducto";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public ActionResult Activate1()
        {
            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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

        public ActionResult Save(Usuario usuario)
        {
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                Usuario oUsuario = _ServiceUsuario.GetUsuarioByID(usuario.IdUsuario);

                //Revisa id 
                if (ModelState.IsValid )
                {
          
                    oUsuario  = _ServiceUsuario.Save(usuario);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", usuario);
                }

                //SweetAlert
                TempData["AlertMessageTitle"] = "Operacion Exitosa";
                TempData["AlertMessageBody"] = "-";
                TempData["AlertMessageType"] = "success";

                //lo devuelve al index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "CategoriaProducto";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


        public ActionResult ActivarConfirmado(int idUsuario)
        {
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                Usuario oUsuario = _ServiceUsuario.GetUsuarioByID(idUsuario);

                //Revisa id 
                if (ModelState.IsValid)
                {
                   oUsuario.IdEstadoSistema=1;
                   oUsuario.EstadoSistema = null;
                  _ServiceUsuario.Save(oUsuario);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", oUsuario);
                }

                //SweetAlert
                TempData["AlertMessageTitle"] = "Operacion Exitosa";
                TempData["AlertMessageBody"] = "-";
                TempData["AlertMessageType"] = "success";

                //lo devuelve al index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "CategoriaProducto";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult DesactivarConfirmado(int idUsuario)
        {
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                Usuario oUsuario = _ServiceUsuario.GetUsuarioByID(idUsuario);

                //Revisa id 
                if (ModelState.IsValid)
                {
                    oUsuario.IdEstadoSistema = 0;
                    oUsuario.EstadoSistema = null;
                    _ServiceUsuario.Save(oUsuario);
                }
                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);
                    return View("Create", oUsuario);
                }

                //SweetAlert
                TempData["AlertMessageTitle"] = "Operacion Exitosa";
                TempData["AlertMessageBody"] = "-";
                TempData["AlertMessageType"] = "success";

                //lo devuelve al index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "CategoriaProducto";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

    }
}
