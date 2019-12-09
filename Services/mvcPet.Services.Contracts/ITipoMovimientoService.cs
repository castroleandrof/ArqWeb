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
    public interface ITipoMovimientoService
    {
        [OperationContract]
        TipoMovimiento Agregar(TipoMovimiento tipoMovimiento);

        [OperationContract]
        TipoMovimiento Editar(TipoMovimiento tipoMovimiento);

        [OperationContract]
        TipoMovimiento BuscarPorId(int id);

        [OperationContract]
        List<TipoMovimiento> ListarTodos();

        [OperationContract]
        TipoMovimiento Eliminar(int id);
    }
}
