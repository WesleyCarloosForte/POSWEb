using System.ComponentModel.DataAnnotations;

namespace SharedProject.DTOs
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

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Descuento { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TotalIVa { get; set; }
        public int IvaPorcent { get; set; }


        public decimal TotalVenta { get; set; }


        public decimal TotalCompra { get; set; }
    }
}
