using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.DataAccessLayer;
using SistemaVentas.Entities;

namespace SistemaVentas.BusinessLayer
{
    class ProductoService
    {
        private ProductoDao oProductoDao;
        public ProductoService()
        {
            oProductoDao = new ProductoDao();
        }
        public IList<Producto> ObtenerTodos()
        {
            return oProductoDao.GetAll();
        }
        public Producto ObtenerProductoPorId(int id)
        {
            return oProductoDao.GetProductoById(id);
        }
    }
}
