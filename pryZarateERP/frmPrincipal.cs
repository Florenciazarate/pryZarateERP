using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmPrincipal : Form
    {
        private Label tabActivo;

        public frmPrincipal(string usuario, string rol, DateTime fechaLogin)
        {
            InitializeComponent();
            lblTitulo.Text = "Bienvenido, " + usuario;
            lblSubtitulo.Text = "Rol: " + rol + "  |  " + fechaLogin.ToString("dd/MM/yyyy HH:mm");

            // Arranca en la pestaña Personal
            MarcarActivo(lblTabPersonal);
            MostrarFormulario(new frmPersonalizarPerfil());
        }

        // ── Navegación ──

        private void lblTabPersonal_Click(object sender, EventArgs e)
        {
            MarcarActivo(lblTabPersonal);
            MostrarFormulario(new frmPersonalizarPerfil());
        }

        private void lblTabAuditoria_Click(object sender, EventArgs e)
        {
            MarcarActivo(lblTabAuditoria);
            MostrarFormulario(new frmAuditoria());
        }

        // Pinta el tab activo (blanco + bold + indicador debajo)
        private void MarcarActivo(Label lbl)
        {
            // Desactivo el anterior
            if (tabActivo != null)
            {
                tabActivo.ForeColor = Color.FromArgb(148, 163, 184);
                tabActivo.Font = new Font("Segoe UI", 10F);
            }

            // Activo el nuevo
            tabActivo = lbl;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            // Muevo el indicador violeta debajo del label activo
            pnlIndicador.Location = new Point(lbl.Location.X, 34);
            pnlIndicador.Size = new Size(lbl.Width, 3);
        }

        // Carga un formulario hijo dentro del panel de contenido
        private void MostrarFormulario(Form form)
        {
            pnlContenido.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(form);
            form.Show();
        }
    }
}
