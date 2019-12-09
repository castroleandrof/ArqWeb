using System.Collections.Generic;
using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;

namespace mvcPet.UI.Web.Controllers
{
    public class SalaService : ISalaService
    {
        public Sala Agregar(Sala sala)
        {
            var bc = new SalaComponent();
            return bc.Agregar(sala);
        }

        public Sala BuscarPorId(int id)
        {
            var bc = new SalaComponent();
            return bc.BuscarPorId(id);
        }

        public Sala Editar(Sala sala)
        {
            var bc = new SalaComponent();
            return bc.Editar(sala);
        }

        public List<Sala> ListarTodos()
        {
            var bc = new SalaComponent();
            return bc.ListarTodos();
        }

        public Sala Eliminar(int id)
        {
            var bc = new SalaComponent();
            return bc.Eliminar(id);
        }
    }
}
