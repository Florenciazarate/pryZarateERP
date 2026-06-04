namespace pryZarateERP
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCerrarSesion = new Guna.UI2.WinForms.Guna2Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabInicio = new System.Windows.Forms.TabPage();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblBienvenidaSub = new System.Windows.Forms.Label();
            this.tabPersonal = new System.Windows.Forms.TabPage();
            this.tabAuditoria = new System.Windows.Forms.TabPage();
            this.pnlStatus = new Guna.UI2.WinForms.Guna2Panel();
            this.lblConectado = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabInicio.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.btnCerrarSesion);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnCerrarSesion.BorderRadius = 6;
            this.btnCerrarSesion.BorderThickness = 1;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FillColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCerrarSesion.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCerrarSesion.Location = new System.Drawing.Point(755, 18);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(123, 36);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(26, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(0, 15);
            this.lblSubtitulo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblTitulo.Location = new System.Drawing.Point(24, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 30);
            this.lblTitulo.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInicio);
            this.tabControl.Controls.Add(this.tabPersonal);
            this.tabControl.Controls.Add(this.tabAuditoria);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(120, 36);
            this.tabControl.Location = new System.Drawing.Point(0, 70);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 804);
            this.tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.tabControl.TabButtonSize = new System.Drawing.Size(120, 36);
            this.tabControl.TabIndex = 1;
            this.tabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.tabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabInicio
            // 
            this.tabInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.tabInicio.Controls.Add(this.lblBienvenida);
            this.tabInicio.Controls.Add(this.lblBienvenidaSub);
            this.tabInicio.Location = new System.Drawing.Point(4, 40);
            this.tabInicio.Name = "tabInicio";
            this.tabInicio.Size = new System.Drawing.Size(892, 760);
            this.tabInicio.TabIndex = 2;
            this.tabInicio.Text = "Inicio";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblBienvenida.Location = new System.Drawing.Point(40, 300);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(234, 54);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // lblBienvenidaSub
            // 
            this.lblBienvenidaSub.AutoSize = true;
            this.lblBienvenidaSub.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblBienvenidaSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblBienvenidaSub.Location = new System.Drawing.Point(40, 364);
            this.lblBienvenidaSub.Name = "lblBienvenidaSub";
            this.lblBienvenidaSub.Size = new System.Drawing.Size(47, 28);
            this.lblBienvenidaSub.TabIndex = 1;
            this.lblBienvenidaSub.Text = "Sub";
            // 
            // tabPersonal
            // 
            this.tabPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.tabPersonal.Location = new System.Drawing.Point(4, 40);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Size = new System.Drawing.Size(892, 760);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Personal";
            // 
            // tabAuditoria
            // 
            this.tabAuditoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.tabAuditoria.Location = new System.Drawing.Point(4, 40);
            this.tabAuditoria.Name = "tabAuditoria";
            this.tabAuditoria.Size = new System.Drawing.Size(892, 760);
            this.tabAuditoria.TabIndex = 1;
            this.tabAuditoria.Text = "Auditoría";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlStatus.Controls.Add(this.lblConectado);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 874);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(900, 26);
            this.pnlStatus.TabIndex = 2;
            // 
            // lblConectado
            // 
            this.lblConectado.AutoSize = true;
            this.lblConectado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblConectado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(222)))), ((int)(((byte)(128)))));
            this.lblConectado.Location = new System.Drawing.Point(10, 5);
            this.lblConectado.Name = "lblConectado";
            this.lblConectado.Size = new System.Drawing.Size(74, 15);
            this.lblConectado.TabIndex = 0;
            this.lblConectado.Text = "● Conectado";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(900, 900);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabInicio.ResumeLayout(false);
            this.tabInicio.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private Guna.UI2.WinForms.Guna2Button btnCerrarSesion;
        private Guna.UI2.WinForms.Guna2TabControl tabControl;
        private System.Windows.Forms.TabPage tabInicio;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblBienvenidaSub;
        private System.Windows.Forms.TabPage tabPersonal;
        private System.Windows.Forms.TabPage tabAuditoria;
        private Guna.UI2.WinForms.Guna2Panel pnlStatus;
        private System.Windows.Forms.Label lblConectado;
    }
}
