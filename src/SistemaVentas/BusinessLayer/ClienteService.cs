using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.Entities;
using SistemaVentas.DataAccessLayer;

namespace SistemaVentas.BusinessLayer
{
    public class ClienteService
    {
        private ClienteDao oClienteDao;
        public ClienteService()
        {
            oClienteDao = new ClienteDao();
        }

        public IList<Cliente> ConsultarClientesConFiltrosCondiciones(String condiciones)
        {
            return oClienteDao.GetClienteByFiltersCondiciones(condiciones);
        }

        public IList<Cliente> ConsultarClientesConFiltros(Dictionary<string, object> parametros)
        {
            return oClienteDao.GetClienteByFilters(parametros);
        }

        public Cliente ConsultarClientesPorId(int id)
        {
            return oClienteDao.GetClienteById(id);
        }
        public IList<Cliente> ObtenerTodos()
        {
            return oClienteDao.GetAll();
        }
        internal bool CrearCliente(Cliente oUsuario)
        {
            return oClienteDao.Create(oUsuario);
        }

        internal bool ActualizarCliente(Cliente oClienteSelected)
        {
            return oClienteDao.Update(oClienteSelected);
        }

        internal object ObtenerCliente(string cliente)
        {
            //SIN PARAMETROS
            return oClienteDao.GetClienteSinParametros(cliente);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }
        internal bool EliminarCliente(Cliente oClienteSelected)
        {
            //            throw new NotImplementedException();
            return oClienteDao.Eliminar(oClienteSelected);
        }
    }
}
