using System;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Formulario de inicio de sesión: pide usuario y contraseña,
    // valida contra la base de datos y abre el formulario principal si es correcto.
    public partial class frmInicioSesion : Form
    {
        private int intentosFallidos = 0;   // contador de veces que el usuario ingresó mal las credenciales
        private const int MaxIntentos = 3;  // cantidad máxima de intentos antes de bloquear

        public frmInicioSesion()
        {
            InitializeComponent();              // crea todos los controles del Designer
            lblError.Text = string.Empty;       // arranca sin mensaje de error visible
            btnAceptar.Enabled = false;         // el botón empieza deshabilitado hasta que se escriba algo
            this.AcceptButton = btnAceptar;     // presionar Enter equivale a hacer clic en "Ingresar"
        }

        // Se ejecuta cada vez que el usuario escribe en el campo de mail o de contraseña.
        // Habilita el botón solo si ambos campos tienen algo escrito, y borra el error anterior.
        private void ValidarCampos(object sender, EventArgs e)
        {
            if (intentosFallidos >= MaxIntentos) return; // si ya está bloqueado, no hace nada
            btnAceptar.Enabled = txtMail.Text.Trim().Length > 0 && txtContraseña.Text.Length > 0;
            lblError.Text = string.Empty;
        }

        // Se ejecuta cuando el usuario hace clic en "Ingresar" (o presiona Enter)
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario  = txtMail.Text.Trim();
            string password = txtContraseña.Text;

            // Validaciones básicas: verifico que ambos campos tengan algo
            if (usuario.Length == 0)
            {
                lblError.Text = "Ingresá tu usuario (o tu mail).";
                txtMail.Focus();
                return;
            }
            if (password.Length == 0)
            {
                lblError.Text = "Ingresá tu contraseña.";
                txtContraseña.Focus();
                return;
            }

            // Llamo a la base de datos para validar: devuelve true si las credenciales son correctas,
            // y por parámetros "out" devuelve el nombre real, el rol y un motivo de bloqueo (si corresponde)
            string nombreUsuario, rol, motivoBloqueo;
            bool ok = clsBaseDatos.ValidarUsuario(usuario, password, out nombreUsuario, out rol, out motivoBloqueo);

            // Caso especial: el usuario existe pero el personal vinculado está inactivo.
            // No cuenta como intento fallido, solo muestro el mensaje.
            if (!ok && !string.IsNullOrEmpty(motivoBloqueo))
            {
                lblError.Text = motivoBloqueo;
                clsBaseDatos.RegistrarAuditoria(usuario, "Inicio de Sesión", "Bloqueado", motivoBloqueo, false);
                return;
            }

            // Registro en la auditoría si el intento fue exitoso o fallido
            clsBaseDatos.RegistrarAuditoria(
                usuario,
                "Inicio de Sesión",
                ok ? "Inicio exitoso" : "Intento fallido",
                ok ? $"Rol: {rol}" : "Usuario o contraseña incorrectos",
                ok);

            if (ok)
            {
                // Guardo los datos del usuario en la sesión global para que los usen los demás formularios
                SessionInfo.Usuario = nombreUsuario;
                SessionInfo.Rol     = rol;

                this.Hide(); // oculto el login mientras el principal está abierto

                bool cerroSesion;
                using (var principal = new frmPrincipal(SessionInfo.Usuario, rol))
                {
                    principal.ShowDialog();                  // abro el formulario principal y espero a que se cierre
                    cerroSesion = principal.CerrarSesion;   // consulto si se cerró por "Cerrar sesión" o por la X
                }

                if (cerroSesion)
                {
                    // El usuario eligió "Cerrar sesión": limpio los campos y vuelvo a mostrar el login
                    txtMail.Text       = "";
                    txtContraseña.Text = "";
                    lblError.Text      = "";
                    btnAceptar.Enabled = false;
                    this.Show();
                    txtMail.Focus();
                }
                else
                {
                    this.Close(); // cerró con la X => cierro todo
                }
            }
            else
            {
                // Credenciales incorrectas: sumo un intento y muestro cuántos quedan
                intentosFallidos++;

                if (intentosFallidos >= MaxIntentos)
                {
                    btnAceptar.Enabled = false; // deshabilito el botón definitivamente
                    MessageBox.Show("Cuenta bloqueada tras 3 intentos fallidos.", "Acceso bloqueado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int restantes = MaxIntentos - intentosFallidos;
                    lblError.Text = $"Usuario o contraseña incorrectos. Te queda(n) {restantes} intento(s).";
                }
            }
        }
    }
}
