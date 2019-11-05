using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdapterPattern
{
    public class Tests
    {
        [Test]
        public void StubRenderer()
        {
            var renderer = new DataRenderer(new StubDataAdapter());

            var writer = new StringWriter();

            renderer.Render(writer);

            var result = writer.ToString();

            Console.Write(result);

            var lineCount = result.Count(c => c == '\n') + 1;
            Assert.AreEqual(4, lineCount);
        }
    }
}
