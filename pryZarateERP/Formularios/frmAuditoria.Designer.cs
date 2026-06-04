namespace pryZarateERP
{
    partial class frmAuditoria
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
            System.Windows.Forms.DataGridViewCellStyle hAlt = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle hHead = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle hCell = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlFiltros = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuarioFiltro = new System.Windows.Forms.Label();
            this.cmbUsuarioFiltro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.cmbExitosoFiltro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnFiltrar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.pnlGrilla = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvAuditoria = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlFiltros.SuspendLayout();
            this.pnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.SuspendLayout();
            //
            // pnlFiltros (arriba, fijo)
            //
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlFiltros.Controls.Add(this.lblTitulo);
            this.pnlFiltros.Controls.Add(this.lblUsuarioFiltro);
            this.pnlFiltros.Controls.Add(this.cmbUsuarioFiltro);
            this.pnlFiltros.Controls.Add(this.lblResultado);
            this.pnlFiltros.Controls.Add(this.cmbExitosoFiltro);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.pnlFiltros.Size = new System.Drawing.Size(900, 172);
            this.pnlFiltros.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(190, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Auditoría de sesión";
            //
            // lblUsuarioFiltro
            //
            this.lblUsuarioFiltro.AutoSize = true;
            this.lblUsuarioFiltro.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUsuarioFiltro.Location = new System.Drawing.Point(20, 56);
            this.lblUsuarioFiltro.Name = "lblUsuarioFiltro";
            this.lblUsuarioFiltro.Size = new System.Drawing.Size(47, 15);
            this.lblUsuarioFiltro.TabIndex = 1;
            this.lblUsuarioFiltro.Text = "Usuario";
            //
            // cmbUsuarioFiltro  (reemplaza al txtUsuarioFiltro)
            //
            this.cmbUsuarioFiltro.BackColor = System.Drawing.Color.Transparent;
            this.cmbUsuarioFiltro.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbUsuarioFiltro.BorderRadius = 8;
            this.cmbUsuarioFiltro.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.cmbUsuarioFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarioFiltro.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbUsuarioFiltro.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbUsuarioFiltro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbUsuarioFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbUsuarioFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbUsuarioFiltro.ItemHeight = 28;
            this.cmbUsuarioFiltro.Location = new System.Drawing.Point(20, 74);
            this.cmbUsuarioFiltro.Name = "cmbUsuarioFiltro";
            this.cmbUsuarioFiltro.Size = new System.Drawing.Size(200, 34);
            this.cmbUsuarioFiltro.TabIndex = 2;
            //
            // lblResultado
            //
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblResultado.Location = new System.Drawing.Point(240, 56);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(59, 15);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "Resultado";
            //
            // cmbExitosoFiltro
            //
            this.cmbExitosoFiltro.BackColor = System.Drawing.Color.Transparent;
            this.cmbExitosoFiltro.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.cmbExitosoFiltro.BorderRadius = 8;
            this.cmbExitosoFiltro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbExitosoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExitosoFiltro.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbExitosoFiltro.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbExitosoFiltro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.cmbExitosoFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbExitosoFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbExitosoFiltro.ItemHeight = 26;
            this.cmbExitosoFiltro.Items.AddRange(new object[] { "Todos", "Exitoso", "Fallido" });
            this.cmbExitosoFiltro.Location = new System.Drawing.Point(240, 74);
            this.cmbExitosoFiltro.Name = "cmbExitosoFiltro";
            this.cmbExitosoFiltro.Size = new System.Drawing.Size(180, 34);
            this.cmbExitosoFiltro.TabIndex = 4;
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDesde.Location = new System.Drawing.Point(440, 56);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(40, 15);
            this.lblDesde.TabIndex = 5;
            this.lblDesde.Text = "Desde";
            //
            // dtpDesde
            //
            this.dtpDesde.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.dtpDesde.BorderRadius = 8;
            this.dtpDesde.Checked = false;
            this.dtpDesde.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(440, 74);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(160, 34);
            this.dtpDesde.TabIndex = 6;
            this.dtpDesde.Value = new System.DateTime(2026, 1, 1, 0, 0, 0, 0);
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblHasta.Location = new System.Drawing.Point(620, 56);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(37, 15);
            this.lblHasta.TabIndex = 7;
            this.lblHasta.Text = "Hasta";
            //
            // dtpHasta
            //
            this.dtpHasta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.dtpHasta.BorderRadius = 8;
            this.dtpHasta.Checked = false;
            this.dtpHasta.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(620, 74);
            this.dtpHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(160, 34);
            this.dtpHasta.TabIndex = 8;
            this.dtpHasta.Value = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            //
            // btnFiltrar
            //
            this.btnFiltrar.BorderRadius = 8;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.btnFiltrar.Location = new System.Drawing.Point(20, 122);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(130, 36);
            this.btnFiltrar.TabIndex = 9;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnLimpiar.BorderRadius = 8;
            this.btnLimpiar.BorderThickness = 1;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FillColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnLimpiar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiar.Location = new System.Drawing.Point(158, 122);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 36);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // pnlGrilla (llena el resto)
            //
            this.pnlGrilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlGrilla.Controls.Add(this.dgvAuditoria);
            this.pnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrilla.Location = new System.Drawing.Point(0, 172);
            this.pnlGrilla.Name = "pnlGrilla";
            this.pnlGrilla.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.pnlGrilla.Size = new System.Drawing.Size(900, 548);
            this.pnlGrilla.TabIndex = 1;
            //
            // dgvAuditoria
            //
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToDeleteRows = false;
            this.dgvAuditoria.AllowUserToResizeRows = false;
            hAlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(64)))));
            hAlt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            hAlt.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            hAlt.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAuditoria.AlternatingRowsDefaultCellStyle = hAlt;
            this.dgvAuditoria.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAuditoria.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            hHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            hHead.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            hHead.ForeColor = System.Drawing.Color.White;
            hHead.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            hHead.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAuditoria.ColumnHeadersDefaultCellStyle = hHead;
            this.dgvAuditoria.ColumnHeadersHeight = 36;
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            hCell.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            hCell.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            hCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            hCell.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            hCell.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAuditoria.DefaultCellStyle = hCell;
            this.dgvAuditoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditoria.EnableHeadersVisualStyles = false;
            this.dgvAuditoria.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvAuditoria.Location = new System.Drawing.Point(20, 0);
            this.dgvAuditoria.MultiSelect = false;
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.RowTemplate.Height = 30;
            this.dgvAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditoria.Size = new System.Drawing.Size(860, 528);
            this.dgvAuditoria.TabIndex = 0;
            //
            // frmAuditoria
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(900, 720);
            this.Controls.Add(this.pnlGrilla);
            this.Controls.Add(this.pnlFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAuditoria";
            this.Text = "Auditoría";
            this.Load += new System.EventHandler(this.frmAuditoria_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioFiltro;
        private Guna.UI2.WinForms.Guna2ComboBox cmbUsuarioFiltro;
        private System.Windows.Forms.Label lblResultado;
        private Guna.UI2.WinForms.Guna2ComboBox cmbExitosoFiltro;
        private System.Windows.Forms.Label lblDesde;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHasta;
        private Guna.UI2.WinForms.Guna2Button btnFiltrar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Panel pnlGrilla;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAuditoria;
    }
}
