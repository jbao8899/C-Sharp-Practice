using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; set; }

        public TimeSpan Timeout { get; set; }

        public DbConnection(string setConnectionString, TimeSpan setTimeout)
        {
            if (string.IsNullOrWhiteSpace(setConnectionString))
            {
                throw new ArgumentNullException("Connection string must not be null or empty.");
            }
            ConnectionString = setConnectionString;
            Timeout = setTimeout;
        }

        public abstract void OpenConnection();

        public abstract void CloseConnection();
    }
}
