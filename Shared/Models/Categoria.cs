using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
