using Deliche;
using System;
using System.Windows.Forms;

namespace deliche
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void InicializarFormulario()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormCliente form = new FormCliente())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir gestión de clientes: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormProducto form = new FormProducto())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir gestión de productos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormPedido form = new FormPedido())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir gestión de pedidos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionPagos_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormPagos form = new FormPagos())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir gestión de pagos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionEntregas_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormEntrega form = new FormEntrega())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir gestión de entregas: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormReporte form = new FormReporte())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir reportes: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblBienvenida_Click(object sender, EventArgs e)
        {
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}