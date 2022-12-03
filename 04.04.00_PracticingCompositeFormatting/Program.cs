using System;

namespace _04._04._00_PracticingCompositeFormatting
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            int numForFirstCol = int.Parse(inputLine);
            inputLine = Console.ReadLine();
            double numForSecondCol = double.Parse(inputLine);
            inputLine = Console.ReadLine();
            double numForThirdCol = double.Parse(inputLine);
            Console.WriteLine("{0,-10:X}{1,-10:F2}{2,-10:F2}",
                numForFirstCol, numForSecondCol, numForThirdCol);
        }
    }
}
