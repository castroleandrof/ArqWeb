//using mvcPet.Entities;
//using mvcPet.UI.Proces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace mvcPet.Hosts.Web.Controllers
{
    [System.Web.Http.RoutePrefix("api/Cita")]
    public class CitaController : ApiController
    {
        public CitaController()
        {
        }


        [System.Web.Http.Authorize]
        [System.Web.Http.Route("ToList")]
        //public List<mvcPet.Entities.Cita> Index()
        //{
        //    var cp = new CitaProcess();
        //    return (cp.ListarCita());
        //}

       
            // GET: api/Cita/5
            public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cita
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cita/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cita/5
        public void Delete(int id)
        {
        }
    }
}
