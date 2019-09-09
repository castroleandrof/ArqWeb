using System.Collections.Generic;
using System.ServiceModel;
using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PrecioService : IPrecioService
    {
        public Precio Agregar(Precio precio)
        {
            var bc = new PrecioComponent();
            return bc.Agregar(precio);
        }

        public List<Precio> ListarTodos()
        {
            var bc = new PrecioComponent();
            return bc.ListarTodos();
        }

        public void Edit(Precio precio)
        {
            var bc = new PrecioComponent();
            bc.Edit(precio);
        }

        public void Delete(int Id)
        {
            var bc = new PrecioComponent();
            bc.Delete(Id);
        }

        public Precio Details(int Id)
        {
            var bc = new PrecioComponent();
            return bc.Details(Id);
        }
    }
}
