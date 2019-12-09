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
    public class CitaService : ICitaService
    {
        public Cita Agregar(Cita cita)
        {
            var bc = new CitaComponent();
            return bc.Agregar(cita);
        }

        public Cita BuscarPorId(int id)
        {
            var bc = new CitaComponent();
            return bc.BuscarPorId(id);
        }

        public Cita Editar(Cita cita)
        {
            var bc = new CitaComponent();
            return bc.Editar(cita);
        }

        public Cita Eliminar(int id)
        {
            var bc = new CitaComponent();
            return bc.Eliminar(id);
        }

        public bool ExisteCita(Cita model)
        {
            var bc = new CitaComponent();
            return bc.ExisteCita(model);
        }

        public List<Cita> ListarTodos(int pacienteId)
        {
            var bc = new CitaComponent();
            return bc.ListarTodos(pacienteId);
        }

        public List<Cita> ListarTodos()
        {
            var bc = new CitaComponent();
            return bc.ListarTodos();
        }
    }
}
