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
    public class PedidoBL
    {
        private PedidoDAO dao = new PedidoDAO();

        public DataTable ListarReporte()
        {
            return dao.ListarReporte();
        }

        public DataTable ListarSimple()
        {
            return dao.ListarSimple();
        }

        public int Insertar(Pedido pedido)
        {
            if (pedido.Detalles.Count == 0)
                throw new Exception("No se puede guardar un pedido sin productos.");

            // devuelve el ID generado en BD
            int idGenerado = dao.Insertar(pedido);
            pedido.IdPedido = idGenerado;
            return idGenerado;
        }
    }
}