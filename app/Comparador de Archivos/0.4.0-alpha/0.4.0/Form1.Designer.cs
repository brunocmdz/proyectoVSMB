namespace _0._4._0
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnCargarMadre = new System.Windows.Forms.Button();
            this.txtMadre = new System.Windows.Forms.TextBox();
            this.btnCargarComparar = new System.Windows.Forms.Button();
            this.txtComparar = new System.Windows.Forms.TextBox();
            this.btnComparar = new System.Windows.Forms.Button();
            this.btnCorregir = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCargarMadre
            // 
            this.btnCargarMadre.Location = new System.Drawing.Point(20, 20);
            this.btnCargarMadre.Size = new System.Drawing.Size(150, 30);
            this.btnCargarMadre.Text = "Cargar Madre";
            this.btnCargarMadre.Click += new System.EventHandler(this.btnCargarMadre_Click);
            // 
            // txtMadre
            // 
            this.txtMadre.Location = new System.Drawing.Point(20, 60);
            this.txtMadre.Multiline = true;
            this.txtMadre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMadre.Size = new System.Drawing.Size(350, 200);
            // 
            // btnCargarComparar
            // 
            this.btnCargarComparar.Location = new System.Drawing.Point(400, 20);
            this.btnCargarComparar.Size = new System.Drawing.Size(150, 30);
            this.btnCargarComparar.Text = "Cargar Nuevo";
            this.btnCargarComparar.Click += new System.EventHandler(this.btnCargarComparar_Click);
            // 
            // txtComparar
            // 
            this.txtComparar.Location = new System.Drawing.Point(400, 60);
            this.txtComparar.Multiline = true;
            this.txtComparar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComparar.Size = new System.Drawing.Size(350, 200);
            // 
            // btnComparar
            // 
            this.btnComparar.Location = new System.Drawing.Point(20, 280);
            this.btnComparar.Size = new System.Drawing.Size(150, 30);
            this.btnComparar.Text = "Comparar";
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnCorregir
            // 
            this.btnCorregir.Location = new System.Drawing.Point(180, 280);
            this.btnCorregir.Size = new System.Drawing.Size(180, 30);
            this.btnCorregir.Text = "Generar Corrección";
            this.btnCorregir.Click += new System.EventHandler(this.btnCorregir_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(20, 330);
            this.txtResultado.Multiline = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(730, 200);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(370, 280);
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(500, 280);
            this.btnLimpiar.Size = new System.Drawing.Size(120, 30);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(630, 280);
            this.btnHistorial.Size = new System.Drawing.Size(120, 30);
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(780, 550);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnCorregir);
            this.Controls.Add(this.btnComparar);
            this.Controls.Add(this.txtComparar);
            this.Controls.Add(this.btnCargarComparar);
            this.Controls.Add(this.txtMadre);
            this.Controls.Add(this.btnCargarMadre);
            this.Text = "Comparador de Archivos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnCargarMadre;
        private System.Windows.Forms.TextBox txtMadre;
        private System.Windows.Forms.Button btnCargarComparar;
        private System.Windows.Forms.TextBox txtComparar;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.Button btnCorregir;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnHistorial;
    }
}
