using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace deliche
{
    public partial class FormPagos : Form
    {
        private PagoBL pagoBL = new PagoBL();
        private PedidoBL pedidoBL = new PedidoBL();

        public FormPagos()
        {
            InitializeComponent();
            Inicializar();
        }
        public FormPagos(object g) : this() { }

        private void Inicializar()
        {
            cmbTipoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbEstadoPago.Items.AddRange(new string[] { "Pendiente", "Parcial", "Pagado" });

            CargarPedidos();
            ActualizarGrid();
        }

        private void CargarPedidos()
        {
          
            cmbPedidoAsociado.DataSource = pedidoBL.ListarSimple();
            cmbPedidoAsociado.DisplayMember = "id_pedido";
            cmbPedidoAsociado.ValueMember = "total"; 
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (cmbPedidoAsociado.SelectedIndex == -1) return;

            try
            {
                DataRowView fila = (DataRowView)cmbPedidoAsociado.SelectedItem;

                int idPedido = Convert.ToInt32(fila["id_pedido"]);
                decimal totalPedido = Convert.ToDecimal(fila["total"]);
                decimal montoPagado = decimal.Parse(txtMontoPago.Text);

                decimal saldo = totalPedido - montoPagado;
                if (saldo < 0) saldo = 0;

                Pago nuevoPago = new Pago();
                nuevoPago.IdPedido = idPedido;
                nuevoPago.TipoPago = cmbTipoPago.Text;
                nuevoPago.MontoPagado = montoPagado;
                nuevoPago.SaldoPendiente = saldo;

                if (saldo <= 0) nuevoPago.EstadoPago = "Pagado";
                else nuevoPago.EstadoPago = "Parcial";

                pagoBL.Insertar(nuevoPago);

                MessageBox.Show("Pago registrado en BD ✅");
                ActualizarGrid();

                txtSaldoPendiente.Text = saldo.ToString("N2");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ActualizarGrid()
        {
            dgvPagos.DataSource = pagoBL.Listar();
        }

        private void btnSalirPagos_Click(object sender, EventArgs e) => this.Close();
        private void FormPagos_Load(object sender, EventArgs e) { }
    }
}