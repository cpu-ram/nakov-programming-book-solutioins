using System;

namespace _03._00_Formatted_output
{
    class Program
    {
        static void Main(string[] args)
        {
			int naturalNumber = 2;
			int multiplicator;
			string fullText = "";
			int iteration = 0;
			for (int x = 0; x <= 99; x++)

			{

				if (iteration == 0 || iteration == 1 || iteration == 2 || iteration == 4)
				{
					multiplicator = 1;
				}
				else
				{
					multiplicator = -1;
				}

				int numberForString = naturalNumber * multiplicator;
				string numberAsAString = Convert.ToString(numberForString);
				fullText += numberAsAString + " ";

				if (iteration == 6) { iteration = 0; }
				else { iteration = iteration + 1; }
				naturalNumber += 1;
			}
			System.Console.WriteLine(fullText);
		}
    }
}
