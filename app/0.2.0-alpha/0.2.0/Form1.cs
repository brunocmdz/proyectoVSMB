using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1
{
    public partial class Form1: Form
    {
        private string rutaArchivoCargado;
        public Form1()
        {
            InitializeComponent();
            panelAM.AllowDrop = true;
            panelAM.DragEnter += panelDrop_DragEnter;
            panelAM.DragDrop += panelAM_DragDrop; 
            panelAC.AllowDrop = true;
            panelAC.DragEnter += panelDrop_DragEnter;
            panelAC.DragDrop += panelAC_DragDrop;
        }

        private void panelDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void panelAC_DragDrop(object sender, DragEventArgs e)
        {
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
            manejarArchivosCargados(archivos, archivoCargadoAC, archivosCargadosAC, examinarBTNAC, labelArrastrarAC);
        }

        private void manejarArchivosCargados(string[] archivos, Label lblTitulo, Label lblListado, Button botonExaminar, Label labelArrastrar)
        {
            if (archivos.Length > 0)
            {
                string nombres = string.Join(Environment.NewLine, archivos.Select(a => "• " + Path.GetFileName(a)));

                lblTitulo.Text = "Archivos cargados:";
                lblListado.Text = nombres;

                botonExaminar.Visible = false;
                labelArrastrar.Visible = false;
            }
        }
        private void panelAM_DragDrop(object sender, DragEventArgs e)
        {
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
            manejarArchivosCargados(archivos, archivoCargadoAM, archivosCargadosAM, examinarBTNAM, labelArrastrarAM);
        }
        private void examinarBTNAM_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.Multiselect = true;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                manejarArchivosCargados(dialogo.FileNames, archivoCargadoAM, archivosCargadosAM, examinarBTNAM, labelArrastrarAM);
            }
        }
        private void examinarBTNAC_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.Multiselect = true;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                manejarArchivosCargados(dialogo.FileNames, archivoCargadoAC, archivosCargadosAC, examinarBTNAC, labelArrastrarAC);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
