using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    class UniversityManager
    {
        public List<University> Universities;
        public List<Student202> Students;

        public UniversityManager()
        {
            Universities = new List<University>
            {
                new University(1, "Yale"),
                new University(2, "Beijing Tech")
            };
            Students = new List<Student202>
            {
                new Student202(1, "Carla", "Female",  17, 1),
                new Student202(2, "Tony",  "Male",    21, 1),
                new Student202(3, "Frank", "Male",    22, 2),
                new Student202(4, "Leyla", "Female",  19, 2),
                new Student202(5, "James", "Unknown", 25, 2),
                new Student202(6, "Linda", "Female",  22, 2)
            };
        }

        public void GetMaleStudents()
        {
            IEnumerable<Student202> maleStudents = from student in Students
                                                   where student.Gender == "Male"
                                                   select student;

            foreach (Student202 student in maleStudents)
            {
                student.Print();
            }
        }

        public void GetFemaleStudents()
        {
            IEnumerable<Student202> femaleStudents = from student in Students
                                                     where student.Gender == "Female"
                                                     select student;

            foreach (Student202 student in femaleStudents)
            {
                student.Print();
            }
        }

        public void GetStudentsSortedByAge()
        {
            IEnumerable<Student202> sortedStudents = from student in Students
                                                     orderby student.Age ascending
                                                     select student;

            foreach (Student202 student in sortedStudents)
            {
                student.Print();
            }
        }

        public void GetAllStudentsAtBeijingTech()
        {
            IEnumerable<Student202> bjtStudents = from student in Students
                                                  join university in Universities
                                                  on student.UniversityID equals university.ID
                                                  where university.Name == "Beijing Tech"
                                                  select student;

            foreach (Student202 student in bjtStudents)
            {
                student.Print();
            }
        }

        public void GetStudentsOfSpecifiedUniversity()
        {
            Console.WriteLine("Enter the ID of the university you want to know the students of");
            
            int desiredUniversityID;
            
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out desiredUniversityID))
                {
                    Console.WriteLine("That is not a valid ID!");
                }
                else
                {
                    break;
                }
            }

            IEnumerable<Student202> studentsFromSpecifiedUniversity = from student in Students
                                                                      where student.UniversityID == desiredUniversityID
                                                                      select student;

            foreach (Student202 student in studentsFromSpecifiedUniversity)
            {
                student.Print();
            }
        }

        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in Students
                                join university in Universities
                                on student.UniversityID equals university.ID
                                orderby student.Name
                                select new { studentName = student.Name, universityName = university.Name };

            Console.WriteLine("New collections");
            foreach (var col in newCollection)
            {
                Console.WriteLine("Student {0} from university {1}", col.studentName, col.universityName);
            }
        }
    }
}
