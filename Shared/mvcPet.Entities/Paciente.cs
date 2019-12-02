using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public class Paciente : IEntity
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Cliente")]
        [Required]
        public int ClienteId { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Especie")]
        [Required]
        public int EspecieId { get; set; }

        [DisplayName("Observacion")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }


        public Cliente Cliente { get; set; }

        public Especie Especie { get; set; }

    }
}
