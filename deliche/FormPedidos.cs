
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace Deliche
{
    public partial class FormPedido : Form
    {
        private ClienteBL clienteBL = new ClienteBL();
        private PedidoBL pedidoBL = new PedidoBL();

        private List<DetallePedido> detallesTemp = new List<DetallePedido>();

        public FormPedido()
        {
            InitializeComponent();
            CargarCombos();
        }
        public FormPedido(object g) : this() { }

        private void CargarCombos()
        {
            cbCliente.DataSource = clienteBL.Listar();
            cbCliente.DisplayMember = "nombre";
            cbCliente.ValueMember = "id_cliente";

            cbEstado.Items.Clear();
            cbEstado.Items.AddRange(new string[] { "Pendiente", "En preparación", "Entregado" });
            cbEstado.SelectedIndex = 0;
        }

        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            try
            {
                DetallePedido det = new DetallePedido();

                det.IdProducto = 1; // AQUÍ luego puedes poner el ID real del producto
                det.Cantidad = int.Parse(tbCantidad.Text);
                det.Subtotal = det.Cantidad * decimal.Parse(tbPrecio.Text);

                // Si tienes un TextBox con nombre del producto, puedes hacer:
                det.NombreProducto = tbProducto.Text;
                // Por ahora lo dejamos vacío y en el correo mostramos "Producto #Id"

                detallesTemp.Add(det);
                ActualizarGridDetalles();
            }
            catch (Exception ex) { MessageBox.Show("Revise cantidad o precio: " + ex.Message); }
        }

        private void ActualizarGridDetalles()
        {
            dgDetalles.DataSource = null;
            dgDetalles.DataSource = detallesTemp;
            lblTotal.Text = $"Total: S/ {detallesTemp.Sum(x => x.Subtotal):F2}";
        }

        private void btnGuardarPedido_Click_1(object sender, EventArgs e)
        {
            if (detallesTemp.Count == 0)
            {
                MessageBox.Show("Agregue productos al pedido.");
                return;
            }

            try
            {
                Pedido p = new Pedido();
                p.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                p.FechaPedido = dtFechaPedido.Value;
                p.FechaEntrega = dtFechaEntrega.Value;
                p.EstadoPedido = cbEstado.Text;
                p.Total = detallesTemp.Sum(x => x.Subtotal);
                p.Detalles = detallesTemp;

                // 1. Guardar en SQL → SQL genera el ID real
                int idGenerado = pedidoBL.Insertar(p);
                p.IdPedido = idGenerado;

                // 2. Asignar ese ID a los detalles para mostrarlo en la grilla
                foreach (var det in detallesTemp)
                {
                    det.IdPedido = idGenerado;
                }

                // 3. Refrescar grilla
                ActualizarGridDetalles();

                // 4. Enviar correo (si lo tienes)
                Cliente cliente = clienteBL.ObtenerPorId(p.IdCliente);
                CorreoHelper.EnviarCorreoPedido(p, cliente);

                MessageBox.Show("Pedido guardado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
        private void panelContenido_Paint(object sender, PaintEventArgs e) { }
    }
}