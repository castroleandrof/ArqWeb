using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvcPet.Entities;
using mvcPet.Data;

namespace mvcPet.Business
{
    public partial class SalaComponent
    {
        public Sala Agregar(Sala sala)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();
            result = salaDAC.Create(sala);
            return result;
        }
        public Sala Editar(Sala sala)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();
            salaDAC.Update(sala);
            result = sala;
            return result;
        }
        public Sala BuscarPorId(int id)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();
            result = salaDAC.ReadBy(id);
            return result;
        }
        public List<Sala> ListarTodos()
        {
            List<Sala> result = default(List<Sala>);
            var salaDAC = new SalaDAC();
            result = salaDAC.Read();
            return result;

        }

        public Sala Eliminar(int id)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();
            try
            {
                result = salaDAC.ReadBy(id);
                salaDAC.Delete(id);
                return result;
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
    }
}
