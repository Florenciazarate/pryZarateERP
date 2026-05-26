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
            // Prefer file-based auditoria if available, otherwise fall back to DB
            try
            {
                var dt = AuditLogger.ReadAllAsDataTable();
                if (dt.Rows.Count > 0)
                {
                    dgvAuditoria.DataSource = dt;
                    return;
                }
            }
            catch { }

            dgvAuditoria.DataSource = clsBaseDatos.ObtenerAuditoria(); // Cargar los datos de auditoría en el DataGridView al cargar el formulario
        }
    }
}
