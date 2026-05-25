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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlGrilla = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvAuditoria = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblListado = new System.Windows.Forms.Label();
            this.pnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.SuspendLayout();
            //
            // pnlGrilla
            //
            this.pnlGrilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlGrilla.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlGrilla.BorderRadius = 8;
            this.pnlGrilla.BorderThickness = 1;
            this.pnlGrilla.Controls.Add(this.dgvAuditoria);
            this.pnlGrilla.Controls.Add(this.lblListado);
            this.pnlGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrilla.Location = new System.Drawing.Point(24, 24);
            this.pnlGrilla.Name = "pnlGrilla";
            this.pnlGrilla.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGrilla.Size = new System.Drawing.Size(850, 700);
            this.pnlGrilla.TabIndex = 0;
            //
            // lblListado
            //
            this.lblListado.AutoSize = true;
            this.lblListado.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblListado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(139)))), ((int)(((byte)(250)))));
            this.lblListado.Location = new System.Drawing.Point(18, 15);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(200, 25);
            this.lblListado.TabIndex = 0;
            this.lblListado.Text = "Auditoría de Sesión";
            //
            // dgvAuditoria
            //
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToDeleteRows = false;
            this.dgvAuditoria.AllowUserToResizeRows = false;
            //
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            headerStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAuditoria.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvAuditoria.ColumnHeadersHeight = 38;
            //
            cellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            cellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            cellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            cellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditoria.DefaultCellStyle = cellStyle;
            //
            altStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            altStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvAuditoria.AlternatingRowsDefaultCellStyle = altStyle;
            //
            this.dgvAuditoria.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvAuditoria.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuditoria.Location = new System.Drawing.Point(18, 50);
            this.dgvAuditoria.MultiSelect = false;
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.RowTemplate.Height = 32;
            this.dgvAuditoria.Size = new System.Drawing.Size(814, 635);
            this.dgvAuditoria.TabIndex = 1;
            this.dgvAuditoria.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvAuditoria.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.dgvAuditoria.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAuditoria.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAuditoria.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvAuditoria.ThemeStyle.ReadOnly = true;
            this.dgvAuditoria.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvAuditoria.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAuditoria.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvAuditoria.ThemeStyle.RowsStyle.Height = 32;
            this.dgvAuditoria.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvAuditoria.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            //
            // frmAuditoria
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(900, 750);
            this.Controls.Add(this.pnlGrilla);
            this.Name = "frmAuditoria";
            this.Text = "Auditoría";
            this.Load += new System.EventHandler(this.frmAuditoria_Load);
            this.pnlGrilla.ResumeLayout(false);
            this.pnlGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlGrilla;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAuditoria;
        private System.Windows.Forms.Label lblListado;
    }
}
