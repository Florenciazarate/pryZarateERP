using System;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal(string usuario, string rol, DateTime fechaLogin)
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

            if (tab == tabPersonal)
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

        private void CargarFormulario(TabPage tab, Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tab.Controls.Add(form);
            form.Show();
        }
    }
}
