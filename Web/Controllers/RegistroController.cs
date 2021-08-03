using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace Web.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registro/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: Registro/Create
        [HttpPost]
        public ActionResult Save(Usuario usuario)
        {
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                var oUsuario = _ServiceUsuario.GetUsuarioByEmail(usuario.Correo);

                if (ModelState.IsValid)
                {
                    if (oUsuario == null)
                    {
                        usuario.IdEstadoSistema = 0;
                        usuario.IdTipoUsuario = 1;
                        Usuario usuarioNew = _ServiceUsuario.Save(usuario);
                        //SweetAlert
                        TempData["AlertMessageTitle"] = "Registro exitoso";
                        TempData["AlertMessageBody"] = "El administrador le notificara  por medio de un correo electronico la aprobacion de la cuenta.";
                        TempData["AlertMessageType"] = "success";
                        return RedirectToAction("Index", "Registro");
                    }
                }

                else
                {
                    //Valida errores si Js está deshabilitado
                    Util.Util.ValidateErrors(this);

                    //SweetAlert
                    TempData["AlertMessageTitle"] = "Registro invalido";
                    TempData["AlertMessageBody"] = "Por favor verifique sus datos";
                    TempData["AlertMessageType"] = "warning";


                    return View("Index", usuario);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Color";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
