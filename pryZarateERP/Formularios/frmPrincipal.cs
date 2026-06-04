using System;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Formulario principal del ERP: contiene las pestañas de cada sección.
    // Se abre luego de un login exitoso y se cierra cuando el usuario cierra sesión o la X.
    public partial class frmPrincipal : Form
    {
        private readonly string _rol; // guarda el rol del usuario logueado para usarlo en los métodos

        // El login lee esto al cerrarse:
        // true  => el usuario eligió "Cerrar sesión" → vuelve a la pantalla de login
        // false => cerró con la X → se cierra la aplicación
        public bool CerrarSesion { get; private set; }

        // Constructor: recibe el nombre y el rol del usuario que inició sesión
        public frmPrincipal(string usuario, string rol)
        {
            InitializeComponent(); // crea todos los controles del Designer
            _rol = rol;

            // Completo el encabezado y la barra de estado con los datos del usuario
            lblTitulo.Text    = "Sistema de Gestión";
            lblSubtitulo.Text = usuario + "  |  " + rol;
            lblConectado.Text = $"●  {usuario}  |  {rol}  |  Conectado a las {DateTime.Now:HH:mm}";

            // Pantalla de bienvenida: mensajes centrados que ve cualquier rol al entrar
            lblBienvenida.Text    = "¡Bienvenido, " + usuario + "!";
            lblBienvenidaSub.Text = "Ingresaste como " + rol + ".";

            AplicarPermisos(rol); // muestra u oculta pestañas según el rol

            tabControl.SelectedTab = tabInicio; // siempre arranca en la pestaña de bienvenida

            // Recentra el mensaje de bienvenida cada vez que cambia el tamaño de la pestaña o se muestra el form
            tabInicio.SizeChanged += (s, e) => CentrarBienvenida();
            this.Shown            += (s, e) => CentrarBienvenida();
            CentrarBienvenida();
        }

        // Calcula la posición de los dos labels de bienvenida para que queden centrados en la pestaña
        private void CentrarBienvenida()
        {
            int cx = tabInicio.ClientSize.Width  / 2;
            int cy = tabInicio.ClientSize.Height / 2;
            lblBienvenida.Location    = new System.Drawing.Point(cx - lblBienvenida.Width    / 2, cy - lblBienvenida.Height    - 4);
            lblBienvenidaSub.Location = new System.Drawing.Point(cx - lblBienvenidaSub.Width / 2, cy + 8);
        }

        // Muestra u oculta pestañas según el rol que devolvió la BD:
        // - Auditoría: solo Administrador
        // - Personal:  Administrador y Recursos Humanos
        private void AplicarPermisos(string rol)
        {
            bool esAdmin = string.Equals(rol, "Administrador",    StringComparison.OrdinalIgnoreCase);
            bool esRRHH  = string.Equals(rol, "Recursos Humanos", StringComparison.OrdinalIgnoreCase);

            if (!esAdmin)
                tabControl.TabPages.Remove(tabAuditoria); // si no es admin, oculto la pestaña de auditoría

            if (!esAdmin && !esRRHH)
                tabControl.TabPages.Remove(tabPersonal); // si no es admin ni RRHH, oculto la pestaña de personal
        }

        // Se ejecuta cada vez que el usuario hace clic en una pestaña del tabControl.
        // Carga el formulario correspondiente la PRIMERA vez que se entra a esa pestaña (lazy loading).
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = tabControl.SelectedTab;
            if (tab == null) return;

            // Si la pestaña ya tiene controles adentro, significa que ya fue cargada → no vuelvo a cargarla
            if (tab == tabPersonal && tab.Controls.Count == 0)
            {
                CargarFormulario(tab, new frmPersonalizarPerfil());
                clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Navegación", "Abrir sección", "Personalizar Perfil", true);
            }
            else if (tab == tabAuditoria && tab.Controls.Count == 0)
            {
                CargarFormulario(tab, new frmAuditoria());
                clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Navegación", "Abrir sección", "Auditoría", true);
            }
        }

        // Inserta un formulario dentro de una pestaña haciéndolo ocupar todo el espacio disponible.
        // TopLevel = false y Dock = Fill son necesarios para embeber un Form dentro de un TabPage.
        private void CargarFormulario(TabPage tab, Form form)
        {
            form.TopLevel         = false;             // le digo que no es una ventana independiente
            form.FormBorderStyle  = FormBorderStyle.None; // le saco el borde/título propio
            form.Dock             = DockStyle.Fill;    // que ocupe todo el espacio de la pestaña
            tab.Controls.Add(form);                    // lo agrego como control de la pestaña
            form.Show();                               // lo hago visible
        }

        // Se ejecuta cuando el usuario hace clic en "Cerrar sesión"
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Querés cerrar la sesión?", "Cerrar sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Inicio de Sesión", "Cierre de sesión", "Rol: " + _rol, true);
            CerrarSesion = true; // marco que se cerró por "Cerrar sesión" (no por la X)
            this.Close();        // cierro el formulario principal → el login lee CerrarSesion y decide qué hacer
        }
    }
}
