using System.Collections.Generic;

namespace PrototypePattern
{
    public class PrototypeManager
    {
        private Dictionary<string, Prototype> prototypeLibrary = new Dictionary<string, Prototype>();

        public Prototype this[string key]
        {
            get { return prototypeLibrary[key]; }
            set { prototypeLibrary.Add(key, value); }
        }
    }
}
