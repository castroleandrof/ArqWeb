using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace mvcPet.Entities
{
    public partial class Especie : IEntity
    {
        
        [DisplayName("Id")]
        public int Id { get; set; }

        
        [DisplayName("Nombre de la especie")]
        [Required]
        public string Nombre { get; set; }
    }
}
