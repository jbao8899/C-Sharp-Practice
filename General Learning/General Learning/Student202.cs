using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    class Student202
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign key
        public int UniversityID { get; set; }

        public Student202(int setID, string setName, string setGender, int setAge, int setUniversityID)
        {
            ID = setID;
            Name = setName;
            Gender = setGender;
            Age = setAge;
            UniversityID = setUniversityID;
        }

        public void Print()
        {
            Console.WriteLine("Student {0} with ID {1} with gender {2} and age {3} from the university with an ID of {4}.", Name, ID, Gender, Age, UniversityID);
        }
    }
}
