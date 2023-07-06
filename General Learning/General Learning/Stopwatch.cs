using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Stopwatch
    {
        private DateTime startTime;
        public bool IsRunning { get; private set; }
        public Stopwatch()
        {
            IsRunning = false;
        }

        public void Start()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Cannot start the stopwatch if it has already started");
            }
            else
            {
                startTime = DateTime.Now;
                IsRunning = true;
            }
        }

        public void Stop()
        {
            if (!IsRunning)
            {
                throw new InvalidOperationException("Cannot stop the stopwatch if it is already stopped");
            }
            else
            {
                IsRunning = false;
                Console.WriteLine("The stopwatch ran for {0}", DateTime.Now - startTime);
            }
        }
    }
}
