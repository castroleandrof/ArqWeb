using System.Collections.Generic;
using System.ServiceModel;
using mvcPet.Entities;


namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface IPrecioService
    {
        [OperationContract]
        Precio Agregar(Precio precioServicio);

        [OperationContract]
        List<Precio> ListarTodos();

        [OperationContract]
        void Edit(Precio precioServicio);

        [OperationContract]
        void Delete(int Id);

        [OperationContract]
        Precio Details(int Id);
    }
}
