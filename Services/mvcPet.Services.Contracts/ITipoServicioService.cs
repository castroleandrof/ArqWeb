using System.Collections.Generic;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface ITipoServicioService
    {
        [OperationContract]
        TipoServicio Agregar(TipoServicio tipoServicio);

        [OperationContract]
        List<TipoServicio> ListarTodos();

        [OperationContract]
        void Edit(TipoServicio tipoServicio);

        [OperationContract]
        void Delete(int Id);

        [OperationContract]
        TipoServicio BuscarPorId(int Id);
    }
}
