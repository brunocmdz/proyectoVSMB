using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace _0._4._0
{
    public partial class Form1 : Form
    {
        private string madreContenido;
        private string nuevaContenido;

        // 🔥 Ahora es automático
        private string connectionString;

        private string nombreMadre = "";
        private string nombreNuevo = "";

        public Form1()
        {
            InitializeComponent();

            // Detecta cualquier servidor SQL disponible
            connectionString = DetectarServidorSQL();
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


        // =====================
        //  CARGAR ARCHIVO MADRE
        // =====================
        private void btnCargarMadre_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Archivos de texto|*.txt";

            if (op.ShowDialog() == DialogResult.OK)
            {
                nombreMadre = Path.GetFileName(op.FileName);
                madreContenido = File.ReadAllText(op.FileName);
                txtMadre.Text = madreContenido;
            }
        }

        // ===========================
        //  CARGAR ARCHIVO A COMPARAR
        // ===========================
        private void btnCargarComparar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Archivos de texto|*.txt";

            if (op.ShowDialog() == DialogResult.OK)
            {
                nombreNuevo = Path.GetFileName(op.FileName);
                nuevaContenido = File.ReadAllText(op.FileName);
                txtComparar.Text = nuevaContenido;
            }
        }

        // ===============================
        //       BOTÓN "COMPARAR"
        // ===============================
        private void btnComparar_Click(object sender, EventArgs e)
        {
            if (madreContenido == null || nuevaContenido == null)
            {
                MessageBox.Show("Debe cargar ambos archivos.");
                return;
            }

            string[] madre = madreContenido.Split('\n');
            string[] nueva = nuevaContenido.Split('\n');

            int max = Math.Max(madre.Length, nueva.Length);

            string resultado = "=== CAMBIOS DETECTADOS ===\r\n\r\n";

            for (int i = 0; i < max; i++)
            {
                string m = i < madre.Length ? madre[i].Trim() : "";
                string n = i < nueva.Length ? nueva[i].Trim() : "";

                if (m != n && (m != "" || n != ""))
                {
                    resultado += $"[LÍNEA {i + 1}]\r\n";
                    resultado += $"ORIGINAL: {m}\r\n";
                    resultado += $"NUEVO:    {n}\r\n\r\n";
                }
            }

            txtResultado.Text = resultado;
        }

        // =======================================
        //     BOTÓN "GENERAR CORRECCIÓN"
        // =======================================
        private void btnCorregir_Click(object sender, EventArgs e)
        {
            if (madreContenido == null || nuevaContenido == null)
            {
                MessageBox.Show("Debe cargar ambos archivos.");
                return;
            }

            string corregido = madreContenido;

            string tipo = ExtraerLinea(nuevaContenido, "tipo");
            string numero = ExtraerLinea(nuevaContenido, "num");
            string fechas = ExtraerFechas(nuevaContenido);
            string titular = ExtraerLinea(nuevaContenido, "titular");
            string codigo = ExtraerLinea(nuevaContenido, "codigo");

            corregido = ReemplazarDato(corregido, "tipo", tipo);
            corregido = ReemplazarDato(corregido, "num", numero);
            corregido = ReemplazarDato(corregido, "fecha", fechas);
            corregido = ReemplazarDato(corregido, "validas", fechas);
            corregido = ReemplazarDato(corregido, "titular", titular);
            corregido = ReemplazarDato(corregido, "codigo", codigo);

            txtResultado.Text = corregido;

            GuardarArchivoEnBD(nombreMadre, nombreNuevo, corregido);
        }

        // =======================================
        //     EXTRACCIÓN DE DATOS VITALES
        // =======================================
        private string ExtraerLinea(string texto, string clave)
        {
            var lineas = texto.Split('\n');

            foreach (string l in lineas)
            {
                if (l.ToLower().Contains(clave))
                {
                    return l.Trim();
                }
            }
            return null;
        }

        private string ExtraerFechas(string texto)
        {
            var match = Regex.Matches(texto, @"\d{2}/\d{2}");

            if (match.Count >= 1)
                return string.Join(" ", match.Cast<Match>().Select(m => m.Value));

            return null;
        }

        // =======================================
        // REEMPLAZAR LÍNEA EN ARCHIVO MADRE
        // =======================================
        private string ReemplazarDato(string texto, string clave, string nuevaLinea)
        {
            if (nuevaLinea == null) return texto;

            string[] lineas = texto.Split('\n');

            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].ToLower().Contains(clave))
                {
                    lineas[i] = nuevaLinea;
                }
            }

            return string.Join("\n", lineas);
        }

        // =======================================
        //       GUARDAR EN BASE DE DATOS
        // =======================================
        private void GuardarArchivoEnBD(string madre, string nuevo, string corregido)
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            int idArchivo;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO ArchivosProcesados (NombreMadre, NombreNuevo, Resultado)
                               OUTPUT INSERTED.Id
                               VALUES (@madre, @nuevo, @resultado);";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@madre", madre);
                    cmd.Parameters.AddWithValue("@nuevo", nuevo);
                    cmd.Parameters.AddWithValue("@resultado", corregido);

                    idArchivo = (int)cmd.ExecuteScalar();
                }
            }

            GuardarDatosTarjeta(idArchivo);
        }

        private void GuardarDatosTarjeta(int idArchivo)
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            string t = nuevaContenido.ToLower();

            string tipo = ExtraerLinea(t, "tipo");
            string num = ExtraerLinea(t, "num");
            string fechas = ExtraerFechas(t);
            string titular = ExtraerLinea(t, "titular");
            string codigo = ExtraerLinea(t, "codigo");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO TarjetasExtraidas 
                               (IdArchivo, TipoTarjeta, Numero, Fecha1, Titular, Codigo)
                               VALUES (@id, @tipo, @num, @fecha, @tit, @cod);";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idArchivo);
                    cmd.Parameters.AddWithValue("@tipo", (object)tipo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@num", (object)num ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha", (object)fechas ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tit", (object)titular ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cod", (object)codigo ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ====================================================
        //             GUARDAR RESULTADO FINAL
        // ====================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResultado.Text))
            {
                MessageBox.Show("No hay contenido para guardar.");
                return;
            }

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Archivos de texto|*.txt";

            if (sd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sd.FileName, txtResultado.Text);
                MessageBox.Show("Archivo guardado.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMadre.Clear();
            txtComparar.Clear();
            txtResultado.Clear();
            madreContenido = null;
            nuevaContenido = null;
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial fh = new FormHistorial();
            fh.ShowDialog();
        }


    }
}
