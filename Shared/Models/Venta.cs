namespace SharedProject.Models
{
    public class Venta
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

        public Cliente Cliente { get; set; }
        public NumeracionComprobante Comprobante { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }
    }
}
