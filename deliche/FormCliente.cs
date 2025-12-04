
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace deliche
{
    public partial class FormCliente : Form
    {
        private ClienteBL clienteBL = new ClienteBL();

        public FormCliente()
        {
            InitializeComponent();
            CargarDatos();
        }

        public FormCliente(object gestor) : this() { }

        private void CargarDatos()
        {
  
            dgClientes.DataSource = clienteBL.Listar();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            try
            {
                Cliente c = new Cliente();
                // Nota: No asignamos ID porque es IDENTITY en SQL
                c.Nombre = tbNombre.Text;
                c.Telefono = tbTelefono.Text;
                c.Correo = tbCorreo.Text;

                clienteBL.Insertar(c);

                MessageBox.Show("Cliente registrado correctamente en Base de Datos ✅");
                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgClientes.CurrentRow != null)
            {
                // Obtenemos el ID de la celda (asegúrate que coincida con el nombre de columna en SQL o índice)
                // Usualmente la columna 0 es el ID
                int id = Convert.ToInt32(dgClientes.CurrentRow.Cells[0].Value);

                if (MessageBox.Show("¿Eliminar cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clienteBL.Eliminar(id);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente.");
            }
        }

        private void LimpiarCampos()
        {
            tbCodigoCliente.Clear();
            tbNombre.Clear();
            tbTelefono.Clear();
            tbCorreo.Clear();
        }

        private void btnSalirCliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListarCliente_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e) { }
        private void panelContenido_Paint_1(object sender, PaintEventArgs e) { }
    }
}