namespace _1._1
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
            this.archivoMadre = new System.Windows.Forms.Panel();
            this.archivosCargados = new System.Windows.Forms.Label();
            this.archivoCargado = new System.Windows.Forms.Label();
            this.examinarBTN = new System.Windows.Forms.Button();
            this.labelArrastrar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.archivoComparar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.examinarBTNAC = new System.Windows.Forms.Button();
            this.labelArrastarAC = new System.Windows.Forms.Label();
            this.archivoMadre.SuspendLayout();
            this.archivoComparar.SuspendLayout();
            this.SuspendLayout();
            // 
            // archivoMadre
            // 
            this.archivoMadre.BackColor = System.Drawing.Color.Black;
            this.archivoMadre.Controls.Add(this.archivosCargados);
            this.archivoMadre.Controls.Add(this.archivoCargado);
            this.archivoMadre.Controls.Add(this.examinarBTN);
            this.archivoMadre.Controls.Add(this.labelArrastrar);
            this.archivoMadre.Location = new System.Drawing.Point(132, 124);
            this.archivoMadre.Name = "archivoMadre";
            this.archivoMadre.Size = new System.Drawing.Size(310, 176);
            this.archivoMadre.TabIndex = 0;
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
            // archivoCargado
            // 
            this.archivoCargado.AutoSize = true;
            this.archivoCargado.ForeColor = System.Drawing.Color.White;
            this.archivoCargado.Location = new System.Drawing.Point(37, 23);
            this.archivoCargado.Name = "archivoCargado";
            this.archivoCargado.Size = new System.Drawing.Size(0, 13);
            this.archivoCargado.TabIndex = 2;
            // 
            // examinarBTN
            // 
            this.examinarBTN.BackColor = System.Drawing.Color.Black;
            this.examinarBTN.ForeColor = System.Drawing.Color.White;
            this.examinarBTN.Location = new System.Drawing.Point(119, 58);
            this.examinarBTN.Name = "examinarBTN";
            this.examinarBTN.Size = new System.Drawing.Size(75, 23);
            this.examinarBTN.TabIndex = 2;
            this.examinarBTN.Text = "Examinar";
            this.examinarBTN.UseVisualStyleBackColor = false;
            this.examinarBTN.Click += new System.EventHandler(this.examinarBTN_Click);
            // 
            // labelArrastrar
            // 
            this.labelArrastrar.AutoSize = true;
            this.labelArrastrar.BackColor = System.Drawing.Color.Black;
            this.labelArrastrar.ForeColor = System.Drawing.Color.White;
            this.labelArrastrar.Location = new System.Drawing.Point(102, 107);
            this.labelArrastrar.Name = "labelArrastrar";
            this.labelArrastrar.Size = new System.Drawing.Size(124, 13);
            this.labelArrastrar.TabIndex = 2;
            this.labelArrastrar.Text = "o arrastre su archivo acá";
            this.labelArrastrar.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo madre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Archivo a comparar";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // archivoComparar
            // 
            this.archivoComparar.BackColor = System.Drawing.Color.Black;
            this.archivoComparar.Controls.Add(this.label3);
            this.archivoComparar.Controls.Add(this.label4);
            this.archivoComparar.Controls.Add(this.examinarBTNAC);
            this.archivoComparar.Controls.Add(this.labelArrastarAC);
            this.archivoComparar.Location = new System.Drawing.Point(556, 124);
            this.archivoComparar.Name = "archivoComparar";
            this.archivoComparar.Size = new System.Drawing.Size(310, 176);
            this.archivoComparar.TabIndex = 2;
            this.archivoComparar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(37, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 2;
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
            // 
            // labelArrastarAC
            // 
            this.labelArrastarAC.AutoSize = true;
            this.labelArrastarAC.BackColor = System.Drawing.Color.Black;
            this.labelArrastarAC.ForeColor = System.Drawing.Color.White;
            this.labelArrastarAC.Location = new System.Drawing.Point(102, 107);
            this.labelArrastarAC.Name = "labelArrastarAC";
            this.labelArrastarAC.Size = new System.Drawing.Size(124, 13);
            this.labelArrastarAC.TabIndex = 2;
            this.labelArrastarAC.Text = "o arrastre su archivo acá";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 580);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.archivoComparar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.archivoMadre);
            this.Name = "Form1";
            this.Text = "Comparador de archivos 1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.archivoMadre.ResumeLayout(false);
            this.archivoMadre.PerformLayout();
            this.archivoComparar.ResumeLayout(false);
            this.archivoComparar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel archivoMadre;
        private System.Windows.Forms.Label labelArrastrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button examinarBTN;
        private System.Windows.Forms.Label archivoCargado;
        private System.Windows.Forms.Label archivosCargados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel archivoComparar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button examinarBTNAC;
        private System.Windows.Forms.Label labelArrastarAC;
    }
}

