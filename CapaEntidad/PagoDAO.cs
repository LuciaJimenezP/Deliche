using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class PagoDAO
    {


        public DataTable Listar()
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                string query = "SELECT * FROM tt_pago WHERE estado = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insertar(Pago p)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                string query = "INSERT INTO tt_pago(id_pedido, tipo_pago, monto_pagado, saldo_pendiente, estado_pago, estado) VALUES (@idp, @tipo, @monto, @saldo, @est, 1)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idp", p.IdPedido);
                cmd.Parameters.AddWithValue("@tipo", p.TipoPago);
                cmd.Parameters.AddWithValue("@monto", p.MontoPagado);
                cmd.Parameters.AddWithValue("@saldo", p.SaldoPendiente);
                cmd.Parameters.AddWithValue("@est", p.EstadoPago);
                cmd.ExecuteNonQuery();
            }
        }
    }
}