using System;
using System.Data;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Formulario de auditoría: muestra un registro de todos los inicios de sesión,
    // y permite filtrar por usuario, resultado y rango de fechas.
    public partial class frmAuditoria : Form
    {
        private DataTable tablaOriginal; // guarda la tabla completa sin filtrar, para poder restablecer los datos

        public frmAuditoria()
        {
            InitializeComponent(); // crea todos los controles visuales definidos en el Designer
        }

        // Se ejecuta cuando el formulario termina de cargarse
        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            CargarAuditoria(); // traigo los datos de la base de datos

            // cmbExitosoFiltro ya tiene sus ítems fijos en el Designer (Todos, Exitoso, Fallido)
            cmbExitosoFiltro.SelectedIndex = 0;

            // cmbUsuarioFiltro se carga dinámico con los usuarios únicos que aparecen en la auditoría
            cmbUsuarioFiltro.Items.Clear();
            cmbUsuarioFiltro.Items.Add("Todos los usuarios");
            var vistos = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow row in tablaOriginal.Rows)
            {
                string u = row["Usuario"].ToString();
                if (!string.IsNullOrEmpty(u) && vistos.Add(u))
                    cmbUsuarioFiltro.Items.Add(u);
            }
            cmbUsuarioFiltro.SelectedIndex = 0;
        }

        // Trae los datos directamente de la BD — el IIF en la query ya devuelve "Exitoso"/"Fallido"
        private void CargarAuditoria()
        {
            tablaOriginal = clsBaseDatos.ObtenerAuditoria();
            dgvAuditoria.DataSource          = tablaOriginal; // muestro la tabla completa sin filtrar en la grilla
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // ajusto el ancho de las columnas para que ocupen todo el espacio disponible
            if (dgvAuditoria.Columns.Contains("FechaHora")) dgvAuditoria.Columns["FechaHora"].HeaderText = "Fecha y hora"; 
            if (dgvAuditoria.Columns.Contains("Accion"))    dgvAuditoria.Columns["Accion"].HeaderText    = "Acción";
        }

        // Se ejecuta cuando el usuario hace clic en "Filtrar"
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (tablaOriginal == null) return; // si todavía no hay datos, no hago nada

            // Si está en "Todos los usuarios" (índice 0) no filtro por usuario; si no, filtro por el seleccionado
            string usuario   = (cmbUsuarioFiltro.SelectedIndex <= 0) ? "" : cmbUsuarioFiltro.SelectedItem.ToString();
            string seleccion = cmbExitosoFiltro.SelectedItem.ToString(); // resultado elegido en el combo

            DataTable tablaFiltrada = tablaOriginal.Clone(); // creo una tabla vacía con las mismas columnas

            foreach (DataRow row in tablaOriginal.Rows) // recorro cada fila de la tabla original
            {
                // Si hay un usuario seleccionado y esta fila no es de ese usuario, la salteo
                if (usuario != "" && row["Usuario"].ToString().ToUpper().IndexOf(usuario.ToUpper()) < 0)
                    continue;

                // si eligió un resultado específico y esta fila no coincide, la salteo
                if (seleccion != "Todos" && row["Resultado"].ToString() != seleccion) continue;

                // Si el checkbox "Desde" está tildado y la fecha es anterior, la salteo
                if (dtpDesde.Checked && Convert.ToDateTime(row["FechaHora"]).Date < dtpDesde.Value.Date) continue; // convierto a DateTime y comparo solo la parte de la fecha (sin hora) para que el filtro incluya todo el día seleccionado

                // Si el checkbox "Hasta" está tildado y la fecha es posterior, la salteo
                if (dtpHasta.Checked && Convert.ToDateTime(row["FechaHora"]).Date > dtpHasta.Value.Date) continue; // convierto a DateTime y comparo solo la parte de la fecha (sin hora) para que el filtro incluya todo el día seleccionado

                // Si llegó hasta acá, pasó todos los filtros: la agrego a la tabla filtrada
                tablaFiltrada.ImportRow(row);
            }

            dgvAuditoria.DataSource = tablaFiltrada; // muestro la tabla filtrada en la grilla
        }

        // Se ejecuta cuando el usuario hace clic en "Limpiar": restablece todos los filtros
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbUsuarioFiltro.SelectedIndex  = 0;     // vuelvo a "Todos los usuarios"
            cmbExitosoFiltro.SelectedIndex  = 0;     // vuelvo a "Todos"
            dtpDesde.Checked = false;                // destildo el filtro de fecha "Desde"
            dtpHasta.Checked = false;                // destildo el filtro de fecha "Hasta"
            dgvAuditoria.DataSource = tablaOriginal; // vuelvo a mostrar la tabla completa sin filtros
        }
    }
}
