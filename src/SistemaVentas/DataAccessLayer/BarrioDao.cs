using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SistemaVentas.Entities;

namespace SistemaVentas.DataAccessLayer
{
    public class BarrioDao
    {
        public IList<Barrio> GetAll(string idciu)
        {
            List<Barrio> listadoBarrios = new List<Barrio>();

            var strSql = "SELECT id_barrio, nombre FROM Barrios WHERE borrado = 0 ";
            if (!string.IsNullOrEmpty(idciu))
                strSql += " AND ciudad = " + idciu;

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBarrios.Add(MappingBarrio(row));
            }

            return listadoBarrios;
        }

        private Barrio MappingBarrio(DataRow row)
        {
            Barrio oBarrio = new Barrio
            {
                ID_Barrio = Convert.ToInt32(row["id_barrio"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oBarrio;
        }
    }
}
