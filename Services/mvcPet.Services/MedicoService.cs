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
    public class MedicoService : IMedicoService
    {
        public Medico Agregar(Medico medico)
        {
            var bc = new MedicoComponent();
            return bc.Agregar(medico);
        }

        public Medico BuscarPorId(int id)
        {
            var bc = new MedicoComponent();
            return bc.BuscarPorId(id);
        }

        public Medico Editar(Medico medico)
        {
            var bc = new MedicoComponent();
            return bc.Editar(medico);
        }

        public Medico Eliminar(int id)
        {
            var bc = new MedicoComponent();
            return bc.Eliminar(id);
        }

        public List<Medico> ListarTodos()
        {
            var bc = new MedicoComponent();
            return bc.ListarTodos();
        }
    }
}
