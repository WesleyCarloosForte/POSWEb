﻿using SharedProject.Models;
using System.ComponentModel.DataAnnotations;

namespace  SharedProject.DTOs
{
    public class CompraViewDTO
    {
        public int Id { get; set; }
        public int? ProveedorId { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroComprobante { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? TotalCompra { get; set; }
        public bool? Estado { get; set; }

        public Proveedor Proveedor { get; set; }
        public List<CompraDetalleView> DetalleCompra { get; set; }

    }
}
