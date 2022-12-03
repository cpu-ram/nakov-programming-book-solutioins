using System;
using System.Text;

namespace _13._03_CheckForCorrectParentheses
{
    class Program
    {
        static bool CheckForCorrectParentheses(string entryString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(entryString);
            int counter = 0;
            char leftBracket = Convert.ToChar("(");
            char rightBracket = Convert.ToChar(")");



            for(int i=0; i<stringBuilder.Length; i++)
            {
                if (stringBuilder[i].Equals(leftBracket))
                {
                    counter++;
                }
                if (stringBuilder[i].Equals(rightBracket))
                {
                    counter--;
                }
                if (counter < 0)
                {
                    return false;
                }
            }
            if (counter > 0) return false;
            return true;
        }

        static void Main(string[] args)
        {
            string expression = "((3+5)^3)-(37*5)";
            bool isCorrect = CheckForCorrectParentheses(expression);
            Console.WriteLine(isCorrect);
        }
    }
}
