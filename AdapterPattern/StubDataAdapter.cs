using System;
using System.Data;

namespace AdapterPattern
{
    public class StubDataAdapter: IDataAdapter
    {
        public int Fill(DataSet dataSet)
        {
            var dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");

            var row = dt.NewRow();

            row[0] = 1;
            row[1] = "Hippo";
            row[2] = "Large, mostly herbivorous, semiaquatic mammal and ungulate native to sub-Saharan Africa.";

            dt.Rows.Add(row);

            row = dt.NewRow();

            row[0] = 2;
            row[1] = "Kangaroo";
            row[2] = "Marsupial from the family Macropodidae (macropods, meaning \"large foot\").";

            dt.Rows.Add(row);

            dataSet.Tables.Add(dt);

            dataSet.AcceptChanges();

            return 1;
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