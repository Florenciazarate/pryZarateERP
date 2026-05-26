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

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex < 0)
            {
                cmbLocalidad.DataSource = null;
                return;
            }

            string prov = cmbProvincia.Text.Trim();

            if (prov.Equals("Córdoba", StringComparison.OrdinalIgnoreCase) ||
                prov.Equals("Cordoba", StringComparison.OrdinalIgnoreCase))
            {
                var tabla = clsBaseDatos.ObtenerLocalidadesCordoba();

                // If there are no rows, clear the combo
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    cmbLocalidad.DataSource = null;
                    return;
                }

                // Determine display and value column names dynamically to avoid mismatches with DB schema
                string displayCol = null;
                string valueCol = null;

                // Prefer columns whose name contains 'localidad' or 'localidades'
                displayCol = tabla.Columns.Cast<DataColumn>()
                    .FirstOrDefault(c => c.DataType == typeof(string) && 
                        (c.ColumnName.IndexOf("localidad", StringComparison.OrdinalIgnoreCase) >= 0 ||
                         c.ColumnName.IndexOf("localidades", StringComparison.OrdinalIgnoreCase) >= 0))
                    ?.ColumnName;

                // Fallback to the last string column
                if (string.IsNullOrEmpty(displayCol))
                {
                    displayCol = tabla.Columns.Cast<DataColumn>()
                        .FirstOrDefault(c => c.DataType == typeof(string))?.ColumnName;
                }

                // Determine value column: prefer column containing 'id'
                valueCol = tabla.Columns.Cast<DataColumn>()
                    .FirstOrDefault(c => c.ColumnName.IndexOf("id", StringComparison.OrdinalIgnoreCase) >= 0)?.ColumnName;

                // Fallback to the first column if none matched
                if (string.IsNullOrEmpty(valueCol))
                {
                    valueCol = tabla.Columns[0].ColumnName;
                }

                // If still no display column, just bind the table and let ToString be used
                if (!string.IsNullOrEmpty(displayCol))
                {
                    cmbLocalidad.DataSource = tabla;
                    cmbLocalidad.DisplayMember = displayCol;
                    cmbLocalidad.ValueMember = valueCol;
                    cmbLocalidad.SelectedIndex = -1;
                }
                else
                {
                    // As a last resort bind to a list of strings from the last column
                    var list = tabla.Rows.Cast<DataRow>().Select(r => r[tabla.Columns.Count - 1].ToString()).ToList();
                    cmbLocalidad.DataSource = list;
                    cmbLocalidad.SelectedIndex = -1;
                }
            }
            else
            {
                cmbLocalidad.DataSource = null;
            }
        }

        // ══════════════════════════════════
        // GRILLA PRINCIPAL
        // ══════════════════════════════════

        private void CargarGrilla()
        {
            dgvPersonal.DataSource = clsBaseDatos.ObtenerPersonal();

            if (dgvPersonal.Columns.Contains("IdPersonal"))
                dgvPersonal.Columns["IdPersonal"].Visible = false;
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
        // ══════════════════════════════════

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
        // ══════════════════════════════════

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
            cmbTipo.SelectedIndex = -1;
            txtValor.Text = "";
            dgvDomicilios.DataSource = null;
            dgvContactos.DataSource = null;
            dgvPersonal.ClearSelection();
        }
    }
}
