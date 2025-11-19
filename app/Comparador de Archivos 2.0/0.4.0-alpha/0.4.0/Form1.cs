using System;
using System.Collections.Generic;
using System.Data.SqlClient; // Para la conexión a SQL Server
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _0._4._0
{
    public partial class Form1 : Form
    {
        // Almacena las rutas de los archivos cargados en el panelAC
        private string[] rutasArchivosAC;

        // Lista para almacenar las rutas de los archivos corregidos
        private List<string> rutasArchivosCorregidos = new List<string>();

        // Cadena de conexión a la base de datos SQL Server
        private string connectionString;

        public Form1()
        {
            InitializeComponent();

            // Configuración de Drag & Drop para el panelAM
            panelAM.AllowDrop = true; // Permite arrastrar y soltar archivos
            panelAM.DragEnter += panelDrop_DragEnter; // Evento al entrar un archivo
            panelAM.DragDrop += panelAM_DragDrop; // Evento al soltar un archivo

            // Configuración de Drag & Drop para el panelAC
            panelAC.AllowDrop = true; // Permite arrastrar y soltar archivos
            panelAC.DragEnter += panelDrop_DragEnter; // Evento al entrar un archivo
            panelAC.DragDrop += panelAC_DragDrop; // Evento al soltar un archivo

            // Detecta automáticamente el servidor SQL disponible al iniciar
            connectionString = DetectarServidorSQL();
        }

        // Evento que se ejecuta cuando un archivo entra en un panel
        private void panelDrop_DragEnter(object sender, DragEventArgs e)
        {
            // Verifica si los datos arrastrados son archivos y permite copiarlos
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        // Evento que se ejecuta al soltar archivos en el panelAC
        private void panelAC_DragDrop(object sender, DragEventArgs e)
        {
            // Obtiene las rutas de los archivos arrastrados
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Maneja los archivos cargados en el panelAC
            manejarArchivosCargados(archivos, archivoCargadoAC, archivosCargadosAC, examinarBTNAC, labelArrastrarAC);
        }

        // Evento que se ejecuta al soltar archivos en el panelAM
        private void panelAM_DragDrop(object sender, DragEventArgs e)
        {
            // Obtiene las rutas de los archivos arrastrados
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Maneja los archivos cargados en el panelAM
            manejarArchivosCargados(archivos, archivoCargadoAM, archivosCargadosAM, examinarBTNAM, labelArrastrarAM);
        }

        // Maneja los archivos cargados en un panel específico
        private void manejarArchivosCargados(string[] archivos, Label lblTitulo, Label lblListado, Button botonExaminar, Label labelArrastrar)
        {
            if (archivos.Length > 0)
            {
                // Muestra los nombres de los archivos cargados en el panel
                string nombres = string.Join(Environment.NewLine, archivos.Select(a => "• " + Path.GetFileName(a)));
                lblTitulo.Text = "Archivos cargados:";
                lblListado.Text = nombres;

                // Oculta el botón de examinar y el texto de arrastrar
                botonExaminar.Visible = false;
                labelArrastrar.Visible = false;

                // Si los archivos se cargaron en el panelAC, guarda las rutas
                if (lblTitulo == archivoCargadoAC)
                    rutasArchivosAC = archivos;
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Examinar" del panelAM
        private void examinarBTNAM_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt", // Filtra solo archivos .txt
                Multiselect = true // Permite seleccionar múltiples archivos
            };

            // Si el usuario selecciona archivos, los maneja
            if (dialogo.ShowDialog() == DialogResult.OK)
                manejarArchivosCargados(dialogo.FileNames, archivoCargadoAM, archivosCargadosAM, examinarBTNAM, labelArrastrarAM);
        }

        // Evento que se ejecuta al hacer clic en el botón "Examinar" del panelAC
        private void examinarBTNAC_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt", // Filtra solo archivos .txt
                Multiselect = true // Permite seleccionar múltiples archivos
            };

            // Si el usuario selecciona archivos, los maneja
            if (dialogo.ShowDialog() == DialogResult.OK)
                manejarArchivosCargados(dialogo.FileNames, archivoCargadoAC, archivosCargadosAC, examinarBTNAC, labelArrastrarAC);
        }

        // Evento que se ejecuta al hacer clic en el botón "Comparar"
        private void compararBTN_Click(object sender, EventArgs e)
        {
            // Verifica si hay archivos cargados en el panelAC
            if (rutasArchivosAC == null || rutasArchivosAC.Length == 0)
            {
                MessageBox.Show("No hay archivos para comparar.");
                return;
            }

            rutasArchivosCorregidos.Clear(); // Limpia la lista de archivos corregidos

            foreach (string rutaOriginal in rutasArchivosAC)
            {
                string carpeta = Path.GetDirectoryName(rutaOriginal); // Obtiene la carpeta del archivo
                string nombre = Path.GetFileNameWithoutExtension(rutaOriginal); // Obtiene el nombre sin extensión
                string extension = Path.GetExtension(rutaOriginal); // Obtiene la extensión
                string rutaCorregida = Path.Combine(carpeta, nombre + "C" + extension); // Genera la ruta del archivo corregido

                // Corrige el formato de las líneas del archivo
                var lineas = File.ReadAllLines(rutaOriginal).Select(l => ArreglarFormatoLinea(l)).ToArray();
                string contenidoCorregido = string.Join(Environment.NewLine, lineas); // Une las líneas corregidas

                // Guarda el archivo corregido localmente
                File.WriteAllLines(rutaCorregida, lineas, Encoding.UTF8);
                rutasArchivosCorregidos.Add(rutaCorregida);

                // Guarda el archivo corregido en la base de datos
                if (!string.IsNullOrEmpty(connectionString))
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string nombreOriginal = Path.GetFileName(rutaOriginal);
                            string nombreCorregido = Path.GetFileName(rutaCorregida);

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
                        MessageBox.Show($"Error al guardar en la base de datos el archivo {Path.GetFileName(rutaOriginal)}: {ex.Message}", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Muestra los nombres de los archivos corregidos
            string nombresCorregidos = string.Join(Environment.NewLine, rutasArchivosCorregidos.Select(r => "• " + Path.GetFileName(r)));
            archivoACR.Text = nombresCorregidos;
        }

        // Evento que se ejecuta al hacer clic en el botón "Descargar"
        private void descargarBTN_Click(object sender, EventArgs e)
        {
            // Verifica si hay archivos corregidos para descargar
            if (rutasArchivosCorregidos == null || rutasArchivosCorregidos.Count == 0)
            {
                MessageBox.Show("No hay archivos corregidos para descargar.");
                return;
            }

            FolderBrowserDialog dialogo = new FolderBrowserDialog
            {
                Description = "Seleccioná la carpeta de destino"
            };

            // Si el usuario selecciona una carpeta, copia los archivos corregidos
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

        // Evento que se ejecuta al hacer clic en el botón "Historial"
        private void historialBTN_Click(object sender, EventArgs e)
        {
            // Abre el formulario de historial como un diálogo modal
            FormHistorial formHistorial = new FormHistorial();
            formHistorial.ShowDialog();
        }

        // Detecta automáticamente el servidor SQL disponible
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
                        MessageBox.Show($"Conectado exitosamente a:\n\nServidor: {srv}\nBase de datos: ComparadorDB", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return cs;
                    }
                }
                catch
                {
                    // Si falla, intenta con el siguiente servidor
                }
            }

            MessageBox.Show("No se pudo conectar a ningún servidor SQL.\nAsegúrese de tener instalado SQL Server Express o LocalDB.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "";
        }

        // Corrige el formato de una línea de texto
        private static string ArreglarFormatoLinea(string linea)
        {
            if (string.IsNullOrWhiteSpace(linea)) return linea;

            // Lógica para corregir bordes, patrones y otros formatos
            // ...
            return linea.Trim();
        }
    }
}