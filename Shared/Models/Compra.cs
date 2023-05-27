namespace SharedProject.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int? ProveedorId { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroComprobante { get; set; }
        public decimal? TotalCompra { get; set; }
        public bool? Estado { get; set; }

        public Proveedor Proveedor { get; set; }
        public List<DetalleCompra> DetallesCompra { get; set; }
    }
}
