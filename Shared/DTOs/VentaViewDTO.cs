﻿using SharedProject.Models;
using System.ComponentModel.DataAnnotations;

namespace  SharedProject.DTOs
{
    public class VentaViewDTO
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? ComprobanteId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string NumeroComprobante { get; set; }
        public string Timbrado { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoExpedicion { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? TotalCompra { get; set; }
        public bool? Estado { get; set; }

        public Cliente Cliente { get; set; }
        public NumeracionComprobante Comprobante { get; set; }
        public List<DetalleVentaViewDTO> DetallesVenta { get; set; }
    }
}
