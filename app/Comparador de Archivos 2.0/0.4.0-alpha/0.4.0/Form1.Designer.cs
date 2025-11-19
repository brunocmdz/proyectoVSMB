namespace _0._4._0
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.descargarBTN = new System.Windows.Forms.Button();
            this.labelACR = new System.Windows.Forms.Label();
            this.compararBTN = new System.Windows.Forms.Button();
            this.panelACR = new System.Windows.Forms.Panel();
            this.archivoACR = new System.Windows.Forms.Label();
            this.labelAC = new System.Windows.Forms.Label();
            this.panelAC = new System.Windows.Forms.Panel();
            this.archivosCargadosAC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.archivoCargadoAC = new System.Windows.Forms.Label();
            this.examinarBTNAC = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelArrastrarAC = new System.Windows.Forms.Label();
            this.labelAM = new System.Windows.Forms.Label();
            this.panelAM = new System.Windows.Forms.Panel();
            this.archivosCargadosAM = new System.Windows.Forms.Label();
            this.archivosCargados = new System.Windows.Forms.Label();
            this.archivoCargadoAM = new System.Windows.Forms.Label();
            this.archivoCargado = new System.Windows.Forms.Label();
            this.examinarBTNAM = new System.Windows.Forms.Button();
            this.labelArrastrarAM = new System.Windows.Forms.Label();
            this.historialBTN = new System.Windows.Forms.Button(); // Nueva declaración
            this.panelACR.SuspendLayout();
            this.panelAC.SuspendLayout();
            this.panelAM.SuspendLayout();
            this.SuspendLayout();
            // 
            // descargarBTN
            // 
            this.descargarBTN.Location = new System.Drawing.Point(468, 441);
            this.descargarBTN.Name = "descargarBTN";
            this.descargarBTN.Size = new System.Drawing.Size(101, 23);
            this.descargarBTN.TabIndex = 23;
            this.descargarBTN.Text = "Descarrgar en:";
            this.descargarBTN.UseVisualStyleBackColor = true;
            this.descargarBTN.Click += new System.EventHandler(this.descargarBTN_Click);
            // 
            // historialBTN
            // 
            this.historialBTN.Location = new System.Drawing.Point(600, 441);
            this.historialBTN.Name = "historialBTN";
            this.historialBTN.Size = new System.Drawing.Size(101, 23);
            this.historialBTN.TabIndex = 24;
            this.historialBTN.Text = "Historial";
            this.historialBTN.UseVisualStyleBackColor = true;
            this.historialBTN.Click += new System.EventHandler(this.historialBTN_Click);
            // 
            // labelACR
            // 
            this.labelACR.AutoSize = true;
            this.labelACR.Location = new System.Drawing.Point(85, 334);
            this.labelACR.Name = "labelACR";
            this.labelACR.Size = new System.Drawing.Size(110, 13);
            this.labelACR.TabIndex = 22;
            this.labelACR.Text = "Archivo/s corregido/s";
            // 
            // compararBTN
            // 
            this.compararBTN.Location = new System.Drawing.Point(891, 163);
            this.compararBTN.Name = "compararBTN";
            this.compararBTN.Size = new System.Drawing.Size(75, 23);
            this.compararBTN.TabIndex = 21;
            this.compararBTN.Text = "Comparar";
            this.compararBTN.UseVisualStyleBackColor = true;
            this.compararBTN.Click += new System.EventHandler(this.compararBTN_Click);
            // 
            // panelACR
            // 
            this.panelACR.BackColor = System.Drawing.Color.Black;
            this.panelACR.Controls.Add(this.archivoACR);
            this.panelACR.Location = new System.Drawing.Point(88, 363);
            this.panelACR.Name = "panelACR";
            this.panelACR.Size = new System.Drawing.Size(310, 176);
            this.panelACR.TabIndex = 20;
            // 
            // archivoACR
            // 
            this.archivoACR.AutoSize = true;
            this.archivoACR.ForeColor = System.Drawing.Color.White;
            this.archivoACR.Location = new System.Drawing.Point(20, 34);
            this.archivoACR.Name = "archivoACR";
            this.archivoACR.Size = new System.Drawing.Size(0, 13);
            this.archivoACR.TabIndex = 16;
            // 
            // labelAC
            // 
            this.labelAC.AutoSize = true;
            this.labelAC.Location = new System.Drawing.Point(509, 61);
            this.labelAC.Name = "labelAC";
            this.labelAC.Size = new System.Drawing.Size(99, 13);
            this.labelAC.TabIndex = 19;
            this.labelAC.Text = "Archivo a comparar";
            // 
            // panelAC
            // 
            this.panelAC.BackColor = System.Drawing.Color.Black;
            this.panelAC.Controls.Add(this.archivosCargadosAC);
            this.panelAC.Controls.Add(this.label3);
            this.panelAC.Controls.Add(this.label2);
            this.panelAC.Controls.Add(this.label4);
            this.panelAC.Controls.Add(this.archivoCargadoAC);
            this.panelAC.Controls.Add(this.examinarBTNAC);
            this.panelAC.Controls.Add(this.label6);
            this.panelAC.Controls.Add(this.labelArrastrarAC);
            this.panelAC.Location = new System.Drawing.Point(512, 97);
            this.panelAC.Name = "panelAC";
            this.panelAC.Size = new System.Drawing.Size(310, 176);
            this.panelAC.TabIndex = 18;
            // 
            // archivosCargadosAC
            // 
            this.archivosCargadosAC.AutoSize = true;
            this.archivosCargadosAC.ForeColor = System.Drawing.Color.White;
            this.archivosCargadosAC.Location = new System.Drawing.Point(14, 51);
            this.archivosCargadosAC.Name = "archivosCargadosAC";
            this.archivosCargadosAC.Size = new System.Drawing.Size(0, 13);
            this.archivosCargadosAC.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(37, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 2;
            // 
            // archivoCargadoAC
            // 
            this.archivoCargadoAC.AutoSize = true;
            this.archivoCargadoAC.ForeColor = System.Drawing.Color.White;
            this.archivoCargadoAC.Location = new System.Drawing.Point(14, 23);
            this.archivoCargadoAC.Name = "archivoCargadoAC";
            this.archivoCargadoAC.Size = new System.Drawing.Size(0, 13);
            this.archivoCargadoAC.TabIndex = 12;
            // 
            // examinarBTNAC
            // 
            this.examinarBTNAC.BackColor = System.Drawing.Color.Black;
            this.examinarBTNAC.ForeColor = System.Drawing.Color.White;
            this.examinarBTNAC.Location = new System.Drawing.Point(119, 58);
            this.examinarBTNAC.Name = "examinarBTNAC";
            this.examinarBTNAC.Size = new System.Drawing.Size(75, 23);
            this.examinarBTNAC.TabIndex = 2;
            this.examinarBTNAC.Text = "Examinar";
            this.examinarBTNAC.UseVisualStyleBackColor = false;
            this.examinarBTNAC.Click += new System.EventHandler(this.examinarBTNAC_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 10;
            // 
            // labelArrastrarAC
            // 
            this.labelArrastrarAC.AutoSize = true;
            this.labelArrastrarAC.BackColor = System.Drawing.Color.Black;
            this.labelArrastrarAC.ForeColor = System.Drawing.Color.White;
            this.labelArrastrarAC.Location = new System.Drawing.Point(102, 107);
            this.labelArrastrarAC.Name = "labelArrastrarAC";
            this.labelArrastrarAC.Size = new System.Drawing.Size(124, 13);
            this.labelArrastrarAC.TabIndex = 2;
            this.labelArrastrarAC.Text = "o arrastre su archivo acá";
            // 
            // labelAM
            // 
            this.labelAM.AutoSize = true;
            this.labelAM.Location = new System.Drawing.Point(85, 61);
            this.labelAM.Name = "labelAM";
            this.labelAM.Size = new System.Drawing.Size(75, 13);
            this.labelAM.TabIndex = 17;
            this.labelAM.Text = "Archivo madre";
            // 
            // panelAM
            // 
            this.panelAM.BackColor = System.Drawing.Color.Black;
            this.panelAM.Controls.Add(this.archivosCargadosAM);
            this.panelAM.Controls.Add(this.archivosCargados);
            this.panelAM.Controls.Add(this.archivoCargadoAM);
            this.panelAM.Controls.Add(this.archivoCargado);
            this.panelAM.Controls.Add(this.examinarBTNAM);
            this.panelAM.Controls.Add(this.labelArrastrarAM);
            this.panelAM.Location = new System.Drawing.Point(88, 97);
            this.panelAM.Name = "panelAM";
            this.panelAM.Size = new System.Drawing.Size(310, 176);
            this.panelAM.TabIndex = 16;
            // 
            // archivosCargadosAM
            // 
            this.archivosCargadosAM.AutoSize = true;
            this.archivosCargadosAM.ForeColor = System.Drawing.Color.White;
            this.archivosCargadosAM.Location = new System.Drawing.Point(20, 51);
            this.archivosCargadosAM.Name = "archivosCargadosAM";
            this.archivosCargadosAM.Size = new System.Drawing.Size(0, 13);
            this.archivosCargadosAM.TabIndex = 9;
            // 
            // archivosCargados
            // 
            this.archivosCargados.AutoSize = true;
            this.archivosCargados.ForeColor = System.Drawing.Color.White;
            this.archivosCargados.Location = new System.Drawing.Point(40, 49);
            this.archivosCargados.Name = "archivosCargados";
            this.archivosCargados.Size = new System.Drawing.Size(0, 13);
            this.archivosCargados.TabIndex = 3;
            // 
            // archivoCargadoAM
            // 
            this.archivoCargadoAM.AutoSize = true;
            this.archivoCargadoAM.ForeColor = System.Drawing.Color.White;
            this.archivoCargadoAM.Location = new System.Drawing.Point(20, 23);
            this.archivoCargadoAM.Name = "archivoCargadoAM";
            this.archivoCargadoAM.Size = new System.Drawing.Size(0, 13);
            this.archivoCargadoAM.TabIndex = 8;
            // 
            // archivoCargado
            // 
            this.archivoCargado.AutoSize = true;
            this.archivoCargado.ForeColor = System.Drawing.Color.White;
            this.archivoCargado.Location = new System.Drawing.Point(37, 23);
            this.archivoCargado.Name = "archivoCargado";
            this.archivoCargado.Size = new System.Drawing.Size(0, 13);
            this.archivoCargado.TabIndex = 2;
            // 
            // examinarBTNAM
            // 
            this.examinarBTNAM.BackColor = System.Drawing.Color.Black;
            this.examinarBTNAM.ForeColor = System.Drawing.Color.White;
            this.examinarBTNAM.Location = new System.Drawing.Point(105, 58);
            this.examinarBTNAM.Name = "examinarBTNAM";
            this.examinarBTNAM.Size = new System.Drawing.Size(75, 23);
            this.examinarBTNAM.TabIndex = 2;
            this.examinarBTNAM.Text = "Examinar";
            this.examinarBTNAM.UseVisualStyleBackColor = false;
            this.examinarBTNAM.Click += new System.EventHandler(this.examinarBTNAM_Click);
            // 
            // labelArrastrarAM
            // 
            this.labelArrastrarAM.AutoSize = true;
            this.labelArrastrarAM.BackColor = System.Drawing.Color.Black;
            this.labelArrastrarAM.ForeColor = System.Drawing.Color.White;
            this.labelArrastrarAM.Location = new System.Drawing.Point(102, 107);
            this.labelArrastrarAM.Name = "labelArrastrarAM";
            this.labelArrastrarAM.Size = new System.Drawing.Size(124, 13);
            this.labelArrastrarAM.TabIndex = 2;
            this.labelArrastrarAM.Text = "o arrastre su archivo acá";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 601);
            this.Controls.Add(this.historialBTN); // Nuevo control añadido
            this.Controls.Add(this.descargarBTN);
            this.Controls.Add(this.labelACR);
            this.Controls.Add(this.compararBTN);
            this.Controls.Add(this.panelACR);
            this.Controls.Add(this.labelAC);
            this.Controls.Add(this.panelAC);
            this.Controls.Add(this.labelAM);
            this.Controls.Add(this.panelAM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelACR.ResumeLayout(false);
            this.panelACR.PerformLayout();
            this.panelAC.ResumeLayout(false);
            this.panelAC.PerformLayout();
            this.panelAM.ResumeLayout(false);
            this.panelAM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button descargarBTN;
        private System.Windows.Forms.Label labelACR;
        private System.Windows.Forms.Button compararBTN;
        private System.Windows.Forms.Panel panelACR;
        private System.Windows.Forms.Label archivoACR;
        private System.Windows.Forms.Label labelAC;
        private System.Windows.Forms.Panel panelAC;
        private System.Windows.Forms.Label archivosCargadosAC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label archivoCargadoAC;
        private System.Windows.Forms.Button examinarBTNAC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelArrastrarAC;
        private System.Windows.Forms.Label labelAM;
        private System.Windows.Forms.Panel panelAM;
        private System.Windows.Forms.Label archivosCargadosAM;
        private System.Windows.Forms.Label archivosCargados;
        private System.Windows.Forms.Label archivoCargadoAM;
        private System.Windows.Forms.Label archivoCargado;
        private System.Windows.Forms.Button examinarBTNAM;
        private System.Windows.Forms.Label labelArrastrarAM;
        private System.Windows.Forms.Button historialBTN; // Nueva propiedad añadida
    }
}