using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmPersonalizarPerfil : Form
    {
        private int idSeleccionado = -1; // ID de la persona seleccionada en la grilla, -1 = ninguna

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

        // ══════════════════════════════════
        // CARGA INICIAL DE COMBOS
        // ══════════════════════════════════

        private void CargarProvincias()
        {
            var tabla = clsBaseDatos.ObtenerProvincias(); // traigo las provincias de la BD
            cmbProvincia.DataSource = tabla; // las cargo como fuente de datos del combo
            cmbProvincia.DisplayMember = "Provincias"; // lo que se muestra en el combo
            cmbProvincia.ValueMember = "ID_Provincias"; // el valor interno de cada item
            cmbProvincia.SelectedIndex = -1; // que arranque sin nada seleccionado

            // cuando el usuario seleccione o escriba una provincia, intento cargar sus localidades
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            cmbProvincia.TextChanged += cmbProvincia_TextChanged;

            // habilito que el combo sugiera opciones mientras el usuario escribe
            try
            {
                cmbProvincia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProvincia.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbProvincia.DropDownHeight = 200;
                cmbProvincia.MaxDropDownItems = 10;
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

        // ══════════════════════════════════
        // LOCALIDADES (depende de la provincia)
        // ══════════════════════════════════

        private void cmbProvincia_TextChanged(object sender, EventArgs e)
        {
            CargarLocalidades(cmbProvincia.Text.Trim());
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(cmbProvincia.Text.Trim());
        }

        private void CargarLocalidades(string provincia)
        {
            // si no escribió nada, limpio el combo de localidades y salgo
            if (string.IsNullOrEmpty(provincia))
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
                return;
            }

            // solo cargo localidades si la provincia contiene "Cord" (acepta Córdoba, Cordoba, etc.)
            if (provincia.IndexOf("Cord", StringComparison.OrdinalIgnoreCase) < 0)
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
                return;
            }

            var tabla = clsBaseDatos.ObtenerLocalidadesCordoba();

            if (tabla == null || tabla.Rows.Count == 0)
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
                return;
            }

            // cargo las localidades en el combo
            cmbLocalidad.DataSource = tabla;
            cmbLocalidad.DisplayMember = "LocalidadesCordoba"; // columna que se muestra
            cmbLocalidad.ValueMember = "ID_Localidades"; // columna del ID
            cmbLocalidad.SelectedIndex = -1;

            // habilito autocompletado en el combo de localidades
            try
            {
                cmbLocalidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch { }
        }

        // ══════════════════════════════════
        // GRILLA PRINCIPAL DE PERSONAL
        // ══════════════════════════════════

        private void CargarGrilla()
        {
            dgvPersonal.DataSource = clsBaseDatos.ObtenerPersonal();

            try
            {
                dgvPersonal.ReadOnly = false; // permito edición para el checkbox de Activo

                if (dgvPersonal.Columns.Contains("Activo"))
                {
                    var col = dgvPersonal.Columns["Activo"];

                    // si la columna Activo no es un checkbox, la reemplazo por una que sí lo sea
                    if (!(col is DataGridViewCheckBoxColumn))
                    {
                        int idx = col.Index; // guardo la posición original
                        dgvPersonal.Columns.Remove(col); // la saco
                        var chkCol = new DataGridViewCheckBoxColumn
                        {
                            Name = "Activo",
                            HeaderText = "Activo",
                            DataPropertyName = "Activo",
                            ReadOnly = false,
                            TrueValue = true,
                            FalseValue = false
                        };
                        dgvPersonal.Columns.Insert(idx, chkCol); // la inserto en la misma posición
                    }

                    // todas las columnas en solo lectura, excepto Activo
                    foreach (DataGridViewColumn c in dgvPersonal.Columns)
                    {
                        c.ReadOnly = (c.Name != "Activo");
                    }

                    // conecto los eventos del checkbox para que se guarde al hacer click
                    dgvPersonal.CellContentClick -= dgvPersonal_CellContentClick;
                    dgvPersonal.CellContentClick += dgvPersonal_CellContentClick;
                    dgvPersonal.CellValueChanged -= dgvPersonal_CellValueChanged;
                    dgvPersonal.CellValueChanged += dgvPersonal_CellValueChanged;
                }

                // oculto la columna del ID porque no le sirve al usuario verla
                if (dgvPersonal.Columns.Contains("IdPersonal"))
                    dgvPersonal.Columns["IdPersonal"].Visible = false;
            }
            catch { }
        }

        // cuando hacen click en el checkbox de Activo, fuerzo que se confirme el cambio
        private void dgvPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPersonal.Columns[e.ColumnIndex].Name == "Activo")
                dgvPersonal.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // cuando cambia el valor del checkbox, actualizo en la BD
        private void dgvPersonal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPersonal.Columns[e.ColumnIndex].Name != "Activo") return;

            try
            {
                var row = dgvPersonal.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["IdPersonal"].Value);
                string dni = row.Cells["DNI"].Value.ToString();
                string nombre = row.Cells["Nombre"].Value.ToString();
                string apellido = row.Cells["Apellido"].Value.ToString();

                bool activo = false;
                var cell = row.Cells["Activo"].Value;
                if (cell != null && cell != DBNull.Value)
                    bool.TryParse(cell.ToString(), out activo);

                clsBaseDatos.ActualizarPersonal(id, dni, nombre, apellido, activo);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el estado Activo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // cuando hacen click en una fila de la grilla, cargo sus datos en los campos del formulario
        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvPersonal.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdPersonal"].Value);

            txtDni.Text = fila.Cells["DNI"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
            chkActivar.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);

            CargarDomicilios(); // cargo los domicilios de esa persona
            CargarContactos(); // cargo los contactos de esa persona
        }

        // ══════════════════════════════════
        // DOMICILIOS
        // ══════════════════════════════════

        private void CargarDomicilios()
        {
            if (idSeleccionado == -1) // si no hay persona seleccionada, limpio la grilla
            {
                dgvDomicilios.DataSource = null;
                return;
            }

            dgvDomicilios.DataSource = clsBaseDatos.ObtenerDomicilios(idSeleccionado);

            if (dgvDomicilios.Columns.Contains("IdDomicilio"))
                dgvDomicilios.Columns["IdDomicilio"].Visible = false; // oculto el ID
        }

        private void btnAgregarDom_Click(object sender, EventArgs e)
        {
            // valido que haya una persona seleccionada y que la dirección no esté vacía
            if (idSeleccionado == -1 || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Guarda la persona primero y completa la direccion.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // tomo provincia y localidad del combo, si hay algo seleccionado
            string provincia = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : "";
            string localidad = (cmbLocalidad.DataSource != null && cmbLocalidad.SelectedIndex >= 0)
                                ? cmbLocalidad.Text : "";

            try
            {
                clsBaseDatos.InsertarDomicilio(idSeleccionado, txtDireccion.Text.Trim(), txtGeo.Text.Trim(), provincia, localidad);

                // limpio los campos después de agregar
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

            // si ya es una URL la abro directo, si no armo una búsqueda en Google Maps
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

            // renombro el encabezado "Valor" a "Nombre" para que se entienda mejor
            if (dgvContactos.Columns.Contains("Valor"))
                dgvContactos.Columns["Valor"].HeaderText = "Nombre";
        }

        private void btnAgregarCont_Click(object sender, EventArgs e)
        {
            // valido que haya persona seleccionada, tipo elegido y valor completado
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
        // PERSONA: GUARDAR / MODIFICAR / ELIMINAR / LIMPIAR
        // ══════════════════════════════════

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // valido que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Completa DNI, Nombre y Apellido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // verifico que no exista otra persona con el mismo DNI
            if (clsBaseDatos.ExisteDni(txtDni.Text.Trim(), idSeleccionado))
            {
                MessageBox.Show("Ya existe una persona con ese DNI.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idSeleccionado == -1) // si no hay persona seleccionada, es un alta nueva
                {
                    idSeleccionado = clsBaseDatos.InsertarPersonal(
                        txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), chkActivar.Checked);
                }
                else // si hay persona seleccionada, es una modificación
                {
                    clsBaseDatos.ActualizarPersonal(
                        idSeleccionado, txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), chkActivar.Checked);
                }

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                clsBaseDatos.ActualizarPersonal(idSeleccionado, txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), chkActivar.Checked);
                CargarGrilla();
                MessageBox.Show("Persona modificada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;

            // pregunto si está seguro antes de borrar
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
            idSeleccionado = -1; // desselecciono la persona
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
