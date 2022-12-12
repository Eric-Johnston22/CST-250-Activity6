using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQdemo
{
    public class Student : IComparable<Student>
    {
        public string name { get; set; }
        public int age { get; set; }
        public int grade { get; set; }

        public Student(string name, int age, int grade)
        {
            this.name = name;
            this.age = age;
            this.grade = grade;
        }

        public int CompareTo(Student? other)
        {
            return other.grade.CompareTo(this.grade);
        }
    }
}
