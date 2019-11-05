using System.Data;
using System.IO;

namespace AdapterPattern
{
    public class DataRenderer
    {
        readonly IDataAdapter dataAdapter;

        public DataRenderer(IDataAdapter dataAdapter)
        {
            this.dataAdapter = dataAdapter;
        }

        void WriteRowSeparator(TextWriter tw, int width)
        {
            for (var i = 0; i < width; i++)
                tw.Write("-");
        }

        public void Render(TextWriter tw)
        {
            var ds = new DataSet();

            dataAdapter.Fill(ds);

            var columnWidth = 15;

            foreach (DataTable dt in ds.Tables)
            {
                var width = dt.Columns.Count * columnWidth
                            + dt.Columns.Count - 1
                            + 85;

                foreach (DataColumn col in dt.Columns)
                    tw.Write(col.ColumnName.PadRight(columnWidth));

                tw.WriteLine();

                WriteRowSeparator(tw, width);

                foreach (DataRow row in dt.Rows)
                {
                    tw.WriteLine();

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        tw.Write(row[i].ToString().PadRight(columnWidth));
                    }
                }
            }
        }
    }
}