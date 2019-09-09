using System.Collections.Generic;
using mvcPet.Entities;
using mvcPet.Data;


namespace mvcPet.Business
{
    public partial class EspecieComponent
    {        
        public Especie Agregar(Especie especie)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();
            result = especieDAC.Create(especie);
            return result;
        }
        public List<Especie> ListarTodos()
        {
            List<Especie> result = default(List<Especie>);
            var especieDAC = new EspecieDAC();
            result = especieDAC.Read();
            return result;

        }

        public void Edit(Especie especie)
        {
            var especieDAC = new EspecieDAC();
            especieDAC.Update(especie);
        }

        public void Delete(int Id)
        {
            var especieDAC = new EspecieDAC();
            especieDAC.Delete(Id);
        }

        public Especie Details(int Id)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();
            result = especieDAC.ReadBy(Id);
            return result;

        }
    }
}
