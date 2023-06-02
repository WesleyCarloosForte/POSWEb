using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SharedProject.Models
{
    public class Rol
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        [StringLength(20, ErrorMessage = "La Descripción debe tener como máximo {1} caracteres.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
