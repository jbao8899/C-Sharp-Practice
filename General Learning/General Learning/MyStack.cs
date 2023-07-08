using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class MyStack
    {
        public int Size { get; set; }
        private StackNode? Head { get; set; }

        public MyStack()
        {
            Size = 0;
            Head = null;
        }

        public void Push(object data)
        {
            if (data == null)
            {
                throw new InvalidOperationException("Do not insert null into the stack");
            }

            StackNode newHead = new StackNode(null, data);

            if (Head != null)
            {
                newHead.Next = Head;
            }

            Head = newHead;
            Size++;
        }

        public object Pop()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("The stack is empty, so you cannot pop anything.");
            }

            StackNode retNode = Head;
            Head = retNode.Next;

            Size--;

            return retNode.Content;
        }

        public void Clear()
        {
            Size = 0;
            Head = null;
        }
    }
}