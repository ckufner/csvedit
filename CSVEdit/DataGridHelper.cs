using System.Collections.Generic;
using System.Data;

namespace CSVEdit
{
    internal class DataGridHelper
    {
        public static DataTable CreateDataTable(List<string[]> content)
        {
            var dataTable = new DataTable();

            if (content.Count > 0)
            {
                var headerRow = content[0];
                content.RemoveAt(0);

                AddHeaderRow(dataTable, headerRow);

                foreach (var row in content)
                {
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        private static void AddHeaderRow(DataTable dataTable, string[] headerRow)
        {
            foreach (var header in headerRow)
            {

                var dataColumn = new DataColumn();
                dataColumn.ColumnName = header;
                dataColumn.DataType = typeof(string);
                dataTable.Columns.Add(dataColumn);
            }
        }

    }
}
