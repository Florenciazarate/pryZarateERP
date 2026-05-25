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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlNav = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTabPersonal = new System.Windows.Forms.Label();
            this.lblTabAuditoria = new System.Windows.Forms.Label();
            this.pnlIndicador = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlIndicador.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 70);
            this.pnlHeader.TabIndex = 0;
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
            // pnlNav
            //
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlNav.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pnlNav.BorderThickness = 0;
            this.pnlNav.Controls.Add(this.pnlIndicador);
            this.pnlNav.Controls.Add(this.lblTabPersonal);
            this.pnlNav.Controls.Add(this.lblTabAuditoria);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 70);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(900, 40);
            this.pnlNav.TabIndex = 1;
            //
            // lblTabPersonal
            //
            this.lblTabPersonal.AutoSize = true;
            this.lblTabPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabPersonal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTabPersonal.ForeColor = System.Drawing.Color.White;
            this.lblTabPersonal.Location = new System.Drawing.Point(30, 10);
            this.lblTabPersonal.Name = "lblTabPersonal";
            this.lblTabPersonal.Size = new System.Drawing.Size(68, 19);
            this.lblTabPersonal.TabIndex = 0;
            this.lblTabPersonal.Text = "Personal";
            this.lblTabPersonal.Click += new System.EventHandler(this.lblTabPersonal_Click);
            //
            // lblTabAuditoria
            //
            this.lblTabAuditoria.AutoSize = true;
            this.lblTabAuditoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabAuditoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTabAuditoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTabAuditoria.Location = new System.Drawing.Point(120, 10);
            this.lblTabAuditoria.Name = "lblTabAuditoria";
            this.lblTabAuditoria.Size = new System.Drawing.Size(73, 19);
            this.lblTabAuditoria.TabIndex = 1;
            this.lblTabAuditoria.Text = "Auditoría";
            this.lblTabAuditoria.Click += new System.EventHandler(this.lblTabAuditoria_Click);
            //
            // pnlIndicador
            //
            this.pnlIndicador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.pnlIndicador.BorderRadius = 2;
            this.pnlIndicador.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.pnlIndicador.Location = new System.Drawing.Point(30, 34);
            this.pnlIndicador.Name = "pnlIndicador";
            this.pnlIndicador.Size = new System.Drawing.Size(68, 3);
            this.pnlIndicador.TabIndex = 2;
            //
            // pnlContenido
            //
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 120);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(900, 780);
            this.pnlContenido.TabIndex = 2;
            this.pnlContenido.AutoScroll = true;
            //
            // frmPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(900, 900);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlIndicador.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private Guna.UI2.WinForms.Guna2Panel pnlNav;
        private System.Windows.Forms.Label lblTabPersonal;
        private System.Windows.Forms.Label lblTabAuditoria;
        private Guna.UI2.WinForms.Guna2Panel pnlIndicador;
        private System.Windows.Forms.Panel pnlContenido;
    }
}
