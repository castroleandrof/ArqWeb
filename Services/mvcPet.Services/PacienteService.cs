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
    public class PacienteService : IPacienteService
    {
        public Paciente Agregar(Paciente paciente)
        {
            var bc = new PacienteComponent();
            return bc.Agregar(paciente);
        }

        public Paciente BuscarPorId(int id)
        {
            var bc = new PacienteComponent();
            return bc.BuscarPorId(id);
        }

        public Paciente Editar(Paciente paciente)
        {
            var bc = new PacienteComponent();
            return bc.Editar(paciente);
        }

        public Paciente Eliminar(int id)
        {
            var bc = new PacienteComponent();
            return bc.Eliminar(id);
        }

        public List<Paciente> ListarTodos()
        {
            var bc = new PacienteComponent();
            return bc.ListarTodos();
        }

        public List<Paciente> ListarTodos(int clienteId)
        {
            var bc = new PacienteComponent();
            return bc.ListarTodos(clienteId);
        }
    }
}
