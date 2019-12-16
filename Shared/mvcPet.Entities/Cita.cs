using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public class Cita : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Fecha { get; set; }

        [Required]
        [DisplayName("Hora")]
        public int Hora { get; set; }

        [Required]
        [DisplayName("Médico")]
        public int MedicoId { get; set; }

        [Required]
        [DisplayName("Paciente")]
        public int PacienteId { get; set; }

        [Required]
        [DisplayName("Sala")]
        public int SalaId { get; set; }

        [Required]
        [DisplayName("Tipo Servicio")]
        public int TipoServicioId { get; set; }

        [Required]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [Required]
        [DisplayName("CreatedBy")]
        public string CreatedBy { get; set; }

        [Required]
        [DisplayName("CreatedDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy H:mm}")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("ChangedBy")]
        public string ChangedBy { get; set; }

        [DisplayName("ChangedDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy H:mm}")]
        public DateTime? ChangedDate { get; set; }

        [DisplayName("DeletedBy")]
        public string DeletedBy { get; set; }

        [DisplayName("DeletedDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy H:mm}")]
        public DateTime? DeletedDate { get; set; }

        [DisplayName("Deleted")]
        public bool Deleted { get; set; }


        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public Sala Sala { get; set; }
        public TipoServicio TipoServicio { get; set; }
    }
}
