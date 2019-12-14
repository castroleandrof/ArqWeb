using mvcPet.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Business
{
    public partial class MovimientoComponent
    {
        public Movimiento Agregar(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.Create(movimiento);
            return result;
        }
        public Movimiento Editar(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();
            movimientoDAC.Update(movimiento);
            result = movimiento;
            return result;
        }

        public Movimiento Eliminar(int id)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.ReadBy(id);
            movimientoDAC.Delete(id);
            return result;
        }

        public Movimiento BuscarPorId(int id)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.ReadBy(id);
            return result;
        }
        public List<Movimiento> ListarTodos()
        {
            List<Movimiento> result = default(List<Movimiento>);
            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.Read();
            return result;
        }

        public List<Movimiento> ListarTodos(int clienteId)
        {
            List<Movimiento> result = default(List<Movimiento>);
            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.ReadByClienteId(clienteId);
            return result;
        }
    }
}
