using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmPersonalizarPerfil : Form
    {
        private int idSeleccionado = -1; // -1 = nuevo, otro valor = editando

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

        // ── Cargar combo de provincias ──
        private void CargarProvincias()
        {
            var tabla = clsBaseDatos.ObtenerProvincias();
            cmbProvincia.DataSource = tabla;
            cmbProvincia.DisplayMember = "Provincias";
            cmbProvincia.ValueMember = "ID_Provincias";
            cmbProvincia.SelectedIndex = -1;

            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
        }

        // ── Cargar combo de tipos de contacto ──
        private void CargarTiposContacto()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new object[]
            {
                "Email", "Telefono", "Instagram", "Facebook", "Twitter", "LinkedIn"
            });
            cmbTipo.SelectedIndex = -1;
        }

        // ── Cuando cambia la provincia ──
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex < 0)
            {
                cmbLocalidad.DataSource = null;
                return;
            }

            string prov = cmbProvincia.Text;

            if (prov.IndexOf("rdoba", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var tabla = clsBaseDatos.ObtenerLocalidadesCordoba();
                cmbLocalidad.DataSource = tabla;
                cmbLocalidad.DisplayMember = "LocalidadesCordoba";
                cmbLocalidad.ValueMember = "ID_Localidades";
                cmbLocalidad.SelectedIndex = -1;
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

        // Click en una fila → cargo datos + domicilios + contactos
        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvPersonal.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdPersonal"].Value);

            txtDni.Text = fila.Cells["DNI"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
            chkActivar.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);

            // Cargo sus domicilios y contactos
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
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Primero guarda la persona.",
                    "Sin persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La direccion es obligatoria.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Limpio los campos de domicilio
                txtDireccion.Text = "";
                txtGeo.Text = "";
                cmbProvincia.SelectedIndex = -1;
                cmbLocalidad.DataSource = null;

                CargarDomicilios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar domicilio: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            string texto = txtGeo.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                MessageBox.Show("Ingresa coordenadas o un link de Maps.",
                    "Sin ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string url;

            if (texto.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                // Ya es un link, lo abro directo
                url = texto;
            }
            else
            {
                // Lo trato como coordenadas o nombre de lugar
                url = "https://www.google.com/maps?q=" + Uri.EscapeDataString(texto);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void btnEliminarDom_Click(object sender, EventArgs e)
        {
            if (dgvDomicilios.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un domicilio para eliminar.",
                    "Sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDom = Convert.ToInt32(dgvDomicilios.CurrentRow.Cells["IdDomicilio"].Value);

            try
            {
                clsBaseDatos.EliminarDomicilio(idDom);
                CargarDomicilios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar domicilio: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Primero guarda la persona.",
                    "Sin persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTipo.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Selecciona un tipo y escribi un valor.",
                    "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                clsBaseDatos.InsertarContacto(
                    idSeleccionado,
                    cmbTipo.Text,
                    txtValor.Text.Trim());

                cmbTipo.SelectedIndex = -1;
                txtValor.Text = "";

                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar contacto: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCont_Click(object sender, EventArgs e)
        {
            if (dgvContactos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un contacto para eliminar.",
                    "Sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCont = Convert.ToInt32(dgvContactos.CurrentRow.Cells["IdContacto"].Value);

            try
            {
                clsBaseDatos.EliminarContacto(idCont);
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar contacto: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("DNI, Nombre y Apellido son obligatorios.",
                    "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsBaseDatos.ExisteDni(txtDni.Text.Trim(), idSeleccionado))
            {
                MessageBox.Show("Ya existe una persona con ese DNI.",
                    "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idSeleccionado == -1)
                {
                    // INSERT → guardo el ID generado para poder agregar domicilios/contactos
                    idSeleccionado = clsBaseDatos.InsertarPersonal(
                        txtDni.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        chkActivar.Checked);

                    MessageBox.Show("Personal registrado. Ahora podes agregar domicilios y contactos.",
                        "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // UPDATE
                    clsBaseDatos.ActualizarPersonal(
                        idSeleccionado,
                        txtDni.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        chkActivar.Checked);

                    MessageBox.Show("Personal actualizado.",
                        "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona una persona de la grilla para eliminar.",
                    "Sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "Estas seguro de que queres eliminar a " + txtNombre.Text + " " + txtApellido.Text +
                "?\nSe borraran tambien sus domicilios y contactos.",
                "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    clsBaseDatos.EliminarPersonal(idSeleccionado);
                    MessageBox.Show("Personal eliminado.",
                        "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Domicilio
            txtDireccion.Text = "";
            txtGeo.Text = "";
            cmbProvincia.SelectedIndex = -1;
            cmbLocalidad.DataSource = null;

            // Contacto
            cmbTipo.SelectedIndex = -1;
            txtValor.Text = "";

            // Sub-grillas
            dgvDomicilios.DataSource = null;
            dgvContactos.DataSource = null;

            dgvPersonal.ClearSelection();
        }
    }
}
