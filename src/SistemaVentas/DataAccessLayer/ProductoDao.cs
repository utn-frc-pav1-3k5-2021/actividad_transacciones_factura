using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SistemaVentas.Entities;

namespace SistemaVentas.DataAccessLayer
{
    class ProductoDao
    {
        public IList<Producto> GetAll()
        {
            List<Producto> listadoProductos = new List<Producto>();

            var strSql = "SELECT id_producto, nombre, precio, stock FROM Productos WHERE borrado = 0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProductos.Add(MappingProducto(row));
            }

            return listadoProductos;
        }

        public Producto GetProductoById(int IDProd)
        {
            var strSql = "SELECT id_producto, nombre, precio, stock FROM Productos "
                        + "WHERE borrado = 0 AND id_producto = " + IDProd.ToString();

            DataTable fila = DataManager.GetInstance().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                return MappingProducto(fila.Rows[0]);
            else
                return null;
        }
        
        private Producto MappingProducto(DataRow row)
        {
            Producto oProducto = new Producto
            {
                IdProducto = Convert.ToInt32(row["id_producto"].ToString()),
                Nombre = row["nombre"].ToString(),
                Precio = Convert.ToDouble(row["precio"].ToString()),
                Stock = Convert.ToInt32(row["stock"].ToString())
            };

            return oProducto;
        }
    }
}
