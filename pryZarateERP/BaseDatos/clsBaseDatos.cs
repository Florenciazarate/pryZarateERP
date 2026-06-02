using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace pryZarateERP
{
    internal class clsBaseDatos
    {
        private static string _connectionString; // guarda la cadena de conexión para no recalcularla cada vez

        private static string ObtenerConnectionString()
        {
            if (_connectionString != null) return _connectionString; // si ya la tengo guardada, la devuelvo

            // armo la ruta al archivo de la base de datos Access
            string ruta = Path.Combine(Application.StartupPath, "BaseDatos", "Zarate.accdb");
            // proveedores OleDb que puede tener instalado el equipo
            string[] providers = { "Microsoft.ACE.OLEDB.12.0", "Microsoft.ACE.OLEDB.16.0" };

            foreach (var prov in providers) // por cada proveedor disponible
            {
                var cs = $"Provider={prov};Data Source={ruta};Persist Security Info=False;";
                try
                {
                    using (var conn = new OleDbConnection(cs)) // creo una conexión con ese proveedor
                        conn.Open(); // intento abrirla para ver si funciona
                    _connectionString = cs; // si no tiró error, guardo la cadena
                    return _connectionString;
                }
                catch { } // si falla, pruebo con el siguiente proveedor
            }
            return null;
        }

        // ══════════════════════════════════
        // LOGIN
        // ══════════════════════════════════

        public static bool ValidarUsuario(string usuario, string password, string perfil, out string nombreUsuario, out string rol)
        {
            // inicializo las variables de salida en null
            nombreUsuario = null;
            rol = null;

            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    // consulta que une Usuario con Perfil a través de la tabla Relacion-Usuario-Perfil
                    string sql = "SELECT U.[Nombre], U.[Apellido], P.[Perfil] " +
                                 "FROM ([Usuario] U " +
                                 "INNER JOIN [Relacion-Usuario-Perfil] R ON U.[ID_Usuario] = R.[ID_Usuario]) " +
                                 "INNER JOIN [Perfil] P ON R.[ID_Perfil] = P.[ID_Perfil] " +
                                 "WHERE U.[Nombre] = ? AND U.[Contraseña] = ? AND P.[Perfil] = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", usuario); // reemplazo el primer ? por el usuario
                        cmd.Parameters.AddWithValue("?", password); // reemplazo el segundo ? por la contraseña
                        cmd.Parameters.AddWithValue("?", perfil); // reemplazo el tercer ? por el perfil
                        using (var reader = cmd.ExecuteReader()) // ejecuto la consulta y obtengo un lector de resultados
                        {
                            if (reader.Read()) // si hay al menos una fila, el usuario es válido
                            {
                                nombreUsuario = reader["Nombre"].ToString();
                                rol = reader["Perfil"].ToString();
                                return true; // login correcto
                            }
                        }
                    }
                }
                return false; // no encontró coincidencia
            }
            catch { return false; }
        }

        public static DataTable ObtenerPerfiles()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                // traigo los perfiles únicos (sin repetir) que no sean null
                using (var da = new OleDbDataAdapter("SELECT DISTINCT Perfil FROM Perfil WHERE Perfil IS NOT NULL", conn))
                {
                    da.Fill(tabla); // lleno la tabla con los resultados
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
                        cmd.Parameters.AddWithValue("?", DateTime.Now); // fecha y hora actual
                        cmd.Parameters.AddWithValue("?", usuario ?? "desconocido"); // si usuario es null, pongo "desconocido"
                        cmd.Parameters.AddWithValue("?", exitoso);
                        cmd.Parameters.AddWithValue("?", detalle ?? ""); // si detalle es null, pongo vacío
                        cmd.Parameters.AddWithValue("?", modulo ?? "");
                        cmd.Parameters.AddWithValue("?", accion ?? "");
                        cmd.ExecuteNonQuery(); // ejecuto el INSERT
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
                // traigo todos los registros de auditoría ordenados del más reciente al más viejo
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
                using (var cmd2 = new OleDbCommand("SELECT @@IDENTITY", conn)) // @@IDENTITY devuelve el último ID autogenerado
                {
                    return Convert.ToInt32(cmd2.ExecuteScalar()); // lo convierto a int y lo devuelvo
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
                // borro primero los domicilios y contactos asociados para no violar las relaciones
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
                // recién ahora borro el personal
                using (var cmd = new OleDbCommand("DELETE FROM Personal WHERE IdPersonal=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool ExisteDni(string dni, int excluirId = -1) // excluirId = -1 significa que no excluyo ningún registro
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    string sql;

                    if (excluirId == -1) // si no tengo que excluir ningún ID
                        sql = "SELECT COUNT(*) FROM Personal WHERE DNI = ?";
                    else // si tengo que excluir un ID (para no comparar consigo mismo al editar)
                        sql = "SELECT COUNT(*) FROM Personal WHERE DNI = ? AND IdPersonal <> ?";

                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", dni);
                        if (excluirId != -1)
                            cmd.Parameters.AddWithValue("?", excluirId);

                        int count = Convert.ToInt32(cmd.ExecuteScalar()); // obtengo el resultado del COUNT
                        return count > 0; // si count es mayor a 0, el DNI ya existe
                    }
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
                    da.SelectCommand.Parameters.AddWithValue("?", idPersonal); // le paso el ID del personal al parámetro
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
                using (var da = new OleDbDataAdapter("SELECT IdContacto, Tipo, Valor AS Nombre FROM PersonalContactos WHERE IdPersonal=? ORDER BY Tipo", conn))
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
