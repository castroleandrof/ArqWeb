using mvcPet.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Business
{
    public partial class CitaComponent
    {
        public Cita Agregar(Cita cita)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();
            result = citaDAC.Create(cita);
            return result;
        }
        public Cita Editar(Cita cita)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();
            citaDAC.Update(cita);
            result = cita;
            return result;
        }

        public Cita Eliminar(int id)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();
            result = citaDAC.ReadBy(id);
            citaDAC.Delete(id);
            return result;
        }

        public Cita BuscarPorId(int id)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();
            result = citaDAC.ReadBy(id);
            return result;
        }

        public bool ExisteCita(Cita model)
        {
            var citaDAC = new CitaDAC();
            bool result = citaDAC.ExisteCita(model);
            return result;
        }

        public List<Cita> ListarTodos(int pacienteId)
        {
            List<Cita> result = default(List<Cita>);
            var citaDAC = new CitaDAC();
            result = citaDAC.ReadByPacienteId(pacienteId);
            return result;
        }

        public List<Cita> ListarTodos()
        {
            var citaDAC = new CitaDAC();
            var result = citaDAC.Read();
            return result;
        }
    }
}
