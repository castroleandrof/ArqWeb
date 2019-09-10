using mvcPet.Entities;
using mvcPet.Services;
using mvcPet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPet.UI.Web.Controllers
{
    public class PrecioController : Controller
    {
        // GET: Precio
        public ActionResult Index()
        {
            IPrecioService precioService = new PrecioService();
            var lista = precioService.ListarTodos();
            return View(lista);
        }

        // GET: Precio/Details/5
        public ActionResult Details(int id)
        {
            IPrecioService precioService = new PrecioService();
            var lista = precioService.ListarTodos();
            return View(lista);
        }

        // GET: Precio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Precio/Create
        [HttpPost]
        public ActionResult Create(Precio modelo)
        {
            try
            {
                // TODO: Add insert logic here

                IPrecioService precioService = new PrecioService();
                precioService.Agregar(modelo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Precio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Precio/Edit/5
        [HttpPost]
        public ActionResult Edit(Precio modelo)
        {
            try
            {
                // TODO: Add update logic here
                IPrecioService precioService = new PrecioService();
                precioService.Edit(modelo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Precio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Precio/Delete/5
        [HttpPost]
        public ActionResult Delete(Precio modelo)
        {
            try
            {
                // TODO: Add delete logic here
                IPrecioService precioService = new PrecioService();
                precioService.Delete(modelo.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
