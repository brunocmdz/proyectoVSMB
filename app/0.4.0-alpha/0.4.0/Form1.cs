using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0._4._0
{
    public partial class Form1 : Form
    {
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
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void panelAC_DragDrop(object sender, DragEventArgs e)
        {
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
            manejarArchivosCargados(archivos, archivoCargadoAC, archivosCargadosAC, examinarBTNAC, labelArrastrarAC);
        }

        private void panelAM_DragDrop(object sender, DragEventArgs e)
        {
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
            manejarArchivosCargados(archivos, archivoCargadoAM, archivosCargadosAM, examinarBTNAM, labelArrastrarAM);
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

        private void examinarBTNAM_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.Multiselect = true;
            if (dialogo.ShowDialog() == DialogResult.OK)
                manejarArchivosCargados(dialogo.FileNames, archivoCargadoAM, archivosCargadosAM, examinarBTNAM, labelArrastrarAM);
        }

        private void examinarBTNAC_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.Multiselect = true;
            if (dialogo.ShowDialog() == DialogResult.OK)
                manejarArchivosCargados(dialogo.FileNames, archivoCargadoAC, archivosCargadosAC, examinarBTNAC, labelArrastrarAC);
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

                var lineas = File.ReadAllLines(rutaOriginal).Select(l => ArreglarFormatoLinea(l)).ToArray();

                File.WriteAllLines(rutaCorregida, lineas, Encoding.UTF8);
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

        private static readonly char[] BordesPermitidos = new[] { '°', '_', '/', '=', '<', '>', '-', };

        private static string ArreglarFormatoLinea(string linea)
        {
            if (string.IsNullOrWhiteSpace(linea)) return linea;

            char? bordeChar = null;
            int runInicio = 0, runFin = 0;

            if (linea.Length > 0 && BordesPermitidos.Contains(linea[0]))
            {
                char c0 = linea[0];
                int i = 0;
                while (i < linea.Length && linea[i] == c0) { runInicio++; i++; }
                bordeChar = c0;
            }

            if (linea.Length > 0 && BordesPermitidos.Contains(linea[linea.Length - 1]))
            {
                char cF = linea[linea.Length - 1];
                int j = linea.Length - 1;
                while (j >= 0 && linea[j] == cF) { runFin++; j--; }
                if (bordeChar == null) bordeChar = cF;
            }

            string inner = linea;
            if (runInicio > 0)
                inner = inner.Substring(runInicio);
            if (runFin > 0)
                inner = inner.Substring(0, inner.Length - runFin);

            inner = Regex.Replace(inner, @"[°_/=<>-]{3,}", m => m.Value.Substring(0, 2));

            if (inner.IndexOf("num", StringComparison.OrdinalIgnoreCase) >= 0 ||
                inner.IndexOf("tarjeta", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                inner = Regex.Replace(inner, @"(?<!/)/(?!/)", "//");
            }

            inner = Regex.Replace(inner, @"(\b\d{1,2})\D{1,4}(\d{2}\b)", m =>
            {
                if (int.TryParse(m.Groups[1].Value, out int mes) && int.TryParse(m.Groups[2].Value, out int anio))
                {
                    if (mes >= 1 && mes <= 12 && anio >= 0 && anio <= 99)
                        return $"{mes:00}/{anio:00}";
                }
                return m.Value;
            });

            inner = Regex.Replace(inner, @"[/]{3,}", "//");

            inner = Regex.Replace(inner,
                @"<+.*?titular.*?:.*?([A-Za-zÁÉÍÓÚáéíóúÑñ]{2,})[<>\s]+([A-Za-zÁÉÍÓÚáéíóúÑñ]{2,}).*?>+",
                m =>
                {
                    string nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.Groups[1].Value.ToLower());
                    string apellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.Groups[2].Value.ToLower());
                    return $"<<<<titular>>:>>{nombre}<<{apellido}>>>>";
                }, RegexOptions.IgnoreCase);

            inner = Regex.Replace(inner, @"([<>{}_=/\-])\1{4,}", "$1$1$1$1");

            string resultado = inner;
            if (bordeChar.HasValue)
            {
                string borde = new string(bordeChar.Value, 4);
                resultado = borde + inner + borde;
            }

            return resultado.Trim();
        }
    }
}
