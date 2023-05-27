namespace  SharedProject.DTOs
{
    public class ProductoViewDTO
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string CodigoBarras { get; set; }
        public decimal StockActual { get; set; }
        public decimal? StockMinimo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Categoria { get; set; }
    }
}
