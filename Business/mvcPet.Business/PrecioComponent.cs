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

        public List<Precio> BuscarPorTipoServicio(int tipoServicioId)
        {
            List<Precio> result = default(List<Precio>);
            var precioDAC = new PrecioDAC();
            result = precioDAC.ReadByTipoServicioId(tipoServicioId);
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

           public Precio Editar(Precio precio)
        {
            Precio result = default(Precio);
            var precioDAC = new PrecioDAC();
            precioDAC.Update(precio);
            result = precio;
            return result;
        }

        public Precio Eliminar (int Id)
            
            {
                Precio result = default(Precio);
                var precioDAC = new PrecioDAC();
                result = precioDAC.ReadBy(Id);
                precioDAC.Delete(Id);
                return result;
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

