using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1._1
{
    public partial class Form1: Form
    {
        private string rutaArchivoCargado;

        public Form1()
        {
            InitializeComponent();
            archivoMadre.AllowDrop = true;
            archivoMadre.DragEnter += panelDrop_DragEnter;
            archivoMadre.DragDrop += panelDrop_DragDrop;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void panelDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void manejarArchivosCargados(string[] archivos)
        {
            if (archivos.Length > 0)
            {
                rutaArchivoCargado = archivos[0]; // Usás el primero como principal

                string nombres = string.Join(Environment.NewLine, archivos.Select(a => "• " + Path.GetFileName(a)));
                archivoCargado.Text = "Archivos cargados:";
                archivosCargados.Text = nombres;

                examinarBTN.Visible = false;
                labelArrastrar.Visible = false;
            }
        }
        private void panelDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
            manejarArchivosCargados(archivos);
        }

        private void examinarBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.Multiselect = true;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                manejarArchivosCargados(dialogo.FileNames);
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
