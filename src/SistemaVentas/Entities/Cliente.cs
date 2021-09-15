using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string CUIT { get; set; }

        public string NombreLocal { get; set; }

        public string NombreCliente { get; set; }

        public string DomicilioCalle { get; set; }

        public int DomicilioNumero { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; }

        public Barrio Barrio { get; set; }

        public EstadoCliente EstadoCliente { get; set; }

        public TipoCliente TipoCliente { get; set; }

        public override string ToString()
        {
            return NombreCliente;
        }
    }
}
