using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmInicioSesion : Form
    {
        private int intentosFallidos = 0;
        private const int MaxIntentos = 3;

        // Guardar valores originales
        private Padding _origPadding;
        private bool _origAutoSize;
        private Size _origPanelSize;

        public frmInicioSesion()
        {
            InitializeComponent();
            lblError.Text = string.Empty;
            btnAceptar.Enabled = false;
            this.AcceptButton = btnAceptar; // Habilitar el botón Aceptar al presionar Enter

            // suscribirse a resize para centrar/ajustar el panel
            this.Resize += FrmInicioSesion_Resize;
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

            // Guardar valores iniciales del panel
            _origPadding = pnlContenedor.Padding;
            _origAutoSize = pnlContenedor.AutoSize;
            _origPanelSize = pnlContenedor.Size;

            // Evitar que el panel se haga más pequeño que su tamaño original (previene superposición)
            pnlContenedor.MinimumSize = _origPanelSize;

            // Centrarlo al iniciar
            CentrarPanel();
        }

        private void FrmInicioSesion_Resize(object sender, EventArgs e)
        {
            CentrarPanel();
        }

        // Centra pnlContenedor dentro del cliente del formulario y ajusta su tamaño cuando el form es pequeño o grande
        private void CentrarPanel()
        {
            // Si el Form está maximizado, hacemos que el panel ocupe un porcentaje razonable del ancho
            if (this.WindowState == FormWindowState.Maximized)
            {
                pnlContenedor.AutoSize = false;

                // Calcular ancho objetivo pero nunca menor que el ancho original del panel
                int candidateWidth = (int)(this.ClientSize.Width * 0.5); // 50% del ancho
                int width = Math.Max(_origPanelSize.Width, Math.Min(candidateWidth, this.ClientSize.Width - 40));

                // Mantener la altura original para evitar que los controles internos se superpongan
                int height = _origPanelSize.Height;

                pnlContenedor.Size = new Size(width, height);
                pnlContenedor.Padding = new Padding(40);
            }
            else
            {
                pnlContenedor.AutoSize = _origAutoSize;
                pnlContenedor.Size = _origPanelSize;
                pnlContenedor.Padding = _origPadding;
            }

            // Calcular posición centrada
            int left = Math.Max(0, (this.ClientSize.Width - pnlContenedor.Width) / 2);
            int top = Math.Max(0, (this.ClientSize.Height - pnlContenedor.Height) / 2);
            pnlContenedor.Location = new Point(left, top);
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
