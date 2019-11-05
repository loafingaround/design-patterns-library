using System;
using System.IO;
using System.Linq;
using AdapterPattern.Adapters;
using NUnit.Framework;

namespace AdapterPattern
{
    public class Tests
    {
        [Test]
        public void StubDataAdapter()
        {
            var renderer = new DataRenderer(new StubDataAdapter());

            var writer = new StringWriter();

            renderer.Render(writer);

            var result = writer.ToString();

            Console.Write(result);

            var lineCount = result.Count(c => c == '\n') + 1;
            Assert.AreEqual(4, lineCount);
        }

        [Test]
        public void CsvDataAdapter()
        {
            var renderer = new DataRenderer(new CsvDataAdapter());

            var writer = new StringWriter();

            renderer.Render(writer);

            var result = writer.ToString();

            Console.Write(result);

            var lineCount = result.Count(c => c == '\n') + 1;
            Assert.AreEqual(61, lineCount);
        }
    }
}
