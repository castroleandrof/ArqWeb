using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public partial class TipoMovimiento : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }


        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Multiplicador")]
        public Int16 Multiplicador { get; set; }
    }
}
