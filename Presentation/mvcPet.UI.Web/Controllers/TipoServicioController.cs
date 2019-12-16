using System.Web.Mvc;
using mvcPet.Entities;
using mvcPet.Services;
using mvcPet.Services.Contracts;
using System.Reflection;

namespace mvcPet.UI.Web.Controllers
{
    public class TipoServicioController : Controller
    {
        // GET: TipoServicio
        public ActionResult Index()
        {
            ITipoServicioService tipoServicioService = new TipoServicioService();
            var lista = tipoServicioService.ListarTodos();
            return View(lista);
        }

        // GET: TipoServicio/Details/5
        public ActionResult Details(TipoServicio modelo)
        {
            ITipoServicioService tipoServicioService = new TipoServicioService();
            var tipoServicio = tipoServicioService.BuscarPorId(modelo.Id);
            return View(tipoServicio); 
        }

        // GET: TipoServicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicio/Create
        [HttpPost]
        public ActionResult Create(TipoServicio modelo)
        {
            try
            {
                // TODO: Add insert logic here
                ITipoServicioService tipoServicioService = new TipoServicioService();
                tipoServicioService.Agregar(modelo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoServicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoServicio/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoServicio modelo)
        {
            try
            {
                // TODO: Add update logic here
                ITipoServicioService tipoServicioService = new TipoServicioService();
                tipoServicioService.Edit(modelo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoServicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoServicio/Delete/5
        [HttpPost]
        public ActionResult Delete(TipoServicio modelo)
        {
            try
            {
                // TODO: Add delete logic here
                ITipoServicioService tipoServicioService = new TipoServicioService();
                tipoServicioService.Delete(modelo.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
