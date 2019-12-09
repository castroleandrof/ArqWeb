using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClienteService : IClienteService
    {
        public Cliente Agregar(Cliente cliente)
        {
            var bc = new ClienteComponent();
            return bc.Agregar(cliente);
        }

        public Cliente BuscarPorId(int id)
        {
            var bc = new ClienteComponent();
            return bc.BuscarPorId(id);
        }

        public Cliente Editar(Cliente cliente)
        {
            var bc = new ClienteComponent();
            return bc.Editar(cliente);
        }

        public Cliente Eliminar(int id)
        {
            var bc = new ClienteComponent();
            return bc.Eliminar(id);
        }

        public List<Cliente> ListarTodos()
        {
            var bc = new ClienteComponent();
            return bc.ListarTodos();
        }
    }
}
