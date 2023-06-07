using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SharedProject.DTOs
{
    public class ProveedorCreateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(200, ErrorMessage = "El campo Nombre debe tener como máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Dirección es requerido.")]
        [StringLength(200, ErrorMessage = "El campo Dirección debe tener como máximo {1} caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        [StringLength(50, ErrorMessage = "El campo Teléfono debe tener como máximo {1} caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido.")]
        [StringLength(100, ErrorMessage = "El campo Email debe tener como máximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Número de Documento es requerido.")]
        [StringLength(50, ErrorMessage = "El campo Número de Documento debe tener como máximo {1} caracteres.")]
        public string NumeroDocumento { get; set; }

        public bool? Estado { get; set; }

        [ForeignKey("Documento")]
        public int? DocumentoId { get; set; }
    }
}
