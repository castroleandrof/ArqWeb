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
    public interface IPrecioService
    {
        [OperationContract]
        Precio Agregar(Precio precio);

        [OperationContract]
        Precio Editar(Precio precio);

        [OperationContract]
        List<Precio> BuscarPorTipoServicio(int tipoServicioId);

        [OperationContract]
        Precio BuscarPorId(int id);

        [OperationContract]
        List<Precio> ListarTodos();

        [OperationContract]
        Precio Eliminar(int id);

        [OperationContract]
        void EliminarTodos(int tipoServicioId);
    }
}
