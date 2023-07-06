using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Members
    {
        // member - private field
        private string _memberName;
        private string _jobTitle;
        private int _salary = 20000;

        // member - public field
        public int _age;

        // Property
        public string JobTitle 
        {
            get
            {
                return _jobTitle;
            }
            set
            {
                _jobTitle = value;
            }
        }

        // public member method, can be called from other classes
        public void Introduce(bool isFriend)
        {
            if (isFriend)
            {
                SharingPrivateInfo();
            }
            Console.WriteLine("Hi, my name is {0} and my job title is {1}. I am {2} years old.", _memberName, _jobTitle, _age);
        }

        private void SharingPrivateInfo()
        {
            Console.WriteLine("My salary is {0}", _salary);
        }

        // member constructor
        public Members()
        {
            _age = 30;
            _memberName = "Lucy";
            _salary = 60000;
            _jobTitle = "Developer";
            Console.WriteLine("Object constructed");
        }

        // Destructor (can only have one). Cannot be overloaded, inherited, or called
        // Automatically called when this object leaves the score
        // Used for cleaning up
        // Don't make this unless it is needed
        ~Members()
        {
            // Program ends before this gets called.
            Console.WriteLine("Members object destroyed");
        }
    }
}
