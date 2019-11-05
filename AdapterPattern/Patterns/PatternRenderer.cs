using System.Collections.Generic;

namespace AdapterPattern.Patterns
{
    public class PatternRenderer
    {
        // suppose we want some client code to receive our patterns rendered in the same way
        // done by DataRenderer, however it uses this method and we have no control over it
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            return patterns.ToString();
        }
    }
}