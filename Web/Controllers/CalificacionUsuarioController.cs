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
    public class CalificacionUsuarioController : Controller
    {




        // GET: CalificacionUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalificacionUsuario/Save
        [HttpPost]
        public ActionResult Save(CalificacionUsuario calificacionUsuario, int idEstadoSistema)
        {

            try
            {
                IServiceColor _ServiceColor = new ServiceColor();
                IServiceCalificacionUsuario _service = new ServiceCalificacionUsuario();
                _service.Save(calificacionUsuario, idEstadoSistema);

                //SweetAlert
                TempData["AlertMessageTitle"] = "Califiacion Enviada";
                TempData["AlertMessageBody"] = "-";
                TempData["AlertMessageType"] = "success";

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Home";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
    }
}
