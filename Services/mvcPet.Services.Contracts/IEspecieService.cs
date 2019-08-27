using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Entities;

namespace mvcPet.Services.Contracts
{    
    [ServiceContract]
    public interface IEspecieService
    {
        [OperationContract]
        Especie Agregar(Especie especie);

        [OperationContract]
        List<Especie> ListarTodos();

        [OperationContract]
        void Edit(Especie especie);

        [OperationContract]
        void Delete(int Id);

        [OperationContract]
        Especie Details(int Id);
    }
}
