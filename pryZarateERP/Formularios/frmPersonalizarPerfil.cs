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
            cmbLocalidad.DataSource = tabla; // las cargo como fuente de datos del combo
            cmbLocalidad.DisplayMember = "Provincias"; // lo que se muestra en el combo
            cmbLocalidad.ValueMember = "ID_Provincias"; // el valor interno de cada item
            cmbLocalidad.SelectedIndex = -1; // que arranque sin nada seleccionado

            // cuando el usuario seleccione o escriba una provincia, intento cargar sus localidades
            cmbLocalidad.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged; // evento para cuando selecciona una provincia del combo
            cmbLocalidad.TextChanged += cmbProvincia_TextChanged; // evento para cuando escribe algo en el combo (si borra el texto, también se limpia el combo de localidades)

            // habilito que el combo sugiera opciones mientras el usuario escribe
            try
            {
                cmbLocalidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // el combo sugiere y completa automáticamente mientras el usuario escribe
                cmbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems; // las sugerencias se basan en los items del combo (las provincias que cargué de la BD)
            }
            catch { } // si el autocompletado no funciona por alguna razón, no hago nada para que el combo siga funcionando aunque sin esa función
        }

        private void CargarTiposContacto()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new object[] // agrego los tipos de contacto posibles al combo, podrían ser más o menos según lo que necesites
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
            CargarLocalidades(cmbLocalidad.Text.Trim());
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(cmbLocalidad.Text.Trim());
        }

        private void CargarLocalidades(string provincia)
        {
            // si no escribió nada, limpio el combo de localidades y salgo
            if (string.IsNullOrEmpty(provincia))
            {
                cmbProvincia.DataSource = null;
                cmbProvincia.Items.Clear();
                return;
            }

            // solo cargo localidades si la provincia contiene "Cord" (acepta Córdoba, Cordoba, etc.)
            if (provincia.IndexOf("Cord", StringComparison.OrdinalIgnoreCase) < 0) // si la provincia no contiene "Cord" (en cualquier combinación de mayúsculas/minúsculas), limpio el combo de localidades y salgo, porque solo tengo localidades de Córdoba cargadas en la BD
            {
                cmbProvincia.DataSource = null; // limpio el combo de localidades porque la provincia seleccionada no es Córdoba, y solo tengo localidades de Córdoba en la BD, así evito mostrar localidades que no corresponden a la provincia seleccionada
                cmbProvincia.Items.Clear(); // limpio los items del combo de localidades para que quede vacío
                return;
            }

            var tabla = clsBaseDatos.ObtenerLocalidadesCordoba(); // traigo las localidades de Córdoba de la BD, porque la provincia seleccionada es Córdoba (o algo que contiene "Cord"), y las voy a mostrar en el combo de localidades

            if (tabla == null || tabla.Rows.Count == 0) // si no hay localidades para mostrar, limpio el combo de localidades y salgo
            {
                cmbProvincia.DataSource = null; // limpio la fuente de datos del combo de localidades para que quede vacío
                cmbProvincia.Items.Clear(); 
                return;
            }

            // cargo las localidades en el combo
            cmbProvincia.DataSource = tabla;
            cmbProvincia.DisplayMember = "LocalidadesCordoba"; // columna que se muestra
            cmbProvincia.ValueMember = "ID_Localidades"; // columna del ID
            cmbProvincia.SelectedIndex = -1;

            // habilito autocompletado en el combo de localidades
            try
            {
                cmbProvincia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProvincia.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch { }
        }

        // ══════════════════════════════════
        // GRILLA PRINCIPAL DE PERSONAL
        // ══════════════════════════════════

        private void CargarGrilla()
        {
            dgvPersonal.DataSource = clsBaseDatos.ObtenerPersonal(); // traigo el listado de personal desde la BD y lo muestro en la grilla

            try
            {
                dgvPersonal.ReadOnly = false; // permito edición para el checkbox de Activo

                if (dgvPersonal.Columns.Contains("Activo")) // si la grilla tiene la columna Activo, verifico que sea un checkbox para permitir marcar/desmarcar directamente desde la grilla, y si no es un checkbox, la reemplazo por una columna de tipo checkbox para que el usuario pueda interactuar con ella correctamente desde la grilla, así hago más fácil y rápido activar o desactivar a una persona desde la lista sin tener que modificar toda la persona, pero si por alguna razón esa columna no es un checkbox (por ejemplo, si viene como string "True"/"False" desde la BD), entonces la reemplazo por una columna de tipo checkbox para que se muestre correctamente en la grilla y el usuario pueda interactuar con ella
                {
                    var col = dgvPersonal.Columns["Activo"]; // tomo la columna Activo para verificar si es del tipo checkbox, porque necesito que sea un checkbox para que el usuario pueda marcar/desmarcar el estado Activo directamente desde la grilla, sin tener que modificar toda la persona, así hago más fácil y rápido activar o desactivar a una persona desde la lista, pero si por alguna razón esa columna no es un checkbox (por ejemplo, si viene como string "True"/"False" desde la BD), entonces la reemplazo por una columna de tipo checkbox para que el usuario pueda interactuar con ella correctamente desde la grilla

                    // si la columna Activo no es un checkbox, la reemplazo por una que sí lo sea
                    if (!(col is DataGridViewCheckBoxColumn))
                    {
                        int idx = col.Index; // guardo la posición original
                        dgvPersonal.Columns.Remove(col); // la saco
                        var chkCol = new DataGridViewCheckBoxColumn // creo una nueva columna de tipo checkbox para el campo Activo, con las mismas propiedades de nombre y data property name para que se vincule correctamente con el campo Activo del origen de datos, y con TrueValue/FalseValue para que se guarde como booleano en la BD
                        {
                            Name = "Activo", // el nombre de la columna debe ser el mismo que el campo en la BD para que se vincule correctamente, y también para que pueda identificarla fácilmente al manejar los eventos de la grilla
                            HeaderText = "Activo",
                            DataPropertyName = "Activo",
                            ReadOnly = false,
                            TrueValue = true,
                            FalseValue = false
                        };
                        dgvPersonal.Columns.Insert(idx, chkCol); // la inserto en la misma posición
                    }

                    // todas las columnas en solo lectura, excepto Activo
                    foreach (DataGridViewColumn c in dgvPersonal.Columns) // recorro todas las columnas de la grilla para configurar cuáles son editables y cuáles no, porque solo quiero que el usuario pueda editar el checkbox de Activo directamente desde la grilla, y para modificar cualquier otro dato de la persona (como DNI, nombre o apellido), que tenga que seleccionar la persona y usar los campos del formulario para modificarla, así evito que se modifiquen datos importantes directamente desde la grilla sin querer, y también guío al usuario a usar el formulario para hacer modificaciones completas de la persona, pero dejo el checkbox de Activo editable directamente desde la grilla para que sea más fácil y rápido activar o desactivar a una persona sin tener que modificar toda la persona
                    { 
                        c.ReadOnly = (c.Name != "Activo"); // si la columna no es Activo, la dejo como solo lectura para que no se pueda editar directamente desde la grilla, y así evito modificaciones accidentales de datos importantes como DNI, nombre o apellido directamente desde la grilla sin querer, y guío al usuario a usar el formulario para hacer modificaciones completas de la persona, pero dejo el checkbox de Activo editable directamente desde la grilla para que sea más fácil y rápido activar o desactivar a una persona sin tener que modificar toda la persona
                    }

                    // conecto los eventos del checkbox para que se guarde al hacer click
                    dgvPersonal.CellContentClick -= dgvPersonal_CellContentClick; // me aseguro de desconectar el evento antes de volver a conectarlo para evitar que se conecte varias veces si se recarga la grilla varias veces, así evito que el mismo evento se ejecute varias veces por cada recarga de la grilla, lo que podría causar problemas como que se guarde varias veces o que se ejecute código duplicado al hacer click en el checkbox, y así me aseguro de que el evento esté conectado solo una vez y funcione correctamente sin importar cuántas veces se recargue la grilla
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
        private void dgvPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e) // este evento se dispara cuando hacen click en el checkbox, pero el valor del checkbox todavía no cambió en la grilla, así que aquí lo confirmo para que se actualice el valor del checkbox antes de que se dispare el evento CellValueChanged donde hago la actualización en la BD, así me aseguro de que el nuevo estado del checkbox se refleje correctamente en la BD cuando el usuario haga click sobre él
        { 
            if (e.RowIndex < 0) return; // si hacen click en el encabezado de la grilla, no hago nada
            if (dgvPersonal.Columns[e.ColumnIndex].Name == "Activo") // solo si hicieron click en la columna del checkbox de Activo, confirmo el cambio para que se actualice el valor del checkbox antes de que se dispare el evento CellValueChanged donde hago la actualización en la BD, así me aseguro de que el nuevo estado del checkbox se refleje correctamente en la BD cuando el usuario haga click sobre él
                dgvPersonal.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // cuando cambia el valor del checkbox, actualizo en la BD
        private void dgvPersonal_CellValueChanged(object sender, DataGridViewCellEventArgs e) // este evento se dispara después de que el valor del checkbox cambió y se confirmó, así que aquí hago la actualización en la BD para guardar el nuevo estado Activo de esa persona
        {
            if (e.RowIndex < 0) return; 
            if (dgvPersonal.Columns[e.ColumnIndex].Name != "Activo") return;

            try
            {
                var row = dgvPersonal.Rows[e.RowIndex]; // tomo la fila que cambió
                int id = Convert.ToInt32(row.Cells["IdPersonal"].Value); // tomo el ID de esa persona para actualizarla en la BD
                string dni = row.Cells["DNI"].Value.ToString(); // tomo el DNI, nombre y apellido de esa fila para actualizar la persona completa en la BD, porque el método de actualización requiere todos esos datos, aunque solo haya cambiado el checkbox de Activo, así me aseguro de no perder los datos que ya tenía esa persona al actualizar solo el estado Activo
                string nombre = row.Cells["Nombre"].Value.ToString();
                string apellido = row.Cells["Apellido"].Value.ToString();

                bool activo = false; // por defecto lo dejo como false, pero si el checkbox está marcado, lo voy a actualizar a true, así me aseguro de guardar el estado correcto aunque haya algún problema al leer el valor del checkbox
                var cell = row.Cells["Activo"].Value;
                if (cell != null && cell != DBNull.Value) // si el valor del checkbox no es nulo, intento convertirlo a booleano para guardar el estado correcto en la BD, así me aseguro de que aunque haya algún problema al leer el valor del checkbox (por ejemplo, si viene como string "True" o "False" en lugar de un booleano), igual se guarde el estado correcto en la BD
                    bool.TryParse(cell.ToString(), out activo); // intento convertir el valor del checkbox a booleano, si no se puede convertir, dejo el estado como false para evitar guardar un valor incorrecto en la BD

                clsBaseDatos.ActualizarPersonal(id, dni, nombre, apellido, activo); //  actualizo la persona en la BD con el nuevo estado Activo, junto con el DNI, nombre y apellido que ya tenía esa persona para asegurarme de no perder esos datos al actualizar solo el estado Activo, aunque en este caso solo cambió el checkbox de Activo, así me aseguro de que se refleje el nuevo estado en la BD correctamente
                CargarGrilla(); // recargo la grilla para mostrar el cambio actualizado, aunque solo cambió el checkbox de Activo, así me aseguro de que se refleje el nuevo estado en la grilla después de actualizarlo en la BD
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el estado Activo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // cuando hacen click en una fila de la grilla, cargo sus datos en los campos del formulario
        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e) // este evento se dispara cuando hacen click en cualquier parte de la fila, no solo en el checkbox, así que cargo los datos para que se puedan modificar o ver los domicilios/contactos de esa persona, y también para que se muestre el estado del checkbox aunque no hagan click directo sobre él
        {
            if (e.RowIndex < 0) return; // si hacen click en el encabezado de la grilla, no hago nada

            DataGridViewRow fila = dgvPersonal.Rows[e.RowIndex]; // tomo la fila que hicieron click
            idSeleccionado = Convert.ToInt32(fila.Cells["IdPersonal"].Value); // guardo el ID de la persona seleccionada para usarlo en otras operaciones como cargar domicilios/contactos, modificar o eliminar

            txtDni.Text = fila.Cells["DNI"].Value.ToString(); // cargo el DNI en el campo de texto correspondiente
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
            chkActivar.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);

            CargarDomicilios(); // cargo los domicilios de esa persona
            CargarContactos(); // cargo los contactos de esa persona
        }

        // ══════════════════════════════════
        // DOMICILIOS
        // ══════════════════════════════════

        private void CargarDomicilios() // cargo los domicilios de la persona seleccionada en la grilla, y los muestro en la grilla de domicilios, si no hay persona seleccionada, limpio la grilla de domicilios para que quede vacía y el usuario sepa que no hay domicilios cargados hasta que seleccione una persona de la lista
        {
            if (idSeleccionado == -1) // si no hay persona seleccionada, limpio la grilla
            {
                dgvDomicilios.DataSource = null; // limpio la grilla de domicilios porque no hay persona seleccionada, así evito mostrar domicilios que no corresponden a ninguna persona, y dejo la grilla vacía para que el usuario sepa que no hay domicilios cargados hasta que seleccione una persona de la lista, y así también evito posibles confusiones o errores al mostrar domicilios que no corresponden a la persona seleccionada
                return;
            }

            dgvDomicilios.DataSource = clsBaseDatos.ObtenerDomicilios(idSeleccionado); // traigo los domicilios de la persona seleccionada y los muestro en la grilla
        }

        private void btnAgregarDom_Click(object sender, EventArgs e) // agrego un nuevo domicilio para la persona seleccionada, con los datos de dirección, geolocalización, provincia y localidad que el usuario completó en los campos correspondientes del formulario
        {
            // valido que haya una persona seleccionada y que la dirección no esté vacía
            if (idSeleccionado == -1 || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Guarda la persona primero y completa la direccion.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // tomo provincia y localidad del combo, si hay algo seleccionado
            string provincia = cmbLocalidad.SelectedIndex >= 0 ? cmbLocalidad.Text : ""; // si no hay nada seleccionado, dejo vacío para que se guarde como NULL en la BD
            string localidad = (cmbProvincia.DataSource != null && cmbProvincia.SelectedIndex >= 0) // solo tomo la localidad si el combo tiene datos y hay algo seleccionado, sino dejo vacío para que se guarde como NULL en la BD
                                ? cmbProvincia.Text : ""; // si no hay nada seleccionado, dejo vacío para que se guarde como NULL en la BD

            try
            {
                clsBaseDatos.InsertarDomicilio(idSeleccionado, txtDireccion.Text.Trim(), txtGeo.Text.Trim(), provincia, localidad);

                // limpio los campos después de agregar
                txtDireccion.Text = "";
                txtGeo.Text = "";
                cmbLocalidad.SelectedIndex = -1;
                cmbProvincia.DataSource = null;

                CargarDomicilios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerMapa_Click(object sender, EventArgs e) // abro la dirección en Google Maps, usando el campo de texto de geolocalización
        {
            string texto = txtGeo.Text.Trim(); // tomo el texto del campo de geolocalización
            if (string.IsNullOrEmpty(texto)) return; // si el campo está vacío, no hago nada

            // si ya es una URL la abro directo, si no armo una búsqueda en Google Maps
            string url = texto.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                ? texto // si el texto ya es una URL, la uso tal cual
                : "https://www.google.com/maps?q=" + Uri.EscapeDataString(texto); // si no es una URL, armo una búsqueda en Google Maps con el texto

            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true }); // abro la URL en el navegador predeterminado del sistema
        }

        private void btnEliminarDom_Click(object sender, EventArgs e)
        {
            if (dgvDomicilios.CurrentRow == null) return; // si no hay fila seleccionada, no hago nada

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
        }

        private void btnAgregarCont_Click(object sender, EventArgs e)
        {
            // valido que haya persona seleccionada, tipo elegido y valor completado
            if (idSeleccionado == -1 || cmbTipo.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Guarda la persona primero, selecciona un tipo y completa el valor.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // si no se cumple alguna de esas condiciones, no hago nada y muestro un mensaje para que el usuario sepa qué falta completar
            }

            try
            {
                clsBaseDatos.InsertarContacto(idSeleccionado, cmbTipo.Text, txtValor.Text.Trim()); // inserto el nuevo contacto en la BD

                cmbTipo.SelectedIndex = -1;
                txtValor.Text = "";

                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCont_Click(object sender, EventArgs e) // elimino el contacto seleccionado en la grilla de contactos
        {
            if (dgvContactos.CurrentRow == null) return; // si no hay fila seleccionada, no hago nada

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

            try // intento actualizar la persona con los datos del formulario
            {
                clsBaseDatos.ActualizarPersonal(idSeleccionado, txtDni.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), chkActivar.Checked); // actualizo en la BD
                CargarGrilla(); // recargo la grilla para mostrar los cambios
                MessageBox.Show("Persona modificada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) // si hay error, muestro un mensaje con el detalle para que el usuario sepa qué pasó
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;

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
            cmbLocalidad.SelectedIndex = -1;
            cmbProvincia.DataSource = null;
            cmbProvincia.Items.Clear();
            cmbTipo.SelectedIndex = -1;
            txtValor.Text = "";
            dgvDomicilios.DataSource = null;
            dgvContactos.DataSource = null;
            dgvPersonal.ClearSelection();
        }
    }
}
