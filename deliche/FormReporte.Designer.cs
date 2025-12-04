namespace deliche
{
    partial class FormReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.btnProductosBajoStock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPagosRealizados = new System.Windows.Forms.Button();
            this.btnReporteVentas = new System.Windows.Forms.Button();
            this.btnReporteEntregas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(32, 170);
            this.dgvReportes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.RowTemplate.Height = 24;
            this.dgvReportes.Size = new System.Drawing.Size(685, 223);
            this.dgvReportes.TabIndex = 9;
            // 
            // btnProductosBajoStock
            // 
            this.btnProductosBajoStock.BackColor = System.Drawing.Color.Red;
            this.btnProductosBajoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductosBajoStock.ForeColor = System.Drawing.Color.White;
            this.btnProductosBajoStock.Location = new System.Drawing.Point(575, 80);
            this.btnProductosBajoStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductosBajoStock.Name = "btnProductosBajoStock";
            this.btnProductosBajoStock.Size = new System.Drawing.Size(142, 73);
            this.btnProductosBajoStock.TabIndex = 8;
            this.btnProductosBajoStock.Text = "Mostrar productos con bajo stock";
            this.btnProductosBajoStock.UseVisualStyleBackColor = false;
            this.btnProductosBajoStock.Click += new System.EventHandler(this.btnProductosBajoStock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(294, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reportes";
            // 
            // btnPagosRealizados
            // 
            this.btnPagosRealizados.BackColor = System.Drawing.Color.Red;
            this.btnPagosRealizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagosRealizados.ForeColor = System.Drawing.Color.White;
            this.btnPagosRealizados.Location = new System.Drawing.Point(201, 80);
            this.btnPagosRealizados.Name = "btnPagosRealizados";
            this.btnPagosRealizados.Size = new System.Drawing.Size(152, 73);
            this.btnPagosRealizados.TabIndex = 10;
            this.btnPagosRealizados.Text = "Pagos Realizados";
            this.btnPagosRealizados.UseVisualStyleBackColor = false;
            this.btnPagosRealizados.Click += new System.EventHandler(this.btnPagosRealizados_Click);
            // 
            // btnReporteVentas
            // 
            this.btnReporteVentas.BackColor = System.Drawing.Color.Red;
            this.btnReporteVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteVentas.ForeColor = System.Drawing.Color.White;
            this.btnReporteVentas.Location = new System.Drawing.Point(32, 80);
            this.btnReporteVentas.Name = "btnReporteVentas";
            this.btnReporteVentas.Size = new System.Drawing.Size(136, 73);
            this.btnReporteVentas.TabIndex = 11;
            this.btnReporteVentas.Text = "Reporte de Ventas";
            this.btnReporteVentas.UseVisualStyleBackColor = false;
            this.btnReporteVentas.Click += new System.EventHandler(this.btnReporteVentas_Click);
            // 
            // btnReporteEntregas
            // 
            this.btnReporteEntregas.BackColor = System.Drawing.Color.Red;
            this.btnReporteEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEntregas.ForeColor = System.Drawing.Color.White;
            this.btnReporteEntregas.Location = new System.Drawing.Point(398, 80);
            this.btnReporteEntregas.Name = "btnReporteEntregas";
            this.btnReporteEntregas.Size = new System.Drawing.Size(142, 73);
            this.btnReporteEntregas.TabIndex = 12;
            this.btnReporteEntregas.Text = "Reporte de Entregas";
            this.btnReporteEntregas.UseVisualStyleBackColor = false;
            this.btnReporteEntregas.Click += new System.EventHandler(this.btnReporteEntregas_Click);
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 426);
            this.Controls.Add(this.btnReporteEntregas);
            this.Controls.Add(this.btnReporteVentas);
            this.Controls.Add(this.btnPagosRealizados);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.btnProductosBajoStock);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormReporte";
            this.Text = "FormReporte";
            this.Load += new System.EventHandler(this.FormReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Button btnProductosBajoStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagosRealizados;
        private System.Windows.Forms.Button btnReporteVentas;
        private System.Windows.Forms.Button btnReporteEntregas;
    }
}