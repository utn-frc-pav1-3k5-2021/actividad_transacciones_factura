using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SistemaVentas.Entities;

namespace SistemaVentas.DataAccessLayer
{
    class TipoClienteDao
    {
        public IList<TipoCliente> GetAll()
        {
            List<TipoCliente> listadoTipoClientes = new List<TipoCliente>();

            var strSql = "SELECT id_tipoc, descripcion from TipoCliente where borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoTipoClientes.Add(MappingTipoCliente(row));
            }

            return listadoTipoClientes;
        }

        private TipoCliente MappingTipoCliente(DataRow row)
        {
            TipoCliente oTipoCliente = new TipoCliente
            {
                IDTipoCliente = Convert.ToInt32(row["id_tipoc"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };

            return oTipoCliente;
        }
    }
}
