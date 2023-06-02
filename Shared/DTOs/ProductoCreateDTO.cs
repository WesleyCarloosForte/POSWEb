using System.ComponentModel.DataAnnotations;

namespace  SharedProject.DTOs
{
    public class ProductoCreateDTO
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string CodigoBarras { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal StockActual { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? StockMinimo { get; set; }
        public string Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal PrecioCompra { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal PrecioVenta { get; set; }

    }
}
