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
    public interface IMovimientoService
    {
        [OperationContract]
        Movimiento Agregar(Movimiento movimiento);

        [OperationContract]
        Movimiento Editar(Movimiento movimiento);

        [OperationContract]
        Movimiento BuscarPorId(int id);

        [OperationContract]
        List<Movimiento> ListarTodos();

        [OperationContract]
        Movimiento Eliminar(int id);
        
        [OperationContract]
        List<Movimiento> ListarTodos(int clienteId);
    }
}
