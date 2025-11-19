namespace _0._4._0
{
    partial class FormHistorial
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnVerContenido;
        private System.Windows.Forms.TextBox txtContenido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnVerContenido = new System.Windows.Forms.Button();
            this.txtContenido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(20, 20);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(500, 250);
            // 
            // btnVerContenido
            // 
            this.btnVerContenido.Location = new System.Drawing.Point(540, 20);
            this.btnVerContenido.Name = "btnVerContenido";
            this.btnVerContenido.Size = new System.Drawing.Size(150, 30);
            this.btnVerContenido.TabIndex = 1;
            this.btnVerContenido.Text = "Ver contenido";
            this.btnVerContenido.UseVisualStyleBackColor = true;
            this.btnVerContenido.Click += new System.EventHandler(this.btnVerContenido_Click);
            // 
            // txtContenido
            // 
            this.txtContenido.Location = new System.Drawing.Point(20, 290);
            this.txtContenido.Multiline = true;
            this.txtContenido.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContenido.Size = new System.Drawing.Size(670, 230);
            this.txtContenido.ReadOnly = true;
            // 
            // FormHistorial
            // 
            this.ClientSize = new System.Drawing.Size(720, 540);
            this.Controls.Add(this.txtContenido);
            this.Controls.Add(this.btnVerContenido);
            this.Controls.Add(this.dgvHistorial);
            this.Name = "FormHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de archivos procesados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
