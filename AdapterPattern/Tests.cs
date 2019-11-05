using System;
using System.IO;
using System.Linq;
using AdapterPattern.Adapters;
using AdapterPattern.Patterns;
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

        [Test]
        public void PatternAdapter()
        {
            var patterns = new[]
            {
                new Pattern{Id = 1, Name = "Zig-zag", Description = "Goes diagonally from side to side."},
                new Pattern{Id = 1, Name = "Dashes", Description = "Line broken at regular intervals."},
                new Pattern{Id = 1, Name = "Spots", Description = "Regularly positioned small circles in close proximity."}
            };

            var renderer = new PatternRenderer();

            var result = renderer.ListPatterns(patterns);

            Console.Write(result);

            var lineCount = result.Count(c => c == '\n') + 1;
            Assert.AreEqual(5, lineCount);
        }
    }
}
