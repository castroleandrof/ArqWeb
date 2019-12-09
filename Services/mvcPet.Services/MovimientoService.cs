using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MovimientoService : IMovimientoService
    {
        public Movimiento Agregar(Movimiento movimiento)
        {
            var bc = new MovimientoComponent();
            return bc.Agregar(movimiento);
        }

        public Movimiento BuscarPorId(int id)
        {
            var bc = new MovimientoComponent();
            return bc.BuscarPorId(id);
        }

        public Movimiento Editar(Movimiento movimiento)
        {
            var bc = new MovimientoComponent();
            return bc.Editar(movimiento);
        }

        public Movimiento Eliminar(int id)
        {
            var bc = new MovimientoComponent();
            return bc.Eliminar(id);
        }

        public List<Movimiento> ListarTodos()
        {
            var bc = new MovimientoComponent();
            return bc.ListarTodos();
        }

        public List<Movimiento> ListarTodos(int clienteId)
        {
            var bc = new MovimientoComponent();
            return bc.ListarTodos(clienteId);
        }
    }
}
