using System.ComponentModel.DataAnnotations;

namespace  SharedProject.DTOs
{
    public class DetalleCompraCreateDTO
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public string CodigoBarras { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal PrecioCompraUnitario { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Cantidad { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TotalCompra { get; set; }
    }
}
