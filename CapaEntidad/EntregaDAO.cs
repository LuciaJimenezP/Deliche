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
    public class EntregaDAO
    {
       

        public DataTable Listar()
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                string query = "SELECT * FROM tt_entrega WHERE estado = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insertar(Entrega e)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                string query = "INSERT INTO tt_entrega(id_pedido, direccion, fecha_entrega, estado_entrega, estado) VALUES (@idp, @dir, @fe, @est, 1)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idp", e.IdPedido);
                cmd.Parameters.AddWithValue("@dir", e.Direccion);
                cmd.Parameters.AddWithValue("@fe", e.FechaEntrega);
                cmd.Parameters.AddWithValue("@est", e.EstadoEntrega);
                cmd.ExecuteNonQuery();
            }
        }
    }
}