using System.ComponentModel.DataAnnotations.Schema;

namespace SharedProject.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int DatosGeneralesId { get; set; }
        public int? RolId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [ForeignKey(nameof(RolId))]
        public Rol Rol { get; set; }
        [ForeignKey(nameof(DatosGeneralesId))]
        public DatosGenerales DatosGenerales { get; set; }
    }
}
