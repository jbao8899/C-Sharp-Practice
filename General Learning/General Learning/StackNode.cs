using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class StackNode
    {
        public StackNode? Next { get; set; }
        public object Content { get; set; }

        public StackNode(StackNode? setNext, object setContent)
        {
            Next = setNext;
            Content = setContent;
        }
    }
}
