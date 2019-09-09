using System.Collections.Generic;
using mvcPet.Entities;
using mvcPet.Data;

namespace mvcPet.Business
{
    public partial class TipoServicioComponent
    {
        public TipoServicio Agregar(TipoServicio tipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            var tipoServicioDAC = new TipoServicioDAC();
            result = tipoServicioDAC.Create(tipoServicio);
            return result;
        }
        public List<TipoServicio> ListarTodos()
        {
            List<TipoServicio> result = default(List<TipoServicio>);
            var tipoServicioDAC = new TipoServicioDAC();
            result = tipoServicioDAC.Read();
            return result;

        }

        public void Edit(TipoServicio tipoServicio)
        {
            var especieDAC = new TipoServicioDAC();
            especieDAC.Update(tipoServicio);
        }

        public void Delete(int Id)
        {
            var especieDAC = new TipoServicioDAC();
            especieDAC.Delete(Id);
        }

        public TipoServicio Details(int Id)
        {
            TipoServicio result = default(TipoServicio);
            var tipoServicioDAC = new TipoServicioDAC();
            result = tipoServicioDAC.ReadBy(Id);
            return result;

        }
    }
}
