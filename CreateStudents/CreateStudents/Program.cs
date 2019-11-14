using System;

using static System.Console;

namespace CreateStudents {
    class Student {
        private double gradePointAverage;
        public const double HIGHEST_GPA = 4.0;
        public const double LOWEST_GPA = 0.0;
        public int IdNumber { get; set; }
        public string LastName { get; set; }
        public double GradePointAverage {
            get {
                return gradePointAverage;
            }
            set {
                if (value >= LOWEST_GPA && value <= HIGHEST_GPA) {
                    gradePointAverage = value;
                }
                else {
                    gradePointAverage = LOWEST_GPA;
                }
            }
        }
    }
    class Program {
        static void Display(Student stu) {
            WriteLine("{0, 5} {1, -10}{2,6}", stu.IdNumber, stu.LastName, stu.GradePointAverage.ToString("F1"));
        }
        static void Main(string[] args) {
            Student first = new Student();
            Student second = new Student();
            first.IdNumber = 123;
            first.LastName = "Anderson";
            first.GradePointAverage = 3.5;
            second.IdNumber = 789;
            second.LastName = "Daniels";
            second.GradePointAverage = 4.1;

            Display(first);
            Display(second);
        }
    }
}
