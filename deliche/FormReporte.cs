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

namespace deliche
{
    public partial class FormReporte : Form
    {
        private PedidoBL pedidoBL = new PedidoBL();
        private PagoBL pagoBL = new PagoBL();
        private EntregaBL entregaBL = new EntregaBL();
        private ProductoBL productoBL = new ProductoBL();

        public FormReporte()
        {
            InitializeComponent();
        }
        public FormReporte(object g) : this() { }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.AllowUserToAddRows = false;
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
        
            dgvReportes.DataSource = pedidoBL.ListarReporte();
            if (dgvReportes.Rows.Count == 0) MessageBox.Show("Sin datos de ventas.");
        }

        private void btnPagosRealizados_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = pagoBL.Listar();
        }

        private void btnReporteEntregas_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = entregaBL.Listar();
        }

        private void btnProductosBajoStock_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = productoBL.ReporteBajoStock();
            if (dgvReportes.Rows.Count == 0) MessageBox.Show("Todo el stock está correcto.");
        }
    }
}