using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClienteBL
    {
        private ClienteDAO dao = new ClienteDAO();

        public DataTable Listar()
        {
            return dao.Listar();
        }

        public void Insertar(Cliente cli)
        {
            if (string.IsNullOrEmpty(cli.Nombre))
                throw new Exception("El nombre del cliente es obligatorio.");

            dao.Insertar(cli);
        }

        public void Eliminar(int id)
        {
            dao.Eliminar(id);
        }

        public Cliente ObtenerPorId(int id)
        {
            return dao.ObtenerPorId(id);
        }
    }
}