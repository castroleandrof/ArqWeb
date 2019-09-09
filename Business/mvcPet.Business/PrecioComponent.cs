using mvcPet.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Business
    {
        public partial class PrecioComponent
        {
            public Precio Agregar(Precio tipoServicio)
            {
                Precio result = default(Precio);
                var precioDAC = new PrecioDAC();
                result = precioDAC.Create(tipoServicio);
                return result;
            }
            public List<Precio> ListarTodos()
            {
                List<Precio> result = default(List<Precio>);
                var precioDAC = new PrecioDAC();
                result = precioDAC.Read();
                return result;

            }

            public void Edit(Precio precio)
            {
                var especieDAC = new PrecioDAC();
                especieDAC.Update(precio);
            }

            public void Delete(int Id)
            {
                var precioDAC = new PrecioDAC();
                precioDAC.Delete(Id);
            }

            public Precio Details(int Id)
            {
                Precio result = default(Precio);
                var precioDAC = new PrecioDAC();
                result = precioDAC.ReadBy(Id);
                return result;

            }
        }
    }

