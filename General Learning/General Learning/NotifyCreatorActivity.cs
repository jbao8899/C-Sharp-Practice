using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class NotifyCreatorActivity : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Notifying video creator.");
        }
    }
}
