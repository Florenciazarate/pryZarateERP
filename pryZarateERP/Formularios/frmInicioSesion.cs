using System;
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
            // Cargo los perfiles de la BD en el combo
            var tablaPerfiles = clsBaseDatos.ObtenerPerfiles();
            cmbPerfil.DataSource = tablaPerfiles;
            cmbPerfil.DisplayMember = "Perfil";   // La columna que se MUESTRA en el combo
            cmbPerfil.ValueMember = "Perfil";      // La columna que se USA como valor
            cmbPerfil.SelectedIndex = -1;          // Que arranque sin nada seleccionado
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtMail.Text.Trim(); // Asumo que el mail es el usuario
            string password = txtContraseña.Text; 
            string perfilElegido = cmbPerfil.Text; // Obtengo el perfil seleccionado como texto

            if (string.IsNullOrEmpty(perfilElegido))
            {
                lblError.Text = "Seleccioná un perfil.";
                return;
            }

            string nombreUsuario, rol; // Variables para recibir el nombre y rol desde la validación
            bool ok = clsBaseDatos.ValidarUsuario(usuario, password, perfilElegido, out nombreUsuario, out rol); // Ahora también valida el perfil
            clsBaseDatos.RegistrarAuditoria(
                usuario,
                "Inicio de Sesión",
                ok ? "Inicio exitoso" : "Intento fallido",
                $"Perfil: {perfilElegido}",
                ok);

            if (ok)
            {
                // Guardar usuario en sesión
                SessionInfo.Usuario = string.IsNullOrEmpty(nombreUsuario) ? usuario : nombreUsuario;

                this.Hide();

                if (perfilElegido == "Administrador")
                {
                    using (var principal = new frmPrincipal(nombreUsuario, rol, DateTime.Now)) // Paso el nombre, rol y fecha al frmPrincipal
                    {
                        principal.ShowDialog();
                    }
                }
                else if (perfilElegido == "Recursos Humanos")
                {
                    using (var perfil = new frmPersonalizarPerfil()) 
                    {
                        perfil.ShowDialog();
                    }
                }

                this.Close();
            }
            else
            {
                intentosFallidos++;

                if (intentosFallidos >= MaxIntentos)
                {
                    lblError.Text = "Cuenta bloqueada tras 3 intentos fallidos.";
                    btnAceptar.Enabled = false;
                }
                else
                {
                    lblError.Text = "Usuario, contraseña o perfil incorrecto.";
                }
            }
        }
    }
}
