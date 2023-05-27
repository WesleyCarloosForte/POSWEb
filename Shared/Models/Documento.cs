using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models
{
    public class Documento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Descripcion { get; set; }

        [Required]
        public short CantidadDigitos { get; set; }

        public bool? Estado { get; set; }
    }    
}

