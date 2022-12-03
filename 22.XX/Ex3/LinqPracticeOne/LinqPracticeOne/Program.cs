using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPracticeOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Mary = new Student("Mary", "Virgin", 28);
            Student Martha = new Student("Martha", "Mary's Sister", 20);
            Student Luke = new Student("Luke", "Fisherman", 30);
            Student John = new Student("John", "Baptist", 64);
            Student Mark = new Student("Mark", "Fisherman", 19);

            List<Student> listOfStudents = new List<Student>();
            listOfStudents.Add(Mary);
            listOfStudents.Add(Martha);
            listOfStudents.Add(Luke);
            listOfStudents.Add(John);
            listOfStudents.Add(Mark);

            //TestLinq(listOfStudents);
            //TestLambdaSorting(listOfStudents);
            //TestLinqSorting(listOfStudents);

            //int[] numbers = new int[10] { 7, 10, 21, 42, 50, 60, 65, 84, 168, 500 };
            //FindMultiplesWithLambda(numbers, 7, 3);



        }
        static void TestLinqSelection(List<Student> studentList)
        {
            var selection =
                from student in studentList
                where student.Age >= 18 && student.Age <= 24
                select student;

            foreach (var student in selection)
            {
                Console.WriteLine(student);
            }
        }
        static void TestLambdaSorting(List<Student> studentList)
        {
            var sortedStudents = studentList.OrderByDescending(c => c.FirstName).
                ThenBy(c => c.LastName);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
        static void TestLinqSorting(List<Student> studentList)
        {
            var sortedStudents =
                from student in studentList
                orderby student.FirstName descending, student.LastName descending
                select student;
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
        static void FindMultiplesWithLambda(int[] numberList, params int[] divisors)
        {
            int jointDivisor = 1;
            foreach (int element in divisors)
            {
                jointDivisor *= element;
            }

            var filteredNumbers = Array.FindAll(numberList, x => (x % jointDivisor) == 0);
            foreach(int number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
        }
        static void FindMultiplesWithLinq(int[] numberList, params int[] divisors)
        {
            int jointDivisor = 1;
            foreach (int element in divisors)
            {
                jointDivisor *= element;
            }

            var filteredNumbers =
                from number in numberList
                where number % jointDivisor == 0
                select number;
            foreach(int number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
        }

        
    }
}
