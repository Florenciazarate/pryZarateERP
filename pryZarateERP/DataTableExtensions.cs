using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace pryZarateERP
{
    public static class DataTableExtensions
    {
        public static DataTable CopyToDataTableOrEmpty(this IEnumerable<DataRow> rows)
        {
            if (rows == null) return new DataTable();
            var list = rows.ToList();
            if (!list.Any()) return new DataTable();
            return list.CopyToDataTable();
        }
    }
}
