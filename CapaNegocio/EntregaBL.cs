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
    public class EntregaBL
    {
        private EntregaDAO dao = new EntregaDAO();

        public DataTable Listar()
        {
            return dao.Listar();
        }

        public void Insertar(Entrega entrega)
        {
            dao.Insertar(entrega);
        }
    }
}