namespace  SharedProject.DTOs
{
    public class DetalleCompraCreateDTO
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public string CodigoBarras { get; set; }
        public decimal PrecioCompraUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal TotalCompra { get; set; }
    }
}
