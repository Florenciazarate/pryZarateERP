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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonalizarPerfil));
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
            this.btnVerMapa = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDomicilio = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAgregarDom = new Guna.UI2.WinForms.Guna2Button();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGeo = new System.Windows.Forms.Label();
            this.txtGeo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cmbLocalidad = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cmbProvincia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnEliminarDom = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDomicilios = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlContacto = new Guna.UI2.WinForms.Guna2Panel();
            this.txtValor = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnAgregarCont = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminarCont = new Guna.UI2.WinForms.Guna2Button();
            this.dgvContactos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlGrilla = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvPersonal = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblGrilla = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            this.pnlDomicilio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).BeginInit();
            this.pnlContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.pnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlDatos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
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
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(158, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos personales";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblDni.Location = new System.Drawing.Point(20, 55);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 15);
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtDni.BorderRadius = 6;
            this.txtDni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDni.DefaultText = "";
            this.txtDni.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtDni.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDni.Location = new System.Drawing.Point(90, 48);
            this.txtDni.Name = "txtDni";
            this.txtDni.PlaceholderText = "";
            this.txtDni.SelectedText = "";
            this.txtDni.Size = new System.Drawing.Size(330, 34);
            this.txtDni.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblNombre.Location = new System.Drawing.Point(20, 97);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtNombre.BorderRadius = 6;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtNombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtNombre.Location = new System.Drawing.Point(90, 90);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "";
            this.txtNombre.SelectedText = "";
            this.txtNombre.Size = new System.Drawing.Size(330, 34);
            this.txtNombre.TabIndex = 4;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblApellido.Location = new System.Drawing.Point(20, 139);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtApellido.BorderRadius = 6;
            this.txtApellido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApellido.DefaultText = "";
            this.txtApellido.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtApellido.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtApellido.Location = new System.Drawing.Point(90, 132);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PlaceholderText = "";
            this.txtApellido.SelectedText = "";
            this.txtApellido.Size = new System.Drawing.Size(330, 34);
            this.txtApellido.TabIndex = 6;
            // 
            // chkActivar
            // 
            this.chkActivar.Checked = true;
            this.chkActivar.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.chkActivar.CheckedState.BorderRadius = 0;
            this.chkActivar.CheckedState.BorderThickness = 0;
            this.chkActivar.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.chkActivar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.chkActivar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chkActivar.Location = new System.Drawing.Point(25, 178);
            this.chkActivar.Name = "chkActivar";
            this.chkActivar.Size = new System.Drawing.Size(100, 25);
            this.chkActivar.TabIndex = 7;
            this.chkActivar.Text = "Activar";
            this.chkActivar.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.chkActivar.UncheckedState.BorderRadius = 0;
            this.chkActivar.UncheckedState.BorderThickness = 0;
            this.chkActivar.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 6;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnGuardar.Location = new System.Drawing.Point(20, 220);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 38);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnEliminar.BorderRadius = 6;
            this.btnEliminar.BorderThickness = 2;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FillColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnEliminar.Location = new System.Drawing.Point(157, 220);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 38);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnLimpiar.BorderRadius = 6;
            this.btnLimpiar.BorderThickness = 2;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FillColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnLimpiar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiar.Location = new System.Drawing.Point(295, 220);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(125, 38);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Modificar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnVerMapa
            // 
            this.btnVerMapa.BorderRadius = 6;
            this.btnVerMapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerMapa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnVerMapa.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnVerMapa.ForeColor = System.Drawing.Color.White;
            this.btnVerMapa.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(100)))), ((int)(((byte)(249)))));
            this.btnVerMapa.Location = new System.Drawing.Point(310, 127);
            this.btnVerMapa.Name = "btnVerMapa";
            this.btnVerMapa.Size = new System.Drawing.Size(115, 30);
            this.btnVerMapa.TabIndex = 9;
            this.btnVerMapa.Text = "Ver Ubicacion";
            this.btnVerMapa.Click += new System.EventHandler(this.btnVerMapa_Click);
            // 
            // pnlDomicilio
            // 
            this.pnlDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlDomicilio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlDomicilio.BorderRadius = 12;
            this.pnlDomicilio.BorderThickness = 1;
            this.pnlDomicilio.Controls.Add(this.btnAgregarDom);
            this.pnlDomicilio.Controls.Add(this.lblDomicilio);
            this.pnlDomicilio.Controls.Add(this.lblDireccion);
            this.pnlDomicilio.Controls.Add(this.txtDireccion);
            this.pnlDomicilio.Controls.Add(this.lblGeo);
            this.pnlDomicilio.Controls.Add(this.txtGeo);
            this.pnlDomicilio.Controls.Add(this.lblProvincia);
            this.pnlDomicilio.Controls.Add(this.cmbLocalidad);
            this.pnlDomicilio.Controls.Add(this.lblLocalidad);
            this.pnlDomicilio.Controls.Add(this.cmbProvincia);
            this.pnlDomicilio.Controls.Add(this.btnVerMapa);
            this.pnlDomicilio.Controls.Add(this.btnEliminarDom);
            this.pnlDomicilio.Controls.Add(this.dgvDomicilios);
            this.pnlDomicilio.Location = new System.Drawing.Point(20, 305);
            this.pnlDomicilio.Name = "pnlDomicilio";
            this.pnlDomicilio.Size = new System.Drawing.Size(440, 370);
            this.pnlDomicilio.TabIndex = 1;
            // 
            // btnAgregarDom
            // 
            this.btnAgregarDom.BorderRadius = 6;
            this.btnAgregarDom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnAgregarDom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDom.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDom.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnAgregarDom.Location = new System.Drawing.Point(109, 10);
            this.btnAgregarDom.Name = "btnAgregarDom";
            this.btnAgregarDom.Size = new System.Drawing.Size(32, 25);
            this.btnAgregarDom.TabIndex = 10;
            this.btnAgregarDom.Text = "+";
            this.btnAgregarDom.Click += new System.EventHandler(this.btnAgregarDom_Click);
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblDomicilio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblDomicilio.Location = new System.Drawing.Point(15, 10);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(94, 25);
            this.lblDomicilio.TabIndex = 0;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblDireccion.Location = new System.Drawing.Point(15, 59);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(58, 15);
            this.lblDireccion.TabIndex = 1;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtDireccion.BorderRadius = 6;
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDireccion.DefaultText = "";
            this.txtDireccion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtDireccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDireccion.Location = new System.Drawing.Point(85, 53);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PlaceholderText = "";
            this.txtDireccion.SelectedText = "";
            this.txtDireccion.Size = new System.Drawing.Size(340, 30);
            this.txtDireccion.TabIndex = 2;
            // 
            // lblGeo
            // 
            this.lblGeo.AutoSize = true;
            this.lblGeo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblGeo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblGeo.Location = new System.Drawing.Point(15, 97);
            this.lblGeo.Name = "lblGeo";
            this.lblGeo.Size = new System.Drawing.Size(28, 15);
            this.lblGeo.TabIndex = 3;
            this.lblGeo.Text = "Geo";
            // 
            // txtGeo
            // 
            this.txtGeo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtGeo.BorderRadius = 6;
            this.txtGeo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGeo.DefaultText = "";
            this.txtGeo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtGeo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtGeo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGeo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtGeo.Location = new System.Drawing.Point(85, 91);
            this.txtGeo.Name = "txtGeo";
            this.txtGeo.PlaceholderText = "";
            this.txtGeo.SelectedText = "";
            this.txtGeo.Size = new System.Drawing.Size(340, 30);
            this.txtGeo.TabIndex = 4;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvincia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblProvincia.Location = new System.Drawing.Point(15, 169);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(56, 15);
            this.lblProvincia.TabIndex = 5;
            this.lblProvincia.Text = "Provincia";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.BackColor = System.Drawing.Color.Transparent;
            this.cmbLocalidad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbLocalidad.BorderRadius = 6;
            this.cmbLocalidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbLocalidad.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbLocalidad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbLocalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbLocalidad.ItemHeight = 26;
            this.cmbLocalidad.Location = new System.Drawing.Point(85, 199);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(340, 32);
            this.cmbLocalidad.TabIndex = 6;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblLocalidad.Location = new System.Drawing.Point(15, 205);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(58, 15);
            this.lblLocalidad.TabIndex = 7;
            this.lblLocalidad.Text = "Localidad";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.BackColor = System.Drawing.Color.Transparent;
            this.cmbProvincia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbProvincia.BorderRadius = 6;
            this.cmbProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbProvincia.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbProvincia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbProvincia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProvincia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProvincia.ItemHeight = 26;
            this.cmbProvincia.Items.AddRange(new object[] {
            "Córdoba"});
            this.cmbProvincia.Location = new System.Drawing.Point(85, 164);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(340, 32);
            this.cmbProvincia.TabIndex = 8;
            // 
            // btnEliminarDom
            // 
            this.btnEliminarDom.BorderRadius = 6;
            this.btnEliminarDom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarDom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnEliminarDom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDom.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDom.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnEliminarDom.Location = new System.Drawing.Point(146, 10);
            this.btnEliminarDom.Name = "btnEliminarDom";
            this.btnEliminarDom.Size = new System.Drawing.Size(32, 25);
            this.btnEliminarDom.TabIndex = 11;
            this.btnEliminarDom.Text = "−";
            this.btnEliminarDom.Click += new System.EventHandler(this.btnEliminarDom_Click);
            // 
            // dgvDomicilios
            // 
            this.dgvDomicilios.AllowUserToAddRows = false;
            this.dgvDomicilios.AllowUserToDeleteRows = false;
            this.dgvDomicilios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDomicilios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDomicilios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvDomicilios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDomicilios.ColumnHeadersHeight = 28;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDomicilios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDomicilios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvDomicilios.Location = new System.Drawing.Point(15, 237);
            this.dgvDomicilios.MultiSelect = false;
            this.dgvDomicilios.Name = "dgvDomicilios";
            this.dgvDomicilios.ReadOnly = true;
            this.dgvDomicilios.RowHeadersVisible = false;
            this.dgvDomicilios.RowTemplate.Height = 25;
            this.dgvDomicilios.Size = new System.Drawing.Size(410, 121);
            this.dgvDomicilios.TabIndex = 12;
            this.dgvDomicilios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDomicilios.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDomicilios.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDomicilios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDomicilios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDomicilios.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvDomicilios.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvDomicilios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDomicilios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDomicilios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDomicilios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDomicilios.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDomicilios.ThemeStyle.HeaderStyle.Height = 28;
            this.dgvDomicilios.ThemeStyle.ReadOnly = true;
            this.dgvDomicilios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDomicilios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDomicilios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDomicilios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDomicilios.ThemeStyle.RowsStyle.Height = 25;
            this.dgvDomicilios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDomicilios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlContacto
            // 
            this.pnlContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlContacto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlContacto.BorderRadius = 12;
            this.pnlContacto.BorderThickness = 1;
            this.pnlContacto.Controls.Add(this.txtValor);
            this.pnlContacto.Controls.Add(this.lblContacto);
            this.pnlContacto.Controls.Add(this.lblTipo);
            this.pnlContacto.Controls.Add(this.cmbTipo);
            this.pnlContacto.Controls.Add(this.lblValor);
            this.pnlContacto.Controls.Add(this.btnAgregarCont);
            this.pnlContacto.Controls.Add(this.btnEliminarCont);
            this.pnlContacto.Controls.Add(this.dgvContactos);
            this.pnlContacto.Location = new System.Drawing.Point(20, 685);
            this.pnlContacto.Name = "pnlContacto";
            this.pnlContacto.Size = new System.Drawing.Size(440, 260);
            this.pnlContacto.TabIndex = 2;
            // 
            // txtValor
            // 
            this.txtValor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtValor.BorderRadius = 6;
            this.txtValor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValor.DefaultText = "";
            this.txtValor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtValor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.txtValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtValor.Location = new System.Drawing.Point(270, 49);
            this.txtValor.Name = "txtValor";
            this.txtValor.PlaceholderText = "";
            this.txtValor.SelectedText = "";
            this.txtValor.Size = new System.Drawing.Size(150, 32);
            this.txtValor.TabIndex = 4;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblContacto.Location = new System.Drawing.Point(15, 10);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(90, 25);
            this.lblContacto.TabIndex = 0;
            this.lblContacto.Text = "Contacto";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblTipo.Location = new System.Drawing.Point(15, 55);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 15);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbTipo.BorderRadius = 6;
            this.cmbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbTipo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbTipo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTipo.ItemHeight = 26;
            this.cmbTipo.Location = new System.Drawing.Point(55, 49);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(150, 32);
            this.cmbTipo.TabIndex = 2;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblValor.Location = new System.Drawing.Point(215, 55);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(51, 15);
            this.lblValor.TabIndex = 3;
            this.lblValor.Text = "Nombre";
            // 
            // btnAgregarCont
            // 
            this.btnAgregarCont.BorderRadius = 6;
            this.btnAgregarCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCont.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnAgregarCont.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCont.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCont.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnAgregarCont.Location = new System.Drawing.Point(105, 10);
            this.btnAgregarCont.Name = "btnAgregarCont";
            this.btnAgregarCont.Size = new System.Drawing.Size(32, 25);
            this.btnAgregarCont.TabIndex = 5;
            this.btnAgregarCont.Text = "+";
            this.btnAgregarCont.Click += new System.EventHandler(this.btnAgregarCont_Click);
            // 
            // btnEliminarCont
            // 
            this.btnEliminarCont.BorderRadius = 6;
            this.btnEliminarCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCont.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnEliminarCont.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCont.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCont.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnEliminarCont.Location = new System.Drawing.Point(143, 10);
            this.btnEliminarCont.Name = "btnEliminarCont";
            this.btnEliminarCont.Size = new System.Drawing.Size(32, 25);
            this.btnEliminarCont.TabIndex = 6;
            this.btnEliminarCont.Text = "−";
            this.btnEliminarCont.Click += new System.EventHandler(this.btnEliminarCont_Click);
            // 
            // dgvContactos
            // 
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvContactos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvContactos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvContactos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContactos.ColumnHeadersHeight = 28;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContactos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvContactos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvContactos.Location = new System.Drawing.Point(15, 87);
            this.dgvContactos.MultiSelect = false;
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.RowTemplate.Height = 25;
            this.dgvContactos.Size = new System.Drawing.Size(410, 161);
            this.dgvContactos.TabIndex = 7;
            this.dgvContactos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvContactos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvContactos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvContactos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvContactos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvContactos.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvContactos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvContactos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvContactos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvContactos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContactos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvContactos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContactos.ThemeStyle.HeaderStyle.Height = 28;
            this.dgvContactos.ThemeStyle.ReadOnly = true;
            this.dgvContactos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvContactos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvContactos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContactos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvContactos.ThemeStyle.RowsStyle.Height = 25;
            this.dgvContactos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvContactos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlGrilla
            // 
            this.pnlGrilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlGrilla.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlGrilla.BorderRadius = 12;
            this.pnlGrilla.BorderThickness = 1;
            this.pnlGrilla.Controls.Add(this.dgvPersonal);
            this.pnlGrilla.Controls.Add(this.lblGrilla);
            this.pnlGrilla.Location = new System.Drawing.Point(475, 15);
            this.pnlGrilla.Name = "pnlGrilla";
            this.pnlGrilla.Size = new System.Drawing.Size(400, 930);
            this.pnlGrilla.TabIndex = 3;
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.AllowUserToDeleteRows = false;
            this.dgvPersonal.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvPersonal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPersonal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.dgvPersonal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPersonal.ColumnHeadersHeight = 36;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonal.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPersonal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvPersonal.Location = new System.Drawing.Point(15, 45);
            this.dgvPersonal.MultiSelect = false;
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.ReadOnly = true;
            this.dgvPersonal.RowHeadersVisible = false;
            this.dgvPersonal.RowTemplate.Height = 30;
            this.dgvPersonal.Size = new System.Drawing.Size(370, 870);
            this.dgvPersonal.TabIndex = 0;
            this.dgvPersonal.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPersonal.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPersonal.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPersonal.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPersonal.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPersonal.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvPersonal.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvPersonal.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.dgvPersonal.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPersonal.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPersonal.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPersonal.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPersonal.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvPersonal.ThemeStyle.ReadOnly = true;
            this.dgvPersonal.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvPersonal.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPersonal.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPersonal.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvPersonal.ThemeStyle.RowsStyle.Height = 30;
            this.dgvPersonal.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvPersonal.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonal_CellClick);
            // 
            // lblGrilla
            // 
            this.lblGrilla.AutoSize = true;
            this.lblGrilla.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblGrilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblGrilla.Location = new System.Drawing.Point(15, 12);
            this.lblGrilla.Name = "lblGrilla";
            this.lblGrilla.Size = new System.Drawing.Size(176, 25);
            this.lblGrilla.TabIndex = 1;
            this.lblGrilla.Text = "Listado de Personal";
            // 
            // frmPersonalizarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 960);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(900, 960);
            this.Controls.Add(this.pnlGrilla);
            this.Controls.Add(this.pnlContacto);
            this.Controls.Add(this.pnlDomicilio);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersonalizarPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmPersonalizarPerfil_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlDomicilio.ResumeLayout(false);
            this.pnlDomicilio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).EndInit();
            this.pnlContacto.ResumeLayout(false);
            this.pnlContacto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.pnlGrilla.ResumeLayout(false);
            this.pnlGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
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
        private Guna.UI2.WinForms.Guna2ComboBox cmbLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProvincia;
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
