using System;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            dgvAuditoria.DataSource = clsBaseDatos.ObtenerAuditoria();
        }
    }
}
