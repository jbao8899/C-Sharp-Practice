using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class DBMigrator35
    {
        private readonly ILogger _logger;

        // dependency injection
        public DBMigrator35(ILogger setLogger)
        {
            _logger = setLogger;
        }

        public void Migrate()
        {
            // If we want to write to file or database instead of Console,
            // then we must rewrite, recompile, and redeploy this class
            // We can make this extensible using an interface
            // We use ILogger instead of Console
            // This class now knows nothing about the Console, but just talks to interface

            //Console.WriteLine($"Migration started at {DateTime.Now}");
            _logger.LogInfo($"Migration started at {DateTime.Now}");

            Random random = new Random();
            Thread.Sleep(random.Next(0, 5000));

            //Console.WriteLine($"Migration ended at {DateTime.Now}");
            _logger.LogInfo($"Migration ended at {DateTime.Now}");
        }
    }
}
