﻿using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ColorController : Controller
    {

        private MyContext db = new MyContext();

        // GET: Color
        public ActionResult Index()
        {
            IEnumerable<Color> lista = null;
            try
            {
                IServiceColor _ServiceColor = new ServiceColor();
                lista = _ServiceColor.GetColorByEstadoSistemaID(1);
                ViewBag.title = "Lista Color";
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                //Redirección a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Color/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Color/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Color/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Color/Edit/5
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

        // GET: Color/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Color/Delete/5
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
