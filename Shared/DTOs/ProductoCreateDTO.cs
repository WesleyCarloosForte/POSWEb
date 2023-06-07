using System.ComponentModel.DataAnnotations;

namespace  SharedProject.DTOs
{
    public class ProductoCreateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Categoría es requerido.")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo Código de Barras es requerido.")]
        [StringLength(50, ErrorMessage = "El campo Código de Barras debe tener como máximo {1} caracteres.")]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "El campo Stock Actual es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Stock Actual debe ser un valor positivo.")]
        public decimal StockActual { get; set; }

        [Required(ErrorMessage = "El campo Stock Mínimo es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Stock Mínimo debe ser un valor positivo.")]
        public decimal? StockMinimo { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        [StringLength(200, ErrorMessage = "El campo Descripción debe tener como máximo {1} caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Precio de Compra es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Precio de Compra debe ser un valor positivo.")]
        public decimal PrecioCompra { get; set; }

        [Required(ErrorMessage = "El campo Precio de Venta es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Precio de Venta debe ser un valor positivo.")]
        public decimal PrecioVenta { get; set; }

    }
}


