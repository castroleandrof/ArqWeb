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
    public interface ICitaService
    {
        [OperationContract]
        Cita Agregar(Cita cita);

        [OperationContract]
        Cita Editar(Cita cita);

        [OperationContract]
        Cita BuscarPorId(int id);

        [OperationContract]
        List<Cita> ListarTodos(int pacienteId);
        
        [OperationContract]
        List<Cita> ListarTodos();

        [OperationContract]
        Cita Eliminar(int id);

        [OperationContract]
        bool ExisteCita(Cita model);
    }
}
