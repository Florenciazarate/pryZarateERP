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
            cmbExitosoFiltro.Items.Clear();
            cmbExitosoFiltro.Items.Add("Todos");
            cmbExitosoFiltro.Items.Add("Inicio Exitoso");
            cmbExitosoFiltro.Items.Add("Intento Fallido");
            cmbExitosoFiltro.SelectedIndex = 0;

            CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            var tablaBD = clsBaseDatos.ObtenerAuditoria();
            tablaOriginal = new DataTable();
            tablaOriginal.Columns.Add("FechaHora", typeof(DateTime));
            tablaOriginal.Columns.Add("Usuario", typeof(string));
            tablaOriginal.Columns.Add("Accion", typeof(string));
            tablaOriginal.Columns.Add("Resultado", typeof(string));
            tablaOriginal.Columns.Add("Detalle", typeof(string));

            foreach (DataRow row in tablaBD.Rows)
            {
                string resultado = Convert.ToBoolean(row["Exitoso"]) ? "Exitoso" : "Fallido";
                tablaOriginal.Rows.Add(
                    row["FechaHora"],
                    row["Usuario"],
                    row["Accion"],
                    resultado,
                    row["Detalle"]);
            }

            dgvAuditoria.DataSource = tablaOriginal;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (tablaOriginal == null) return;

            var filtrado = tablaOriginal.AsEnumerable();

            string usuario = txtUsuarioFiltro.Text.Trim();
            if (!string.IsNullOrEmpty(usuario))
                filtrado = filtrado.Where(r => r["Usuario"].ToString().IndexOf(usuario, StringComparison.OrdinalIgnoreCase) >= 0);

            string seleccion = cmbExitosoFiltro.SelectedItem?.ToString() ?? "Todos";
            if (seleccion == "Inicio Exitoso")
                filtrado = filtrado.Where(r => r["Resultado"].ToString() == "Exitoso");
            else if (seleccion == "Intento Fallido")
                filtrado = filtrado.Where(r => r["Resultado"].ToString() == "Fallido");

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
            cmbExitosoFiltro.SelectedIndex = 0;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            dgvAuditoria.DataSource = tablaOriginal;
        }
    }
}
