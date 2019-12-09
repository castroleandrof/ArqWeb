using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface ISalaService
    {
        [OperationContract]
        Sala Agregar(Sala sala);

        [OperationContract]
        Sala Editar(Sala sala);

        [OperationContract]
        Sala BuscarPorId(int id);

        [OperationContract]
        List<Sala> ListarTodos();

        [OperationContract]
        Sala Eliminar(int id);
    }
}
