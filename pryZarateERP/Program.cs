using System;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Punto de entrada de la aplicación (lo que se ejecuta primero cuando arranca el .exe)
    internal static class Program
    {
        [STAThread] // necesario para que WinForms funcione en el hilo principal
        static void Main()
        {
            Application.EnableVisualStyles();                       // activa los estilos visuales de Windows
            Application.SetCompatibleTextRenderingDefault(false);   // usa GDI+ para renderizar texto
            Application.Run(new frmInicioSesion());                 // arranca la aplicación mostrando el formulario de login
        }
    }
}
