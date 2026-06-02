using System;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal(string usuario, string rol, DateTime fechaLogin) // Agrega parámetros para personalizar el mensaje de bienvenida
        {
            InitializeComponent();
            lblTitulo.Text = "Bienvenido, " + usuario;
            lblSubtitulo.Text = "Rol: " + rol + "  |  " + fechaLogin.ToString("dd/MM/yyyy HH:mm");
            CargarFormulario(tabPersonal, new frmPersonalizarPerfil());
            clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Navegación", "Abrir sección", "Personalizar Perfil", true);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = tabControl.SelectedTab;
            tab.Controls.Clear();

            if (tab == tabPersonal) // Si el tab seleccionado es el de Personal, carga el formulario correspondiente
            {
                CargarFormulario(tab, new frmPersonalizarPerfil());
                clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Navegación", "Abrir sección", "Personalizar Perfil", true);
            }
            else if (tab == tabAuditoria)
            {
                CargarFormulario(tab, new frmAuditoria());
                clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Navegación", "Abrir sección", "Auditoria", true);
            }
        }

        private void CargarFormulario(TabPage tab, Form form) // Método para cargar un formulario dentro de un TabPage
        {
            form.TopLevel = false; // Permite que el formulario se muestre dentro del TabPage
            form.FormBorderStyle = FormBorderStyle.None; // Elimina los bordes del formulario para que se integre mejor
            form.Dock = DockStyle.Fill; // Hace que el formulario ocupe todo el espacio del TabPage
            tab.Controls.Add(form); // Agrega el formulario al TabPage
            form.Show(); 
        }
    }
}
