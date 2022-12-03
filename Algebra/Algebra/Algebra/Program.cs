using System;

namespace Algebra
{
    class Program
    {
        static void Main(string[] args)
        {
            string formula = "((10+6*x)^y)";
            Expression expression = new Expression(formula);
            expression.Evaluate();
            decimal expressionValue = expression.Value;
            Console.WriteLine(expressionValue);
        }
    }
}
