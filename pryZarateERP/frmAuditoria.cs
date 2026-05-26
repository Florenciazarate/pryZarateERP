using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmAuditoria : Form
    {
        private DataTable originalTable;

        public frmAuditoria()
        {
            InitializeComponent();
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            LoadAuditData();
        }

        private void LoadAuditData()
        {
            // Load either file-based or DB-based audit into a DataTable
            try
            {
                var dtFile = AuditLogger.ReadAllAsDataTable();
                if (dtFile.Rows.Count > 0)
                {
                    originalTable = dtFile;
                    dgvAuditoria.DataSource = originalTable;
                    return;
                }
            }
            catch { }

            originalTable = clsBaseDatos.ObtenerAuditoria();
            dgvAuditoria.DataSource = originalTable;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (originalTable == null) return;

            string usuario = txtUsuarioFiltro.Text?.Trim();
            string accion = txtAccion.Text?.Trim();

            var filtered = originalTable.AsEnumerable();

            if (!string.IsNullOrEmpty(usuario))
            {
                filtered = filtered.Where(r => (r["Usuario"]?.ToString() ?? string.Empty).IndexOf(usuario, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrEmpty(accion))
            {
                // Some sources may store action in column named 'Accion' or 'Exitoso' or similar; try to match
                string accionCol = null;
                if (originalTable.Columns.Contains("Accion")) accionCol = "Accion";
                else if (originalTable.Columns.Contains("Exitoso")) accionCol = "Exitoso"; // fallback
                else
                {
                    // Try find a column likely to be action
                    var col = originalTable.Columns.Cast<DataColumn>().FirstOrDefault(c => c.ColumnName.IndexOf("accion", StringComparison.OrdinalIgnoreCase) >= 0 || c.ColumnName.IndexOf("exito", StringComparison.OrdinalIgnoreCase) >= 0 || c.ColumnName.IndexOf("observ", StringComparison.OrdinalIgnoreCase) >= 0);
                    if (col != null) accionCol = col.ColumnName;
                }

                if (!string.IsNullOrEmpty(accionCol))
                {
                    string colName = accionCol;
                    filtered = filtered.Where(r => (r[colName]?.ToString() ?? string.Empty).IndexOf(accion, StringComparison.OrdinalIgnoreCase) >= 0);
                }
            }

            // Date filtering: try find a datetime column
            if (dtpDesde.Checked || dtpHasta.Checked)
            {
                string dateCol = null;
                if (originalTable.Columns.Contains("FechaHora")) dateCol = "FechaHora";
                else
                {
                    var col = originalTable.Columns.Cast<DataColumn>().FirstOrDefault(c => c.DataType == typeof(DateTime) || c.ColumnName.IndexOf("fecha", StringComparison.OrdinalIgnoreCase) >= 0);
                    if (col != null) dateCol = col.ColumnName;
                }

                if (!string.IsNullOrEmpty(dateCol))
                {
                    if (dtpDesde.Checked)
                    {
                        var desde = dtpDesde.Value.Date;
                        filtered = filtered.Where(r => DateTime.TryParse(r[dateCol]?.ToString() ?? string.Empty, out DateTime d) && d.Date >= desde);
                    }
                    if (dtpHasta.Checked)
                    {
                        var hasta = dtpHasta.Value.Date;
                        filtered = filtered.Where(r => DateTime.TryParse(r[dateCol]?.ToString() ?? string.Empty, out DateTime d) && d.Date <= hasta);
                    }
                }
            }

            var result = filtered.CopyToDataTableOrEmpty();
            dgvAuditoria.DataSource = result;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuarioFiltro.Text = string.Empty;
            txtAccion.Text = string.Empty;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;

            if (originalTable != null)
                dgvAuditoria.DataSource = originalTable;
        }
    }
}
