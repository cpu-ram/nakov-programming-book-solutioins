using System;
using System.Text;

namespace SubstringExtension
{
    static class Program
    {
        public static StringBuilder Substring(this StringBuilder stringBuilder,
            int startPosition, int length)
        {
            if ((startPosition + length) > stringBuilder.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            StringBuilder newSB = new StringBuilder();

            for(int i=0; i<length; i++)
            {
                int currentPosition = startPosition + i;
                newSB.Append(stringBuilder[currentPosition]);
            }
            return newSB;
        }


        static void Main(string[] args)
        {
            string helloWorld = "Hello, world! What is up?";
            StringBuilder helloWorldSB = new StringBuilder(helloWorld);
            helloWorldSB = helloWorldSB.Substring(14,11);
            Console.WriteLine(helloWorldSB);
        }
    }
}
