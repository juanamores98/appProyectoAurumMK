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
    }
}