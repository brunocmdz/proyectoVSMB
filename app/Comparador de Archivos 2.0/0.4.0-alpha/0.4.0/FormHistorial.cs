using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0._4._0
{
    public partial class FormHistorial : Form
    {
        private string connectionString;

        public FormHistorial()
        {
            InitializeComponent();
            connectionString = DetectarServidorSQL();
            CargarHistorial();
        }

        // FUNCION QUE DETECTA AUTOMÁTICAMENTE EL SERVIDOR DISPONIBLE
        private string DetectarServidorSQL()
        {
            // Lista de servidores que suelen existir en cualquier PC
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
                        return cs; // Si funciona, usar este
                    }
                }
                catch
                {
                    // si falla, intenta el siguiente
                }
            }

            MessageBox.Show(
                "No se pudo conectar a ningún servidor SQL.\n" +
                "Asegúrate de tener SQL Server Express o LocalDB instalado.",
                "Error de Conexión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            // Evita que la aplicación crashee
            return "";
        }

        // CARGAR HISTORIAL DE LA BASE DE DATOS
        private void CargarHistorial()
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT Id, NombreMadre, NombreNuevo, Fecha FROM ArchivosProcesados ORDER BY Fecha DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHistorial.DataSource = dt;
                }
            }
        }
        //  VER EL CONTENIDO DE UN ARCHIVO
        private void btnVerContenido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            if (dgvHistorial.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un archivo del historial.");
                return;
            }

            int id = Convert.ToInt32(dgvHistorial.SelectedRows[0].Cells["Id"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT Resultado FROM ArchivosProcesados WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    string contenido = cmd.ExecuteScalar()?.ToString();
                    txtContenido.Text = contenido ?? "No hay información.";
                }
            }
        }
    }
}
