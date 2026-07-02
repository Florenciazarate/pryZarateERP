using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace pryZarateERP
{
    // Posibles resultados de un intento de login. La capa de datos los devuelve
    // y el formulario decide qué mensaje mostrar para cada caso.
    public enum ResultadoLogin
    {
        Ok,               // credenciales correctas
        Invalido,         // usuario o contraseña incorrectos
        PersonalInactivo  // el empleado vinculado a la cuenta está inactivo
    }

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

            // Ningún provider funcionó: tiro un error claro en vez de devolver null
            // (devolver null haría fallar después con un mensaje confuso).
            throw new Exception(
                "No se encontró el driver de Access (Microsoft ACE OLEDB). " +
                "Instalá 'Microsoft Access Database Engine' para poder usar el sistema.");
        }

        // Devuelve el hash SHA-256 (en hexadecimal) de un texto.
        // Se usa para no guardar las contraseñas en texto plano: en la BD se guarda el hash,
        // y al loguearse se compara el hash de lo que escribió el usuario contra el guardado.
        private static string Hash(string texto)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto ?? ""));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }

        // ══════════════════════════════════
        // LOGIN
        // ══════════════════════════════════

        // Valida usuario y contraseña contra la BD y devuelve el resultado del intento.
        // - Si es Ok, rellena nombreUsuario y rol.
        // - Si no es Ok, rellena "mensaje" con el texto a mostrarle al usuario.
        // El conteo de intentos y el cierre de la app tras 3 fallos lo maneja el formulario de login.
        // Si hay un error de conexión, lanza excepción (la maneja el formulario).
        public static ResultadoLogin ValidarUsuario(string usuario, string password,
            out string nombreUsuario, out string rol, out string mensaje)
        {
            nombreUsuario = null; rol = null; mensaje = null;

            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            {
                conn.Open();

                // Une Usuario → Relacion-Usuario-Perfil → Perfil para obtener el rol, y con LEFT JOIN
                // trae el estado del empleado vinculado (si lo hay). Comparo el hash de la contraseña.
                string sql =
                    "SELECT U.[Nombre], P.[Perfil], Per.[Activo] AS PersonalActivo " +
                    "FROM (([Usuario] U " +
                    "INNER JOIN [Relacion-Usuario-Perfil] R ON U.[ID_Usuario] = R.[ID_Usuario]) " +
                    "INNER JOIN [Perfil] P ON R.[ID_Perfil] = P.[ID_Perfil]) " +
                    "LEFT JOIN [Personal] Per ON U.[IdPersonal] = Per.[IdPersonal] " +
                    "WHERE (U.[Nombre] = ? OR U.[Mail] = ?) AND U.[Contraseña] = ?";

                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", usuario);       // se compara contra Nombre
                    cmd.Parameters.AddWithValue("?", usuario);       // y también contra Mail
                    cmd.Parameters.AddWithValue("?", Hash(password)); // se compara el hash, no el texto plano

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            mensaje = "Usuario o contraseña incorrectos.";
                            return ResultadoLogin.Invalido;
                        }

                        // Credenciales correctas: ¿el empleado vinculado a la cuenta está inactivo?
                        var personalActivo = reader["PersonalActivo"];
                        if (personalActivo != DBNull.Value && !Convert.ToBoolean(personalActivo))
                        {
                            mensaje = "Tu acceso está bloqueado porque el personal vinculado a esta cuenta está inactivo. Contactá al administrador.";
                            return ResultadoLogin.PersonalInactivo;
                        }

                        nombreUsuario = reader["Nombre"].ToString();
                        rol           = reader["Perfil"].ToString();
                        return ResultadoLogin.Ok;
                    }
                }
            }
        }

        // Trae los nombres de los usuarios reales del sistema (para el filtro de la auditoría)
        public static DataTable ObtenerUsuarios()
        {
            var tabla = new DataTable();
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            using (var da = new OleDbDataAdapter("SELECT Nombre FROM Usuario ORDER BY Nombre", conn))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        // ══════════════════════════════════
        // AUDITORIA
        // ══════════════════════════════════

        // Inserta un registro en la tabla AuditoriaSesion con la acción que acaba de ocurrir.
        // Se llama desde cualquier parte de la app para registrar eventos importantes.
        public static void RegistrarAuditoria(string usuario, string modulo, string accion, string detalle, bool exitoso)
        {
            // Esta es la única excepción a "no tragarse errores": si falla el registro de auditoría
            // (algo secundario), no quiero cortar la operación principal que el usuario está haciendo.
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
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            using (var da = new OleDbDataAdapter(
                "SELECT FechaHora, Usuario, Modulo, Accion, " +
                "IIF(Exitoso, 'Exitoso', 'Fallido') AS Resultado, Detalle " +
                "FROM AuditoriaSesion ORDER BY FechaHora DESC", conn))
            {
                da.Fill(tabla); // llena la DataTable con los resultados de la consulta
            }
            return tabla;
        }

        // ══════════════════════════════════
        // PERSONAL
        // ══════════════════════════════════

        // Trae todos los registros de la tabla Personal, ordenados por apellido y nombre
        public static DataTable ObtenerPersonal()
        {
            var tabla = new DataTable();
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            using (var da = new OleDbDataAdapter(
                "SELECT IdPersonal, DNI, Apellido, Nombre, Activo FROM Personal ORDER BY Apellido, Nombre", conn))
            {
                da.Fill(tabla);
            }
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

        // ══════════════════════════════════
        // DOMICILIOS
        // ══════════════════════════════════

        // Trae todos los domicilios de una persona
        public static DataTable ObtenerDomicilios(int idPersonal)
        {
            var tabla = new DataTable();
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            using (var da = new OleDbDataAdapter(
                "SELECT IdDomicilio, Direccion, Geo, Provincia, Localidad " +
                "FROM PersonalDomicilios WHERE IdPersonal=?", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("?", idPersonal);
                da.Fill(tabla);
            }
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
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            using (var da = new OleDbDataAdapter(
                "SELECT IdContacto, Tipo, Valor FROM PersonalContactos WHERE IdPersonal=? ORDER BY Tipo", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("?", idPersonal);
                da.Fill(tabla);
            }
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
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            using (var da = new OleDbDataAdapter(
                "SELECT ID_Provincias, Provincias FROM Provincias ORDER BY Provincias", conn))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        // Trae las localidades de la provincia indicada, ordenadas alfabéticamente
        public static DataTable ObtenerLocalidades(int idProvincia)
        {
            var tabla = new DataTable();
            using (var conn = new OleDbConnection(ObtenerConnectionString()))
            using (var da = new OleDbDataAdapter(
                "SELECT ID_Localidades, Localidad FROM Localidades WHERE ID_Provincias = ? ORDER BY Localidad", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("?", idProvincia);
                da.Fill(tabla);
            }
            return tabla;
        }
    }
}
