using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace mvcPet.Entities
{
    public partial class TipoServicio : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }


        [DisplayName("Nombre del Tipo de Servicio")]
        [Required]
        public string Nombre { get; set; }
    }
}
