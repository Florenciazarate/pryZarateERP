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
            this.pnlPersonas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPersonas = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.lstPersonas = new System.Windows.Forms.ListBox();
            this.btnNueva = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lblTitDatos = new System.Windows.Forms.Label();
            this.btnDesactivar = new Guna.UI2.WinForms.Guna2Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.lblSep1 = new System.Windows.Forms.Label();
            this.lblTitUbic = new System.Windows.Forms.Label();
            this.lblProv = new System.Windows.Forms.Label();
            this.cmbProvincia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLoc = new System.Windows.Forms.Label();
            this.cmbLocalidad = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.txtDireccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGeo = new System.Windows.Forms.Label();
            this.txtGeo = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAgregarDom = new Guna.UI2.WinForms.Guna2Button();
            this.btnVerMapa = new Guna.UI2.WinForms.Guna2Button();
            this.lstDom = new System.Windows.Forms.ListBox();
            this.btnQuitarDom = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitRedes = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAgregarCont = new Guna.UI2.WinForms.Guna2Button();
            this.lstCont = new System.Windows.Forms.ListBox();
            this.btnQuitarCont = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPersonas.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPersonas
            // 
            this.pnlPersonas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlPersonas.Controls.Add(this.lblPersonas);
            this.pnlPersonas.Controls.Add(this.txtBuscar);
            this.pnlPersonas.Controls.Add(this.lstPersonas);
            this.pnlPersonas.Controls.Add(this.btnNueva);
            this.pnlPersonas.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPersonas.Location = new System.Drawing.Point(0, 0);
            this.pnlPersonas.Name = "pnlPersonas";
            this.pnlPersonas.Size = new System.Drawing.Size(220, 760);
            this.pnlPersonas.TabIndex = 0;
            // 
            // lblPersonas
            // 
            this.lblPersonas.AutoSize = true;
            this.lblPersonas.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblPersonas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblPersonas.Location = new System.Drawing.Point(16, 16);
            this.lblPersonas.Name = "lblPersonas";
            this.lblPersonas.Size = new System.Drawing.Size(89, 28);
            this.lblPersonas.TabIndex = 0;
            this.lblPersonas.Text = "Personal";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtBuscar.Location = new System.Drawing.Point(16, 58);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtBuscar.PlaceholderText = "Buscar por nombre o DNI...";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(188, 36);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lstPersonas
            // 
            this.lstPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPersonas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lstPersonas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPersonas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstPersonas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lstPersonas.IntegralHeight = false;
            this.lstPersonas.ItemHeight = 17;
            this.lstPersonas.Location = new System.Drawing.Point(16, 104);
            this.lstPersonas.Name = "lstPersonas";
            this.lstPersonas.Size = new System.Drawing.Size(188, 592);
            this.lstPersonas.TabIndex = 1;
            this.lstPersonas.SelectedIndexChanged += new System.EventHandler(this.lstPersonas_SelectedIndexChanged);
            // 
            // btnNueva
            // 
            this.btnNueva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNueva.BorderRadius = 8;
            this.btnNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNueva.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnNueva.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNueva.ForeColor = System.Drawing.Color.White;
            this.btnNueva.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnNueva.Location = new System.Drawing.Point(16, 708);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(188, 36);
            this.btnNueva.TabIndex = 2;
            this.btnNueva.Text = "+  Nueva persona";
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlDetalle.Controls.Add(this.lblTitDatos);
            this.pnlDetalle.Controls.Add(this.btnDesactivar);
            this.pnlDetalle.Controls.Add(this.lblDni);
            this.pnlDetalle.Controls.Add(this.txtDni);
            this.pnlDetalle.Controls.Add(this.lblNombre);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.lblApellido);
            this.pnlDetalle.Controls.Add(this.txtApellido);
            this.pnlDetalle.Controls.Add(this.btnGuardar);
            this.pnlDetalle.Controls.Add(this.lblSep1);
            this.pnlDetalle.Controls.Add(this.lblTitUbic);
            this.pnlDetalle.Controls.Add(this.lblProv);
            this.pnlDetalle.Controls.Add(this.cmbProvincia);
            this.pnlDetalle.Controls.Add(this.lblLoc);
            this.pnlDetalle.Controls.Add(this.cmbLocalidad);
            this.pnlDetalle.Controls.Add(this.lblDir);
            this.pnlDetalle.Controls.Add(this.txtDireccion);
            this.pnlDetalle.Controls.Add(this.lblGeo);
            this.pnlDetalle.Controls.Add(this.txtGeo);
            this.pnlDetalle.Controls.Add(this.btnAgregarDom);
            this.pnlDetalle.Controls.Add(this.btnVerMapa);
            this.pnlDetalle.Controls.Add(this.lstDom);
            this.pnlDetalle.Controls.Add(this.btnQuitarDom);
            this.pnlDetalle.Controls.Add(this.lblTitRedes);
            this.pnlDetalle.Controls.Add(this.lblTipo);
            this.pnlDetalle.Controls.Add(this.cmbTipo);
            this.pnlDetalle.Controls.Add(this.lblValor);
            this.pnlDetalle.Controls.Add(this.txtValor);
            this.pnlDetalle.Controls.Add(this.btnAgregarCont);
            this.pnlDetalle.Controls.Add(this.lstCont);
            this.pnlDetalle.Controls.Add(this.btnQuitarCont);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Location = new System.Drawing.Point(220, 0);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(672, 760);
            this.pnlDetalle.TabIndex = 1;
            // 
            // lblTitDatos
            // 
            this.lblTitDatos.AutoSize = true;
            this.lblTitDatos.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblTitDatos.Location = new System.Drawing.Point(16, 18);
            this.lblTitDatos.Name = "lblTitDatos";
            this.lblTitDatos.Size = new System.Drawing.Size(141, 25);
            this.lblTitDatos.TabIndex = 0;
            this.lblTitDatos.Text = "Nueva persona";
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesactivar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDesactivar.BorderRadius = 8;
            this.btnDesactivar.BorderThickness = 1;
            this.btnDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivar.FillColor = System.Drawing.Color.Transparent;
            this.btnDesactivar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDesactivar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnDesactivar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnDesactivar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDesactivar.Location = new System.Drawing.Point(491, 18);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(165, 34);
            this.btnDesactivar.TabIndex = 7;
            this.btnDesactivar.Text = "Desactivar usuario";
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDni.Location = new System.Drawing.Point(16, 60);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 15);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtDni.BorderRadius = 8;
            this.txtDni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDni.DefaultText = "";
            this.txtDni.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtDni.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDni.Location = new System.Drawing.Point(16, 78);
            this.txtDni.Name = "txtDni";
            this.txtDni.PlaceholderText = "";
            this.txtDni.SelectedText = "";
            this.txtDni.Size = new System.Drawing.Size(150, 36);
            this.txtDni.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNombre.Location = new System.Drawing.Point(182, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtNombre.BorderRadius = 8;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtNombre.Location = new System.Drawing.Point(182, 78);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "";
            this.txtNombre.SelectedText = "";
            this.txtNombre.Size = new System.Drawing.Size(190, 36);
            this.txtNombre.TabIndex = 2;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblApellido.Location = new System.Drawing.Point(388, 60);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 0;
            this.lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtApellido.BorderRadius = 8;
            this.txtApellido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApellido.DefaultText = "";
            this.txtApellido.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtApellido.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtApellido.Location = new System.Drawing.Point(388, 78);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PlaceholderText = "";
            this.txtApellido.SelectedText = "";
            this.txtApellido.Size = new System.Drawing.Size(150, 36);
            this.txtApellido.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnGuardar.Location = new System.Drawing.Point(554, 78);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 36);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblSep1
            // 
            this.lblSep1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSep1.Location = new System.Drawing.Point(16, 132);
            this.lblSep1.Name = "lblSep1";
            this.lblSep1.Size = new System.Drawing.Size(640, 1);
            this.lblSep1.TabIndex = 0;
            // 
            // lblTitUbic
            // 
            this.lblTitUbic.AutoSize = true;
            this.lblTitUbic.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitUbic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblTitUbic.Location = new System.Drawing.Point(16, 146);
            this.lblTitUbic.Name = "lblTitUbic";
            this.lblTitUbic.Size = new System.Drawing.Size(99, 25);
            this.lblTitUbic.TabIndex = 0;
            this.lblTitUbic.Text = "Domicilios";
            // 
            // lblProv
            // 
            this.lblProv.AutoSize = true;
            this.lblProv.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblProv.Location = new System.Drawing.Point(16, 180);
            this.lblProv.Name = "lblProv";
            this.lblProv.Size = new System.Drawing.Size(56, 15);
            this.lblProv.TabIndex = 0;
            this.lblProv.Text = "Provincia";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.BackColor = System.Drawing.Color.Transparent;
            this.cmbProvincia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbProvincia.BorderRadius = 8;
            this.cmbProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbProvincia.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbProvincia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbProvincia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbProvincia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbProvincia.ItemHeight = 30;
            this.cmbProvincia.Location = new System.Drawing.Point(16, 198);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(304, 36);
            this.cmbProvincia.TabIndex = 8;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblLoc.Location = new System.Drawing.Point(16, 242);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(58, 15);
            this.lblLoc.TabIndex = 0;
            this.lblLoc.Text = "Localidad";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.BackColor = System.Drawing.Color.Transparent;
            this.cmbLocalidad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbLocalidad.BorderRadius = 8;
            this.cmbLocalidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbLocalidad.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbLocalidad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbLocalidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbLocalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbLocalidad.ItemHeight = 30;
            this.cmbLocalidad.Location = new System.Drawing.Point(16, 260);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(304, 36);
            this.cmbLocalidad.TabIndex = 9;
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDir.Location = new System.Drawing.Point(16, 304);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(58, 15);
            this.lblDir.TabIndex = 0;
            this.lblDir.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtDireccion.BorderRadius = 8;
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDireccion.DefaultText = "";
            this.txtDireccion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtDireccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDireccion.Location = new System.Drawing.Point(16, 322);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PlaceholderText = "";
            this.txtDireccion.SelectedText = "";
            this.txtDireccion.Size = new System.Drawing.Size(304, 36);
            this.txtDireccion.TabIndex = 10;
            // 
            // lblGeo
            // 
            this.lblGeo.AutoSize = true;
            this.lblGeo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblGeo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblGeo.Location = new System.Drawing.Point(16, 366);
            this.lblGeo.Name = "lblGeo";
            this.lblGeo.Size = new System.Drawing.Size(107, 15);
            this.lblGeo.TabIndex = 0;
            this.lblGeo.Text = "Geo (link o lat, lng)";
            // 
            // txtGeo
            // 
            this.txtGeo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtGeo.BorderRadius = 8;
            this.txtGeo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGeo.DefaultText = "";
            this.txtGeo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtGeo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtGeo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGeo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtGeo.Location = new System.Drawing.Point(16, 384);
            this.txtGeo.Name = "txtGeo";
            this.txtGeo.PlaceholderText = "";
            this.txtGeo.SelectedText = "";
            this.txtGeo.Size = new System.Drawing.Size(304, 36);
            this.txtGeo.TabIndex = 11;
            // 
            // btnAgregarDom
            // 
            this.btnAgregarDom.BorderRadius = 8;
            this.btnAgregarDom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnAgregarDom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDom.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDom.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnAgregarDom.Location = new System.Drawing.Point(16, 432);
            this.btnAgregarDom.Name = "btnAgregarDom";
            this.btnAgregarDom.Size = new System.Drawing.Size(196, 36);
            this.btnAgregarDom.TabIndex = 12;
            this.btnAgregarDom.Text = "Agregar domicilio";
            this.btnAgregarDom.Click += new System.EventHandler(this.btnAgregarDom_Click);
            // 
            // btnVerMapa
            // 
            this.btnVerMapa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnVerMapa.BorderRadius = 8;
            this.btnVerMapa.BorderThickness = 1;
            this.btnVerMapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerMapa.FillColor = System.Drawing.Color.Transparent;
            this.btnVerMapa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVerMapa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnVerMapa.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnVerMapa.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnVerMapa.Location = new System.Drawing.Point(220, 432);
            this.btnVerMapa.Name = "btnVerMapa";
            this.btnVerMapa.Size = new System.Drawing.Size(100, 36);
            this.btnVerMapa.TabIndex = 13;
            this.btnVerMapa.Text = "Ver mapa";
            this.btnVerMapa.Click += new System.EventHandler(this.btnVerMapa_Click);
            // 
            // lstDom
            // 
            this.lstDom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstDom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lstDom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstDom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lstDom.IntegralHeight = false;
            this.lstDom.ItemHeight = 17;
            this.lstDom.Location = new System.Drawing.Point(16, 476);
            this.lstDom.Name = "lstDom";
            this.lstDom.Size = new System.Drawing.Size(304, 216);
            this.lstDom.TabIndex = 14;
            // 
            // btnQuitarDom
            // 
            this.btnQuitarDom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitarDom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnQuitarDom.BorderRadius = 8;
            this.btnQuitarDom.BorderThickness = 1;
            this.btnQuitarDom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarDom.FillColor = System.Drawing.Color.Transparent;
            this.btnQuitarDom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuitarDom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnQuitarDom.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnQuitarDom.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnQuitarDom.Location = new System.Drawing.Point(16, 704);
            this.btnQuitarDom.Name = "btnQuitarDom";
            this.btnQuitarDom.Size = new System.Drawing.Size(304, 36);
            this.btnQuitarDom.TabIndex = 15;
            this.btnQuitarDom.Text = "Quitar domicilio";
            this.btnQuitarDom.Click += new System.EventHandler(this.btnQuitarDom_Click);
            // 
            // lblTitRedes
            // 
            this.lblTitRedes.AutoSize = true;
            this.lblTitRedes.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitRedes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblTitRedes.Location = new System.Drawing.Point(336, 146);
            this.lblTitRedes.Name = "lblTitRedes";
            this.lblTitRedes.Size = new System.Drawing.Size(161, 25);
            this.lblTitRedes.TabIndex = 0;
            this.lblTitRedes.Text = "Redes y contactos";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTipo.Location = new System.Drawing.Point(336, 180);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 15);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbTipo.BorderRadius = 8;
            this.cmbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbTipo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbTipo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbTipo.ItemHeight = 30;
            this.cmbTipo.Location = new System.Drawing.Point(336, 198);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(304, 36);
            this.cmbTipo.TabIndex = 16;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblValor.Location = new System.Drawing.Point(336, 242);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(33, 15);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Dato";
            // 
            // txtValor
            // 
            this.txtValor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtValor.BorderRadius = 8;
            this.txtValor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValor.DefaultText = "";
            this.txtValor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtValor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtValor.Location = new System.Drawing.Point(336, 260);
            this.txtValor.Name = "txtValor";
            this.txtValor.PlaceholderText = "";
            this.txtValor.SelectedText = "";
            this.txtValor.Size = new System.Drawing.Size(304, 36);
            this.txtValor.TabIndex = 17;
            // 
            // btnAgregarCont
            // 
            this.btnAgregarCont.BorderRadius = 8;
            this.btnAgregarCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCont.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnAgregarCont.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCont.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCont.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnAgregarCont.Location = new System.Drawing.Point(336, 322);
            this.btnAgregarCont.Name = "btnAgregarCont";
            this.btnAgregarCont.Size = new System.Drawing.Size(304, 36);
            this.btnAgregarCont.TabIndex = 18;
            this.btnAgregarCont.Text = "Agregar contacto";
            this.btnAgregarCont.Click += new System.EventHandler(this.btnAgregarCont_Click);
            // 
            // lstCont
            // 
            this.lstCont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lstCont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCont.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstCont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lstCont.IntegralHeight = false;
            this.lstCont.ItemHeight = 17;
            this.lstCont.Location = new System.Drawing.Point(336, 384);
            this.lstCont.Name = "lstCont";
            this.lstCont.Size = new System.Drawing.Size(304, 308);
            this.lstCont.TabIndex = 19;
            // 
            // btnQuitarCont
            // 
            this.btnQuitarCont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitarCont.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnQuitarCont.BorderRadius = 8;
            this.btnQuitarCont.BorderThickness = 1;
            this.btnQuitarCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarCont.FillColor = System.Drawing.Color.Transparent;
            this.btnQuitarCont.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuitarCont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnQuitarCont.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnQuitarCont.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnQuitarCont.Location = new System.Drawing.Point(336, 704);
            this.btnQuitarCont.Name = "btnQuitarCont";
            this.btnQuitarCont.Size = new System.Drawing.Size(304, 36);
            this.btnQuitarCont.TabIndex = 20;
            this.btnQuitarCont.Text = "Quitar contacto ";
            this.btnQuitarCont.Click += new System.EventHandler(this.btnQuitarCont_Click);
            // 
            // frmPersonalizarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(892, 760);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlPersonas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPersonalizarPerfil";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmPersonalizarPerfil_Load);
            this.pnlPersonas.ResumeLayout(false);
            this.pnlPersonas.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlPersonas;
        private System.Windows.Forms.Label lblPersonas;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.ListBox lstPersonas;
        private Guna.UI2.WinForms.Guna2Button btnNueva;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label lblTitDatos;
        private Guna.UI2.WinForms.Guna2Button btnDesactivar;
        private System.Windows.Forms.Label lblDni;
        private Guna.UI2.WinForms.Guna2TextBox txtDni;
        private System.Windows.Forms.Label lblNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private Guna.UI2.WinForms.Guna2TextBox txtApellido;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private System.Windows.Forms.Label lblSep1;
        private System.Windows.Forms.Label lblTitUbic;
        private System.Windows.Forms.Label lblProv;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblLoc;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLocalidad;
        private System.Windows.Forms.Label lblDir;
        private Guna.UI2.WinForms.Guna2TextBox txtDireccion;
        private System.Windows.Forms.Label lblGeo;
        private Guna.UI2.WinForms.Guna2TextBox txtGeo;
        private Guna.UI2.WinForms.Guna2Button btnAgregarDom;
        private Guna.UI2.WinForms.Guna2Button btnVerMapa;
        private System.Windows.Forms.ListBox lstDom;
        private Guna.UI2.WinForms.Guna2Button btnQuitarDom;
        private System.Windows.Forms.Label lblTitRedes;
        private System.Windows.Forms.Label lblTipo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipo;
        private System.Windows.Forms.Label lblValor;
        private Guna.UI2.WinForms.Guna2TextBox txtValor;
        private Guna.UI2.WinForms.Guna2Button btnAgregarCont;
        private System.Windows.Forms.ListBox lstCont;
        private Guna.UI2.WinForms.Guna2Button btnQuitarCont;
    }
}
