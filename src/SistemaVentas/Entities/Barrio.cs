using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Entities
{
    public class Barrio
    {
        public int ID_Barrio { get; set; }

        public string Nombre { get; set; }

        public Ciudad Ciudad { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
