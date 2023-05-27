﻿using SharedProject.Models;

namespace  SharedProject.DTOs
{
    public class CreateVentaDTO
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? ComprobanteId { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroComprobante { get; set; }
        public string Timbrado { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoExpedicion { get; set; }
        public decimal? TotalCompra { get; set; }
        public bool? Estado { get; set; }

        public List<CreateDetalleVentaDTO> DetallesVenta { get; set; }
    }
}