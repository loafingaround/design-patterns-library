using System;
using System.Data;
using System.IO;
using NUnit.Framework;

namespace AdapterPattern.Adapters
{
    public class CsvDataAdapter: IDataAdapter
    {
        public int Fill(DataSet dataSet)
        {
            var count = 0;

            var table = new DataTable();

            var isFirstRow = true;

            foreach (var line in File.ReadLines(Path.Combine(TestContext.CurrentContext.TestDirectory, "WIKI-AET.csv")))
            {
                var cols = line.Split(',');

                if (isFirstRow)
                {
                    foreach (var col in cols)
                        table.Columns.Add(col);

                    isFirstRow = false;

                    count++;

                    continue;
                }

                var row = table.NewRow();

                for (int i = 0; i < cols.Length; i++)
                    row[i] = cols[i];

                table.Rows.Add(row);

                count++;
            }

            dataSet.Tables.Add(table);

            dataSet.AcceptChanges();

            return count;
        }

        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            throw new NotImplementedException();
        }

        public IDataParameter[] GetFillParameters()
        {
            throw new NotImplementedException();
        }

        public int Update(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        public MissingMappingAction MissingMappingAction { get; set; }
        public MissingSchemaAction MissingSchemaAction { get; set; }
        public ITableMappingCollection TableMappings { get; }
    }
}