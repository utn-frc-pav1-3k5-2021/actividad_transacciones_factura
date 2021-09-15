using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.DataAccessLayer;
using SistemaVentas.Entities;

namespace SistemaVentas.BusinessLayer
{
    public class FacturaService
    {
        private FacturaDao oFacturaDao;
        public FacturaService()
        {
            oFacturaDao = new FacturaDao();
        }

        internal bool Crear(Factura factura)
        {
            return oFacturaDao.Create(factura);
        }
    }
}
