using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models
{
    public class NumeracionComprobante
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public int? NumeroActual { get; set; }

        public int? NumeroFinal { get; set; }

        public DateTime? InicioVigencia { get; set; }

        public DateTime? FinVigencia { get; set; }

        public bool? ValorFiscal { get; set; }

        [StringLength(200)]
        public string Timbrado { get; set; }

        [StringLength(3)]
        public string Establecimiento { get; set; }

        [StringLength(3)]
        public string PuntoExpedicion { get; set; }

        public bool? Estado { get; set; }
    }
}
