using System.ComponentModel.DataAnnotations;

namespace SharedProject.DTOs
{
    public class DetalleCompraCreateDTO
    {
        public int CompraId { get; set; }

        [Required(ErrorMessage = "El campo ProductoId es requerido.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        public string Descipcion { get; set; }

        [Required(ErrorMessage = "El campo Código de Barras es requerido.")]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "El campo Precio de Compra Unitario es requerido.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Precio de Compra Unitario debe ser un valor positivo.")]
        public decimal PrecioCompraUnitario { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es requerido.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Cantidad debe ser un valor positivo.")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Total de Compra es requerido.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Total de Compra debe ser un valor positivo.")]
        public decimal TotalCompra { get; set; }
    }
}
