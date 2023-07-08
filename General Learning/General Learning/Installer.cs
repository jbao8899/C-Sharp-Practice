using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Installer
    {
        private readonly Logger _logger;

        public Installer(Logger setLogger)
        {
            _logger = setLogger;
        }

        public void Install()
        {
            _logger.Log("We are installing the application.");
        }

    }
}
