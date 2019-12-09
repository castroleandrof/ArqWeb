using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)] // TODO: Completar *************esto toque GABY
    public class TipoMovimientoService : ITipoMovimientoService
    {
        public TipoMovimiento Agregar(TipoMovimiento tipoMovimiento)
        {
            // TODO: Completar *************esto toque GABY
            var bc = new TipoMovimientoComponent();
            return bc.Agregar(tipoMovimiento);
            throw new NotImplementedException();
        }

        public TipoMovimiento BuscarPorId(int id)
        {
            // TODO: Completar *************esto toque GABY
            var bc = new TipoMovimientoComponent();
            return bc.BuscarPorId(id);
            throw new NotImplementedException();
        }

        public TipoMovimiento Editar(TipoMovimiento tipoMovimiento)
        {
            var bc = new TipoMovimientoComponent();
            return bc.Editar(tipoMovimiento);
        }

        public List<TipoMovimiento> ListarTodos()
        {
            // TODO: Completar *************esto toque GABY
            var bc = new TipoMovimientoComponent();
            return bc.ListarTodos();
            throw new NotImplementedException();
        }

        public TipoMovimiento Eliminar(int id)
        {
            var bc = new TipoMovimientoComponent();
            return bc.Eliminar(id);
        }
    }
}
