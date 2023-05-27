namespace  SharedProject.DTOs
{
    public class DetalleVentaViewDTO
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string CodigoBarras { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalCompra { get; set; }
        public string Producto { get; set; }
    }
}
