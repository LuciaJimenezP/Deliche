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
    public class PedidoDAO
    {
        

        public DataTable ListarReporte()
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                string query = @"SELECT p.id_pedido, c.nombre as Cliente, p.fecha_pedido, p.fecha_entrega, p.total 
                                 FROM tt_pedido p
                                 INNER JOIN tm_cliente c ON p.id_cliente = c.id_cliente
                                 WHERE p.estado = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ListarSimple()
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                string query = "SELECT id_pedido, total FROM tt_pedido WHERE estado = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int Insertar(Pedido p)
        {
            using (SqlConnection cn = new SqlConnection(ConexionBD.CadenaConexion))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    // 1. Cabecera
                    string queryP = @"INSERT INTO tt_pedido
                                      (fecha_pedido, fecha_entrega, estado_pedido, total, id_cliente, estado) 
                                      VALUES (@fp, @fe, @estp, @tot, @idc, 1); 
                                      SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(queryP, cn, tr);
                    cmd.Parameters.AddWithValue("@fp", p.FechaPedido);
                    cmd.Parameters.AddWithValue("@fe", p.FechaEntrega);
                    cmd.Parameters.AddWithValue("@estp", p.EstadoPedido);
                    cmd.Parameters.AddWithValue("@tot", p.Total);
                    cmd.Parameters.AddWithValue("@idc", p.IdCliente);

                    int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());

                    // 2. Detalles
                    foreach (var det in p.Detalles)
                    {
                        string queryD = @"INSERT INTO td_detalle_pedido
                                          (id_pedido, id_producto, cantidad, subtotal, estado) 
                                          VALUES (@idp, @idprod, @cant, @sub, 1)";
                        SqlCommand cmdD = new SqlCommand(queryD, cn, tr);
                        cmdD.Parameters.AddWithValue("@idp", idGenerado);
                        cmdD.Parameters.AddWithValue("@idprod", det.IdProducto);
                        cmdD.Parameters.AddWithValue("@cant", det.Cantidad);
                        cmdD.Parameters.AddWithValue("@sub", det.Subtotal);
                        cmdD.ExecuteNonQuery();

                        // 3. Restar Stock
                        string queryStock = "UPDATE tm_producto SET stock = stock - @cant WHERE id_producto = @idprod";
                        SqlCommand cmdS = new SqlCommand(queryStock, cn, tr);
                        cmdS.Parameters.AddWithValue("@cant", det.Cantidad);
                        cmdS.Parameters.AddWithValue("@idprod", det.IdProducto);
                        cmdS.ExecuteNonQuery();
                    }

                    tr.Commit();
                    return idGenerado;
                }
                catch (Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }
    }
}