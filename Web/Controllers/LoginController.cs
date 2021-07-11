using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult LoginUsuario(Usuario usuario)
        {
            return View("Index");
        }

        //Página de no autorización al ingreso
        public ActionResult UnAutorized()
        {
            return View();
        }


        //Acción de cierre de sesión
        public ActionResult LogOut()
        {
            return View();
        }
    }
}