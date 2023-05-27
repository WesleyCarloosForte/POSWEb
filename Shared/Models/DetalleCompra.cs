namespace SharedProject.Models
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        public decimal PrecioCompraUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal TotalCompra { get; set; }

        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
    }
}
