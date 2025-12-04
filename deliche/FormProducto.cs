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
    public partial class FormProducto : Form
    {
        private ProductoBL productoBL = new ProductoBL();

        public FormProducto()
        {
            InitializeComponent();
            ConfigurarGrid(); 
            CargarDatos();
        }
        public FormProducto(object gestor) : this() { }

        private void ConfigurarGrid()
        {
            dgvProductos.AutoGenerateColumns = true;
        }

        private void CargarDatos()
        {
            dgvProductos.DataSource = productoBL.Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = new Producto();
                // ID es identity, no lo leemos del textbox
                p.Nombre = txtNombre.Text;
                p.Tipo = txtTipo.Text;
                p.Precio = decimal.Parse(txtPrecio.Text);
                p.Stock = int.Parse(txtStock.Text);

                productoBL.Insertar(p);

                MessageBox.Show("Producto guardado en BD ✅");
                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value); // Asumiendo col 0 es ID
                productoBL.Eliminar(id);
                CargarDatos();
                MessageBox.Show("Producto eliminado 🗑️");
            }
        }

        private void LimpiarCampos()
        {
            txtIdProducto.Clear();
            txtNombre.Clear();
            txtTipo.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnListar_Click(object sender, EventArgs e) => CargarDatos();
        private void FormProducto_Load(object sender, EventArgs e) { }
        private void btnEditar_Click(object sender, EventArgs e) { MessageBox.Show("Función editar pendiente de implementación en DAO"); }
    }
}