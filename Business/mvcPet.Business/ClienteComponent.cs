using mvcPet.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Business
{
    public partial class ClienteComponent
    {
        public Cliente Agregar(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.Create(cliente);
            return result;
        }
        public Cliente Editar(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();
            clienteDAC.Update(cliente);
            result = cliente;
            return result;
        }

        public Cliente Eliminar(int id)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.ReadBy(id);
            clienteDAC.Delete(id);
            return result;
        }

        public Cliente BuscarPorId(int id)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.ReadBy(id);
            return result;
        }
        public List<Cliente> ListarTodos()
        {
            List<Cliente> result = default(List<Cliente>);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.Read();
            return result;
        }
    }
}
