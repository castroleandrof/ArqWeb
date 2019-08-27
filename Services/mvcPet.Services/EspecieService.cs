using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EspecieService : IEspecieService
    {        
        public Especie Agregar(Especie especie)
        {
            var bc = new EspecieComponent();
            return bc.Agregar(especie);
        }
        
        public List<Especie> ListarTodos()
        {
            var bc = new EspecieComponent();
            return bc.ListarTodos();
        }

        public void Edit(Especie especie)
        {
            var bc = new EspecieComponent();
            bc.Edit(especie);
        }

        public void Delete(int Id)
        {
            var bc = new EspecieComponent();
            bc.Delete(Id);
        }

        public Especie Details(int Id) {
            var bc = new EspecieComponent();
            return bc.Details(Id);
        }
    }
}
