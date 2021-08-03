using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace web.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance Index
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index() 
        {
            return View();
        }
    }
}