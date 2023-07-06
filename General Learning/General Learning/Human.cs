using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    class Human
    {
        // Member variables
        private string FirstName = "FirstName";
        private string LastName = "LastName";
        private string EyeColor = "EyeColor";
        private int Age = -1;

        // Member methods
        public void IntroduceSelf()
        {
            if (Age == 1)
            {
                Console.WriteLine("Too young to speak.");
            }
            else
            {
                string output = "Hi.";

                string name = "";
                if (!FirstName.Equals("FirstName"))
                {
                    name += FirstName;
                }
                if (!LastName.Equals("LastName"))
                {
                    if (name.Length > 0)
                    {
                        name += " ";
                    }
                    name += LastName;
                }
                if (name.Length > 0)
                {
                    output += " My name is " + name + ".";
                }

                if (!EyeColor.Equals("EyeColor"))
                {
                    output += " I have " + EyeColor + " eyes.";
                }

                if (Age != -1)
                {
                    output += " I am " + Age + " years old.";
                }

                Console.WriteLine(output);
            }
        }

        // Parameterized Constructor
        public Human(string setFirstName, string setLastName, string setEyeColor, int setAge)
        {
            FirstName = setFirstName;
            LastName = setLastName;
            EyeColor = setEyeColor;
            Age = setAge;
        }

        // Parameterized Constructor without age
        public Human(string setFirstName, string setLastName, string setEyeColor)
        {
            FirstName = setFirstName;
            LastName = setLastName;
            EyeColor = setEyeColor;
        }

        // Parameterized Constructor with only first and last name
        public Human(string setFirstName, string setLastName)
        {
            FirstName = setFirstName;
            LastName = setLastName;
        }

        // Parameterized Constructor with only first name
        public Human(string setFirstName)
        {
            FirstName = setFirstName;
        }

        // Default constructor
        public Human()
        {
            //Console.WriteLine("The default constructor for Human class was called.");
        }
    }
}
