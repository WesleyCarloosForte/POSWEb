using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DatosGeneralesId { get; set; }

        [ForeignKey("DatosGeneralesId")]
        public DatosGenerales DatosGenerales { get; set; }
        public List<Compra> Compras { get; set; }
    }
}
