using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace pryZarateERP
{
    public class AuditEntry
    {
        public DateTime FechaHora { get; set; }
        public string Usuario { get; set; }
        public string Accion { get; set; }
    }

    public static class AuditLogger
    {
        private static readonly string LogFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auditoria.log");
        private static readonly object FileLock = new object();

        public static void Log(string usuario, string accion)
        {
            try
            {
                var line = string.Format("{0}|{1}|{2}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    usuario ?? string.Empty,
                    accion ?? string.Empty);
                lock (FileLock)
                {
                    var dir = Path.GetDirectoryName(LogFile);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    File.AppendAllText(LogFile, line + Environment.NewLine);
                }
            }
            catch
            {
                // Do not throw from logger
            }
        }

        public static List<AuditEntry> ReadAll()
        {
            lock (FileLock)
            {
                var list = new List<AuditEntry>();
                try
                {
                    if (!File.Exists(LogFile)) return list;
                    var lines = File.ReadAllLines(LogFile);
                    foreach (var l in lines)
                    {
                        if (string.IsNullOrWhiteSpace(l)) continue;
                        var parts = l.Split(new[] { '|' }, 3);
                        DateTime dt = DateTime.MinValue;
                        DateTime.TryParse(parts.ElementAtOrDefault(0) ?? string.Empty, out dt);
                        list.Add(new AuditEntry
                        {
                            FechaHora = dt,
                            Usuario = parts.ElementAtOrDefault(1) ?? string.Empty,
                            Accion = parts.ElementAtOrDefault(2) ?? string.Empty
                        });
                    }
                }
                catch
                {
                    // ignore
                }
                return list.OrderByDescending(x => x.FechaHora).ToList();
            }
        }

        public static DataTable ReadAllAsDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("FechaHora", typeof(DateTime));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Accion", typeof(string));

            foreach (var e in ReadAll())
            {
                dt.Rows.Add(e.FechaHora, e.Usuario, e.Accion);
            }
            return dt;
        }
    }
}
