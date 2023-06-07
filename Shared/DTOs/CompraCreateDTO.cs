using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedProject.DTOs
{
    public class CompraCreateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Proveedor es requerido.")]
        public int? ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo Fecha es requerido.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Número de Comprobante es requerido.")]
        [StringLength(50, ErrorMessage = "El campo Número de Comprobante debe tener como máximo {1} caracteres.")]
        public string NumeroComprobante { get; set; }

        [Required(ErrorMessage = "El campo Total de Compra es requerido.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Total de Compra debe ser un valor positivo.")]
        public decimal? TotalCompra { get; set; }

        public bool? Estado { get; set; }

        [Required(ErrorMessage = "Debe agregar al menos un detalle de compra.")]
        public List<DetalleCompraCreateDTO> DetallesCompra { get; set; }
    }
}
