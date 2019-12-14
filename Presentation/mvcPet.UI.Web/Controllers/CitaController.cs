using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcPet.UI.Proces;

namespace mvcPet.UI.Web.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        {
            var cp = new CitaProcess();
            return View(cp.ListarCita());
        }

        // GET: Cita/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cita/Create
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

        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cita/Edit/5
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

        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cita/Delete/5
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
