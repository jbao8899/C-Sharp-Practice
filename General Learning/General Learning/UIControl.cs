using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class UIControl
    {
        public string ID { get; set; }
        public Size UISize { get; set; }
        public Position TopLeft { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine($"UIControl {ID} was drawn.");
        }

        public void Focus()
        {
            Console.WriteLine($"UIControl {ID} received focus.");
        }
    }
}
