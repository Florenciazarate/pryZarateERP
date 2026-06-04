using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Formulario de gestión de personal: permite crear, editar y desactivar personas,
    // y agregar/quitar sus domicilios y contactos.
    public partial class frmPersonalizarPerfil : Form
    {
        // Modo alta: estoy creando una persona nueva
        // Modo edición: estoy viendo/editando una persona existente
        private enum Modo { Alta, Edicion }
        private Modo      _modo = Modo.Alta;

        private int       idSeleccionado = -1; // ID de la persona seleccionada en la lista (-1 = ninguna)
        private DataTable _tabla;              // tabla con todos los registros de Personal de la BD

        // Clases auxiliares para mostrar objetos en los ListBox con un texto personalizado
        private class PersonaItem { public int Id; public string Texto; public override string ToString() => Texto; }
        private class DomItem     { public int Id; public string T;     public override string ToString() => T; }
        private class ContItem    { public int Id; public string T;     public override string ToString() => T; }

        public frmPersonalizarPerfil() { InitializeComponent(); }

        // ─────────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────────

        // Se ejecuta cuando el formulario termina de cargarse
        private void frmPersonalizarPerfil_Load(object sender, EventArgs e)
        {
            CargarProvincias(); // lleno el combo de provincias
            CargarTipos();      // lleno el combo de tipos de contacto
            CargarLista();      // lleno la lista de personas
            SetModo(Modo.Alta); // arranco en modo "nueva persona"
        }

        // ─────────────────────────────────────────────────────────────────
        // ESTADO
        // ─────────────────────────────────────────────────────────────────

        // Cambia el texto de los botones y habilita/deshabilita controles
        // según si estoy creando (Alta) o editando (Edicion) una persona.
        private void SetModo(Modo m)
        {
            _modo = m;
            bool hay = m == Modo.Edicion; // "hay" = hay una persona seleccionada

            // Cambio el texto del título y del botón guardar según el modo
            if (m == Modo.Alta)
            {
                lblTitDatos.Text = "Nueva persona";
                btnGuardar.Text  = "Guardar";
            }
            else
            {
                btnGuardar.Text = "Actualizar";
            }

            // Los controles de domicilios y contactos solo se habilitan cuando hay una persona seleccionada
            // (porque necesitan el ID de la persona para guardar en la BD)
            btnDesactivar.Enabled  = hay;
            cmbProvincia.Enabled   = hay;
            cmbLocalidad.Enabled   = hay;
            txtDireccion.Enabled   = hay;
            txtGeo.Enabled         = hay;
            btnAgregarDom.Enabled  = hay;
            btnQuitarDom.Enabled   = hay;
            btnVerMapa.Enabled     = hay;
            cmbTipo.Enabled        = hay;
            txtValor.Enabled       = hay;
            btnAgregarCont.Enabled = hay;
            btnQuitarCont.Enabled  = hay;
        }

        // ─────────────────────────────────────────────────────────────────
        // LISTA IZQUIERDA
        // ─────────────────────────────────────────────────────────────────

        // Trae todos los registros de Personal de la BD y guarda en _tabla, luego filtra
        private void CargarLista()
        {
            _tabla = clsBaseDatos.ObtenerPersonal();
            FiltrarLista();
        }

        // Muestra en el ListBox solo las personas que coinciden con el texto del buscador
        private void FiltrarLista()
        {
            lstPersonas.Items.Clear();
            if (_tabla == null) return;

            string f = txtBuscar.Text.Trim().ToUpperInvariant(); // texto a buscar, en mayúsculas

            foreach (DataRow row in _tabla.Rows)
            {
                string dni = row["DNI"].ToString();
                string nom = row["Nombre"].ToString();
                string ape = row["Apellido"].ToString();
                bool   act = Convert.ToBoolean(row["Activo"]);

                // Si hay texto en el buscador y la fila no coincide ni por apellido, nombre ni DNI, la salteo
                if (f.Length > 0 &&
                    !ape.ToUpperInvariant().Contains(f) &&
                    !nom.ToUpperInvariant().Contains(f) &&
                    !dni.Contains(f)) continue;

                // Agrego la persona al ListBox con el texto formateado
                lstPersonas.Items.Add(new PersonaItem
                {
                    Id    = Convert.ToInt32(row["IdPersonal"]),
                    Texto = act ? $"{ape}, {nom}" : $"[inact.]  {ape}, {nom}" // los inactivos se marcan con [inact.]
                });
            }
        }

        // Se ejecuta cada vez que el usuario escribe algo en el buscador
        private void txtBuscar_TextChanged(object sender, EventArgs e) => FiltrarLista();

        // Se ejecuta cuando el usuario selecciona una persona en la lista
        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedItem == null) return;

            int id = ((PersonaItem)lstPersonas.SelectedItem).Id; // obtengo el ID de la persona seleccionada

            // Busco la fila correspondiente en _tabla para mostrar sus datos
            foreach (DataRow row in _tabla.Rows)
            {
                if (Convert.ToInt32(row["IdPersonal"]) != id) continue;

                idSeleccionado   = id;
                txtDni.Text      = row["DNI"].ToString();
                txtNombre.Text   = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();

                bool act = Convert.ToBoolean(row["Activo"]);
                lblTitDatos.Text   = $"{row["Apellido"]}, {row["Nombre"]}  ·  {(act ? "Activo" : "Inactivo")}";
                btnDesactivar.Text = act ? "Desactivar" : "Reactivar"; // el botón dice lo contrario del estado actual

                SetModo(Modo.Edicion); // cambio a modo edición
                CargarDomicilios();    // cargo los domicilios de esta persona
                CargarContactos();     // cargo los contactos de esta persona
                break;                 // encontré la fila, no sigo buscando
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // COMBOS
        // ─────────────────────────────────────────────────────────────────

        // Llena el combo de provincias con los datos de la BD
        private void CargarProvincias()
        {
            cmbProvincia.DataSource    = clsBaseDatos.ObtenerProvincias();
            cmbProvincia.DisplayMember = "Provincias";       // columna a mostrar
            cmbProvincia.ValueMember   = "ID_Provincias";    // columna que representa el valor
            cmbProvincia.SelectedIndex = -1;                 // arranca sin ninguna provincia seleccionada
        }

        // Se ejecuta cuando el usuario cambia la provincia seleccionada.
        // Solo carga localidades si la provincia es Córdoba (las demás no tienen datos en la BD).
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLocalidad.DataSource = null;
            cmbLocalidad.Items.Clear();

            if (cmbProvincia.SelectedIndex < 0) { cmbLocalidad.Enabled = true; return; }

            bool esCba = cmbProvincia.Text.IndexOf("doba", StringComparison.OrdinalIgnoreCase) >= 0; // detecta "Córdoba"

            if (esCba)
            {
                // Cargo las localidades de Córdoba desde la BD
                cmbLocalidad.DataSource    = clsBaseDatos.ObtenerLocalidadesCordoba();
                cmbLocalidad.DisplayMember = "LocalidadesCordoba";
                cmbLocalidad.ValueMember   = "ID_Localidades";
                cmbLocalidad.Enabled       = true;
            }
            else
            {
                // Para el resto de las provincias no hay datos de localidades
                cmbLocalidad.Items.Add("(Solo disponible para Córdoba)");
                cmbLocalidad.SelectedIndex = 0;
                cmbLocalidad.Enabled       = false;
            }

            if (cmbLocalidad.Enabled) cmbLocalidad.SelectedIndex = -1;
        }

        // Llena el combo de tipos de contacto con las opciones fijas
        private void CargarTipos()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new object[]
                { "Email", "Teléfono", "WhatsApp", "Instagram", "Facebook", "Twitter / X", "LinkedIn", "TikTok" });
            cmbTipo.SelectedIndex = -1;
        }

        // ─────────────────────────────────────────────────────────────────
        // NUEVA / GUARDAR / DESACTIVAR
        // ─────────────────────────────────────────────────────────────────

        // Se ejecuta cuando el usuario hace clic en "+ Nueva persona"
        private void btnNueva_Click(object sender, EventArgs e)
        {
            lstPersonas.ClearSelected(); // deselecciono la persona de la lista
            LimpiarFormulario();         // borro todos los campos del formulario
            SetModo(Modo.Alta);          // cambio a modo alta
            txtDni.Focus();              // pongo el foco en el campo DNI para que el usuario empiece a escribir
        }

        // Se ejecuta cuando el usuario hace clic en "Guardar" o "Actualizar"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación: verifico que los campos obligatorios estén completos
            var faltantes = new List<string>();
            if (string.IsNullOrWhiteSpace(txtDni.Text))      faltantes.Add("DNI");
            if (string.IsNullOrWhiteSpace(txtNombre.Text))   faltantes.Add("Nombre");
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) faltantes.Add("Apellido");
            if (faltantes.Count > 0) { Aviso("Completá: " + string.Join(", ", faltantes) + "."); return; }

            if (_modo == Modo.Alta)
            {
                // Verifico que no exista ya una persona con ese DNI
                if (clsBaseDatos.ExisteDni(txtDni.Text.Trim()))
                { Aviso("Ya existe una persona con el DNI " + txtDni.Text.Trim() + "."); txtDni.Focus(); return; }

                try
                {
                    // Inserto la persona en la BD y guardo el ID que le asignó la base
                    idSeleccionado = clsBaseDatos.InsertarPersonal(
                        txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), true);

                    CargarLista(); // recargo la lista para que aparezca la persona nueva
                    SetModo(Modo.Edicion); // paso a modo edición para que pueda agregar domicilios y contactos
                    lblTitDatos.Text   = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  Activo";
                    btnDesactivar.Text = "Desactivar";
                    CargarDomicilios();
                    CargarContactos();
                }
                catch (Exception ex) { Err(ex); }
            }
            else
            {
                // Verifico que no exista otra persona con ese DNI (excluyendo a la persona que estoy editando)
                if (clsBaseDatos.ExisteDni(txtDni.Text.Trim(), idSeleccionado))
                { Aviso("Ya existe otra persona con ese DNI."); txtDni.Focus(); return; }

                try
                {
                    bool act = GetActivo(idSeleccionado, _tabla); // obtengo el estado activo/inactivo actual
                    clsBaseDatos.ActualizarPersonal(idSeleccionado,
                        txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), act);

                    CargarLista(); // recargo la lista para reflejar los cambios
                    lblTitDatos.Text = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  {(act ? "Activo" : "Inactivo")}";
                    MessageBox.Show("Datos actualizados.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { Err(ex); }
            }
        }

        // Se ejecuta cuando el usuario hace clic en "Desactivar" o "Reactivar"
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;

            bool esDesac = btnDesactivar.Text == "Desactivar"; // true si voy a desactivar, false si voy a reactivar

            // Pido confirmación antes de cambiar el estado
            if (MessageBox.Show($"¿{(esDesac ? "Desactivar" : "Reactivar")} a {txtNombre.Text} {txtApellido.Text}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bool act  = GetActivo(idSeleccionado, _tabla); // obtengo el estado actual
                bool nuevo = !act;                              // el nuevo estado es el opuesto

                clsBaseDatos.ActualizarPersonal(idSeleccionado,
                    txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), nuevo);

                CargarLista(); // recargo la lista para que refleje el cambio de estado
                lblTitDatos.Text   = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  {(nuevo ? "Activo" : "Inactivo")}";
                btnDesactivar.Text = nuevo ? "Desactivar" : "Reactivar"; // actualizo el texto del botón
            }
            catch (Exception ex) { Err(ex); }
        }

        // Borra el contenido de todos los campos del formulario y resetea el ID seleccionado
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

        // Trae los domicilios de la persona seleccionada y los muestra en el ListBox
        private void CargarDomicilios()
        {
            lstDom.Items.Clear();
            if (idSeleccionado == -1) return;

            foreach (DataRow row in clsBaseDatos.ObtenerDomicilios(idSeleccionado).Rows)
            {
                // Armo el texto a mostrar: "Dirección  —  Provincia, Localidad" (si tienen esos datos)
                string t = row["Direccion"].ToString();
                if (!string.IsNullOrEmpty(row["Provincia"].ToString())) t += "  —  " + row["Provincia"];
                if (!string.IsNullOrEmpty(row["Localidad"].ToString()))  t += ", " + row["Localidad"];

                lstDom.Items.Add(new DomItem { Id = Convert.ToInt32(row["IdDomicilio"]), T = t });
            }
        }

        // Se ejecuta cuando el usuario hace clic en "Agregar domicilio"
        private void btnAgregarDom_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { Aviso("Completá la dirección."); return; }

            // Obtengo los valores opcionales
            string prov = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : "";
            string loc  = (cmbLocalidad.DataSource != null && cmbLocalidad.SelectedIndex >= 0) ? cmbLocalidad.Text : "";
            string geo  = txtGeo.Text.Trim();

            // Intento parsear el campo Geo como coordenadas lat, lng
            double lat, lng;
            bool coords = TryParsear(geo, out lat, out lng);

            try
            {
                // Inserto el domicilio en la BD; si se parsearon coordenadas las guardo, si no, guardo null
                clsBaseDatos.InsertarDomicilio(idSeleccionado, txtDireccion.Text.Trim(), geo, prov, loc,
                    coords ? lat : (double?)null, coords ? lng : (double?)null);

                // Limpio los campos del formulario de domicilio
                txtDireccion.Clear(); txtGeo.Clear();
                cmbProvincia.SelectedIndex = -1;
                cmbLocalidad.DataSource = null; cmbLocalidad.Items.Clear(); cmbLocalidad.Enabled = true;

                CargarDomicilios(); // recargo la lista para mostrar el nuevo domicilio
            }
            catch (Exception ex) { Err(ex); }
        }

        // Se ejecuta cuando el usuario hace clic en "Quitar domicilio seleccionado"
        private void btnQuitarDom_Click(object sender, EventArgs e)
        {
            if (lstDom.SelectedItem == null) { Aviso("Seleccioná un domicilio para quitarlo."); return; }
            try
            {
                clsBaseDatos.EliminarDomicilio(((DomItem)lstDom.SelectedItem).Id); // elimino por ID
                CargarDomicilios(); // recargo la lista
            }
            catch (Exception ex) { Err(ex); }
        }

        // Se ejecuta cuando el usuario hace clic en "Ver mapa"
        // Abre el link de Google Maps en el navegador predeterminado
        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            string t = txtGeo.Text.Trim();
            if (string.IsNullOrEmpty(t)) { Aviso("Completá el campo Geo."); return; }

            // Si el campo Geo ya es una URL la uso directamente; si no, la armo como búsqueda en Google Maps
            string url = t.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                ? t : "https://www.google.com/maps?q=" + Uri.EscapeDataString(t);

            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        // ─────────────────────────────────────────────────────────────────
        // REDES / CONTACTOS
        // ─────────────────────────────────────────────────────────────────

        // Trae los contactos de la persona seleccionada y los muestra en el ListBox
        private void CargarContactos()
        {
            lstCont.Items.Clear();
            if (idSeleccionado == -1) return;

            foreach (DataRow row in clsBaseDatos.ObtenerContactos(idSeleccionado).Rows)
                lstCont.Items.Add(new ContItem
                    { Id = Convert.ToInt32(row["IdContacto"]), T = $"{row["Tipo"]}:  {row["Valor"]}" });
        }

        // Se ejecuta cuando el usuario hace clic en "Agregar contacto"
        private void btnAgregarCont_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;
            if (cmbTipo.SelectedIndex < 0)             { Aviso("Elegí el tipo."); return; }
            if (string.IsNullOrWhiteSpace(txtValor.Text)) { Aviso("Completá el dato."); return; }

            try
            {
                clsBaseDatos.InsertarContacto(idSeleccionado, cmbTipo.Text, txtValor.Text.Trim());
                cmbTipo.SelectedIndex = -1; txtValor.Clear(); // limpio los campos
                CargarContactos(); // recargo la lista
            }
            catch (Exception ex) { Err(ex); }
        }

        // Se ejecuta cuando el usuario hace clic en "Quitar contacto seleccionado"
        private void btnQuitarCont_Click(object sender, EventArgs e)
        {
            if (lstCont.SelectedItem == null) { Aviso("Seleccioná un contacto para quitarlo."); return; }
            try
            {
                clsBaseDatos.EliminarContacto(((ContItem)lstCont.SelectedItem).Id); // elimino por ID
                CargarContactos(); // recargo la lista
            }
            catch (Exception ex) { Err(ex); }
        }

        // ─────────────────────────────────────────────────────────────────
        // HELPERS
        // ─────────────────────────────────────────────────────────────────

        // Intenta parsear el texto del campo Geo como coordenadas (lat, lng).
        // Acepta links de Google Maps o texto directo en formato "-31.4, -64.1".
        // Devuelve true si pudo parsear, y los valores en los parámetros out.
        private static bool TryParsear(string texto, out double lat, out double lng)
        {
            lat = lng = 0;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            var inv = System.Globalization.CultureInfo.InvariantCulture;
            var ns  = System.Globalization.NumberStyles.Float;

            // Pruebo tres patrones de regex: link de Google Maps con @, link con ?q=, y texto plano "lat,lng"
            foreach (string patron in new[] {
                @"/@(-?\d+\.?\d+),\s*(-?\d+\.?\d+)",
                @"[?&]q=(-?\d+\.?\d+)[,+]\s*(-?\d+\.?\d+)",
                @"^(-?\d+\.?\d+)\s*,\s*(-?\d+\.?\d+)\s*$" })
            {
                var m = Regex.Match(texto, patron);
                if (!m.Success) continue;

                double a, b;
                if (double.TryParse(m.Groups[1].Value, ns, inv, out a) &&
                    double.TryParse(m.Groups[2].Value, ns, inv, out b) &&
                    a >= -90 && a <= 90 && b >= -180 && b <= 180) // valido que estén en rango de coordenadas válidas
                { lat = a; lng = b; return true; }
            }
            return false;
        }

        // Busca en _tabla si la persona con el ID dado está activa o no
        private static bool GetActivo(int id, DataTable t)
        {
            foreach (DataRow r in t.Rows)
                if (Convert.ToInt32(r["IdPersonal"]) == id) return Convert.ToBoolean(r["Activo"]);
            return true; // si no la encuentra, asumo activa (no debería pasar)
        }

        // Muestra un mensaje de advertencia al usuario
        private void Aviso(string msg) => MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        // Muestra un mensaje de error con el detalle de la excepción
        private void Err(Exception ex) => MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
