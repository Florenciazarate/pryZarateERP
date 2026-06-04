using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Clase que maneja toda la comunicación con la base de datos Access (.accdb).
    // Todos los métodos son estáticos: se llaman directamente sin crear un objeto (ej: clsBaseDatos.ObtenerPersonal()).
    internal class clsBaseDatos
    {
        private static string _connectionString; // cadena de conexión cacheada para no recalcularla cada vez

        // Arma y cachea la cadena de conexión a la base de datos.
        // Prueba dos versiones del driver ACE (12.0 y 16.0) para mayor compatibilidad entre PCs.
        private static string ObtenerConnectionString()
        {
            if (_connectionString != null) return _connectionString; // si ya la tengo cacheada, la devuelvo directo

            string ruta      = Path.Combine(Application.StartupPath, "BaseDatos", "Zarate.accdb");
            string[] providers = { "Microsoft.ACE.OLEDB.12.0", "Microsoft.ACE.OLEDB.16.0" };

            foreach (var prov in providers)
            {
                var cs = $"Provider={prov};Data Source={ruta};Persist Security Info=False;";
                try
                {
                    using (var conn = new OleDbConnection(cs))
                        conn.Open(); // si abre sin excepción, este provider está disponible

                    _connectionString = cs;
                    return _connectionString;
                }
                catch { } // si ese provider no está instalado, pruebo el siguiente
            }
            return null; // ningún provider funcionó (el driver ACE no está instalado)
        }

        // ══════════════════════════════════
        // LOGIN
        // ══════════════════════════════════

        // Valida usuario y contraseña contra la BD.
        // Si son correctos, devuelve true y rellena los parámetros "out" con el nombre y el rol.
        // Si el personal vinculado está inactivo, devuelve false y rellena motivoBloqueo.
        public static bool ValidarUsuario(string usuario, string password,
            out string nombreUsuario, out string rol, out string motivoBloqueo)
        {
            nombreUsuario = null; rol = null; motivoBloqueo = null;

            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();

                    // Une las tablas Usuario, Relacion-Usuario-Perfil, Perfil y Personal
                    // para obtener el nombre, rol y estado del personal vinculado en una sola consulta.
                    // El LEFT JOIN a Personal es opcional: un usuario puede no tener personal vinculado.
                    string sql =
                        "SELECT U.[Nombre], P.[Perfil], Per.[Activo] AS PersonalActivo " +
                        "FROM (([Usuario] U " +
                        "INNER JOIN [Relacion-Usuario-Perfil] R ON U.[ID_Usuario] = R.[ID_Usuario]) " +
                        "INNER JOIN [Perfil] P ON R.[ID_Perfil] = P.[ID_Perfil]) " +
                        "LEFT JOIN [Personal] Per ON U.[IdPersonal] = Per.[IdPersonal] " +
                        "WHERE (U.[Nombre] = ? OR U.[Mail] = ?) AND U.[Contraseña] = ?";

                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", usuario);  // primer ? = nombre de usuario
                        cmd.Parameters.AddWithValue("?", usuario);  // segundo ? = mail (puede loguearse con cualquiera)
                        cmd.Parameters.AddWithValue("?", password);  // tercer ? = contraseña

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read()) return false; // no encontró ningún usuario con esas credenciales

                            // Si hay personal vinculado y está inactivo, bloqueo el acceso
                            var personalActivo = reader["PersonalActivo"];
                            if (personalActivo != null && personalActivo != DBNull.Value &&
                                !Convert.ToBoolean(personalActivo))
                            {
                                motivoBloqueo = "Tu acceso está bloqueado porque el personal vinculado a esta cuenta está inactivo. Contactá al administrador.";
                                return false;
                            }

                            nombreUsuario = reader["Nombre"].ToString();
                            rol           = reader["Perfil"].ToString();
                            return true; // credenciales correctas y sin bloqueo
                        }
                    }
                }
            }
            catch { return false; } // si hay error de conexión, trato como credenciales inválidas
        }

        // ══════════════════════════════════
        // AUDITORIA
        // ══════════════════════════════════

        // Inserta un registro en la tabla AuditoriaSesion con la acción que acaba de ocurrir.
        // Se llama desde cualquier parte de la app para registrar eventos importantes.
        public static void RegistrarAuditoria(string usuario, string modulo, string accion, string detalle, bool exitoso)
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();
                    // Uso Now() de Access para la fecha porque pasar un DateTime como parámetro
                    // a un campo Fecha/Hora de Access genera error de tipo de datos.
                    using (var cmd = new OleDbCommand(
                        "INSERT INTO AuditoriaSesion (FechaHora, Usuario, Exitoso, Detalle, Modulo, Accion) " +
                        "VALUES (Now(), ?, ?, ?, ?, ?)", conn))
                    {
                        cmd.Parameters.AddWithValue("?", usuario ?? "desconocido");
                        cmd.Parameters.AddWithValue("?", exitoso);
                        cmd.Parameters.AddWithValue("?", detalle ?? "");
                        cmd.Parameters.AddWithValue("?", modulo  ?? "");
                        cmd.Parameters.AddWithValue("?", accion  ?? "");
                        cmd.ExecuteNonQuery(); // ejecuto el INSERT
                    }
                }
            }
            catch { } // si falla el registro de auditoría, no interrumpo el flujo de la app
        }

        // Trae todos los registros de la tabla AuditoriaSesion, ordenados del más reciente al más viejo
        public static DataTable ObtenerAuditoria()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter(
                    "SELECT FechaHora, Usuario, Modulo, Accion, " +
                    "IIF(Exitoso, 'Exitoso', 'Fallido') AS Resultado, Detalle " +
                    "FROM AuditoriaSesion ORDER BY FechaHora DESC", conn))
                {
                    da.Fill(tabla); // llena la DataTable con los resultados de la consulta
                }
            }
            catch { }
            return tabla;
        }

        // ══════════════════════════════════
        // PERSONAL
        // ══════════════════════════════════

        // Trae todos los registros de la tabla Personal, ordenados por apellido y nombre
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

        // Inserta una persona nueva en la tabla Personal.
        // Devuelve el ID que le asignó la base de datos (@@IDENTITY = último autonumérico generado).
        public static int InsertarPersonal(string dni, string nombre, string apellido, bool activo)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand(
                    "INSERT INTO Personal (DNI, Nombre, Apellido, Activo) VALUES (?, ?, ?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("?", dni);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.Parameters.AddWithValue("?", apellido);
                    cmd.Parameters.AddWithValue("?", activo);
                    cmd.ExecuteNonQuery();
                }

                // @@IDENTITY devuelve el último valor autonumérico generado en esta conexión
                using (var cmd2 = new OleDbCommand("SELECT @@IDENTITY", conn))
                {
                    return Convert.ToInt32(cmd2.ExecuteScalar());
                }
            }
        }

        // Actualiza los datos de una persona existente en la tabla Personal
        public static void ActualizarPersonal(int idPersonal, string dni, string nombre, string apellido, bool activo)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand(
                    "UPDATE Personal SET DNI=?, Nombre=?, Apellido=?, Activo=? WHERE IdPersonal=?", conn))
                {
                    cmd.Parameters.AddWithValue("?", dni);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.Parameters.AddWithValue("?", apellido);
                    cmd.Parameters.AddWithValue("?", activo);
                    cmd.Parameters.AddWithValue("?", idPersonal); // el WHERE usa el ID para actualizar solo esa fila
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Verifica si ya existe una persona con el DNI dado.
        // excluirId: cuando se edita, se excluye a la propia persona para que no choque con su propio DNI.
        // -1 significa que no excluyo a nadie (modo alta).
        public static bool ExisteDni(string dni, int excluirId = -1)
        {
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                {
                    conn.Open();

                    // Si excluirId es -1, busco cualquier coincidencia.
                    // Si no, excluyo la fila de la persona que estoy editando.
                    string sql = excluirId == -1
                        ? "SELECT COUNT(*) FROM Personal WHERE DNI = ?"
                        : "SELECT COUNT(*) FROM Personal WHERE DNI = ? AND IdPersonal <> ?";

                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", dni);
                        if (excluirId != -1)
                            cmd.Parameters.AddWithValue("?", excluirId);

                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0; // si COUNT > 0, ya existe
                    }
                }
            }
            catch { return false; }
        }

        // ══════════════════════════════════
        // DOMICILIOS
        // ══════════════════════════════════

        // Trae todos los domicilios de una persona
        public static DataTable ObtenerDomicilios(int idPersonal)
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter(
                    "SELECT IdDomicilio, Direccion, Geo, Provincia, Localidad, Latitud, Longitud " +
                    "FROM PersonalDomicilios WHERE IdPersonal=?", conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("?", idPersonal);
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        // Inserta un domicilio nuevo para una persona
        public static void InsertarDomicilio(int idPersonal, string direccion, string geo, string provincia, string localidad)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand(
                    "INSERT INTO PersonalDomicilios (IdPersonal, Direccion, Geo, Provincia, Localidad) " +
                    "VALUES (?, ?, ?, ?, ?)", conn))
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

        // Elimina un domicilio por su ID
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

        // Trae todos los contactos de una persona, ordenados por tipo
        public static DataTable ObtenerContactos(int idPersonal)
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter(
                    "SELECT IdContacto, Tipo, Valor FROM PersonalContactos WHERE IdPersonal=? ORDER BY Tipo", conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("?", idPersonal);
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        // Inserta un contacto nuevo (email, teléfono, red social, etc.) para una persona
        public static void InsertarContacto(int idPersonal, string tipo, string valor)
        {
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand(
                    "INSERT INTO PersonalContactos (IdPersonal, Tipo, Valor) VALUES (?, ?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("?", idPersonal);
                    cmd.Parameters.AddWithValue("?", tipo);
                    cmd.Parameters.AddWithValue("?", valor);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Elimina un contacto por su ID
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

        // Trae todas las provincias disponibles en la BD, ordenadas alfabéticamente
        public static DataTable ObtenerProvincias()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter(
                    "SELECT ID_Provincias, Provincias FROM Provincias ORDER BY Provincias", conn))
                {
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }

        // Trae las localidades de Córdoba (única provincia con datos en la BD)
        public static DataTable ObtenerLocalidadesCordoba()
        {
            var tabla = new DataTable();
            try
            {
                using (var conn = new OleDbConnection(ObtenerConnectionString()))
                using (var da = new OleDbDataAdapter(
                    "SELECT ID_Localidades, LocalidadesCordoba FROM LocalidadesCordoba ORDER BY LocalidadesCordoba", conn))
                {
                    da.Fill(tabla);
                }
            }
            catch { }
            return tabla;
        }
    }
}
