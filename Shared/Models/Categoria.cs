using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage =$"El campo{nameof(Descripcion)} es obligatorio")]
        [StringLength(100,ErrorMessage = $"El campo{nameof(Descripcion)} debe tener un tamaño maximo de 100 caracteres")]
        [MinLength(3, ErrorMessage = $"El campo{nameof(Descripcion)} debe tener un tamaño minimo de 3 caracteres")]
        public string Descripcion { get; set; }
    }
}
