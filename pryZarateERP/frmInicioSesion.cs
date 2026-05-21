using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmInicioSesion : Form
    {
        private int intentosFallidos = 0;
        private const int MaxIntentos = 3;

        public frmInicioSesion()
        {
            InitializeComponent();
            lblError.Text = string.Empty;
            btnAceptar.Enabled = false;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            if (intentosFallidos >= MaxIntentos) return;
            btnAceptar.Enabled = txtMail.Text.Trim().Length > 0 && txtContraseña.Text.Length > 0;
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            clsBaseDatos.CrearTablaAuditoriaSiNoExiste();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mail = txtMail.Text.Trim();
            string password = txtContraseña.Text;

            string nombreUsuario, rol; // Variables para almacenar el nombre de usuario y rol obtenidos de la base de datos
            bool ok = clsBaseDatos.ValidarUsuario(mail, password, out nombreUsuario, out rol); // Validar el usuario y obtener su nombre y rol
            clsBaseDatos.RegistrarAuditoria(mail, ok); // Registrar el intento de inicio de sesión en la auditoría

            if (ok) // Si la validación es exitosa, abrir el formulario principal
            {
                this.Hide();
                using (var principal = new frmPrincipal(nombreUsuario, rol, DateTime.Now)) // Pasar el nombre de usuario, rol y fecha de inicio de sesión al formulario principal
                {
                    principal.ShowDialog(); // Mostrar el formulario principal como un diálogo modal
                }
                this.Close();
            }
            else
            {
                intentosFallidos++;
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = intentosFallidos >= MaxIntentos
                    ? "Cuenta bloqueada tras 3 intentos fallidos."
                    : "Mail o contraseña incorrecta.";
                btnAceptar.Enabled = intentosFallidos < MaxIntentos;
            }
        }
    }
}
