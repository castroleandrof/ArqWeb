using mvcPet.Entities;
using mvcPet.Services;
using mvcPet.Services.Contracts;
using mvcPet.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mvcPet.UI.Web.Controllers
{
    [Authorize]
    public class EspecieController : BaseController
    {
        private IEspecieService _especieService;

        public EspecieController(IEspecieService especieService)
        {
            _especieService = especieService;
        }

        public EspecieController()
        { }


       // [Authorize]
        public ActionResult Index()
        {
            IEspecieService especieService = new EspecieService();
            var lista = especieService.ListarTodos();
         //   LogService.Log("Listar especies.");
            return View(lista);
        }

        // GET: Especie/Details/5
        [Authorize]
        public ActionResult Details(Especie modelo)
        {
            IEspecieService especieService = new EspecieService();
            var especie = especieService.Details(modelo.Id);
            return View(especie);
        }

        // GET: Especie/Create
        [Authorize(Roles="Admin")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Especie/Create
        [Authorize(Roles="Admin")]
        [HttpPost]
        public ActionResult Create(Especie modelo)
        {
            try
            {
                // TODO: Add insert logic here
                IEspecieService especieService = new EspecieService();
                especieService.Agregar(modelo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int Id)
        {
            return View();
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(Especie modelo)
        {
            try
            {
                IEspecieService especieService = new EspecieService();
                especieService.Edit(modelo);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(Especie modelo)
        {
            try
            {
                // TODO: Add delete logic here
                IEspecieService especieService = new EspecieService();
                especieService.Delete(modelo.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
