using System.Collections.Generic;
using System.ServiceModel;
using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TipoServicioService : ITipoServicioService
    {
        public TipoServicio Agregar(TipoServicio tipoServicio)
        {
            var bc = new TipoServicioComponent();
            return bc.Agregar(tipoServicio);
        }

        public List<TipoServicio> ListarTodos()
        {
            var bc = new TipoServicioComponent();
            return bc.ListarTodos();
        }

        public void Edit(TipoServicio tipoServicio)
        {
            var bc = new TipoServicioComponent();
            bc.Edit(tipoServicio);
        }

        public void Delete(int Id)
        {
            var bc = new TipoServicioComponent();
            bc.Delete(Id);
        }

        public TipoServicio BuscarPorId(int Id)
        {
            var bc = new TipoServicioComponent();
            return bc.Details(Id);
        }
    }
}
