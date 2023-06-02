using System.ComponentModel.DataAnnotations.Schema;

namespace SharedProject.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string CodigoBarras { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal StockActual { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? StockMinimo { get; set; }
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioCompra { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioVenta { get; set; }

        public Categoria Categoria { get; set; }
    }
}
