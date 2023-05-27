using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace  SharedProject.DTOs
{
    public class ProveedorCreateDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroDocumento { get; set; }

        public bool? Estado { get; set; }

        [ForeignKey("Documento")]
        public int? DocumentoId { get; set; }
    }
}
