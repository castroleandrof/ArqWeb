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
    public interface IPacienteService
    {
        [OperationContract]
        Paciente Agregar(Paciente paciente);

        [OperationContract]
        Paciente Editar(Paciente paciente);

        [OperationContract]
        Paciente BuscarPorId(int id);

        [OperationContract]
        List<Paciente> ListarTodos();

        [OperationContract]
        Paciente Eliminar(int id);

        [OperationContract]
        List<Paciente> ListarTodos(int clienteId);
    }
}
