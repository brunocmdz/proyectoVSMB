namespace beta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textoMadre = new System.Windows.Forms.TextBox();
            this.textoValidar = new System.Windows.Forms.TextBox();
            this.textoValidado = new System.Windows.Forms.TextBox();
            this.botonValidar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.errores = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto madre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Texto a validar";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Texto validado:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(725, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textoMadre
            // 
            this.textoMadre.Location = new System.Drawing.Point(132, 158);
            this.textoMadre.Name = "textoMadre";
            this.textoMadre.Size = new System.Drawing.Size(100, 20);
            this.textoMadre.TabIndex = 4;
            // 
            // textoValidar
            // 
            this.textoValidar.Location = new System.Drawing.Point(399, 158);
            this.textoValidar.Name = "textoValidar";
            this.textoValidar.Size = new System.Drawing.Size(100, 20);
            this.textoValidar.TabIndex = 5;
            // 
            // textoValidado
            // 
            this.textoValidado.Location = new System.Drawing.Point(495, 327);
            this.textoValidado.Name = "textoValidado";
            this.textoValidado.Size = new System.Drawing.Size(100, 20);
            this.textoValidado.TabIndex = 6;
            // 
            // botonValidar
            // 
            this.botonValidar.Location = new System.Drawing.Point(656, 155);
            this.botonValidar.Name = "botonValidar";
            this.botonValidar.Size = new System.Drawing.Size(75, 23);
            this.botonValidar.TabIndex = 7;
            this.botonValidar.Text = "Validar";
            this.botonValidar.UseVisualStyleBackColor = true;
            this.botonValidar.Click += new System.EventHandler(this.botonValidar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Errores:";
            // 
            // errores
            // 
            this.errores.Location = new System.Drawing.Point(103, 312);
            this.errores.Name = "errores";
            this.errores.Size = new System.Drawing.Size(100, 20);
            this.errores.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonValidar);
            this.Controls.Add(this.textoValidado);
            this.Controls.Add(this.textoValidar);
            this.Controls.Add(this.textoMadre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Comparador de texto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textoMadre;
        private System.Windows.Forms.TextBox textoValidar;
        private System.Windows.Forms.TextBox textoValidado;
        private System.Windows.Forms.Button botonValidar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox errores;
    }
}

