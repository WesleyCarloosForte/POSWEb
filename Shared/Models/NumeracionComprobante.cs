using SharedProject.Validaciones.Comprobante;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SharedProject.Models
{
    public class NumeracionComprobante
    {
        public NumeracionComprobante()
        {
            NumeroActual = 1;
            NumeroFinal = int.MaxValue;
            Timbrado = "000000";
            Establecimiento = "000";
            PuntoExpedicion = "000";
            ValorFiscal = false;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es requerido.")]
        [StringLength(50, ErrorMessage = "La Descripcion debe tener como máximo {1} caracteres.")]
        public string Descripcion { get; set; }
        [DefaultValue(1)]
        public int? NumeroActual { get; set; }
        [DefaultValue(int.MaxValue)]
        public int? NumeroFinal { get; set; }

        [Display(Name = "Inicio de Vigencia")]
        [DataType(DataType.Date)]
        [FechaInicialValorFiscal(ErrorMessage = "La fecha de inicio de vigencia debe ser igual o anterior a la fecha actual.")]
        public DateTime? InicioVigencia { get; set; }

        [Display(Name = "Fin de Vigencia")]
        [DataType(DataType.Date)]
        [FechaFinalValorFiscal(ErrorMessage = "La fecha de fin de vigencia debe ser igual o posterior a la fecha actual.")]
        public DateTime? FinVigencia { get; set; }

        [Display(Name = "Valor Fiscal")]
        public bool ValorFiscal { get; set; }

        [StringLength(200, ErrorMessage = "El Timbrado debe tener como máximo {1} caracteres.")]
        [DefaultValue("000")]
        public string Timbrado { get; set; }
        [DefaultValue("000")]
        [StringLength(3, ErrorMessage = "El Establecimiento debe tener como máximo {1} caracteres.")]
        public string Establecimiento { get; set; }

        [StringLength(3, ErrorMessage = "El Punto de Expedición debe tener como máximo {1} caracteres.")]
        [DefaultValue("000")]
        public string PuntoExpedicion { get; set; }

        public bool? Estado { get; set; }
    }

 

  
}
