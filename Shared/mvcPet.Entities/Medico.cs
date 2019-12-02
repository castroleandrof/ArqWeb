using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public class Medico : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Tipo de Matrícula")]
        public TipoMatricula TipoMatricula { get; set; }

        [DisplayName("Número de Matrícula")]
        public int NumeroMatricula { get; set; }

        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Especialidad")]
        public string Especialidad { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Debe ser un email válido")]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
    }
}
