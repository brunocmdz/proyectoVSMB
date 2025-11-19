using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0._4._0
{
    public partial class FormHistorial : Form
    {
        // Cadena de conexión que será detectada automáticamente
        private string connectionString;

        public FormHistorial()
        {
            InitializeComponent();

            // Detecta automáticamente un servidor SQL disponible
            connectionString = DetectarServidorSQL();

            // Carga el historial al abrir el formulario
            CargarHistorial();
        }

        // FUNCIÓN PARA DETECTAR AUTOMÁTICAMENTE UN SERVIDOR SQL DISPONIBLE
        private string DetectarServidorSQL()
        {
            // Lista de servidores SQL comunes que pueden existir en una PC típica
            string[] servidores = new string[]
            {
                @".\SQLEXPRESS",          // SQL Server Express
                @"(localdb)\MSSQLLocalDB", // LocalDB de Visual Studio
                @".",                     // Servidor local por defecto
                @"localhost"              // Otra forma de apuntar al servidor local
            };

            // Intenta conectarse a cada uno hasta que alguno funcione
            foreach (var srv in servidores)
            {
                string cs = $"Server={srv};Database=ComparadorDB;Trusted_Connection=True;";

                try
                {
                    // Intenta establecer conexión
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        return cs;  // Si funciona, se usa este servidor
                    }
                }
                catch
                {
                    // Si falla la conexión, intenta el siguiente servidor
                }
            }

            // Si ninguno funcionó, se muestra un mensaje al usuario
            MessageBox.Show(
                "No se pudo conectar a ningún servidor SQL.\n" +
                "Asegúrate de tener SQL Server Express o LocalDB instalado.",
                "Error de Conexión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            // Retorna cadena vacía para evitar errores posteriores
            return "";
        }

        // CARGAR EL HISTORIAL DESDE LA BASE DE DATOS A UN DATAGRIDVIEW
        private void CargarHistorial()
        {
            // Si no hay cadena de conexión, no hace nada
            if (string.IsNullOrEmpty(connectionString)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Consulta SQL para obtener el historial de archivos procesados
                string sql = "SELECT Id, NombreMadre, NombreNuevo, Fecha " +
                             "FROM ArchivosProcesados ORDER BY Fecha DESC";

                // Adaptador para llenar un DataTable con los datos de la BD
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Muestra los datos en el DataGridView
                    dgvHistorial.DataSource = dt;
                }
            }
        }

        // BOTÓN PARA VER EL CONTENIDO DETALLADO DE UN ARCHIVO SELECCIONADO
        private void btnVerContenido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            // Verifica que el usuario haya seleccionado una fila
            if (dgvHistorial.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un archivo del historial.");
                return;
            }

            // Obtiene el ID del registro seleccionado
            int id = Convert.ToInt32(dgvHistorial.SelectedRows[0].Cells["Id"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Consulta para obtener el contenido guardado del archivo
                string sql = "SELECT Resultado FROM ArchivosProcesados WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Parámetro para evitar inyecciones SQL
                    cmd.Parameters.AddWithValue("@id", id);

                    // Obtiene el resultado como texto
                    string contenido = cmd.ExecuteScalar()?.ToString();

                    // Lo muestra en el TextBox correspondiente
                    txtContenido.Text = contenido ?? "No hay información.";
                }
            }
        }
    }
}
