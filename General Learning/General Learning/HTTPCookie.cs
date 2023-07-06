using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    internal class HTTPCookie
    {
        // readonly prevents reassinging, but can still add stuff to dictionary
        private readonly Dictionary<string, string> _dictionary;

        public HTTPCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }
        public string this[string key] // Indexer
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                _dictionary[key] = value;
            }
        }
    }
}
