using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
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

        public Precio BuscarPorId(int id)
        {
            var bc = new PrecioComponent();
            return bc.Details(id);
        }

        public List<Precio> BuscarPorTipoServicio(int tipoServicioId)
        {
            var bc = new PrecioComponent();
            return bc.BuscarPorTipoServicio(tipoServicioId);
        }

        public Precio Editar(Precio precio)
        {
            var bc = new PrecioComponent();
            return bc.Editar(precio);
        }

        public List<Precio> ListarTodos()
        {
            var bc = new PrecioComponent();
            return bc.ListarTodos();
        }

        public Precio Eliminar(int id)
        {
            var bc = new PrecioComponent();
            return bc.Eliminar(id);
        }

    }
}
