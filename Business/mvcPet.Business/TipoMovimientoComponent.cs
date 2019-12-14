using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvcPet.Entities;
using mvcPet.Data;

namespace mvcPet.Business
{
    public partial class TipoMovimientoComponent
    {
        public TipoMovimiento Agregar(TipoMovimiento tipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            result = tipoMovimientoDAC.Create(tipoMovimiento);
            return result;
        }
        public TipoMovimiento Editar(TipoMovimiento tipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            tipoMovimientoDAC.Update(tipoMovimiento);
            result = tipoMovimiento;
            return result;
        }
        public TipoMovimiento BuscarPorId(int id)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            result = tipoMovimientoDAC.ReadBy(id);
            return result;
        }
        public List<TipoMovimiento> ListarTodos()
        {
            List<TipoMovimiento> result = default(List<TipoMovimiento>);
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            result = tipoMovimientoDAC.Read();
            return result;

        }

        public TipoMovimiento Eliminar(int id)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            result = tipoMovimientoDAC.ReadBy(id);
            tipoMovimientoDAC.Delete(id);
            return result;
        }
    }
}
