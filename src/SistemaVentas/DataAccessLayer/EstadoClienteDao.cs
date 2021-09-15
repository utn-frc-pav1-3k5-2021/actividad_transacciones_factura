using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SistemaVentas.Entities;

namespace SistemaVentas.DataAccessLayer
{
    class EstadoClienteDao
    {
        public IList<EstadoCliente> GetAll()
        {
            List<EstadoCliente> listadoEstadoClientes = new List<EstadoCliente>();

            var strSql = "SELECT id_estadoc, descripcion from EstadoCliente where borrado=0";
            
            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoEstadoClientes.Add(MappingEstadoCliente(row));
            }

            return listadoEstadoClientes;
        }

        private EstadoCliente MappingEstadoCliente(DataRow row)
        {
            EstadoCliente oEstadoCliente = new EstadoCliente
            {
                ID_EstadoC = Convert.ToInt32(row["id_estadoc"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };

            return oEstadoCliente;
        }
    }
}
