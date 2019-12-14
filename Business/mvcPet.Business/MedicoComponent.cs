using mvcPet.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Business
{
    public partial class MedicoComponent
    {
        public Medico Agregar(Medico medico)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();
            result = medicoDAC.Create(medico);
            return result;
        }
        public Medico Editar(Medico medico)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();
            medicoDAC.Update(medico);
            result = medico;
            return result;
        }
        public Medico BuscarPorId(int id)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();
            result = medicoDAC.ReadBy(id);
            return result;
        }
        public List<Medico> ListarTodos()
        {
            List<Medico> result = default(List<Medico>);
            var medicoDAC = new MedicoDAC();
            result = medicoDAC.Read();
            return result;

        }

        public Medico Eliminar(int id)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();
            result = medicoDAC.ReadBy(id);
            medicoDAC.Delete(id);
            return result;
        }
    }
}
