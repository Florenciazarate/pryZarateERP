using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmAuditoria : Form
    {
        private DataTable tablaOriginal;

        public frmAuditoria()
        {
            InitializeComponent();
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            // Cargo del archivo de auditoría
            tablaOriginal = AuditLogger.ReadAllAsDataTable();

            // Si está vacío, intento cargar de la BD
            if (tablaOriginal.Rows.Count == 0)
            {
                var tablaBD = clsBaseDatos.ObtenerAuditoria();
                if (tablaBD.Rows.Count > 0)
                {
                    tablaOriginal = new DataTable();
                    tablaOriginal.Columns.Add("FechaHora", typeof(DateTime));
                    tablaOriginal.Columns.Add("Usuario", typeof(string));
                    tablaOriginal.Columns.Add("Accion", typeof(string));

                    foreach (DataRow row in tablaBD.Rows)
                    {
                        string accion = Convert.ToBoolean(row["Exitoso"]) ? "Inicio de sesion exitoso" : "Inicio de sesion fallido";
                        tablaOriginal.Rows.Add(row["FechaHora"], row["Usuario"], accion);
                    }
                }
            }

            dgvAuditoria.DataSource = tablaOriginal;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (tablaOriginal == null) return;

            var filtrado = tablaOriginal.AsEnumerable().AsEnumerable();

            string usuario = txtUsuarioFiltro.Text.Trim();
            string accion = txtAccion.Text.Trim();

            if (!string.IsNullOrEmpty(usuario))
                filtrado = filtrado.Where(r => r["Usuario"].ToString().IndexOf(usuario, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrEmpty(accion))
                filtrado = filtrado.Where(r => r["Accion"].ToString().IndexOf(accion, StringComparison.OrdinalIgnoreCase) >= 0);

            if (dtpDesde.Checked)
                filtrado = filtrado.Where(r => r.Field<DateTime>("FechaHora").Date >= dtpDesde.Value.Date);

            if (dtpHasta.Checked)
                filtrado = filtrado.Where(r => r.Field<DateTime>("FechaHora").Date <= dtpHasta.Value.Date);

            var resultado = filtrado.ToList();
            dgvAuditoria.DataSource = resultado.Any() ? resultado.CopyToDataTable() : new DataTable();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuarioFiltro.Text = "";
            txtAccion.Text = "";
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            dgvAuditoria.DataSource = tablaOriginal;
        }
    }
}
