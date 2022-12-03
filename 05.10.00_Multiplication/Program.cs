using System;

namespace _05._10._00_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
            Console.WriteLine("Enter a natural number x, such that 1<x<=9:");
            int entry = Int32.Parse(Console.ReadLine());
            int result;
            int mult;
            
                switch (entry)
                {
                    case 1:
                        mult = 10;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 2:
                        mult = 10;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 3:
                        mult = 10;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 4:
                        mult = 100;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 5:
                        mult = 100;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 6:
                        mult = 100;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 7:
                        mult = 1000;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 8:
                        mult = 1000;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;
                    case 9:
                        mult = 1000;
                        result = entry * mult;
                        Console.WriteLine($"Result={result}");
                        break;

                    default:
                        Console.WriteLine("Error. Enter a proper number.");
                        break;
                }

                

            }
        }
    }
}
