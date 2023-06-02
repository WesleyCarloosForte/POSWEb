using System.ComponentModel.DataAnnotations;

namespace  SharedProject.DTOs
{
    public class CompraDetalleView
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public string CodigoBarras { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal PrecioCompraUnitario { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Cantidad { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TotalCompra { get; set; }
        public string Producto { get; set; }

    }
}
