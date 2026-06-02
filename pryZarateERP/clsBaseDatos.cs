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
            return null;
        }

        // ══════════════════════════════════
        // LOGIN
        // ══════════════════════════════════

        public static bool ValidarUsuario(string usuario, string password, string perfil, out string nombreUsuario, out string rol)
        {
            nombreUsuario = null;
            rol = null;

            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT U.[Nombre], U.[Apellido], P.[Perfil] " +
                                 "FROM ([Usuario] U " +
                                 "INNER JOIN [Relacion-Usuario-Perfil] R ON U.[ID_Usuario] = R.[ID_Usuario]) " +
                                 "INNER JOIN [Perfil] P ON R.[ID_Perfil] = P.[ID_Perfil] " +
                                 "WHERE U.[Nombre] = ? AND U.[Contraseña] = ? AND P.[Perfil] = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", usuario);
                        cmd.Parameters.AddWithValue("?", password);
                        cmd.Parameters.AddWithValue("?", perfil);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreUsuario = reader["Nombre"].ToString();
                                rol = reader["Perfil"].ToString();
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch { return false; }
        }

        public static DataTable ObtenerPerfiles()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter("SELECT DISTINCT Perfil FROM Perfil WHERE Perfil IS NOT NULL", conn))
                {
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        // ══════════════════════════════════
        // AUDITORIA
        // ══════════════════════════════════

        public static void RegistrarAuditoria(string usuario, string modulo, string accion, string detalle, bool exitoso)
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new OleDbCommand("INSERT INTO AuditoriaSesion (FechaHora, Usuario, Exitoso, Detalle, Modulo, Accion) VALUES (?, ?, ?, ?, ?, ?)", conn))
                    {
                        cmd.Parameters.AddWithValue("?", DateTime.Now);
                        cmd.Parameters.AddWithValue("?", usuario ?? "desconocido");
                        cmd.Parameters.AddWithValue("?", exitoso);
                        cmd.Parameters.AddWithValue("?", detalle ?? "");
                        cmd.Parameters.AddWithValue("?", modulo ?? "");
                        cmd.Parameters.AddWithValue("?", accion ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        public static DataTable ObtenerAuditoria()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter("SELECT FechaHora, Usuario, Modulo, Accion, Exitoso, Detalle FROM AuditoriaSesion ORDER BY FechaHora DESC", conn))
                {
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        // ══════════════════════════════════
        // PERSONAL
        // ══════════════════════════════════

        public static DataTable ObtenerPersonal()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter(
                    "SELECT IdPersonal, DNI, Apellido, Nombre, Activo FROM Personal ORDER BY Apellido, Nombre", conn))
                {
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        // Insertar y devolver el ID generado
        public static int InsertarPersonal(string dni, string nombre, string apellido, bool activo)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand("INSERT INTO Personal (DNI, Nombre, Apellido, Activo) VALUES (?, ?, ?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("?", dni);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.Parameters.AddWithValue("?", apellido);
                    cmd.Parameters.AddWithValue("?", activo);
                    cmd.ExecuteNonQuery();
                }
                // Obtener el ID que se acaba de generar
                using (var cmd2 = new OleDbCommand("SELECT @@IDENTITY", conn))
                {
                    return Convert.ToInt32(cmd2.ExecuteScalar());
                }
            }
        }

        public static void ActualizarPersonal(int idPersonal, string dni, string nombre, string apellido, bool activo)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand("UPDATE Personal SET DNI=?, Nombre=?, Apellido=?, Activo=? WHERE IdPersonal=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", dni);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.Parameters.AddWithValue("?", apellido);
                    cmd.Parameters.AddWithValue("?", activo);
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarPersonal(int idPersonal)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                // Primero borro sus domicilios y contactos
                using (var cmd = new OleDbCommand("DELETE FROM PersonalDomicilios WHERE IdPersonal=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new OleDbCommand("DELETE FROM PersonalContactos WHERE IdPersonal=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new OleDbCommand("DELETE FROM Personal WHERE IdPersonal=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool ExisteDni(string dni, int excluirId = -1)
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    string sql;
                    OleDbCommand cmd;

                    if (excluirId == -1)
                    {
                        sql = "SELECT COUNT(*) FROM Personal WHERE DNI = ?";
                        cmd = new OleDbCommand(sql, conn);
                        cmd.Parameters.AddWithValue("?", dni);
                    }
                    else
                    {
                        sql = "SELECT COUNT(*) FROM Personal WHERE DNI = ? AND IdPersonal <> ?";
                        cmd = new OleDbCommand(sql, conn);
                        cmd.Parameters.AddWithValue("?", dni);
                        cmd.Parameters.AddWithValue("?", excluirId);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    return count > 0;
                }
            }
            catch { return false; }
        }

        // ══════════════════════════════════
        // DOMICILIOS
        // ══════════════════════════════════

        public static DataTable ObtenerDomicilios(int idPersonal)
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter("SELECT IdDomicilio, Direccion, Geo, Provincia, Localidad FROM PersonalDomicilios WHERE IdPersonal=?", conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("?", idPersonal);
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        public static void InsertarDomicilio(int idPersonal, string direccion, string geo, string provincia, string localidad)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand("INSERT INTO PersonalDomicilios (IdPersonal, Direccion, Geo, Provincia, Localidad) VALUES (?, ?, ?, ?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.Parameters.AddWithValue("?", direccion);
                    cmd.Parameters.AddWithValue("?", geo);
                    cmd.Parameters.AddWithValue("?", provincia);
                    cmd.Parameters.AddWithValue("?", localidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarDomicilio(int idDomicilio)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand("DELETE FROM PersonalDomicilios WHERE IdDomicilio=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", idDomicilio);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ══════════════════════════════════
        // CONTACTOS
        // ══════════════════════════════════

        public static DataTable ObtenerContactos(int idPersonal)
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter("SELECT IdContacto, Tipo, Valor FROM PersonalContactos WHERE IdPersonal=? ORDER BY Tipo", conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("?", idPersonal);
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        public static void InsertarContacto(int idPersonal, string tipo, string valor)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand("INSERT INTO PersonalContactos (IdPersonal, Tipo, Valor) VALUES (?, ?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.Parameters.AddWithValue("?", tipo);
                    cmd.Parameters.AddWithValue("?", valor);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarContacto(int idContacto)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand("DELETE FROM PersonalContactos WHERE IdContacto=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", idContacto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ══════════════════════════════════
        // PROVINCIAS / LOCALIDADES
        // ══════════════════════════════════

        public static DataTable ObtenerProvincias()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter("SELECT ID_Provincias, Provincias FROM Provincias ORDER BY Provincias", conn))
                {
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        public static DataTable ObtenerLocalidadesCordoba()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter("SELECT ID_Localidades, LocalidadesCordoba FROM LocalidadesCordoba ORDER BY LocalidadesCordoba", conn))
                {
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }
    }
}
