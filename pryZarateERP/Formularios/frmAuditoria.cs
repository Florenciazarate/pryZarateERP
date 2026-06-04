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
            // Cargo las opciones fijas del combo "Resultado"
            cmbExitosoFiltro.Items.Clear();
            cmbExitosoFiltro.Items.AddRange(new object[] { "Todos", "Inicio Exitoso", "Intento Fallido" });
            cmbExitosoFiltro.SelectedIndex = 0; // selecciono "Todos" por defecto

            CargarAuditoria(); // traigo los datos de la base de datos

            // Cargo el combo de usuarios con todos los usuarios únicos que aparecen en la auditoría
            cmbUsuarioFiltro.Items.Clear();
            cmbUsuarioFiltro.Items.Add("Todos los usuarios");
            var vistos = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow row in tablaOriginal.Rows)
            {
                string u = row["Usuario"].ToString();
                if (!string.IsNullOrEmpty(u) && vistos.Add(u)) // vistos.Add devuelve false si ya estaba
                    cmbUsuarioFiltro.Items.Add(u);
            }
            cmbUsuarioFiltro.SelectedIndex = 0; // selecciono "Todos los usuarios" por defecto
        }

        // Trae los datos de la tabla AuditoriaSesion de la base de datos
        // y los convierte a un formato más amigable para mostrar en la grilla
        private void CargarAuditoria()
        {
            var tablaBD = clsBaseDatos.ObtenerAuditoria(); // traigo todos los registros de la BD

            // Creo una DataTable nueva con las columnas que quiero mostrar en la grilla
            tablaOriginal = new DataTable();
            tablaOriginal.Columns.Add("FechaHora", typeof(DateTime));
            tablaOriginal.Columns.Add("Usuario",   typeof(string));
            tablaOriginal.Columns.Add("Accion",    typeof(string));
            tablaOriginal.Columns.Add("Resultado", typeof(string));
            tablaOriginal.Columns.Add("Detalle",   typeof(string));

            // Por cada fila que vino de la BD, la transformo y la agrego a tablaOriginal
            foreach (DataRow row in tablaBD.Rows)
            {
                // Convierto el booleano "Exitoso" (true/false) a texto legible
                string resultado = Convert.ToBoolean(row["Exitoso"]) ? "Exitoso" : "Fallido";

                tablaOriginal.Rows.Add(
                    row["FechaHora"],
                    row["Usuario"],
                    row["Accion"],
                    resultado,
                    row["Detalle"]);
            }

            dgvAuditoria.DataSource        = tablaOriginal;                            // conecto la tabla a la grilla
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;   // las columnas llenan el ancho disponible

            // Renombro los encabezados de columna para que se vean más prolijos
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

                // Si eligió "Inicio Exitoso" y esta fila es Fallido, la salteo
                if (seleccion == "Inicio Exitoso"  && row["Resultado"].ToString() != "Exitoso") continue;

                // Si eligió "Intento Fallido" y esta fila es Exitoso, la salteo
                if (seleccion == "Intento Fallido" && row["Resultado"].ToString() != "Fallido") continue;

                // Si el checkbox "Desde" está tildado y la fecha es anterior, la salteo
                if (dtpDesde.Checked && Convert.ToDateTime(row["FechaHora"]).Date < dtpDesde.Value.Date) continue;

                // Si el checkbox "Hasta" está tildado y la fecha es posterior, la salteo
                if (dtpHasta.Checked && Convert.ToDateTime(row["FechaHora"]).Date > dtpHasta.Value.Date) continue;

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
