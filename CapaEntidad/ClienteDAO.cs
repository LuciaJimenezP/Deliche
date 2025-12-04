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
    public class ClienteDAO
    {
        public DataTable Listar()
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                string query = "SELECT id_cliente, nombre, telefono, correo FROM tm_cliente WHERE estado = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insertar(Cliente cli)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                string query = "INSERT INTO tm_cliente (nombre, telefono, correo, estado) VALUES (@nom, @tel, @cor, 1)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nom", cli.Nombre);
                cmd.Parameters.AddWithValue("@tel", cli.Telefono);
                cmd.Parameters.AddWithValue("@cor", cli.Correo);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                string query = "UPDATE tm_cliente SET estado = 0 WHERE id_cliente = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                string query = "SELECT id_cliente, nombre, telefono, correo, estado FROM tm_cliente WHERE id_cliente = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Cliente
                        {
                            IdCliente = Convert.ToInt32(dr["id_cliente"]),
                            Nombre = dr["nombre"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Estado = Convert.ToInt32(dr["estado"])
                        };
                    }
                }
            }
            return null;
        }
    }
}
