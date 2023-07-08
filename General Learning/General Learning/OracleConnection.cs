using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class OracleConnection : DbConnection
    {
        public OracleConnection(string setConnectionString, TimeSpan setTimeout)
            : base(setConnectionString, setTimeout) { }

        public override void OpenConnection()
        {
            Console.WriteLine("Opening Oracle connection");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closing Oracle connection");
        }
    }
}
