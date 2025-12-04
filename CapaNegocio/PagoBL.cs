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
    public class PagoBL
    {
        private PagoDAO dao = new PagoDAO();

        public DataTable Listar()
        {
            return dao.Listar();
        }

        public void Insertar(Pago pago)
        {
            dao.Insertar(pago);
        }
    }
}