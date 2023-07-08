using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class DBMigrator
    {
        private readonly Logger _logger;

        public DBMigrator(Logger setLogger)
        {
            _logger = setLogger;
        }

        public void Migrate()
        {
            _logger.Log("We are migrating.");
        }
    }
}
