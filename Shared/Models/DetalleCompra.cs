using System.ComponentModel.DataAnnotations.Schema;

namespace SharedProject.Models
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioCompraUnitario { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cantidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCompra { get; set; }

        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
    }
}
