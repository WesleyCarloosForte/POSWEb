using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Models
{
    public class KardexProducto
    {
        public int Id { get; set; }
        public string Descripcioin { get; set; }
        public string Tipo { get; set; }
        public int ProductoId { get; set;}
        public int stockAnterior { get; set; }
        public int stockActual { get; set; }
        public decimal Valor { get; set; }
        public decimal GananciaUnitaria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal GananciaEsperada { get; set; }
        public string TipoComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public int CantidadMovimiento { get; set; }
        public DateTime? Fecha { get; set;}
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }
        
    }
}
