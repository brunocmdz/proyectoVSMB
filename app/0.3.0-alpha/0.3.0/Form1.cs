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

namespace _0._3._0
{
    public partial class Form1 : Form
    {
        private string rutaArchivoCargado;
        private string[] rutasArchivosAC;
        private List<string> rutasArchivosCorregidos = new List<string>();
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
                if (lblTitulo == archivoCargadoAC)
                    rutasArchivosAC = archivos;
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

        private void compararBTN_Click(object sender, EventArgs e)
        {
            if (rutasArchivosAC == null || rutasArchivosAC.Length == 0)
            {
                MessageBox.Show("No hay archivos para comparar.");
                return;
            }

            rutasArchivosCorregidos.Clear(); 

            foreach (string rutaOriginal in rutasArchivosAC)
            {
                string carpeta = Path.GetDirectoryName(rutaOriginal);
                string nombre = Path.GetFileNameWithoutExtension(rutaOriginal);
                string extension = Path.GetExtension(rutaOriginal);
                string rutaCorregida = Path.Combine(carpeta, nombre + "C" + extension);

                File.Copy(rutaOriginal, rutaCorregida, true);

                rutasArchivosCorregidos.Add(rutaCorregida);
            }

            string nombresCorregidos = string.Join(Environment.NewLine, rutasArchivosCorregidos.Select(r => "• " + Path.GetFileName(r)));
            archivoACR.Text = nombresCorregidos;
        }

        private void descargarBTN_Click(object sender, EventArgs e)
        {
            if (rutasArchivosCorregidos == null || rutasArchivosCorregidos.Count == 0)
            {
                MessageBox.Show("No hay archivos corregidos para descargar.");
                return;
            }

            FolderBrowserDialog dialogo = new FolderBrowserDialog();
            dialogo.Description = "Seleccioná la carpeta de destino";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string destino = dialogo.SelectedPath;

                foreach (string ruta in rutasArchivosCorregidos)
                {
                    string nombreArchivo = Path.GetFileName(ruta);
                    string destinoFinal = Path.Combine(destino, nombreArchivo);
                    File.Copy(ruta, destinoFinal, true);
                }

                MessageBox.Show("Archivos descargados correctamente.");
            }
        }
    }
}
