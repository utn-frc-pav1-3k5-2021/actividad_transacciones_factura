using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.Entities;
using SistemaVentas.DataAccessLayer;


namespace SistemaVentas.BusinessLayer
{
    public class BarrioService
    {
        private BarrioDao oBarrioDao;
        public BarrioService()
        {
            oBarrioDao = new BarrioDao();
        }
        public IList<Barrio> ObtenerTodos(string idciu)
        {
            return oBarrioDao.GetAll(idciu);
        }

    }
}
