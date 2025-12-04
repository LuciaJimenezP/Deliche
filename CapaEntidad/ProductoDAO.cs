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
    public class ProductoDAO
    {
        

        public DataTable Listar()
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                string query = "SELECT id_producto, nombre, tipo, precio, stock FROM tm_producto WHERE estado = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insertar(Producto p)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                string query = "INSERT INTO tm_producto (nombre, tipo, precio, stock, estado) VALUES (@nom, @tip, @pre, @stk, 1)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nom", p.Nombre);
                cmd.Parameters.AddWithValue("@tip", p.Tipo);
                cmd.Parameters.AddWithValue("@pre", p.Precio);
                cmd.Parameters.AddWithValue("@stk", p.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                string query = "UPDATE tm_producto SET estado = 0 WHERE id_producto = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


        public DataTable ObtenerBajoStock()
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                string query = "SELECT id_producto, nombre, tipo, precio, stock, CASE WHEN stock = 0 THEN 'Agotado' ELSE 'Bajo' END as EstadoStock FROM tm_producto WHERE stock < 5 AND estado = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}