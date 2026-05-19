using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pryZarateERP.clsBaseDatos;
namespace pryZarateERP
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private readonly BaseDatosAccess _bd = new BaseDatosAccess();
        private string _rutaBaseDatos = @"C:\Users\Alumno\source\repos\pryZarateERP\pryZarateERP\BaseDatos\Zarate.accdb";

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            string error;
            if (!_bd.Conectar(_rutaBaseDatos, out error))
            {
                lblEstado.Text = "Error de conexión: " + error;
                lblEstado.ForeColor = Color.IndianRed;
            }
            else
            {
                lblEstado.Text = "Conectado exitosamente al ERP. Inicie sesión.";
                lblEstado.ForeColor = Color.SteelBlue;
            }
        }
    }
}