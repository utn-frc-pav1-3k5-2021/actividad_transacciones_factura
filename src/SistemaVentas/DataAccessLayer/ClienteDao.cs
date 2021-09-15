using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SistemaVentas.Entities;


namespace SistemaVentas.DataAccessLayer
{
    class ClienteDao
    {
        internal bool Create(Cliente oCli)
        {
            throw new NotImplementedException();
        }

        internal bool Update(Cliente oCli)
        {
            throw new NotImplementedException();
        }

        internal bool Eliminar(Cliente oCli)
        {
            throw new NotImplementedException();
        }

        public Cliente GetClienteSinParametros(string nombreCliente)
        {
            //Construimos la consulta sql para buscar el cliente en la base de datos.
            String strSql = "SELECT C.id_cliente, C.cuit, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadoc, T.id_tipoc, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 AND C.nombre_cliente = '" + nombreCliente + "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingCliente(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Cliente> GetAll()
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            //            var strSql = "SELECT id_cliente, nombre_cliente FROM Clientes WHERE borrado = 0";

            var strSql = "SELECT C.id_cliente, C.cuit, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadoc, T.id_tipoc, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            Cliente oCliente = new Cliente();

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                //                listadoClientes.Add(MappingClienteSimple(row));
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }

        public Cliente GetClienteById(int IDCliente)
        {
            var strSql = "SELECT C.id_cliente, C.cuit, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "E.id_estadoc, T.id_tipoc, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.descripcion AS Tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 AND C.id_cliente = " + IDCliente.ToString();

            DataTable fila = DataManager.GetInstance().ConsultaSQL(strSql);
            if (fila.Rows.Count > 0)
                //                return MappingCliente(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);
                return MappingCliente(fila.Rows[0]);
            else
                return null;
        }

        public IList<Cliente> GetClienteByFilters(Dictionary<string, object> parametros)
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            //            var strSql = "SELECT C.id_cliente, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
            //                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, "
            //                                        + "E.id_estadoc, E.descripcion AS estado, "
            //                                        + "T.id_tipoc, T.descripcion AS tipo, C.fecha_registro, C.email "
            //                                    + "FROM Clientes C "
            //                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
            //                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
            //                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
            //                                    + "WHERE C.borrado = 0 ";

            var strSql = "SELECT C.id_cliente, C.cuit, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, B.id_barrio, B.nombre AS barrio, "
                                        + "E.id_estadoc, E.descripcion AS estado, B.ciudad, Ciu.nombre AS nomciu, "
                                        + "T.id_tipoc, T.descripcion AS tipo, C.fecha_registro, C.email "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 ";

            if (parametros.ContainsKey("fechaDesde") && parametros.ContainsKey("fechaHasta"))
                strSql += " AND (fecha_registro>=@fechaDesde AND fecha_registro<=@fechaHasta) ";
            if (parametros.ContainsKey("idBarrio"))
                strSql += " AND (B.id_barrio=@idBarrio) ";
            if (parametros.ContainsKey("estado"))
                strSql += " AND (E.id_estadoC=@estado) ";
            if (parametros.ContainsKey("tipo"))
                strSql += " AND (T.id_tipoC=@tipo) ";
            if (parametros.ContainsKey("id_cliente"))
                strSql += " AND (C.id_cliente=@id_cliente) ";
            if (parametros.ContainsKey("id_ciudad"))
                strSql += " AND (Ciu.id_ciudad=@id_ciudad) ";

            strSql += " ORDER BY C.nombre_cliente";

            var resultadoConsulta = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }

        public IList<Cliente> GetClienteByFiltersCondiciones(String condiciones)
        {
            List<Cliente> listadoClientes = new List<Cliente>();
            String sqlcondiciones = condiciones;

            var strSql = "SELECT C.id_cliente, C.cuit, C.nombre_local, C.nombre_cliente, C.domicilio_calle, "
                                        + "C.domicilio_numero, C.telefono, C.id_barrio, B.nombre AS barrio, E.descripcion AS estado, "
                                        + "T.descripcion AS tipo, C.fecha_registro, C.email, B.ciudad, Ciu.nombre AS nomciu "
                                    + "FROM Clientes C "
                                        + "INNER JOIN Barrios B ON B.id_barrio = C.barrio "
                                        + "INNER JOIN Ciudades Ciu ON B.ciudad = Ciu.id_ciudad "
                                        + "INNER JOIN EstadoCliente E ON E.id_estadoc = C.estado_cliente "
                                        + "INNER JOIN TipoCliente T ON T.id_tipoC = C.tipo_cliente "
                                    + "WHERE C.borrado = 0 ";

            strSql += sqlcondiciones;

            //sin parametros
            strSql += "ORDER BY C.nombre_cliente DESC";


            var resultadoConsulta = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }

        private Cliente MappingCliente(DataRow row)
        {
            Cliente oCliente = new Cliente();
            oCliente.IdCliente = Convert.ToInt32(row["id_cliente"].ToString());
            oCliente.CUIT = row["cuit"].ToString();
            oCliente.NombreLocal = row["nombre_local"].ToString();
            oCliente.NombreCliente = row["nombre_cliente"].ToString();
            oCliente.DomicilioCalle = row["domicilio_calle"].ToString();
            oCliente.DomicilioNumero = Convert.ToInt32(row["domicilio_numero"].ToString());
            oCliente.Telefono = row["telefono"].ToString();
            oCliente.Email = row["email"].ToString();

            //oCliente.Fecha_Registro = Convert.ToDateTime(row["fecha_registro"].ToString());
            //string fecha_nula = "00/00/0000";
            DateTime result = new DateTime(1900, 1, 1, 0, 0, 0);
            if (DateTime.TryParse(row["fecha_registro"].ToString(), out result))
                oCliente.FechaRegistro = result;

            oCliente.Barrio = new Barrio();
            //oCliente.Barrio.ID_Barrio = Convert.ToInt32(row["id_barrio"].ToString());
            int i = 0;
            oCliente.Barrio.ID_Barrio = Int32.TryParse(row["id_barrio"].ToString(), out i) ? i : 0;
            oCliente.Barrio.Nombre = row["barrio"].ToString();

            oCliente.Barrio.Ciudad = new Ciudad();
            //            oCliente.Barrio.Ciudad.ID_Ciudad = Convert.ToInt32(row["ciudad"].ToString());
            oCliente.Barrio.Ciudad.ID_Ciudad = Int32.TryParse(row["ciudad"].ToString(), out i) ? i : 0;
            oCliente.Barrio.Ciudad.Nombre = row["nomciu"].ToString();

            oCliente.TipoCliente = new TipoCliente();
            //oCliente.Tipo_Cliente.ID_TipoC = Convert.ToInt32(row["id_tipoc"].ToString());
            oCliente.TipoCliente.IDTipoCliente = Int32.TryParse(row["id_tipoc"].ToString(), out i) ? i : 0;
            oCliente.TipoCliente.Descripcion = row["tipo"].ToString();

            oCliente.EstadoCliente = new EstadoCliente();
            //oCliente.Estado_Cliente.ID_EstadoC = Convert.ToInt32(row["id_estadoc"].ToString());
            oCliente.EstadoCliente.ID_EstadoC = Int32.TryParse(row["id_estadoc"].ToString(), out i) ? i : 0;
            oCliente.EstadoCliente.Descripcion = row["estado"].ToString();

            return oCliente;
        }
        //        private Cliente MappingClienteSimple(DataRow row)
        //        {
        //            Cliente oCliente = new Cliente();
        //            oCliente.ID_Cliente = Convert.ToInt32(row["id_cliente"].ToString());
        //            oCliente.Nombre_Cliente = row["nombre_cliente"].ToString();
        //
        //            return oCliente;
        //        }
    }
}
