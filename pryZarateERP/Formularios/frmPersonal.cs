using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmPersonal : Form
    {
        private int idSeleccionado = -1; // ID de la persona seleccionada (-1 = ninguna / modo alta)
        private bool _activoSeleccionado;      // estado activo/inactivo real de la persona seleccionada
        private DataTable _tabla;              // todos los registros de Personal traídos de la BD

        // Clases auxiliares para guardar el ID junto al texto que muestra el ListBox
        private class PersonaItem { public int Id; public string Texto; public override string ToString() => Texto; } //molde para mostrar el nombre de la persona en el ListBox y tener a la vez su ID guardado para usarlo luego
        private class DomItem { public int Id; public string T; public override string ToString() => T; } //molde para mostrar el domicilio en el ListBox y tener a la vez su ID guardado para usarlo luego
        private class ContItem { public int Id; public string T; public override string ToString() => T; }

        public frmPersonal()
        {
            InitializeComponent();
            txtDni.KeyPress += (s, e) => { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; };  // el campo DNI solo acepta números
            // Nombre y Apellido NO aceptan números (dejan letras, espacios, acentos, etc.)
            txtNombre.KeyPress   += (s, e) => { if (char.IsDigit(e.KeyChar)) e.Handled = true; };
            txtApellido.KeyPress += (s, e) => { if (char.IsDigit(e.KeyChar)) e.Handled = true; };
            // Si el tipo de contacto elegido es "Teléfono", el dato solo acepta números
            txtValor.KeyPress += (s, e) => { if (cmbTipo.Text == "Teléfono" && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; };
            // Las listas desplegables siempre abren hacia abajo (si hay lugar en la pantalla)
            cmbProvincia.DropDown += ForzarAperturaAbajo;
            cmbLocalidad.DropDown += ForzarAperturaAbajo;
            cmbTipo.DropDown      += ForzarAperturaAbajo;
            cmbRed.DropDown       += ForzarAperturaAbajo;
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            CargarProvincias();
            CargarLista();
            SetModo(false);
        }


        // edicion = true: hay una persona seleccionada → habilita domicilios y contactos
        // edicion = false: modo alta → solo DNI, nombre y apellido disponibles
        private void SetModo(bool edicion)
        {
            if (!edicion) lblTitDatos.Text = "Nueva persona";
            btnGuardar.Text = edicion ? "Actualizar" : "Guardar";
            btnGuardar.Enabled = !edicion || _activoSeleccionado;

            btnDesactivar.Enabled = edicion;
            cmbProvincia.Enabled = edicion;
            cmbLocalidad.Enabled = false;
            txtDireccion.Enabled = edicion;
            txtGeo.Enabled = edicion;
            btnAgregarDom.Enabled = edicion;
            btnQuitarDom.Enabled = edicion;
            btnVerMapa.Enabled = edicion;
            cmbTipo.Enabled = edicion;
            cmbRed.Enabled = false; // cmbRed solo se habilita si se elige "Red social"
            txtValor.Enabled = edicion;
            btnAgregarCont.Enabled = edicion;
            btnQuitarCont.Enabled = edicion;

        }


        private void CargarLista()
        {
            try
            {
                _tabla = clsBaseDatos.ObtenerPersonal();
                FiltrarLista();
            }
            catch (Exception ex) { Err(ex); }
        }

        // recorre _tabla y muestra solo las personas que coinciden con el buscador
        private void FiltrarLista()
        {
            lstPersonas.Items.Clear();
            if (_tabla == null) return;

            string f = txtBuscar.Text.Trim().ToUpperInvariant(); // filtro en mayúsculas para que no importe si el usuario escribió minúsculas o mayúsculas

            foreach (DataRow row in _tabla.Rows) // recorro todos los registros de Personal traídos de la BD
            {
                string dni = row["DNI"].ToString(); // el DNI lo dejo tal cual está en la BD (sin pasar a mayúsculas, porque es solo números)
                string nom = row["Nombre"].ToString();
                string ape = row["Apellido"].ToString();
                bool act = Convert.ToBoolean(row["Activo"]); // el estado activo/inactivo real de la persona (no deducido del texto del botón)

                if (f.Length > 0 && // si hay texto en el buscador, filtro por coincidencia en DNI, nombre o apellido
                    !ape.ToUpperInvariant().Contains(f) && // paso a mayúsculas para que no importe si el usuario escribió minúsculas o mayúsculas
                    !nom.ToUpperInvariant().Contains(f) &&
                    !dni.Contains(f)) continue;

                lstPersonas.Items.Add(new PersonaItem // agrego a la lista un objeto PersonaItem que contiene el ID y el texto a mostrar
                {
                    Id = Convert.ToInt32(row["IdPersonal"]), // el ID de la persona lo tengo guardado en el ListBox gracias a la clase PersonaItem
                    Texto = act ? $"{ape}, {nom}" : $"[inact.]  {ape}, {nom}" // el texto que se muestra en la lista indica si la persona está inactiva
                });
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => FiltrarLista();

        // el botón Buscar hace lo mismo que el filtro en tiempo real, pero da feedback visual de que "se buscó"
        private void btnBuscar_Click(object sender, EventArgs e) => FiltrarLista();

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedItem == null) return;

            int id = ((PersonaItem)lstPersonas.SelectedItem).Id; // obtengo el ID de la persona seleccionada del ListBox gracias a la clase PersonaItem

            foreach (DataRow row in _tabla.Rows) // recorro todos los registros de Personal traídos de la BD hasta encontrar el que coincide con el ID seleccionado
            {
                if (Convert.ToInt32(row["IdPersonal"]) != id) continue; // si no coincide, sigo buscando

                idSeleccionado = id;
                txtDni.Text = row["DNI"].ToString();
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();

                bool act = Convert.ToBoolean(row["Activo"]);
                _activoSeleccionado = act; // guardo el estado real en vez de deducirlo del texto del botón
                lblTitDatos.Text = $"{row["Apellido"]}, {row["Nombre"]}  ·  {(act ? "Activo" : "Inactivo")}";
                btnDesactivar.Text = act ? "Desactivar" : "Reactivar";

                SetModo(true); // habilito los campos de domicilios y contactos
                CargarDomicilios();
                CargarContactos();
                break; // una vez que encontré la persona seleccionada, no necesito seguir recorriendo la tabla
            }
        }


        private void CargarProvincias()
        {
            try
            {
                cmbProvincia.DataSource = clsBaseDatos.ObtenerProvincias();
                cmbProvincia.DisplayMember = "Provincias";
                cmbProvincia.ValueMember = "ID_Provincias";
                cmbProvincia.SelectedIndex = -1;
            }
            catch (Exception ex) { Err(ex); }
        }

        // carga las localidades de la provincia seleccionada
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLocalidad.DataSource = null;
            cmbLocalidad.Items.Clear();

            // SelectedValue todavía no es un ID cuando el combo está en medio del binding
            if (cmbProvincia.SelectedIndex < 0 || !(cmbProvincia.SelectedValue is int idProvincia))
            { cmbLocalidad.Enabled = false; return; } // si no hay provincia seleccionada, deshabilito el combo de localidades

            try // si hay provincia seleccionada, cargo las localidades correspondientes
            {
                cmbLocalidad.DataSource = clsBaseDatos.ObtenerLocalidades(idProvincia);
                cmbLocalidad.DisplayMember = "Localidad";
                cmbLocalidad.ValueMember = "ID_Localidades";
                cmbLocalidad.Enabled = true;
                cmbLocalidad.SelectedIndex = -1; 
            }
            catch (Exception ex) { Err(ex); } // si falla la carga de localidades, muestro el error y dejo el combo deshabilitado
        }

        // habilita cmbRed solo cuando el tipo elegido es "Red social"
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esRed = cmbTipo.SelectedIndex >= 0 && cmbTipo.Text == "Red social"; // si el tipo elegido es "Red social", habilito el combo de redes; si no, lo deshabilito y lo limpio
            cmbRed.Enabled = esRed; // si el tipo elegido es "Red social", habilito el combo de redes; si no, lo deshabilito y lo limpio
            if (!esRed) cmbRed.SelectedIndex = -1;  // si no es red social, limpio la selección de red
            txtValor.MaxLength = cmbTipo.Text == "Email" ? 20 : 10; // si es email, el dato puede tener hasta 20 caracteres; si es teléfono o red social, hasta 10
            txtValor.Text = "";
        }

        private void btnNueva_Click(object sender, EventArgs e) // limpia el formulario para dar de alta una nueva persona
        {
            lstPersonas.ClearSelected();
            LimpiarFormulario();
            SetModo(false);
            txtDni.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text)) { Aviso("Completá el DNI."); txtDni.Focus(); return; }
            if (txtDni.Text.Trim().Length < 7) { Aviso("El DNI debe tener entre 7 y 8 dígitos."); txtDni.Focus(); return; } // MaxLength=8 ya impide más de 8
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { Aviso("Completá el nombre."); txtNombre.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { Aviso("Completá el apellido."); txtApellido.Focus(); return; }

            try
            {
                if (idSeleccionado == -1) // modo alta
                {
                    if (clsBaseDatos.ExisteDni(txtDni.Text.Trim()))
                    { Aviso("Ya existe una persona con el DNI " + txtDni.Text.Trim() + "."); txtDni.Focus(); return; }

                    idSeleccionado = clsBaseDatos.InsertarPersonal(
                        txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), true);
                    _activoSeleccionado = true; // una persona recién dada de alta queda activa

                    clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Personal", "Alta",
                        $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()} — DNI: {txtDni.Text.Trim()}", true);
                    CargarLista();
                    SetModo(true);
                    lblTitDatos.Text = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  Activo";
                    btnDesactivar.Text = "Desactivar";
                    CargarDomicilios();
                    CargarContactos();

                    MessageBox.Show("Agregaste a una nueva persona.", "Listo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // modo edición
                {
                    if (clsBaseDatos.ExisteDni(txtDni.Text.Trim(), idSeleccionado))
                    { Aviso("Ya existe otra persona con ese DNI."); txtDni.Focus(); return; }

                    bool activo = _activoSeleccionado; // estado real, no deducido del texto del botón
                    clsBaseDatos.ActualizarPersonal(idSeleccionado,
                        txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), activo);

                    clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Personal", "Modificación",
                        $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()} — DNI: {txtDni.Text.Trim()}", true);
                    CargarLista();
                    lblTitDatos.Text = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  {(activo ? "Activo" : "Inactivo")}";
                    MessageBox.Show("Datos actualizados.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { Err(ex); }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;

            bool desactivar = _activoSeleccionado; // si está activa, la acción es desactivar (y viceversa)

            if (MessageBox.Show($"¿{(desactivar ? "Desactivar" : "Reactivar")} a {txtNombre.Text} {txtApellido.Text}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bool nuevoEstado = !desactivar; // si estaba activa, la paso a inactiva; si estaba inactiva, la paso a activa
                clsBaseDatos.ActualizarPersonal(idSeleccionado, // el ID de la persona ya lo tengo guardado en idSeleccionado
                    txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), nuevoEstado); // actualizo el estado en la BD
                _activoSeleccionado = nuevoEstado; // mantengo sincronizado el estado real

                clsBaseDatos.RegistrarAuditoria(SessionInfo.Usuario, "Personal", // acción de desactivar o reactivar
                    desactivar ? "Desactivar" : "Reactivar", // detalle: nombre y apellido de la persona
                    $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}", true);
                CargarLista(); // recargo la lista para que se vea el cambio de estado (inactivo aparece con "[inact.]" delante)
                lblTitDatos.Text = $"{txtApellido.Text.Trim()}, {txtNombre.Text.Trim()}  ·  {(nuevoEstado ? "Activo" : "Inactivo")}"; // actualizo el título con el nuevo estado
                btnDesactivar.Text = nuevoEstado ? "Desactivar" : "Reactivar"; // actualizo el texto del botón según el nuevo estado
                btnGuardar.Enabled = nuevoEstado; // si la persona quedó inactiva, deshabilito el botón Guardar (no se puede editar una persona inactiva)
            }
            catch (Exception ex) { Err(ex); }
        }

        private void LimpiarFormulario() // limpia todos los campos del formulario para dar de alta una nueva persona
        {
            idSeleccionado = -1; // modo alta
            _activoSeleccionado = false; // no hay persona seleccionada, así que no tiene estado activo/inactivo
            txtDni.Clear(); txtNombre.Clear(); txtApellido.Clear();
            txtDireccion.Clear(); txtGeo.Clear();
            cmbProvincia.SelectedIndex = -1;
            cmbLocalidad.DataSource = null; cmbLocalidad.Items.Clear(); cmbLocalidad.Enabled = false;
            cmbTipo.SelectedIndex = -1;
            cmbRed.SelectedIndex = -1; cmbRed.Enabled = false; // cmbRed solo se habilita si se elige "Red social"
            txtValor.Clear();
            lstDom.Items.Clear(); lstCont.Items.Clear();
        }

        private void CargarDomicilios()
        {
            lstDom.Items.Clear();
            if (idSeleccionado == -1) return;

            try
            {
                foreach (DataRow row in clsBaseDatos.ObtenerDomicilios(idSeleccionado).Rows) // el ID de la persona ya lo tengo guardado en idSeleccionado
                {
                    string t = row["Direccion"].ToString();
                    if (!string.IsNullOrEmpty(row["Provincia"].ToString())) t += "  —  " + row["Provincia"]; // si hay provincia, la muestro separada por "—"
                    if (!string.IsNullOrEmpty(row["Localidad"].ToString())) t += ", " + row["Localidad"]; // si hay localidad, la muestro después de la provincia separada por coma
                    lstDom.Items.Add(new DomItem { Id = Convert.ToInt32(row["IdDomicilio"]), T = t });
                }
            }
            catch (Exception ex) { Err(ex); }
        }

        private void btnAgregarDom_Click(object sender, EventArgs e) // agrega un domicilio a la persona seleccionada
        {
            if (idSeleccionado == -1) return; // si no hay persona seleccionada, no hago nada
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { Aviso("Completá la dirección."); return; } // si no hay dirección, no hago nada

            string prov = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : ""; // si no hay provincia seleccionada, guardo cadena vacía
            string loc = (cmbLocalidad.DataSource != null && cmbLocalidad.SelectedIndex >= 0) ? cmbLocalidad.Text : ""; // si no hay localidad seleccionada, guardo cadena vacía

            try
            {
                clsBaseDatos.InsertarDomicilio(idSeleccionado, txtDireccion.Text.Trim(), txtGeo.Text.Trim(), prov, loc);
                txtDireccion.Clear(); txtGeo.Clear();
                cmbProvincia.SelectedIndex = -1;
                cmbLocalidad.DataSource = null; cmbLocalidad.Items.Clear(); cmbLocalidad.Enabled = false;
                CargarDomicilios();
            }
            catch (Exception ex) { Err(ex); }
        }

        private void btnQuitarDom_Click(object sender, EventArgs e) // quita el domicilio seleccionado de la persona seleccionada
        {
            if (lstDom.SelectedItem == null) { Aviso("Seleccioná un domicilio para quitarlo."); return; }
            try { clsBaseDatos.EliminarDomicilio(((DomItem)lstDom.SelectedItem).Id); CargarDomicilios(); } // que el ID del domicilio a eliminar lo tengo guardado en el ListBox gracias a la clase DomItem
            catch (Exception ex) { Err(ex); }
        }

        // abre el campo Geo en Google Maps (acepta URL directa o texto de búsqueda)
        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            string t = txtGeo.Text.Trim();
            if (string.IsNullOrEmpty(t)) { Aviso("Completá el campo Geo."); return; }

            string url = t.StartsWith("http", StringComparison.OrdinalIgnoreCase) // si el texto empieza con "http" lo trato como URL, sino como búsqueda en Google Maps
                ? t : "https://www.google.com/maps?q=" + Uri.EscapeDataString(t); // si el texto empieza con "http" lo trato como URL, sino como búsqueda en Google Maps

            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true }); //process.start con UseShellExecute = true abre el navegador predeterminado con la URL dada
        }

        private void CargarContactos()
        {
            lstCont.Items.Clear(); // limpio la lista de contactos antes de cargar los nuevos
            if (idSeleccionado == -1) return; // si no hay persona seleccionada, no hago nada

            try
            {
                foreach (DataRow row in clsBaseDatos.ObtenerContactos(idSeleccionado).Rows) // el ID de la persona ya lo tengo guardado en idSeleccionado
                    lstCont.Items.Add(new ContItem 
                    { Id = Convert.ToInt32(row["IdContacto"]), T = $"{row["Tipo"]}:  {row["Valor"]}" }); // que el ID del contacto lo tengo guardado en el ListBox gracias a la clase ContItem, y el texto que se muestra es "Tipo: Valor"
            }
            catch (Exception ex) { Err(ex); }
        }

        private void btnAgregarCont_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;
            if (cmbTipo.SelectedIndex < 0) { Aviso("Elegí el tipo."); return; }

            // si eligió "Red social", verifico que haya elegido la red específica
            if (cmbTipo.Text == "Red social" && cmbRed.SelectedIndex < 0) { Aviso("Elegí la red social."); return; }
            if (string.IsNullOrWhiteSpace(txtValor.Text)) { Aviso("Completá el dato."); return; }
            if (txtValor.Text.Trim().Length <= 5) { Aviso("El dato debe tener entre 6 y 10 caracteres."); return; } // MaxLength=10 ya impide pasarse

            // si es teléfono, verifico que sean solo números (por si pegó texto con Ctrl+V, que el KeyPress no filtra)
            if (cmbTipo.Text == "Teléfono")
                foreach (char c in txtValor.Text.Trim())
                    if (!char.IsDigit(c)) { Aviso("El teléfono solo puede contener números."); return; }

            // si es email, verifico un formato básico: algo@algo.algo
            if (cmbTipo.Text == "Email")
            {
                string mail = txtValor.Text.Trim();
                int arroba = mail.IndexOf('@');
                bool formatoOk = arroba > 0                       // tiene @ y algo antes
                    && arroba == mail.LastIndexOf('@')            // un solo @
                    && arroba + 2 < mail.Length                   // hay al menos 2 caracteres después del @
                    && mail.IndexOf('.', arroba + 2) > 0          // con un punto después (no pegado al @)
                    && !mail.EndsWith(".");                       // y no termina en punto
                if (!formatoOk) { Aviso("El email no tiene un formato válido (correo@algo.algo)."); return; }
            }

            // lo que se guarda como tipo es la red específica (ej: "Instagram"), no "Red social"
            string tipo = cmbTipo.Text == "Red social" ? cmbRed.Text : cmbTipo.Text;

            try
            {
                clsBaseDatos.InsertarContacto(idSeleccionado, tipo, txtValor.Text.Trim()); // el ID de la persona ya lo tengo guardado en idSeleccionado
                cmbTipo.SelectedIndex = -1;
                cmbRed.SelectedIndex = -1; cmbRed.Enabled = false;
                txtValor.Clear();
                CargarContactos();
            }
            catch (Exception ex) { Err(ex); }
        }

        private void btnQuitarCont_Click(object sender, EventArgs e)
        {
            if (lstCont.SelectedItem == null) { Aviso("Seleccioná un contacto para quitarlo."); return; }
            try { clsBaseDatos.EliminarContacto(((ContItem)lstCont.SelectedItem).Id); CargarContactos(); } //que el ID del contacto a eliminar lo tengo guardado en el ListBox gracias a la clase ContItem
            catch (Exception ex) { Err(ex); }
        }


        // Con AutoScroll activado, WinForms scrollea solo para "mostrar entero" el control que recibe
        // el foco: al hacer clic en la lista de personas (más alta que el área visible), la pantalla
        // saltaba hacia abajo. Devolver la posición actual anula ese salto automático;
        // el usuario sigue pudiendo scrollear con la rueda o la barra.
        protected override System.Drawing.Point ScrollToControl(Control activeControl) // anula el scroll automático al hacer clic en un control
        {
            return this.AutoScrollPosition; // devuelve la posición actual del scroll, anulando el salto automático
        }

        // ─── Desplegables siempre hacia abajo ───
        // La dirección en la que se abre la lista de un ComboBox la decide Windows solo
        // (si cree que no hay lugar abajo, la abre hacia arriba). Estas funciones de Windows
        // permiten ubicar la ventana de la lista a mano, debajo del combo.

        [StructLayout(LayoutKind.Sequential)] // para poder usar GetWindowRect y MoveWindow, necesito definir la estructura RECT que representa un rectángulo (coordenadas de la esquina superior izquierda y la inferior derecha)
        private struct RECT { public int Left, Top, Right, Bottom; } // estructura que representa un rectángulo (coordenadas de la esquina superior izquierda y la inferior derecha)

        [StructLayout(LayoutKind.Sequential)] // para poder usar GetComboBoxInfo, necesito definir la estructura COMBOBOXINFO que representa la información de un ComboBox (tamaño, rectángulos de los elementos y botones, estados y handles de las ventanas)
        private struct COMBOBOXINFO // estructura que representa la información de un ComboBox (tamaño, rectángulos de los elementos y botones, estados y handles de las ventanas)
        {
            public int cbSize; // tamaño de la estructura (en bytes)
            public RECT rcItem, rcButton; // rectángulos de los elementos y botones del ComboBox
            public int stateButton; // estado del botón del ComboBox (presionado, deshabilitado, etc.)
            public IntPtr hwndCombo, hwndItem, hwndList; // handles de las ventanas del ComboBox (ventana principal, ventana de los elementos y ventana de la lista desplegable)
        }

        [DllImport("user32.dll")] private static extern bool GetComboBoxInfo(IntPtr hwnd, ref COMBOBOXINFO info); // obtiene información de un ComboBox (tamaño, rectángulos de los elementos y botones, estados y handles de las ventanas)
        [DllImport("user32.dll")] private static extern bool GetWindowRect(IntPtr hwnd, out RECT rect); // obtiene el rectángulo de una ventana (coordenadas de la esquina superior izquierda y la inferior derecha)
        [DllImport("user32.dll")] private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int ancho, int alto, bool repintar); // mueve y redimensiona una ventana (coordenadas de la esquina superior izquierda, ancho, alto y si se debe repintar)

        // Conectado al evento DropDown de los combos: mueve la lista debajo del combo.
        // Si la lista es más alta que el lugar libre, la achica a filas enteras (queda con scroll).
        // Solo si ni siquiera entran 3 filas, se deja donde la puso Windows.
        private void ForzarAperturaAbajo(object sender, EventArgs e)
        {
            var cmb = (ComboBox)sender;
            // BeginInvoke: corre justo después de que Windows ya mostró y ubicó la lista
            BeginInvoke(new Action(() =>
            {
                var info = new COMBOBOXINFO(); // estructura que contiene información del ComboBox (tamaño, rectángulos de los elementos y botones, estados y handles de las ventanas)
                info.cbSize = Marshal.SizeOf(info); // tamaño de la estructura COMBOBOXINFO (en bytes)
                if (!GetComboBoxInfo(cmb.Handle, ref info)) return; // si falla, no hago nada (Windows decide dónde ubicar la lista)
                if (!GetWindowRect(info.hwndList, out RECT lista)) return; // si falla, no hago nada (Windows decide dónde ubicar la lista)

                var destino = cmb.PointToScreen(new System.Drawing.Point(0, cmb.Height)); // coordenadas de la esquina inferior izquierda del combo (donde quiero ubicar la lista)
                int alto  = lista.Bottom - lista.Top; // altura actual de la lista (la que Windows decidió)
                int ancho = lista.Right  - lista.Left;
                int lugar = Screen.FromControl(cmb).WorkingArea.Bottom - destino.Y; // espacio libre hasta abajo de la pantalla

                if (lugar < cmb.ItemHeight * 3 + 2) return; // no entran ni 3 filas: que decida Windows

                if (alto > lugar)
                    alto = (lugar - 2) / cmb.ItemHeight * cmb.ItemHeight + 2; // achico a filas enteras

                MoveWindow(info.hwndList, destino.X, destino.Y, ancho, alto, true);
            }));
        }

        private void Aviso(string msg) => MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); // mensaje de aviso al usuario (no es error, solo falta completar un campo o algo así)
        private void Err(Exception ex) => MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // mensaje de error al usuario (algo falló en la BD, etc.)
    }
}
