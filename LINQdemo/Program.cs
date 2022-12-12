using System.Xml.Linq;

namespace LINQdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new[] { 50, 66, 90, 81, 77, 45, 0, 100, 99, 72, 87, 85, 81, 80, 77, 74, 95, 97 };

            foreach(var individualScore in scores)
            {
                Console.WriteLine("One of these scores was {0}", individualScore);
            }

            var theBestStudents = 
                from individualScore in scores
                where individualScore > 90
                select individualScore;

            foreach(var individualScore in theBestStudents)
            {
                Console.WriteLine("One of the BEST scores was {0}", individualScore);
            }

            var bStudents =
                from individualScore in scores
                where individualScore >= 80 && individualScore < 90
                orderby individualScore ascending
                select individualScore;
            foreach (var individualScore in bStudents)
            {
                Console.WriteLine("The B grade students were {0}", individualScore);
            }

            scores = scores.OrderBy(x => x).ToArray();

            foreach(var individualScore in scores)
            {
                Console.WriteLine("One of the scores was {0}", individualScore);
            }

            Console.WriteLine("\n");
            List<Student> studentList = new List<Student>();
            Student s1 = new Student("Tim", 19, 78);
            Student s2 = new Student("Jessica", 20, 84);
            Student s3 = new Student("Caleb", 19, 89);
            Student s4 = new Student("Ron", 18, 71);
            Student s5 = new Student("Amanda", 19, 93);
            Student s6 = new Student("Cathrine", 21, 65);
            studentList.Add(s1);
            studentList.Add(s2);
            studentList.Add(s3);
            studentList.Add(s4);
            studentList.Add(s5);
            studentList.Add(s6);

            foreach (Student student in studentList)
            {
                Console.WriteLine(student.name + " has a grade of: " + student.grade.ToString());
            }

            studentList.Sort();
            Console.WriteLine();

            foreach (Student student in studentList)
            {
                Console.WriteLine(student.name + " has a grade of: " + student.grade.ToString());
            }

            Console.ReadKey();
        }
    }
}