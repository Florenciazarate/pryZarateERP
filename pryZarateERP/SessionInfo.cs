namespace pryZarateERP
{
    // Clase estática que guarda los datos del usuario con la sesión abierta.
    // Al ser estática, existe una sola instancia compartida por toda la aplicación.
    public static class SessionInfo
    {
        public static string Usuario { get; set; } // nombre del usuario logueado
        public static string Rol     { get; set; } // rol del usuario (ej: "Administrador", "Recursos Humanos")
    }
}
