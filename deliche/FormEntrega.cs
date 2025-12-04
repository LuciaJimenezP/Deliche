using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace deliche
{
    public partial class FormEntrega : Form
    {
        private EntregaBL entregaBL = new EntregaBL();
        private PedidoBL pedidoBL = new PedidoBL();

        public FormEntrega()
        {
            InitializeComponent();
            Inicializar();
        }
        public FormEntrega(object g) : this() { }

        private void Inicializar()
        {
            cmbEstadoEntrega.Items.AddRange(new string[] { "Pendiente", "En camino", "Entregado" });

            // Cargar pedidos en el combo
            cmbPedidoEntrega.DataSource = pedidoBL.ListarSimple();
            cmbPedidoEntrega.DisplayMember = "id_pedido";
            cmbPedidoEntrega.ValueMember = "id_pedido";

            CargarGrid();
        }

        private void btnRegistrarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPedidoEntrega.SelectedIndex == -1) return;

                Entrega ent = new Entrega();
                ent.IdPedido = Convert.ToInt32(cmbPedidoEntrega.SelectedValue);
                ent.Direccion = txtDireccionEntrega.Text;
                ent.FechaEntrega = dtpFechaEntrega.Value;
                ent.EstadoEntrega = cmbEstadoEntrega.Text;

                entregaBL.Insertar(ent);

                MessageBox.Show("Entrega registrada en BD ✅");
                CargarGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CargarGrid()
        {
            dgvEntregas.DataSource = entregaBL.Listar();
        }

        private void btnSalirEntrega_Click(object sender, EventArgs e) => this.Close();
        private void FormEntrega_Load(object sender, EventArgs e) { }
    }
}