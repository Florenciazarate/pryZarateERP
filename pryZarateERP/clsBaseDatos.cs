using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace pryZarateERP
{
    internal class clsBaseDatos
    {
        private static string _connectionString;

        private static string ObtenerConnectionString()
        {
            if (_connectionString != null) return _connectionString; //Si ya tengo la conexión del accdb guardada, devolvela directamente sin volver a calcularla

            string ruta = Path.Combine(Application.StartupPath, "BaseDatos", "Zarate.accdb");
            string[] providers = { "Microsoft.ACE.OLEDB.12.0", "Microsoft.ACE.OLEDB.16.0" }; //Tengo dos opciones de provider en un array

            foreach (var prov in providers) //recorre una lista elemento por elemento. Para cada elemento de providers, guardalo en prov y ejecutá lo que está adentro
            {
                var cs = $"Provider={prov};Data Source={ruta};Persist Security Info=False;"; //"$"texto con variables dentro
                try
                {   
                    using (var conn = new OleDbConnection(cs)) //usalo y cerralo cuando termines
                        conn.Open();
                    _connectionString = cs;
                    return _connectionString;
                }
                catch { }
            }
            return null;

        }

        public static bool ValidarUsuario(string mail, string password, out string nombreUsuario, out string rol) //out: el metodo devuelve esos valores fuera del bool
        {
            nombreUsuario = null;
            rol = null;

            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString())) //abre la conexion
                {
                    conn.Open();
                    string sql = "SELECT U.Nombre, U.Apellido, P.[_Nombre] " +
                                 "FROM (Usuario U " +
                                 "INNER JOIN [Relacion-Usuario-Perfil] R ON U.ID_Usuario = R.ID_Usuario) " + //unite con la otra tabla donde los IDs coincidan
                                 "INNER JOIN Perfil P ON R.ID_Perfil = P.ID_Perfil " +
                                 "WHERE U.Mail = ? AND U.Contraseña = ?"; //?: son los valores que se van a reemplazar despues con el mail y contraseña
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", mail); // reemplaza ? con mail y ? con contraseña
                        cmd.Parameters.AddWithValue("?", password);
                        using (var reader = cmd.ExecuteReader()) //ejecuta la consulta y devuelve un reader para leer los resultados
                        {
                            if (reader.Read()) //si hay un resultado, lee el nombre y rol del usuario
                            {
                                nombreUsuario = reader["Nombre"].ToString(); 
                                rol = reader["_Nombre"].ToString();
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static void CrearTablaAuditoriaSiNoExiste()
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    var schema = conn.GetSchema("Tables"); //"Pedile a la conexión la lista de todas las tablas que existen en la base"
                    foreach (DataRow row in schema.Rows) //recorre cada fila de esa lista de tablas
                    {
                        if (row["TABLE_NAME"].ToString() == "AuditoriaSesion") //si ya existe la tabla, no hagas nada
                            return;
                    }
                    using (var cmd = new OleDbCommand( //si no existe, creala con esta consulta SQL
                        "CREATE TABLE AuditoriaSesion (Id AUTOINCREMENT PRIMARY KEY, FechaHora DATETIME, Usuario TEXT(100), Exitoso YESNO)", conn)) 
                    {
                        cmd.ExecuteNonQuery(); //ejecuta la consulta sin devolver resultados
                    }
                }
            }
            catch { }
        }

        public static void RegistrarAuditoria(string usuario, bool exitoso) //registra un intento de inicio de sesión en la tabla de auditoría
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString())) //abre la conexión
                {
                    conn.Open(); 
                    using (var cmd = new OleDbCommand("INSERT INTO AuditoriaSesion (FechaHora, Usuario, Exitoso) VALUES (?, ?, ?)", conn)) //prepara la consulta para insertar un nuevo registro con la fecha y hora actual, el usuario y si fue exitoso o no
                    {
                        cmd.Parameters.AddWithValue("?", DateTime.Now); //reemplaza los ? con la fecha y hora actual, el usuario y el resultado del intento de inicio de sesión
                        cmd.Parameters.AddWithValue("?", usuario);
                        cmd.Parameters.AddWithValue("?", exitoso);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        public static DataTable ObtenerAuditoria() //devuelve un DataTable con el historial de intentos de inicio de sesión, ordenados por fecha y hora descendente
        {
            var tabla = new DataTable(); //crea un nuevo DataTable para almacenar los resultados de la consulta
            try //intenta abrir la conexión y ejecutar la consulta para llenar el DataTable con los registros de auditoría
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString())) 
                using (var da = new OleDbDataAdapter("SELECT FechaHora, Usuario, Exitoso FROM AuditoriaSesion ORDER BY FechaHora DESC", conn)) 
                {
                    da.Fill(tabla); //ejecuta la consulta y llena el DataTable con los resultados
                }
            }
            catch { }
            return tabla;
        }
    }
}
