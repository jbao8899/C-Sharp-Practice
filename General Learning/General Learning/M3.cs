using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    class M3 : BMW
    {
        public M3(int setHorsepower, string setColor) : base(setHorsepower, setColor, "M3")
        {
        }

        // Cannot override, because it is sealed in parent class (BMW)
        //public override void Repair()
        //{
        //    base.Repair();
        //}
    }
}
