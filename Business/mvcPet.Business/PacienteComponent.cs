using mvcPet.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Business
{
    public partial class PacienteComponent
    {
        public Paciente Agregar(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.Create(paciente);
            return result;
        }
        public Paciente Editar(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();
            pacienteDAC.Update(paciente);
            result = paciente;
            return result;
        }

        public Paciente Eliminar(int id)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.ReadBy(id);
            pacienteDAC.Delete(id);
            return result;
        }

        public Paciente BuscarPorId(int id)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.ReadBy(id);
            return result;
        }
        public List<Paciente> ListarTodos()
        {
            List<Paciente> result = default(List<Paciente>);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.Read();
            return result;
        }

        public List<Paciente> ListarTodos(int clienteId)
        {
            List<Paciente> result = default(List<Paciente>);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.ReadByClienteId(clienteId);
            return result;
        }
    }
}
