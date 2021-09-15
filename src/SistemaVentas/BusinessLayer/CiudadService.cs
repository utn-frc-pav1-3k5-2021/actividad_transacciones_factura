using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.Entities;
using SistemaVentas.DataAccessLayer;

namespace SistemaVentas.BusinessLayer
{
    public class CiudadService
    {
        private CiudadDao oCiudadDao;
        public CiudadService()
        {
            oCiudadDao = new CiudadDao();
        }
        public IList<Ciudad> ObtenerTodos()
        {
            return oCiudadDao.GetAll();
        }

    }
}
