using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Student s1 = new Student("Prayuth", "60039999");
            Console.WriteLine("Student name = " + s1.Name + ", ID = " + s1.ID);
            Console.ReadKey();

        }
    }
    public class Student
    {
        // Fields declaration
        private string name;
        private string id;
        private float gpa;

        public Student(string value1, string value2)
        {
            this.name = value1;
            this.id = value2;
        }

        // read-only property
        public string Name
        {
            get { return name; }
        }

        // read-only property
        public string ID
        {
            get { return id; }
        }

        // read/write property
        public float GPA
        {
            get { return gpa; }
            set { gpa = value; }
        }

    }
}
