using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public class Cliente : IEntity
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Apellido")]
        [Required]
        public string Apellido { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [DisplayName("Url")]
        [Url]
        public string Url { get; set; }

        [Required]
        [DisplayName("FechaNacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [DisplayName("Domicilio")]
        public string Domicilio { get; set; }

    }
}
