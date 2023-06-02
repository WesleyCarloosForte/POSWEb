using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models
{
    public class Documento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        [StringLength(20, ErrorMessage = "La Descripción debe tener como máximo {1} caracteres.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Cantidad de Dígitos es requerido.")]
        [Range(1, short.MaxValue, ErrorMessage = "La Cantidad de Dígitos debe ser un número entre 1 y {2}.")]
        [Display(Name = "Cantidad de Dígitos")]
        public short CantidadDigitos { get; set; }

        public bool? Estado { get; set; }
    }
}
