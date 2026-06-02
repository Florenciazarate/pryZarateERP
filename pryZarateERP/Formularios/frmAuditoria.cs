using System;
using System.Data;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmAuditoria : Form
    {
        private DataTable tablaOriginal; // variable que guarda la tabla completa sin filtrar

        public frmAuditoria()
        {
            InitializeComponent(); // crea todos los controles visuales definidos en el Designer
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            cmbExitosoFiltro.Items.Clear(); // limpio los items del combo por si tiene algo
            cmbExitosoFiltro.Items.Add("Todos"); // agrego la opción "Todos"
            cmbExitosoFiltro.Items.Add("Inicio Exitoso");
            cmbExitosoFiltro.Items.Add("Intento Fallido");
            cmbExitosoFiltro.SelectedIndex = 0; // selecciono el primer item ("Todos") por defecto

            CargarAuditoria(); // cargo los datos de la base de datos en la grilla
        }

        private void CargarAuditoria()
        {
            var tablaBD = clsBaseDatos.ObtenerAuditoria(); // traigo la tabla AuditoriaSesion de la base de datos

            tablaOriginal = new DataTable(); // creo una DataTable nueva vacía
            tablaOriginal.Columns.Add("FechaHora", typeof(DateTime)); // le agrego la columna FechaHora de tipo DateTime
            tablaOriginal.Columns.Add("Usuario", typeof(string));
            tablaOriginal.Columns.Add("Accion", typeof(string));
            tablaOriginal.Columns.Add("Resultado", typeof(string));
            tablaOriginal.Columns.Add("Detalle", typeof(string));

            foreach (DataRow row in tablaBD.Rows) // por cada fila (DataRow) en las filas de tablaBD
            {
                string resultado; // declaro la variable resultado
                if (Convert.ToBoolean(row["Exitoso"])) // si el valor de la columna Exitoso es true
                    resultado = "Exitoso";
                else
                    resultado = "Fallido";

                tablaOriginal.Rows.Add( // agrego una fila nueva a tablaOriginal con estos valores
                    row["FechaHora"],
                    row["Usuario"],
                    row["Accion"],
                    resultado,
                    row["Detalle"]);
            }

            dgvAuditoria.DataSource = tablaOriginal; // asigno la tabla como fuente de datos de la grilla
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (tablaOriginal == null) return; // si no hay datos cargados, salgo del método

            string usuario = txtUsuarioFiltro.Text.Trim(); // obtengo el texto del filtro de usuario, sin espacios
            string seleccion = cmbExitosoFiltro.SelectedItem.ToString(); // obtengo el item seleccionado del combo

            DataTable tablaFiltrada = tablaOriginal.Clone(); // creo una tabla vacía con las mismas columnas que tablaOriginal

            foreach (DataRow row in tablaOriginal.Rows) // por cada fila en la tabla original
            {
                // filtro por usuario: si el campo no está vacío, verifico que la columna Usuario contenga el texto
                if (usuario != "" && row["Usuario"].ToString().ToUpper().IndexOf(usuario.ToUpper()) < 0)
                    continue; // si no coincide, salto a la siguiente fila

                // filtro por resultado: si eligió "Inicio Exitoso", solo acepto filas con Resultado "Exitoso"
                if (seleccion == "Inicio Exitoso" && row["Resultado"].ToString() != "Exitoso")
                    continue;

                // filtro por resultado: si eligió "Intento Fallido", solo acepto filas con Resultado "Fallido"
                if (seleccion == "Intento Fallido" && row["Resultado"].ToString() != "Fallido")
                    continue;

                // filtro por fecha desde: si está tildado, solo acepto filas con fecha mayor o igual
                if (dtpDesde.Checked && Convert.ToDateTime(row["FechaHora"]).Date < dtpDesde.Value.Date)
                    continue;

                // filtro por fecha hasta: si está tildado, solo acepto filas con fecha menor o igual
                if (dtpHasta.Checked && Convert.ToDateTime(row["FechaHora"]).Date > dtpHasta.Value.Date)
                    continue;

                // si pasó todos los filtros, agrego la fila a la tabla filtrada
                tablaFiltrada.ImportRow(row);
            }

            dgvAuditoria.DataSource = tablaFiltrada; // muestro la tabla filtrada en la grilla
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuarioFiltro.Text = ""; // vacío el campo de texto del filtro de usuario
            cmbExitosoFiltro.SelectedIndex = 0; // vuelvo el combo a "Todos"
            dtpDesde.Checked = false; // destildo el filtro de fecha "Desde"
            dtpHasta.Checked = false; // destildo el filtro de fecha "Hasta"
            dgvAuditoria.DataSource = tablaOriginal; // vuelvo a mostrar la tabla completa sin filtros
        }
    }
}
