using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // Nuevo: Para la conexión a SQL Server
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
        private string connectionString; // Nuevo: Almacena la cadena de conexión

        public Form1()
        {
            InitializeComponent();

            // Configuración de Drag & Drop para panelAM
            panelAM.AllowDrop = true;
            panelAM.DragEnter += panelDrop_DragEnter;
            panelAM.DragDrop += panelAM_DragDrop;

            // Configuración de Drag & Drop para panelAC
            panelAC.AllowDrop = true;
            panelAC.DragEnter += panelDrop_DragEnter;
            panelAC.DragDrop += panelAC_DragDrop;

            connectionString = DetectarServidorSQL(); // Nuevo: Intenta conectarse al iniciar

            AplicarEstilo();
        }

        private void AplicarEstilo()
        {
            Color fondo = Color.FromArgb(20, 20, 80);
            Color celeste = Color.FromArgb(55, 229, 255);
            Color celesteSuave = Color.FromArgb(120, 240, 255);

            this.BackColor = fondo;


            foreach (var lbl in this.Controls.OfType<Label>())
            {
                lbl.ForeColor = celeste;
                lbl.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
                lbl.BackColor = Color.Transparent;
            }


            Label[] labelsArrastre = { labelArrastrarAM, labelArrastrarAC };

            foreach (var l in labelsArrastre)
            {
                l.AutoSize = false;
                l.Width = 260;          // Ancho seguro
                l.Height = 28;          // Altura exacta
                l.ForeColor = celesteSuave;
                l.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Italic);
                l.BackColor = Color.Transparent;
                l.TextAlign = ContentAlignment.MiddleCenter;

                // Centrarlos dentro del panel
                if (l.Parent != null)
                {
                    l.Left = (l.Parent.Width - l.Width) / 2;
                }
            }


            Button[] botonesExaminar = { examinarBTNAM, examinarBTNAC };

            foreach (var btn in botonesExaminar)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.BorderColor = celeste;
                btn.ForeColor = celeste;
                btn.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
                btn.BackColor = Color.FromArgb(30, 35, 120);

                btn.Size = new Size(150, 45);
                btn.AutoSize = false;
                btn.AutoEllipsis = false;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Cursor = Cursors.Hand;

                if (btn.Parent != null)
                {
                    btn.Left = (btn.Parent.Width - btn.Width) / 2;
                }

            }


            compararBTN.BackColor = Color.FromArgb(0, 140, 255);
            compararBTN.ForeColor = Color.White;
            compararBTN.FlatAppearance.BorderSize = 0;
            compararBTN.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            compararBTN.Size = new Size(180, 55);
            compararBTN.Cursor = Cursors.Hand;


            descargarBTN.FlatStyle = FlatStyle.Standard;
            descargarBTN.BackColor = SystemColors.Control;
            descargarBTN.ForeColor = Color.Black;
            descargarBTN.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            descargarBTN.Text = "Descargar";
            descargarBTN.AutoSize = true;
            descargarBTN.Cursor = Cursors.Hand;

            // Estilo para el botón de historial (historialBTN)
            historialBTN.FlatStyle = FlatStyle.Standard;
            historialBTN.BackColor = SystemColors.Control;
            historialBTN.ForeColor = Color.Black;
            historialBTN.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            historialBTN.Text = "Historial";
            historialBTN.AutoSize = true;
            historialBTN.Cursor = Cursors.Hand;


            AplicarEstiloPanel(panelAM);
            AplicarEstiloPanel(panelAC);
        }


        private void AplicarEstiloPanel(Panel panel)
        {
            Color celesteSuave = Color.FromArgb(120, 240, 255);

            panel.BackColor = Color.Transparent;
            panel.BorderStyle = BorderStyle.None;

            panel.Paint += (s, e) =>
            {
                Pen p = new Pen(celesteSuave, 2);
                p.DashPattern = new float[] { 5, 5 };
                e.Graphics.DrawRectangle(p, 5, 5, panel.Width - 10, panel.Height - 10);
            };
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

                // Corrección de formato
                var lineas = File.ReadAllLines(rutaOriginal).Select(l => ArreglarFormatoLinea(l)).ToArray();
                string contenidoCorregido = string.Join(Environment.NewLine, lineas); // Contenido para guardar en DB

                // Guardado de archivo corregido localmente
                File.WriteAllLines(rutaCorregida, lineas, Encoding.UTF8);
                rutasArchivosCorregidos.Add(rutaCorregida);

                // -----------------------------------------------------------------
                // 💾 NUEVA LÓGICA: GUARDAR EN BASE DE DATOS
                // -----------------------------------------------------------------
                if (!string.IsNullOrEmpty(connectionString))
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string nombreOriginal = Path.GetFileName(rutaOriginal);
                            string nombreCorregido = Path.GetFileName(rutaCorregida);

                            // Consulta de inserción usando parámetros para prevenir inyección SQL
                            string sql = "INSERT INTO ArchivosProcesados (NombreMadre, NombreNuevo, Resultado) VALUES (@nombreMadre, @nombreNuevo, @resultado)";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@nombreMadre", nombreOriginal);
                                cmd.Parameters.AddWithValue("@nombreNuevo", nombreCorregido);
                                cmd.Parameters.AddWithValue("@resultado", contenidoCorregido);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Muestra un error si la inserción falla, pero permite que el resto de archivos se procesen
                        MessageBox.Show($"Error al guardar en la base de datos el archivo {Path.GetFileName(rutaOriginal)}: {ex.Message}", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // -----------------------------------------------------------------
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

        private void historialBTN_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario de historial
            FormHistorial formHistorial = new FormHistorial();

            // Muestra el formulario como un diálogo modal
            formHistorial.ShowDialog();
        }


        // ---------------------------------------------------------------
        // 🔍 DETECTA AUTOMÁTICAMENTE EL SERVIDOR SQL DISPONIBLE
        // ---------------------------------------------------------------
        private string DetectarServidorSQL()
        {
            string[] servidores = new string[]
            {
                @".\SQLEXPRESS",
                @"(localdb)\MSSQLLocalDB",
                @".",
                @"localhost"
            };

            foreach (var srv in servidores)
            {
                string cs = $"Server={srv};Database=ComparadorDB;Trusted_Connection=True;";

                try
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();

                        // 🔥 MENSAJE DE CONEXIÓN EXITOSA
                        MessageBox.Show(
                            $"✔ Conectado exitosamente a:\n\nServidor: {srv}\nBase de datos: ComparadorDB",
                            "Conexión Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        return cs;
                    }
                }
                catch
                {
                    // Si falla pasa al siguiente
                }
            }

            MessageBox.Show(
                "❌ No se pudo conectar a ningún servidor SQL.\n" +
                "Asegúrese de tener instalado SQL Server Express o LocalDB.",
                "Error de conexión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return "";
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
                @"<<<<titular>>:>>([A-Za-zÁÉÍÓÚáéíóúÑñ]{2,})<<([A-Za-zÁÉÍÓÚáéíóúÑñ]{2,})>>>>",
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