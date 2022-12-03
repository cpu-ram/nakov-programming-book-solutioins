using System;

namespace _05._08._00_ConsoleChoice
{
    class Program
    {
        static void Main(string[] args)
        {

            
            int choice;
            bool wrong = false;
            int entryInt;
            double entryDouble;
            string output;
            string entryString;
            

            while (true)
            {
                Console.WriteLine("Enter 0 to enter an integral, 1 to enter a double, 2 to enter a string:");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Please enter an integral:");
                        entryInt = Int32.Parse(Console.ReadLine());
                        entryInt += 1;
                        output = Convert.ToString(entryInt);
                        Console.WriteLine(output);

                        break;

                    case 1:
                        Console.WriteLine("Please enter an integral:");
                        entryDouble = Double.Parse(Console.ReadLine());
                        entryDouble += 1;
                        output = Convert.ToString(entryDouble);
                        Console.WriteLine(output);
                        break;

                    case 2:
                        Console.WriteLine("Please enter a string:");
                        entryString = (Console.ReadLine());
                        entryString += "*";
                        output = entryString;
                        Console.WriteLine(output);
                        break;

                    default:
                        Console.WriteLine("You entered a wrong number.");
                        wrong = true;
                        break;
                }

                Console.WriteLine($"Boolean 'wrong' = {wrong}");
                
                
               


                

            }
        }
    }
}
