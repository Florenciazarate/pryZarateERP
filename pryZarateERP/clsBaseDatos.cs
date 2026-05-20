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
            if (_connectionString != null) return _connectionString;

            string ruta = Path.Combine(Application.StartupPath, "BaseDatos", "Zarate.accdb");
            string[] providers = { "Microsoft.ACE.OLEDB.12.0", "Microsoft.ACE.OLEDB.16.0" };

            foreach (var prov in providers)
            {
                var cs = $"Provider={prov};Data Source={ruta};Persist Security Info=False;";
                try
                {
                    using (var conn = new OleDbConnection(cs))
                        conn.Open();
                    _connectionString = cs;
                    return _connectionString;
                }
                catch { }
            }

            throw new Exception("No se pudo conectar. Verificá que tenés instalado Microsoft Access Database Engine.");
        }

        public static bool ValidarUsuario(string mail, string password, out string nombreUsuario, out string rol)
        {
            nombreUsuario = null;
            rol = null;

            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT U.Nombre, U.Apellido, P._Nombre " +
                                 "FROM (Usuario U " +
                                 "INNER JOIN [Relacion-Usuario-Perfil] R ON U.ID_Usuario = R.ID_Usuario) " +
                                 "INNER JOIN Perfil P ON R.ID_Perfil = P.ID_Perfil " +
                                 "WHERE U.Mail = ? AND U.Contraseña = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", mail);
                        cmd.Parameters.AddWithValue("?", password);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreUsuario = reader["Nombre"] + " " + reader["Apellido"];
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
                    var schema = conn.GetSchema("Tables");
                    foreach (DataRow row in schema.Rows)
                    {
                        if (row["TABLE_NAME"].ToString() == "AuditoriaSesion")
                            return;
                    }
                    using (var cmd = new OleDbCommand(
                        "CREATE TABLE AuditoriaSesion (Id AUTOINCREMENT PRIMARY KEY, FechaHora DATETIME, Usuario TEXT(100), Exitoso YESNO)", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        public static void RegistrarAuditoria(string usuario, bool exitoso)
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new OleDbCommand("INSERT INTO AuditoriaSesion (FechaHora, Usuario, Exitoso) VALUES (?, ?, ?)", conn))
                    {
                        cmd.Parameters.AddWithValue("?", DateTime.Now);
                        cmd.Parameters.AddWithValue("?", usuario);
                        cmd.Parameters.AddWithValue("?", exitoso);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
    }
}
