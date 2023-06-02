using System.ComponentModel.DataAnnotations.Schema;

namespace SharedProject.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioVenta { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioCompra { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cantidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Descuento { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalVenta { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCompra { get; set; }

        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
