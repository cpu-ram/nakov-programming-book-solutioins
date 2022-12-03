using System;
namespace LinqPracticeOne
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            string resultString = FirstName + " " + LastName + ", " + age;
            return resultString;
        }
    }
}
