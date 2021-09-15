using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Entities
{
    public class FacturaDetalle
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int NroItem { get; set; }
        public Producto Producto { get; set; }
        public Double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public int IdProducto
        {
            get
            {
                return Producto.IdProducto;
            }
        }
        public string ProductoDescripcion
        {
            get
            {
                return Producto.Nombre;
            }
        }

        public Double Importe
        {
            get
            {
                return Cantidad * PrecioUnitario;
            }
        }
    }
}
