using System;
using System.Drawing;
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
            lblEstado.Text = "Conectado al ERP";
            lblEstado.ForeColor = Color.ForestGreen;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dgvJugadores.DataSource = clsBaseDatos.ObtenerAuditoria();
        }
    }
}
