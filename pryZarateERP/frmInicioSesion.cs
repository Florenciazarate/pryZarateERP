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

            string nombreUsuario, rol;
            bool ok = clsBaseDatos.ValidarUsuario(mail, password, out nombreUsuario, out rol);

            clsBaseDatos.RegistrarAuditoria(mail, ok);

            if (ok)
            {
                this.Hide();
                using (var principal = new frmPrincipal(nombreUsuario, rol, DateTime.Now))
                {
                    principal.ShowDialog();
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
