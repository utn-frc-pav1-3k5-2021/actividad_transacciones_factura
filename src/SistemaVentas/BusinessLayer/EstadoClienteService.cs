using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.Entities;
using SistemaVentas.DataAccessLayer;

namespace SistemaVentas.BusinessLayer
{
    public class EstadoClienteService
    {
        private EstadoClienteDao oEstadoClienteDao;
        public EstadoClienteService()
        {
            oEstadoClienteDao = new EstadoClienteDao();
        }
        public IList<EstadoCliente> ObtenerTodos()
        {
            return oEstadoClienteDao.GetAll();
        }

    }
}
