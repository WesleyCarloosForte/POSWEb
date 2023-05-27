using SharedProject.Models;

namespace  SharedProject.DTOs
{
    public class CompraViewDTO
    {
        public int Id { get; set; }
        public int? ProveedorId { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroComprobante { get; set; }
        public decimal? TotalCompra { get; set; }
        public bool? Estado { get; set; }

        public Proveedor Proveedor { get; set; }
        public List<CompraDetalleView> DetalleCompra { get; set; }

    }
}
