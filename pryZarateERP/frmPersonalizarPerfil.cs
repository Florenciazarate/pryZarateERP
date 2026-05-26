using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmPersonalizarPerfil : Form
    {
        private int idSeleccionado = -1;

        public frmPersonalizarPerfil()
        {
            InitializeComponent();
        }

        private void frmPersonalizarPerfil_Load(object sender, EventArgs e)
        {
            CargarProvincias();
            CargarTiposContacto();
            CargarGrilla();
        }

        private void CargarProvincias()
        {
            var tabla = clsBaseDatos.ObtenerProvincias();
            cmbProvincia.DataSource = tabla;
            cmbProvincia.DisplayMember = "Provincias";
            cmbProvincia.ValueMember = "ID_Provincias";
            cmbProvincia.SelectedIndex = -1;
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            cmbProvincia.TextChanged += cmbProvincia_TextChanged;

            // Habilitar autocompletado para permitir escribir y seleccionar
            try
            {
                cmbProvincia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProvincia.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch { }

            // Ajustes para el desplegable: limitar altura para que intente abrir hacia abajo cuando haya espacio
            try
            {
                cmbProvincia.DropDownHeight = 200;
                cmbProvincia.MaxDropDownItems = 10;
            }
            catch { }

            try
            {
                cmbLocalidad.DropDownHeight = 200;
                cmbLocalidad.MaxDropDownItems = 10;
            }
            catch { }
        }

        private void CargarTiposContacto()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new object[]
            {
                "Email", "Telefono", "Instagram", "Facebook", "Twitter", "LinkedIn"
            });
            cmbTipo.SelectedIndex = -1;
        }

        // Called when user types in province
        private void cmbProvincia_TextChanged(object sender, EventArgs e)
        {
            // If user typed a province name (e.g. 'Córdoba'), attempt to load localidades
            TryLoadLocalidadesFromProvincia(cmbProvincia.Text?.Trim());
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            TryLoadLocalidadesFromProvincia(cmbProvincia.Text?.Trim());
        }

        private void TryLoadLocalidadesFromProvincia(string prov)
        {
            if (string.IsNullOrEmpty(prov))
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
                return;
            }

            if (prov.IndexOf("Cord", StringComparison.OrdinalIgnoreCase) >= 0) // allow variants like Cordoba, Córdoba
            {
                var tabla = clsBaseDatos.ObtenerLocalidadesCordoba();

                // If there are no rows, clear the combo
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    cmbLocalidad.DataSource = null;
                    cmbLocalidad.Items.Clear();
                    return;
                }

                // Determine display and value column names dynamically to avoid mismatches with DB schema
                string displayCol = null;
                string valueCol = null;

                // Prefer columns whose name contains 'localidad' or 'localidades' (any type)
                displayCol = tabla.Columns.Cast<DataColumn>()
                    .FirstOrDefault(c => c.ColumnName.IndexOf("localidad", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                         c.ColumnName.IndexOf("localidades", StringComparison.OrdinalIgnoreCase) >= 0)?.ColumnName;

                // Fallback to the last non-id column
                if (string.IsNullOrEmpty(displayCol))
                {
                    displayCol = tabla.Columns.Cast<DataColumn>()
                        .Where(c => c.ColumnName.IndexOf("id", StringComparison.OrdinalIgnoreCase) < 0)
                        .LastOrDefault()?.ColumnName;
                }

                // Determine value column: prefer column containing 'id'
                valueCol = tabla.Columns.Cast<DataColumn>()
                    .FirstOrDefault(c => c.ColumnName.IndexOf("id", StringComparison.OrdinalIgnoreCase) >= 0)?.ColumnName;

                // Fallback to the first column if none matched
                if (string.IsNullOrEmpty(valueCol))
                {
                    valueCol = tabla.Columns[0].ColumnName;
                }

                // Bind
                if (!string.IsNullOrEmpty(displayCol))
                {
                    cmbLocalidad.DataSource = tabla;
                    cmbLocalidad.DisplayMember = displayCol;
                    cmbLocalidad.ValueMember = valueCol;
                    cmbLocalidad.SelectedIndex = -1;

                    // Populate Items for autocomplete and visibility
                    try
                    {
                        cmbLocalidad.Items.Clear();
                        foreach (DataRow r in tabla.Rows)
                        {
                            var val = r[displayCol]?.ToString();
                            if (!string.IsNullOrEmpty(val) && !cmbLocalidad.Items.Contains(val))
                                cmbLocalidad.Items.Add(val);
                        }

                        cmbLocalidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }
                    catch { }
                }
                else
                {
                    // As a last resort bind to a list of strings from the last column
                    var list = tabla.Rows.Cast<DataRow>().Select(r => r[tabla.Columns.Count - 1].ToString()).ToList();
                    cmbLocalidad.DataSource = list;
                    cmbLocalidad.SelectedIndex = -1;

                    try
                    {
                        cmbLocalidad.Items.Clear();
                        foreach (var s in list) cmbLocalidad.Items.Add(s);
                        cmbLocalidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }
                    catch { }
                }
            }
            else
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
            }
        }

        // New handler for "Modificar" button: update existing person with form values
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccioná una persona de la lista para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Completa DNI, Nombre y Apellido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // If user typed a provincia/localidad not in list, take the text; otherwise use selected text
                string provincia = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : cmbProvincia.Text.Trim();
                string localidad = cmbLocalidad.SelectedIndex >= 0 ? cmbLocalidad.Text : cmbLocalidad.Text.Trim();

                // Update personal data
                clsBaseDatos.ActualizarPersonal(idSeleccionado, txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), chkActivar.Checked);

                // Optionally update domicilio - here we do not auto-insert domicilio, user must add via domicilios section

                CargarGrilla();
                MessageBox.Show("Persona modificada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════
        // GRILLA PRINCIPAL
        // ══════════════════════════════════

        private void CargarGrilla()
        {
            dgvPersonal.DataSource = clsBaseDatos.ObtenerPersonal();

            // Make 'Activo' editable as a checkbox while keeping other columns read-only
            try
            {
                // Allow editing in grid (we'll restrict to the checkbox column)
                dgvPersonal.ReadOnly = false;

                // Ensure columns are present
                if (dgvPersonal.Columns.Contains("Activo"))
                {
                    // Convert the column to a checkbox column if it's not one
                    var col = dgvPersonal.Columns["Activo"];                    
                    if (!(col is DataGridViewCheckBoxColumn))
                    {
                        int idx = col.Index;
                        dgvPersonal.Columns.Remove(col);
                        var chkCol = new DataGridViewCheckBoxColumn
                        {
                            Name = "Activo",
                            HeaderText = "Activo",
                            DataPropertyName = "Activo",
                            ReadOnly = false,
                            TrueValue = true,
                            FalseValue = false
                        };
                        dgvPersonal.Columns.Insert(idx, chkCol);
                    }

                    // Set other columns to readonly
                    foreach (DataGridViewColumn c in dgvPersonal.Columns)
                    {
                        if (c.Name != "Activo") c.ReadOnly = true; else c.ReadOnly = false;
                    }

                    // Wire events to handle checkbox changes
                    dgvPersonal.CellContentClick -= dgvPersonal_CellContentClick;
                    dgvPersonal.CellContentClick += dgvPersonal_CellContentClick;
                    dgvPersonal.CellValueChanged -= dgvPersonal_CellValueChanged;
                    dgvPersonal.CellValueChanged += dgvPersonal_CellValueChanged;
                }

                if (dgvPersonal.Columns.Contains("IdPersonal"))
                    dgvPersonal.Columns["IdPersonal"].Visible = false;
            }
            catch { }
        }

        // Commit edit when clicking the checkbox so CellValueChanged fires
        private void dgvPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPersonal.Columns[e.ColumnIndex].Name == "Activo")
            {
                dgvPersonal.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // When the checkbox value changes, update the DB
        private void dgvPersonal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPersonal.Columns[e.ColumnIndex].Name != "Activo") return;

            try
            {
                var row = dgvPersonal.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["IdPersonal"].Value);
                string dni = row.Cells["DNI"].Value?.ToString() ?? string.Empty;
                string nombre = row.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                string apellido = row.Cells["Apellido"].Value?.ToString() ?? string.Empty;
                bool activo = false;
                var cell = row.Cells["Activo"].Value;
                if (cell != null && cell != DBNull.Value)
                {
                    bool.TryParse(cell.ToString(), out activo);
                }

                clsBaseDatos.ActualizarPersonal(id, dni, nombre, apellido, activo);

                // Refresh grid to show consistent data
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el estado Activo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvPersonal.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdPersonal"].Value);

            txtDni.Text = fila.Cells["DNI"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
            chkActivar.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);

            CargarDomicilios();
            CargarContactos();
        }

        // ══════════════════════════════════
        // DOMICILIOS
        // ══════════════════════════

        private void CargarDomicilios()
        {
            if (idSeleccionado == -1)
            {
                dgvDomicilios.DataSource = null;
                return;
            }

            dgvDomicilios.DataSource = clsBaseDatos.ObtenerDomicilios(idSeleccionado);

            if (dgvDomicilios.Columns.Contains("IdDomicilio"))
                dgvDomicilios.Columns["IdDomicilio"].Visible = false;
        }

        private void btnAgregarDom_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1 || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Guarda la persona primero y completa la direccion.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string provincia = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : "";
            string localidad = (cmbLocalidad.DataSource != null && cmbLocalidad.SelectedIndex >= 0)
                                ? cmbLocalidad.Text : "";

            try
            {
                clsBaseDatos.InsertarDomicilio(
                    idSeleccionado,
                    txtDireccion.Text.Trim(),
                    txtGeo.Text.Trim(),
                    provincia,
                    localidad);

                txtDireccion.Text = "";
                txtGeo.Text = "";
                cmbProvincia.SelectedIndex = -1;
                cmbLocalidad.DataSource = null;

                CargarDomicilios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            string texto = txtGeo.Text.Trim();
            if (string.IsNullOrEmpty(texto)) return;

            string url = texto.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                ? texto
                : "https://www.google.com/maps?q=" + Uri.EscapeDataString(texto);

            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void btnEliminarDom_Click(object sender, EventArgs e)
        {
            if (dgvDomicilios.CurrentRow == null) return;

            int idDom = Convert.ToInt32(dgvDomicilios.CurrentRow.Cells["IdDomicilio"].Value);

            try
            {
                clsBaseDatos.EliminarDomicilio(idDom);
                CargarDomicilios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════
        // CONTACTOS
        // ══════════════════════════

        private void CargarContactos()
        {
            if (idSeleccionado == -1)
            {
                dgvContactos.DataSource = null;
                return;
            }

            dgvContactos.DataSource = clsBaseDatos.ObtenerContactos(idSeleccionado);

            if (dgvContactos.Columns.Contains("IdContacto"))
                dgvContactos.Columns["IdContacto"].Visible = false;

            // Cambiar encabezado "Valor" a "Nombre" si existe
            if (dgvContactos.Columns.Contains("Valor"))
            {
                dgvContactos.Columns["Valor"].HeaderText = "Nombre";
            }
            else
            {
                // If column name differs, try to find likely column and rename
                var col = dgvContactos.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText.Equals("Valor", StringComparison.OrdinalIgnoreCase) || c.Name.IndexOf("valor", StringComparison.OrdinalIgnoreCase) >= 0);
                if (col != null) col.HeaderText = "Nombre";
            }
        }

        private void btnAgregarCont_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1 || cmbTipo.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Guarda la persona primero, selecciona un tipo y completa el valor.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                clsBaseDatos.InsertarContacto(idSeleccionado, cmbTipo.Text, txtValor.Text.Trim());

                cmbTipo.SelectedIndex = -1;
                txtValor.Text = "";

                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCont_Click(object sender, EventArgs e)
        {
            if (dgvContactos.CurrentRow == null) return;

            int idCont = Convert.ToInt32(dgvContactos.CurrentRow.Cells["IdContacto"].Value);

            try
            {
                clsBaseDatos.EliminarContacto(idCont);
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════
        // PERSONA: GUARDAR / ELIMINAR / LIMPIAR
        // ══════════════════════════════════

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Completa DNI, Nombre y Apellido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsBaseDatos.ExisteDni(txtDni.Text.Trim(), idSeleccionado))
            {
                MessageBox.Show("Ya existe una persona con ese DNI.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idSeleccionado == -1)
                {
                    idSeleccionado = clsBaseDatos.InsertarPersonal(
                        txtDni.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        chkActivar.Checked);
                }
                else
                {
                    clsBaseDatos.ActualizarPersonal(
                        idSeleccionado,
                        txtDni.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        chkActivar.Checked);
                }

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;

            var resultado = MessageBox.Show(
                "Eliminar a " + txtNombre.Text + " " + txtApellido.Text + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    clsBaseDatos.EliminarPersonal(idSeleccionado);
                    CargarGrilla();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = -1;
            txtDni.Text = "";

            txtNombre.Text = "";
            txtApellido.Text = "";
            chkActivar.Checked = true;
            txtDireccion.Text = "";
            txtGeo.Text = "";
            cmbProvincia.SelectedIndex = -1;
            cmbLocalidad.DataSource = null;
            cmbLocalidad.Items.Clear();
            cmbTipo.SelectedIndex = -1;
            txtValor.Text = "";
            dgvDomicilios.DataSource = null;
            dgvContactos.DataSource = null;
            dgvPersonal.ClearSelection();
        }

       
    }
}
