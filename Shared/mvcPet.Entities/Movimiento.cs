using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public class Movimiento : IEntity
    {
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy H:mm}")]
        public DateTime Fecha { get; set; }

        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        [DisplayName("TipoMovimiento")]
        public int TipoMovimientoId { get; set; }

        [DisplayName("Valor")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C}")]
        [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Valor inválido")]
        public decimal Valor { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
