using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class DbCommand
    {
        public DbConnection Connection { get; set; }

        public string Command { get; set; }

        public DbCommand(DbConnection setConnection, string setCommand)
        {
            if (setConnection == null)
            {
                throw new ArgumentNullException("The connection must not be null.");
            }
            if (string.IsNullOrWhiteSpace(setCommand))
            {
                throw new ArgumentNullException("The command must not be null, empty, or all whitespace.");
            }

            Connection = setConnection;
            Command = setCommand;
        }

        public void Execute()
        {
            Connection.OpenConnection();
            Console.WriteLine(Command);
            Connection.CloseConnection();
        }
    }
}
