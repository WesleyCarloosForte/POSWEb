using SharedProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace  SharedProject.DTOs
{
    public class UsuarioCreateDTO
    {
        [Key]
        [DefaultValue(0)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Dirección es requerido.")]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Número de documento es requerido.")]
        [StringLength(50)]
        [Display(Name = "Número de documento")]
        public string NumeroDocumento { get; set; }

        public bool? Estado { get; set; }

        [ForeignKey("DocumentoId")]
        [Display(Name = "Tipo de documento")]
        [DefaultValue(1)]
        public int? DocumentoId { get; set; }

        [ForeignKey("RolId")]
        [Display(Name = "Rol")]
        [DefaultValue(2)]
        public int? RolId { get; set; }

        [Required(ErrorMessage = "El campo Login es requerido.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "El campo Password es requerido.")]
        public string Password { get; set; }
    }
}
