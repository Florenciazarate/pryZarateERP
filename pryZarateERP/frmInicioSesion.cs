using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryZarateERP
{
    public partial class frmInicioSesion : Form
    {

        private readonly clsBaseDatos.BaseDatosAccess _bd = new clsBaseDatos.BaseDatosAccess();
        private string _rutaBaseDatos = @"C:\Users\Alumno\source\repos\pryZarateERP\pryZarateERP\BaseDatos\Zarate.accdb";

        public frmInicioSesion()
        {
            InitializeComponent();
            lblError.Text = string.Empty;
            // wire event in case designer didn't
            btnAceptar.Click += btnAceptar_Click;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mail = txtMail.Text.Trim();
            string password = txtContraseña.Text;

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
            {
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = "Debe completar mail y contraseña.";
                return;
            }
            string error;
            bool connected = _bd.Conectar(_rutaBaseDatos, out error);
            if (!connected)
            {
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = "Error al conectar a la base de datos: " + error;
                return;
            }

            bool ok = ValidarUsuario(mail, password, out error);

            if (ok)
            {
                lblError.ForeColor = Color.LimeGreen;
                lblError.Text = "Ingreso correcto. Bienvenido.";
                this.Hide();
                using (var principal = new frmPrincipal())
                {
                    principal.ShowDialog();
                }
                this.Close();
            }
            else
            {
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = error ?? "Usuario o contraseña incorrectos.";
            }
        }

        private bool ValidarUsuario(string mail, string password, out string error)
        {
            error = null;
            try
            {
                if (!_bd.EstaConectado)
                {
                    error = "No hay conexión a la base de datos.";
                    return false;
                }

                // Comprobar que exista tabla de usuarios
                var tablas = _bd.ObtenerTablas();
                bool tieneUsuarios = tablas.AsEnumerable().Any(r => string.Equals(r.Field<string>("TABLE_NAME"), "Usuarios", StringComparison.OrdinalIgnoreCase));
                if (!tieneUsuarios)
                {
                    error = "No se encontró la tabla 'Usuarios' en la base de datos.";
                    return false;
                }

                var dt = _bd.ObtenerDatosDeTabla("Usuarios");
                if (dt == null || dt.Rows.Count == 0)
                {
                    error = "No hay registros en la tabla 'Usuarios'.";
                    return false;
                }

                // Intentar detectar columnas comunes para mail y contraseña
                var mailCandidates = new[] { "Mail", "Email", "Usuario", "usuario", "mail", "email" };
                var passCandidates = new[] { "Password", "Contraseña", "Contrasena", "Clave", "clave", "password" };

                string mailCol = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).FirstOrDefault(cn => mailCandidates.Contains(cn));
                string passCol = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).FirstOrDefault(cn => passCandidates.Contains(cn));

                if (mailCol == null || passCol == null)
                {
                    error = "No se encontraron las columnas de mail/contraseña en la tabla 'Usuarios'.";
                    return false;
                }

                var match = dt.AsEnumerable().FirstOrDefault(r => string.Equals((r[mailCol] ?? string.Empty).ToString().Trim(), mail, StringComparison.OrdinalIgnoreCase)
                    && string.Equals((r[passCol] ?? string.Empty).ToString(), password));

                return match != null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}

