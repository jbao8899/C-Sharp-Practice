using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string setPath)
        {
            _path = setPath;
        }

        public void LogError(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine("ERROR " + message);
            }
        }

        public void LogInfo(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
