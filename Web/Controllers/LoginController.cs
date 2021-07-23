using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Utils;
using static Web.Utils.SweetAlerHelper;
namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Login para validar al usuario
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            Usuario oUsuario = null;

            try
            {
                if (ModelState.IsValid)
                {
                    oUsuario = _ServiceUsuario.GetUsuario(usuario.Correo, usuario.Contra);

                    //Si encuentra al usuario y además es un usuario activo lo deja ingresa si no le muestra el error
                    if (oUsuario != null && oUsuario.IdEstadoSistema == 1)
                    {
                        Session["User"] = oUsuario;
                        Log.Info($"Accede {oUsuario.Nombre} con el rol {oUsuario.IdTipoUsuario}");
                        TempData["NotificationMessage"] = SweetAlerHelper.Mensaje("Acceso exitoso", "Bienvenido a Aurum MK", SweetAlertMessageType.success);
                        return RedirectToAction("Index", "Home");
                        
                    }
                    else
                    {
                        TempData["NotificationMessage"] = SweetAlerHelper.Mensaje("Acceso Inválido", "Por favor verifique sus datos", SweetAlertMessageType.warning);
                        Log.Warn($"{usuario.Correo} se intentó conectar y falló");
                        
                    }
                }

                return View("Index");
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

        //Página de no autorización al ingreso
        //GET: UnAuthorized
        public ActionResult UnAuthorized()
        {
            try
            {
                ViewBag.Message = "No autorizado";

                if (Session["User"] != null)
                {
                    Usuario oUsuario = Session["User"] as Usuario;
                    Log.Warn($"El usuario {oUsuario.Nombre} con el rol {oUsuario.IdTipoUsuario} intentó ingresar y no está autorizado");
                }
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Login";
                TempData["Redirect-Action"] = "Login";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


        //Acción de cierre de sesión
        public ActionResult Logout()
        {
            try
            {
                Log.Info("Usuario desconectado!");
                Session["User"] = null;
                return RedirectToAction("Index", "Login");
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
    }
}