using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        Cliente Agregar(Cliente cliente);

        [OperationContract]
        Cliente Editar(Cliente cliente);

        [OperationContract]
        Cliente BuscarPorId(int id);

        [OperationContract]
        List<Cliente> ListarTodos();

        [OperationContract]
        Cliente Eliminar(int id);
    }
}
