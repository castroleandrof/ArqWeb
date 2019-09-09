using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
   public class Precio : IEntity
    {

        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("fecha_desde")]
        [Required]
        public DateTime Fecha_desde { get; set; }

        [DisplayName("fecha_hasta")]
        [Required]
        public  DateTime Fecha_hasta { get; set; }

        [DisplayName("valor")]
        [Required]
        public  Decimal valor { get; set; }
    }
}
