using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.Entities;
using SistemaVentas.DataAccessLayer;

namespace SistemaVentas.BusinessLayer
{
    public class TipoClienteService
    {
        private TipoClienteDao oTipoClienteDao;
        public TipoClienteService()
        {
            oTipoClienteDao = new TipoClienteDao();
        }
        public IList<TipoCliente> ObtenerTodos()
        {
            return oTipoClienteDao.GetAll();
        }

    }
}
