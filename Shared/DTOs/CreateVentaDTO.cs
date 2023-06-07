using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedProject.DTOs
{
    public class CreateVentaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cliente es requerido.")]
        public int? ClienteId { get; set; }

        [Required(ErrorMessage = "El campo Comprobante es requerido.")]
        public int? ComprobanteId { get; set; }

        [Required(ErrorMessage = "El campo Fecha es requerido.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Inicio es requerido.")]
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }


        public string NumeroComprobante { get; set; }

        public string Timbrado { get; set; }

        public string Establecimiento { get; set; }

        public string PuntoExpedicion { get; set; }

        public decimal? TotalCompra { get; set; }

        public bool? Estado { get; set; }

        public List<CreateDetalleVentaDTO> DetallesVenta { get; set; }
    }
}
