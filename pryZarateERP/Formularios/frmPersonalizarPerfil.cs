using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Formulario de gestión de personal: permite crear, editar y desactivar personas,
    // y agregar/quitar sus domicilios y contactos.
    public partial class frmPersonalizarPerfil : Form
    {
        private int       idSeleccionado = -1; // ID de la persona seleccionada (-1 = ninguna / modo alta)
        private DataTable _tabla;              // todos los registros de Personal traídos de la BD

        // Clases auxiliares para guardar el ID junto al texto que muestra el ListBox
        private class PersonaItem { public int Id; public string Texto; public override string ToString() => Texto; }
        private class DomItem     { public int Id; public string T;     public override string ToString() => T; }
        private class ContItem    { public int Id; public string T;     public override string ToString() => T; }

        public frmPersonalizarPerfil() { InitializeComponent(); }

        // ─────────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────────

        private void frmPersonalizarPerfil_Load(object sender, EventArgs e)
        {
            CargarProvincias();
            CargarTipos();
            CargarLista();
            SetModo(false); // arranca en modo alta (sin persona seleccionada)
        }

        // ─────────────────────────────────────────────────────────────────
        // ESTADO
        // ─────────────────────────────────────────────────────────────────

        // edicion = true: hay una persona seleccionada → habilita domicilios y contactos
        // edicion = false: modo alta → solo DNI, nombre y apellido disponibles
        private void SetModo(bool edicion)
        {
            lblTitDatos.Text = edicion ? "" : "Nueva persona";
            btnGuardar.Text  = edicion ? "Actualizar" : "Guardar";

            btnDesactivar.Enabled  = edicion;
            cmbProvincia.Enabled   = edicion;
            cmbLocalidad.Enabled   = edicion;
            txtDireccion.Enabled   = edicion;
            txtGeo.Enabled         = edicion;
            btnAgregarDom.Enabled  = edicion;
            btnQuitarDom.Enabled   = edicion;
            btnVerMapa.Enabled     = edicion;
            cmbTipo.Enabled        = edicion;
            txtValor.Enabled       = edicion;
            btnAgregarCont.Enabled = edicion;
            btnQuitarCont.Enabled  = edicion;
        }

        // ─────────────────────────────────────────────────────────────────
        // LISTA IZQUIERDA
        // ─────────────────────────────────────────────────────────────────

        private void CargarLista()
        {
            _tabla = clsBaseDatos.ObtenerPersonal();
            FiltrarLista();
        }

        // Muestra en el ListBox solo las personas que coinciden con el buscador
        private void FiltrarLista()
        {
            lstPersonas.Items.Clear();
            if (_tabla == null) return;

            string f = txtBuscar.Text.Trim().ToUpperInvariant();

            foreach (DataRow row in _tabla.Rows)
            {
                string dni = row["DNI"].ToString();
                string nom = row["Nombre"].ToString();
                string ape = row["Apellido"].ToString();
                bool   act = Convert.ToBoolean(row["Activo"]);

                // Si hay texto en el buscador y la fila no coincide, la salteo
                if (f.Length > 0 &&
                    !ape.ToUpperInvariant().Contains(f) &&
                    !nom.ToUpperInvariant().Contains(f) &&
                    !dni.Contains(f)) continue;

                lstPersonas.Items.Add(new PersonaItem
                {
                    Id    = Convert.ToInt32(row["IdPersonal"]),
                    Texto = act ? $"{ape}, {nom}" : $"[inact.]  {ape}, {nom}"
                });
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => FiltrarLista();

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedItem == null) return;

            int id = ((PersonaItem)lstPersonas.SelectedItem).Id;

            foreach (DataRow row in _tabla.Rows)
            {
                if (Convert.ToInt32(row["IdPersonal"]) != id) continue;

                idSeleccionado   = id;
                txtDni.Text      = row["DNI"].ToString();
                txtNombre.Text   = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();

                bool act = Convert.ToBoolean(row["Activo"]);
                lblTitDatos.Text   = $"{row["Apellido"]}, {row["Nombre"]}  ·  {(act ? "Activo" : "Inactivo")}";
                btnDesactivar.Text = act ? "Desactivar" : "Reactivar";

                SetModo(true);
                CargarDomicilios();
                CargarContactos();
                break;
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // COMBOS
        // ─────────────────────────────────────────────────────────────────

        private void CargarProvincias()
        {
            cmbProvincia.DataSource    = clsBaseDatos.ObtenerProvincias();
            cmbProvincia.DisplayMember = "Provincias";
            cmbProvincia.ValueMember   = "ID_Provincias";
            cmbProvincia.SelectedIndex = -1;
        }

        // Solo carga localidades si la provincia es Córdoba (las demás no tienen datos en la BD)
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLocalidad.DataSource = null;
            cmbLocalidad.Items.Clear();

            if (cmbProvincia.SelectedIndex < 0) { cmbLocalidad.Enabled = true; return; }

            if (cmbProvincia.Text.IndexOf("doba", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                cmbLocalidad.DataSource    = clsBaseDatos.ObtenerLocalidadesCordoba();
                cmbLocalidad.DisplayMember = "LocalidadesCordoba";
                cmbLocalidad.ValueMember   = "ID_Localidades";
                cmbLocalidad.Enabled       = true;
                cmbLocalidad.SelectedIndex = -1;
            }
            else
            {
                cmbLocalidad.Items.Add("(Solo disponible para Córdoba)");
                cmbLocalidad.SelectedIndex = 0;
                cmbLocalidad.Enabled       = false;
            }
        }

        private void CargarTipos()
        {
            cmbTipo.Items.AddRange(new object[]
                { "Email", "Teléfono", "WhatsApp", "Instagram", "Facebook", "Twitter / X", "LinkedIn", "TikTok" });
            cmbTipo.SelectedIndex = -1;
        }

        // ─────────────────────────────────────────────────────────────────
        // NUEVA / GUARDAR / DESACTIVAR
        // ─────────────────────────────────────────────────────────────────

        private void btnNueva_Click(object sender, EventArgs e)
        {
            lstPersonas.ClearSelected();
            LimpiarFormulario();
            SetModo(false);
            txtDni.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtDni.Text))      { Aviso("Completá el DNI.");      return; }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))   { Aviso("Completá el nombre.");   return; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { Aviso("Completá el apellido."); return; }

            if (idSeleccionado == -1) // modo alta
            {
                if (clsBaseDatos.ExisteDni(txtDni.Text.Trim()))
                { Aviso("Ya existe una persona con el DNI " + txtDni.Text.Trim() + "."); txtDni.Focus(); return; }

                try
                {
                    idSeleccionado = clsBaseDatos.InsertarPersonal(
                        txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), true);

                    CargarLista();
                    SetModo(true);
                    lblTitDatos.Text   = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  Activo";
                    btnDesactivar.Text = "Desactivar";
                    CargarDomicilios();
                    CargarContactos();
                }
                catch (Exception ex) { Err(ex); }
            }
            else // modo edición
            {
                if (clsBaseDatos.ExisteDni(txtDni.Text.Trim(), idSeleccionado))
                { Aviso("Ya existe otra persona con ese DNI."); txtDni.Focus(); return; }

                try
                {
                    // El texto del botón indica el estado actual: "Desactivar" = está activo
                    bool activo = btnDesactivar.Text == "Desactivar";
                    clsBaseDatos.ActualizarPersonal(idSeleccionado,
                        txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), activo);

                    CargarLista();
                    lblTitDatos.Text = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  {(activo ? "Activo" : "Inactivo")}";
                    MessageBox.Show("Datos actualizados.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { Err(ex); }
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;

            // El texto del botón indica la acción a realizar
            bool desactivar = btnDesactivar.Text == "Desactivar";

            if (MessageBox.Show($"¿{(desactivar ? "Desactivar" : "Reactivar")} a {txtNombre.Text} {txtApellido.Text}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bool nuevoEstado = !desactivar; // si voy a desactivar, el nuevo estado es inactivo (false)
                clsBaseDatos.ActualizarPersonal(idSeleccionado,
                    txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), nuevoEstado);

                CargarLista();
                lblTitDatos.Text   = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  {(nuevoEstado ? "Activo" : "Inactivo")}";
                btnDesactivar.Text = nuevoEstado ? "Desactivar" : "Reactivar";
            }
            catch (Exception ex) { Err(ex); }
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = -1;
            txtDni.Clear(); txtNombre.Clear(); txtApellido.Clear();
            txtDireccion.Clear(); txtGeo.Clear();
            cmbProvincia.SelectedIndex = -1;
            cmbLocalidad.DataSource = null; cmbLocalidad.Items.Clear(); cmbLocalidad.Enabled = true;
            cmbTipo.SelectedIndex = -1; txtValor.Clear();
            lstDom.Items.Clear(); lstCont.Items.Clear();
        }

        // ─────────────────────────────────────────────────────────────────
        // DOMICILIOS
        // ─────────────────────────────────────────────────────────────────

        private void CargarDomicilios()
        {
            lstDom.Items.Clear();
            if (idSeleccionado == -1) return;

            foreach (DataRow row in clsBaseDatos.ObtenerDomicilios(idSeleccionado).Rows)
            {
                string t = row["Direccion"].ToString();
                if (!string.IsNullOrEmpty(row["Provincia"].ToString())) t += "  —  " + row["Provincia"];
                if (!string.IsNullOrEmpty(row["Localidad"].ToString()))  t += ", "    + row["Localidad"];
                lstDom.Items.Add(new DomItem { Id = Convert.ToInt32(row["IdDomicilio"]), T = t });
            }
        }

        private void btnAgregarDom_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { Aviso("Completá la dirección."); return; }

            string prov = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : "";
            string loc  = (cmbLocalidad.DataSource != null && cmbLocalidad.SelectedIndex >= 0) ? cmbLocalidad.Text : "";

            try
            {
                clsBaseDatos.InsertarDomicilio(idSeleccionado, txtDireccion.Text.Trim(), txtGeo.Text.Trim(), prov, loc);

                txtDireccion.Clear(); txtGeo.Clear();
                cmbProvincia.SelectedIndex = -1;
                cmbLocalidad.DataSource = null; cmbLocalidad.Items.Clear(); cmbLocalidad.Enabled = true;
                CargarDomicilios();
            }
            catch (Exception ex) { Err(ex); }
        }

        private void btnQuitarDom_Click(object sender, EventArgs e)
        {
            if (lstDom.SelectedItem == null) { Aviso("Seleccioná un domicilio para quitarlo."); return; }
            try { clsBaseDatos.EliminarDomicilio(((DomItem)lstDom.SelectedItem).Id); CargarDomicilios(); }
            catch (Exception ex) { Err(ex); }
        }

        // Abre el campo Geo en Google Maps (acepta URL directa o coordenadas)
        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            string t = txtGeo.Text.Trim();
            if (string.IsNullOrEmpty(t)) { Aviso("Completá el campo Geo."); return; }

            string url = t.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                ? t : "https://www.google.com/maps?q=" + Uri.EscapeDataString(t);

            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        // ─────────────────────────────────────────────────────────────────
        // CONTACTOS
        // ─────────────────────────────────────────────────────────────────

        private void CargarContactos()
        {
            lstCont.Items.Clear();
            if (idSeleccionado == -1) return;

            foreach (DataRow row in clsBaseDatos.ObtenerContactos(idSeleccionado).Rows)
                lstCont.Items.Add(new ContItem
                    { Id = Convert.ToInt32(row["IdContacto"]), T = $"{row["Tipo"]}:  {row["Valor"]}" });
        }

        private void btnAgregarCont_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;
            if (cmbTipo.SelectedIndex < 0)                { Aviso("Elegí el tipo.");      return; }
            if (string.IsNullOrWhiteSpace(txtValor.Text)) { Aviso("Completá el dato.");   return; }

            try
            {
                clsBaseDatos.InsertarContacto(idSeleccionado, cmbTipo.Text, txtValor.Text.Trim());
                cmbTipo.SelectedIndex = -1; txtValor.Clear();
                CargarContactos();
            }
            catch (Exception ex) { Err(ex); }
        }

        private void btnQuitarCont_Click(object sender, EventArgs e)
        {
            if (lstCont.SelectedItem == null) { Aviso("Seleccioná un contacto para quitarlo."); return; }
            try { clsBaseDatos.EliminarContacto(((ContItem)lstCont.SelectedItem).Id); CargarContactos(); }
            catch (Exception ex) { Err(ex); }
        }

        // ─────────────────────────────────────────────────────────────────
        // HELPERS
        // ─────────────────────────────────────────────────────────────────

        private void Aviso(string msg) => MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void Err(Exception ex) => MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
