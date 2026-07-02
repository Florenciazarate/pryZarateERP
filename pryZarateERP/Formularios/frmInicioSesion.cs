using System;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Formulario de inicio de sesión: pide usuario y contraseña,
    // valida contra la base de datos y abre el formulario principal si es correcto.
    public partial class frmInicioSesion : Form
    {
        private int intentosFallidos = 0;   // intentos fallidos en esta corrida de la app
        private const int MaxIntentos = 3;  // a los 3 intentos fallidos se cierra la aplicación

        public frmInicioSesion()
        {
            InitializeComponent();              // crea todos los controles del Designer
            lblError.Text = string.Empty;       // arranca sin mensaje de error visible
            btnAceptar.Enabled = false;         // el botón empieza deshabilitado hasta que se escriba algo
            this.AcceptButton = btnAceptar;     // presionar Enter equivale a hacer clic en "Ingresar"
        }

        // Muestra u oculta la contraseña según el estado del checkbox
        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = chkMostrar.Checked; // si está marcado, muestro la contraseña; si no, la oculto
            txtContraseña.UseSystemPasswordChar = !mostrar;    // false = usa PasswordChar
            txtContraseña.PasswordChar = mostrar ? '\0' : '●'; // '\0' = sin máscara; '●' = oculto
        }

        // Se ejecuta cada vez que el usuario escribe en el campo de mail o de contraseña.
        // Habilita el botón solo si ambos campos tienen algo escrito, y borra el error anterior.
        private void ValidarCampos(object sender, EventArgs e)
        {
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

            // Llamo a la base de datos para validar. Devuelve un ResultadoLogin y, por parámetros "out",
            // el nombre real y el rol (si fue Ok) o un mensaje para mostrar (si no lo fue).
            string nombreUsuario, rol, mensaje;
            ResultadoLogin resultado;
            try
            {
                resultado = clsBaseDatos.ValidarUsuario(usuario, password, out nombreUsuario, out rol, out mensaje);
            }
            catch (Exception ex)
            {
                // Error real de conexión/base: lo muestro como tal, NO como "credenciales incorrectas".
                lblError.Text = "No se pudo conectar con la base de datos. " + ex.Message;
                return;
            }

            switch (resultado)
            {
                case ResultadoLogin.Ok:
                    intentosFallidos = 0; // login correcto: reinicio el contador
                    // Registro el nombre real del usuario (no lo que tipeó, que puede ser el mail),
                    // para que el filtro por usuario de la auditoría encuentre también estos eventos.
                    clsBaseDatos.RegistrarAuditoria(nombreUsuario, "Inicio de Sesión", "Inicio exitoso", $"Rol: {rol}", true);
                    IngresarAlSistema(nombreUsuario, rol);
                    break;

                case ResultadoLogin.PersonalInactivo:
                    // El usuario existe pero su empleado está inactivo: no cuenta como intento fallido.
                    lblError.Text = mensaje;
                    clsBaseDatos.RegistrarAuditoria(usuario, "Inicio de Sesión", "Bloqueado", mensaje, false);
                    break;

                default: // ResultadoLogin.Invalido: usuario o contraseña incorrectos
                    intentosFallidos++;
                    int restantes = MaxIntentos - intentosFallidos;

                    if (restantes > 0)
                    {
                        // Todavía le quedan intentos: se lo aviso claramente.
                        lblError.Text = restantes == 1
                            ? "Usuario o contraseña incorrectos. Te queda 1 intento."
                            : $"Usuario o contraseña incorrectos. Te quedan {restantes} intentos.";
                        clsBaseDatos.RegistrarAuditoria(usuario, "Inicio de Sesión", "Intento fallido",
                            $"Intento {intentosFallidos} de {MaxIntentos}", false);
                    }
                    else
                    {
                        // Se agotaron los 3 intentos: aviso y cierro la aplicación.
                        clsBaseDatos.RegistrarAuditoria(usuario, "Inicio de Sesión", "Bloqueo",
                            "Se cerró la aplicación por 3 intentos fallidos.", false);
                        MessageBox.Show("Demasiados intentos fallidos. Se cerrará la aplicación.",
                            "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close(); // como es el formulario principal, cerrarlo cierra toda la aplicación
                    }
                    break;
            }
        }

        // Abre el formulario principal y, al cerrarse, decide si volver al login o cerrar la app.
        private void IngresarAlSistema(string nombreUsuario, string rol)
        {
            // Guardo los datos del usuario en la sesión global para que los usen los demás formularios
            SessionInfo.Usuario = nombreUsuario;
            SessionInfo.Rol     = rol;

            this.Hide(); // oculto el login mientras el principal está abierto

            bool cerroSesion;
            using (var principal = new frmPrincipal(SessionInfo.Usuario, rol))
            {
                principal.ShowDialog();               // abro el formulario principal y espero a que se cierre
                cerroSesion = principal.CerrarSesion;  // consulto si se cerró por "Cerrar sesión" o por la X
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
    }
}
