namespace pryZarateERP
{
    partial class frmPersonalizarPerfil
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle hdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            // — estilos reutilizables para grillas chicas —
            System.Windows.Forms.DataGridViewCellStyle hdrMini = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellMini = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlDatos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkActivar = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();

            // Domicilio
            this.btnVerMapa = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDomicilio = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGeo = new System.Windows.Forms.Label();
            this.txtGeo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cmbProvincia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cmbLocalidad = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAgregarDom = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminarDom = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDomicilios = new Guna.UI2.WinForms.Guna2DataGridView();

            // Contacto
            this.pnlContacto = new Guna.UI2.WinForms.Guna2Panel();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAgregarCont = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminarCont = new Guna.UI2.WinForms.Guna2Button();
            this.dgvContactos = new Guna.UI2.WinForms.Guna2DataGridView();

            // Grilla principal
            this.pnlGrilla = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGrilla = new System.Windows.Forms.Label();
            this.dgvPersonal = new Guna.UI2.WinForms.Guna2DataGridView();

            this.pnlDatos.SuspendLayout();
            this.pnlDomicilio.SuspendLayout();
            this.pnlContacto.SuspendLayout();
            this.pnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();

            // ══════════════════════════════════
            // Estilos grilla principal
            // ══════════════════════════════════
            hdrStyle.BackColor = System.Drawing.Color.FromArgb(139, 92, 246);
            hdrStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor = System.Drawing.Color.White;
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(139, 92, 246);
            cellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            cellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            altStyle.BackColor = System.Drawing.Color.FromArgb(40, 51, 69);
            altStyle.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);

            // Estilos grillas chicas
            hdrMini.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            hdrMini.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            hdrMini.ForeColor = System.Drawing.Color.White;
            hdrMini.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            cellMini.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cellMini.Font = new System.Drawing.Font("Segoe UI", 8F);
            cellMini.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            cellMini.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85);

            // ══════════════════════════════════
            // pnlDatos — Datos personales + botones
            // ══════════════════════════════════
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDatos.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.pnlDatos.BorderRadius = 12;
            this.pnlDatos.BorderThickness = 1;
            this.pnlDatos.Controls.Add(this.lblTitulo);
            this.pnlDatos.Controls.Add(this.lblDni);
            this.pnlDatos.Controls.Add(this.txtDni);
            this.pnlDatos.Controls.Add(this.lblNombre);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Controls.Add(this.lblApellido);
            this.pnlDatos.Controls.Add(this.txtApellido);
            this.pnlDatos.Controls.Add(this.chkActivar);
            this.pnlDatos.Controls.Add(this.btnGuardar);
            this.pnlDatos.Controls.Add(this.btnEliminar);
            this.pnlDatos.Controls.Add(this.btnLimpiar);
            this.pnlDatos.Location = new System.Drawing.Point(20, 15);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(440, 280);
            this.pnlDatos.TabIndex = 0;
            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Text = "Datos personales";
            // lblDni
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblDni.Location = new System.Drawing.Point(20, 55);
            this.lblDni.Text = "DNI";
            // txtDni
            this.txtDni.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.txtDni.BorderRadius = 6;
            this.txtDni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDni.DefaultText = "";
            this.txtDni.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtDni.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDni.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtDni.Location = new System.Drawing.Point(90, 48);
            this.txtDni.Size = new System.Drawing.Size(330, 34);
            this.txtDni.PlaceholderText = "";
            this.txtDni.SelectedText = "";
            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblNombre.Location = new System.Drawing.Point(20, 97);
            this.lblNombre.Text = "Nombre";
            // txtNombre
            this.txtNombre.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.txtNombre.BorderRadius = 6;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtNombre.Location = new System.Drawing.Point(90, 90);
            this.txtNombre.Size = new System.Drawing.Size(330, 34);
            this.txtNombre.PlaceholderText = "";
            this.txtNombre.SelectedText = "";
            // lblApellido
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblApellido.Location = new System.Drawing.Point(20, 139);
            this.lblApellido.Text = "Apellido";
            // txtApellido
            this.txtApellido.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.txtApellido.BorderRadius = 6;
            this.txtApellido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApellido.DefaultText = "";
            this.txtApellido.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtApellido.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtApellido.Location = new System.Drawing.Point(90, 132);
            this.txtApellido.Size = new System.Drawing.Size(330, 34);
            this.txtApellido.PlaceholderText = "";
            this.txtApellido.SelectedText = "";
            // chkActivar
            this.chkActivar.CheckedState.BorderColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.chkActivar.CheckedState.FillColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.chkActivar.Checked = true;
            this.chkActivar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.chkActivar.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.chkActivar.Location = new System.Drawing.Point(20, 180);
            this.chkActivar.Size = new System.Drawing.Size(100, 25);
            this.chkActivar.Text = "Activar";
            this.chkActivar.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkActivar.UncheckedState.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            // btnGuardar
            this.btnGuardar.BorderRadius = 6;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoverState.FillColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.btnGuardar.Location = new System.Drawing.Point(20, 220);
            this.btnGuardar.Size = new System.Drawing.Size(125, 38);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // btnEliminar
            this.btnEliminar.BorderColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.btnEliminar.BorderRadius = 6;
            this.btnEliminar.BorderThickness = 2;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FillColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.HoverState.FillColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.btnEliminar.Location = new System.Drawing.Point(157, 220);
            this.btnEliminar.Size = new System.Drawing.Size(125, 38);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // btnLimpiar
            this.btnLimpiar.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLimpiar.BorderRadius = 6;
            this.btnLimpiar.BorderThickness = 2;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FillColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnLimpiar.HoverState.FillColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnLimpiar.Location = new System.Drawing.Point(295, 220);
            this.btnLimpiar.Size = new System.Drawing.Size(125, 38);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // ══════════════════════════════════
            // pnlDomicilio
            // ══════════════════════════════════
            this.pnlDomicilio.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlDomicilio.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.pnlDomicilio.BorderRadius = 12;
            this.pnlDomicilio.BorderThickness = 1;
            this.pnlDomicilio.Controls.Add(this.lblDomicilio);
            this.pnlDomicilio.Controls.Add(this.lblDireccion);
            this.pnlDomicilio.Controls.Add(this.txtDireccion);
            this.pnlDomicilio.Controls.Add(this.lblGeo);
            this.pnlDomicilio.Controls.Add(this.txtGeo);
            this.pnlDomicilio.Controls.Add(this.lblProvincia);
            this.pnlDomicilio.Controls.Add(this.cmbProvincia);
            this.pnlDomicilio.Controls.Add(this.lblLocalidad);
            this.pnlDomicilio.Controls.Add(this.cmbLocalidad);
            this.pnlDomicilio.Controls.Add(this.btnVerMapa);
            this.pnlDomicilio.Controls.Add(this.btnAgregarDom);
            this.pnlDomicilio.Controls.Add(this.btnEliminarDom);
            this.pnlDomicilio.Controls.Add(this.dgvDomicilios);
            this.pnlDomicilio.Location = new System.Drawing.Point(20, 305);
            this.pnlDomicilio.Size = new System.Drawing.Size(440, 370);
            this.pnlDomicilio.TabIndex = 1;
            // lblDomicilio
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblDomicilio.ForeColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.lblDomicilio.Location = new System.Drawing.Point(15, 10);
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Text = "Domicilio";
            // lblDireccion
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblDireccion.Location = new System.Drawing.Point(15, 48);
            this.lblDireccion.Text = "Direccion";
            // txtDireccion
            this.txtDireccion.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.txtDireccion.BorderRadius = 6;
            this.txtDireccion.DefaultText = "";
            this.txtDireccion.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtDireccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtDireccion.Location = new System.Drawing.Point(85, 42);
            this.txtDireccion.Size = new System.Drawing.Size(340, 30);
            this.txtDireccion.PlaceholderText = "";
            this.txtDireccion.SelectedText = "";
            // lblGeo
            this.lblGeo.AutoSize = true;
            this.lblGeo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblGeo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblGeo.Location = new System.Drawing.Point(15, 82);
            this.lblGeo.Text = "Geo";
            // txtGeo
            this.txtGeo.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.txtGeo.BorderRadius = 6;
            this.txtGeo.DefaultText = "";
            this.txtGeo.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtGeo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.txtGeo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGeo.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtGeo.Location = new System.Drawing.Point(85, 76);
            this.txtGeo.Size = new System.Drawing.Size(340, 30);
            this.txtGeo.PlaceholderText = "";
            this.txtGeo.SelectedText = "";
            // lblProvincia
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvincia.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblProvincia.Location = new System.Drawing.Point(15, 116);
            this.lblProvincia.Text = "Provincia";
            // cmbProvincia
            this.cmbProvincia.BackColor = System.Drawing.Color.Transparent;
            this.cmbProvincia.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.cmbProvincia.BorderRadius = 6;
            this.cmbProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbProvincia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.cmbProvincia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProvincia.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            this.cmbProvincia.ItemHeight = 26;
            this.cmbProvincia.Location = new System.Drawing.Point(85, 110);
            this.cmbProvincia.Size = new System.Drawing.Size(340, 32);
            // lblLocalidad
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocalidad.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblLocalidad.Location = new System.Drawing.Point(15, 152);
            this.lblLocalidad.Text = "Localidad";
            // cmbLocalidad
            this.cmbLocalidad.BackColor = System.Drawing.Color.Transparent;
            this.cmbLocalidad.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.cmbLocalidad.BorderRadius = 6;
            this.cmbLocalidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbLocalidad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.cmbLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbLocalidad.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            this.cmbLocalidad.ItemHeight = 26;
            this.cmbLocalidad.Location = new System.Drawing.Point(85, 146);
            this.cmbLocalidad.Size = new System.Drawing.Size(340, 32);
            // btnVerMapa
            this.btnVerMapa.BorderRadius = 6;
            this.btnVerMapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerMapa.FillColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnVerMapa.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnVerMapa.ForeColor = System.Drawing.Color.White;
            this.btnVerMapa.HoverState.FillColor = System.Drawing.Color.FromArgb(109, 100, 249);
            this.btnVerMapa.Location = new System.Drawing.Point(310, 76);
            this.btnVerMapa.Size = new System.Drawing.Size(115, 30);
            this.btnVerMapa.Text = "Ver Ubicacion";
            this.btnVerMapa.Click += new System.EventHandler(this.btnVerMapa_Click);
            // btnAgregarDom
            this.btnAgregarDom.BorderRadius = 6;
            this.btnAgregarDom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDom.FillColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.btnAgregarDom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDom.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDom.HoverState.FillColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.btnAgregarDom.Location = new System.Drawing.Point(15, 190);
            this.btnAgregarDom.Size = new System.Drawing.Size(32, 32);
            this.btnAgregarDom.Text = "+";
            this.btnAgregarDom.Click += new System.EventHandler(this.btnAgregarDom_Click);
            // btnEliminarDom
            this.btnEliminarDom.BorderRadius = 6;
            this.btnEliminarDom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarDom.FillColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnEliminarDom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDom.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDom.HoverState.FillColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnEliminarDom.Location = new System.Drawing.Point(55, 190);
            this.btnEliminarDom.Size = new System.Drawing.Size(32, 32);
            this.btnEliminarDom.Text = "−";
            this.btnEliminarDom.Click += new System.EventHandler(this.btnEliminarDom_Click);
            // dgvDomicilios
            this.dgvDomicilios.AllowUserToAddRows = false;
            this.dgvDomicilios.AllowUserToDeleteRows = false;
            this.dgvDomicilios.AllowUserToResizeRows = false;
            this.dgvDomicilios.ColumnHeadersDefaultCellStyle = hdrMini;
            this.dgvDomicilios.ColumnHeadersHeight = 28;
            this.dgvDomicilios.DefaultCellStyle = cellMini;
            this.dgvDomicilios.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvDomicilios.GridColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.dgvDomicilios.Location = new System.Drawing.Point(15, 228);
            this.dgvDomicilios.Size = new System.Drawing.Size(410, 130);
            this.dgvDomicilios.ReadOnly = true;
            this.dgvDomicilios.RowHeadersVisible = false;
            this.dgvDomicilios.RowTemplate.Height = 25;
            this.dgvDomicilios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDomicilios.MultiSelect = false;

            // ══════════════════════════════════
            // pnlContacto
            // ══════════════════════════════════
            this.pnlContacto.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlContacto.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.pnlContacto.BorderRadius = 12;
            this.pnlContacto.BorderThickness = 1;
            this.pnlContacto.Controls.Add(this.lblContacto);
            this.pnlContacto.Controls.Add(this.lblTipo);
            this.pnlContacto.Controls.Add(this.cmbTipo);
            this.pnlContacto.Controls.Add(this.lblValor);
            this.pnlContacto.Controls.Add(this.txtValor);
            this.pnlContacto.Controls.Add(this.btnAgregarCont);
            this.pnlContacto.Controls.Add(this.btnEliminarCont);
            this.pnlContacto.Controls.Add(this.dgvContactos);
            this.pnlContacto.Location = new System.Drawing.Point(20, 685);
            this.pnlContacto.Size = new System.Drawing.Size(440, 260);
            this.pnlContacto.TabIndex = 2;
            // lblContacto
            this.lblContacto.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblContacto.ForeColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.lblContacto.Location = new System.Drawing.Point(15, 10);
            this.lblContacto.AutoSize = true;
            this.lblContacto.Text = "Contacto";
            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblTipo.Location = new System.Drawing.Point(15, 48);
            this.lblTipo.Text = "Tipo";
            // cmbTipo
            this.cmbTipo.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipo.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.cmbTipo.BorderRadius = 6;
            this.cmbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbTipo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            this.cmbTipo.ItemHeight = 26;
            this.cmbTipo.Location = new System.Drawing.Point(55, 42);
            this.cmbTipo.Size = new System.Drawing.Size(150, 32);
            // lblValor
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblValor.Location = new System.Drawing.Point(215, 48);
            this.lblValor.Text = "Valor";
            // txtValor
            this.txtValor.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.txtValor.BorderRadius = 6;
            this.txtValor.DefaultText = "";
            this.txtValor.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtValor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.txtValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtValor.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtValor.Location = new System.Drawing.Point(255, 42);
            this.txtValor.Size = new System.Drawing.Size(170, 30);
            this.txtValor.PlaceholderText = "";
            this.txtValor.SelectedText = "";
            // btnAgregarCont
            this.btnAgregarCont.BorderRadius = 6;
            this.btnAgregarCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCont.FillColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.btnAgregarCont.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCont.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCont.HoverState.FillColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.btnAgregarCont.Location = new System.Drawing.Point(15, 82);
            this.btnAgregarCont.Size = new System.Drawing.Size(32, 32);
            this.btnAgregarCont.Text = "+";
            this.btnAgregarCont.Click += new System.EventHandler(this.btnAgregarCont_Click);
            // btnEliminarCont
            this.btnEliminarCont.BorderRadius = 6;
            this.btnEliminarCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCont.FillColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnEliminarCont.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCont.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCont.HoverState.FillColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnEliminarCont.Location = new System.Drawing.Point(55, 82);
            this.btnEliminarCont.Size = new System.Drawing.Size(32, 32);
            this.btnEliminarCont.Text = "−";
            this.btnEliminarCont.Click += new System.EventHandler(this.btnEliminarCont_Click);
            // dgvContactos
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.AllowUserToResizeRows = false;
            this.dgvContactos.ColumnHeadersDefaultCellStyle = hdrMini;
            this.dgvContactos.ColumnHeadersHeight = 28;
            this.dgvContactos.DefaultCellStyle = cellMini;
            this.dgvContactos.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvContactos.GridColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.dgvContactos.Location = new System.Drawing.Point(15, 120);
            this.dgvContactos.Size = new System.Drawing.Size(410, 128);
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.RowTemplate.Height = 25;
            this.dgvContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContactos.MultiSelect = false;

            // ══════════════════════════════════
            // pnlGrilla — Listado principal
            // ══════════════════════════════════
            this.pnlGrilla.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlGrilla.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.pnlGrilla.BorderRadius = 12;
            this.pnlGrilla.BorderThickness = 1;
            this.pnlGrilla.Controls.Add(this.dgvPersonal);
            this.pnlGrilla.Controls.Add(this.lblGrilla);
            this.pnlGrilla.Location = new System.Drawing.Point(475, 15);
            this.pnlGrilla.Size = new System.Drawing.Size(400, 930);
            this.pnlGrilla.TabIndex = 3;
            // lblGrilla
            this.lblGrilla.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblGrilla.ForeColor = System.Drawing.Color.FromArgb(167, 139, 250);
            this.lblGrilla.Location = new System.Drawing.Point(15, 12);
            this.lblGrilla.AutoSize = true;
            this.lblGrilla.Text = "Listado de Personal";
            // dgvPersonal
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.AllowUserToDeleteRows = false;
            this.dgvPersonal.AllowUserToResizeRows = false;
            this.dgvPersonal.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgvPersonal.ColumnHeadersHeight = 36;
            this.dgvPersonal.DefaultCellStyle = cellStyle;
            this.dgvPersonal.AlternatingRowsDefaultCellStyle = altStyle;
            this.dgvPersonal.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvPersonal.GridColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.dgvPersonal.Location = new System.Drawing.Point(15, 45);
            this.dgvPersonal.Size = new System.Drawing.Size(370, 870);
            this.dgvPersonal.ReadOnly = true;
            this.dgvPersonal.RowHeadersVisible = false;
            this.dgvPersonal.RowTemplate.Height = 30;
            this.dgvPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonal.MultiSelect = false;
            this.dgvPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonal_CellClick);
            this.dgvPersonal.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvPersonal.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.dgvPersonal.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPersonal.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPersonal.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvPersonal.ThemeStyle.ReadOnly = true;
            this.dgvPersonal.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvPersonal.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPersonal.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvPersonal.ThemeStyle.RowsStyle.Height = 30;
            this.dgvPersonal.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85);

            // ══════════════════════════════════
            // frmPersonalizarPerfil
            // ══════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 960);
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(900, 960);
            this.Controls.Add(this.pnlGrilla);
            this.Controls.Add(this.pnlContacto);
            this.Controls.Add(this.pnlDomicilio);
            this.Controls.Add(this.pnlDatos);
            this.Name = "frmPersonalizarPerfil";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmPersonalizarPerfil_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlDomicilio.ResumeLayout(false);
            this.pnlDomicilio.PerformLayout();
            this.pnlContacto.ResumeLayout(false);
            this.pnlContacto.PerformLayout();
            this.pnlGrilla.ResumeLayout(false);
            this.pnlGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);
        }

        // Datos personales
        private Guna.UI2.WinForms.Guna2Panel pnlDatos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDni;
        private Guna.UI2.WinForms.Guna2TextBox txtDni;
        private System.Windows.Forms.Label lblNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private Guna.UI2.WinForms.Guna2TextBox txtApellido;
        private Guna.UI2.WinForms.Guna2CheckBox chkActivar;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;

        // Domicilio
        private Guna.UI2.WinForms.Guna2Panel pnlDomicilio;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblDireccion;
        private Guna.UI2.WinForms.Guna2TextBox txtDireccion;
        private System.Windows.Forms.Label lblGeo;
        private Guna.UI2.WinForms.Guna2TextBox txtGeo;
        private System.Windows.Forms.Label lblProvincia;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblLocalidad;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLocalidad;
        private Guna.UI2.WinForms.Guna2Button btnVerMapa;
        private Guna.UI2.WinForms.Guna2Button btnAgregarDom;
        private Guna.UI2.WinForms.Guna2Button btnEliminarDom;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDomicilios;

        // Contacto
        private Guna.UI2.WinForms.Guna2Panel pnlContacto;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblTipo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipo;
        private System.Windows.Forms.Label lblValor;
        private Guna.UI2.WinForms.Guna2TextBox txtValor;
        private Guna.UI2.WinForms.Guna2Button btnAgregarCont;
        private Guna.UI2.WinForms.Guna2Button btnEliminarCont;
        private Guna.UI2.WinForms.Guna2DataGridView dgvContactos;

        // Grilla principal
        private Guna.UI2.WinForms.Guna2Panel pnlGrilla;
        private System.Windows.Forms.Label lblGrilla;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPersonal;
    }
}
