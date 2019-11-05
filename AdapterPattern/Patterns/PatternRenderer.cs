using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace AdapterPattern.Patterns
{
    public class PatternRenderer
    {
        readonly IDataPatternRendererAdapter dataPatternRendererAdapter;

        public PatternRenderer(IDataPatternRendererAdapter dataPatternRendererAdapter)
        {
            this.dataPatternRendererAdapter = dataPatternRendererAdapter;
        }

        public PatternRenderer(): this(new DataPatternRendererAdapter())
        {
        }

        // suppose we want some client code to receive our patterns rendered in the same way
        // done by DataRenderer, however it uses this method and we have no control over it
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            // we make it depend on an IDataPatternRendererAdapter which in turn
            // has an IDataAdapter so that we can utilise DataRenderer
            return dataPatternRendererAdapter.ListPatterns(patterns);
        }
    }

    public interface IDataPatternRendererAdapter
    {
        string ListPatterns(IEnumerable<Pattern> patterns);
    }

    public class DataPatternRendererAdapter : IDataPatternRendererAdapter
    {
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            var adapter = new PatternDataAdapter(patterns);
            var renderer = new DataRenderer(adapter);

            var writer = new StringWriter();

            renderer.Render(writer);

            return writer.ToString();
        }
    }

    public class PatternDataAdapter: IDataAdapter
    {
        readonly IEnumerable<Pattern> patterns;

        public PatternDataAdapter(IEnumerable<Pattern> patterns)
        {
            this.patterns = patterns;
        }

        public int Fill(DataSet dataSet)
        {
            var count = 0;

            var dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");

            foreach (var pattern in patterns)
            {
                var row = dt.NewRow();

                row[0] = pattern.Id;
                row[1] = pattern.Name;
                row[2] = pattern.Description;

                dt.Rows.Add(row);

                count++;
            }

            dataSet.Tables.Add(dt);

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