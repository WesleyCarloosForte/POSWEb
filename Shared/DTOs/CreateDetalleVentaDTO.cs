namespace  SharedProject.DTOs
{
    public class CreateDetalleVentaDTO
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string CodigoBarras { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        //Es el tanto porciento del precio total del producto ese porcentaje se reprecenta por el totalIVA
        public decimal TotalIVa { get; set; }
        public int IvaPorcent { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalCompra { get; set; }
    }
}
