using System;

namespace _06._17_Euclidian_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter the 'a' number:");

			int a = Int32.Parse(Console.ReadLine());

			Console.WriteLine("Enter the 'a' number:");

			int b = Int32.Parse(Console.ReadLine());



			int c = Math.Max(a, b);
			int d = Math.Min(a, b);

			while (true)
			{
				int e = c % d;

				if (e == 0)
				{
					int lcm = (a * b) / d;
					Console.WriteLine($"For the numbers {a} and {b} GCD = {d}, LCM = {lcm}");
						break;
				}

				else
				{
					c = d;
					d = e;
				}
			}
		}
    }
}
