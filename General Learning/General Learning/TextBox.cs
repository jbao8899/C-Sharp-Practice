using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    // Does not inherit code from the interfaces IDraggable and IDroppable,
    // so interfaces are not for inheritance
    public class TextBox : UIControl, IDraggable, IDroppable
    {
        public void Drag()
        {

        }

        public void Drop()
        {

        }
    }
}
