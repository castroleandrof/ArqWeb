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
    public interface IMedicoService
    {
        [OperationContract]
        Medico Agregar(Medico medico);

        [OperationContract]
        Medico Editar(Medico medico);

        [OperationContract]
        Medico BuscarPorId(int id);

        [OperationContract]
        List<Medico> ListarTodos();

        [OperationContract]
        Medico Eliminar(int id);
    }
}
