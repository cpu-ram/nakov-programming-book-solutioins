using System;
using System.Collections.Generic;
using System.Linq;

namespace _42._00_Calculating_Polynomials
{
    public class Polynomial
    {
        public int elementCount = 0;

        public class Mononomial
        {
            public int Coefficient;
            public char VariableName;
            public int Power;

            public int VariableCount;

            public const char zero = '0';

            public Mononomial(int coefficient=0, char variableName=zero, int power=0)
            {
                Coefficient = coefficient;
                VariableName = variableName;
                Power = power;
            }



            public void Print()
            {
                Console.Write($"{this.Coefficient} {this.VariableName} {this.Power}");
                Console.Write("\n");
            }

        }
        public void AddMononomial(Mononomial mononomial)
        {
            if (mononomial != null)
            {
                elements.Add(mononomial);
                elementCount++;
            }

            else
            {
                Console.WriteLine("No arguments were given to the AddMononomial Method");
            }

        }


        public List<Mononomial> elements = new List<Mononomial>();
        

        public void Print()
        {
            foreach(Mononomial mononomial in elements)
            {
                mononomial.Print();
                
            }
        }
        public Mononomial CreateMononomial()
        {
                Console.WriteLine("Enter the coefficient");
                int coefficient = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the variable");
                char varName = Convert.ToChar(Console.ReadLine());

                Console.WriteLine("Enter the power");
                int power = Convert.ToInt32(Console.ReadLine());

                Mononomial mononomial = new Mononomial(coefficient, varName, power);

            

            return mononomial;

        }
        public static Polynomial CalculateSum(Polynomial sourcePolynomial)
        {

            Polynomial sum = new Polynomial();

            for(int x=0; x<sourcePolynomial.elementCount; x++)
            {

                if (sum.elementCount > 0)
                {
                    for (int y = 0; y < sum.elementCount; y++)
                    {
                        if (sum.elements[y].VariableName == sourcePolynomial.elements[x].VariableName & sum.elements[y].Power == sourcePolynomial.elements[x].Power)
                        {
                            sum.elements[y].Coefficient += sourcePolynomial.elements[x].Coefficient;
                            


                            break;


                        }
                        if (y == sum.elementCount-1)
                        {
                            sum.AddMononomial(sourcePolynomial.elements[x]);

                            break;
                        }
                        else continue;

                    }
                }
                else
                {
                    sum.AddMononomial(sourcePolynomial.elements[x]);

                }
            }
            return sum;

        }
        public void Log(string message)
        {
            Console.WriteLine($"\n {message}\n");
        }
        

        static public void TestSimplePolynomial()
        {


            Console.Write("\n\n\n");

            Polynomial polynomialOne = new Polynomial();
           
            Mononomial mononomialOne = polynomialOne.CreateMononomial();
            polynomialOne.AddMononomial(mononomialOne);
            
            Mononomial mononomialTwo = polynomialOne.CreateMononomial();
            polynomialOne.AddMononomial(mononomialTwo);

            Mononomial mononomialThree = polynomialOne.CreateMononomial();
            polynomialOne.AddMononomial(mononomialThree);

            Console.Write("Polynomial elements:\n");
            polynomialOne.Print();

            Polynomial sum = new Polynomial();
            sum = CalculateSum(polynomialOne);
            Console.Write("Sum of the mononomials:\n");
            sum.Print();






        }
        
        
        
    }

    public class CPolynomial
    {
        public int elementCount = 0;

        public List<Mononomial> elements = new List<Mononomial>();

        public void Print()
        {
            int i = 0;
            foreach (Mononomial mononomial in elements)
            {
                Console.Write($"Element {i}:    ");
                mononomial.Print();
                i++;

            }
        }


        public class Mononomial
        {
            public int Coefficient;
            public char[] VariableName;
            public int[] Power;

            public int VariableCount;

            public const char zero = '0';


            public Mononomial(int coefficient, char[] variableName, int[] power)
            {
                Coefficient = coefficient;
                VariableName = variableName;
                Power = power;
                VariableCount = variableName.Length;
            }
            public Mononomial(int coefficient, char variableName, int power)
            {
                char[] variableNameArr = { variableName };
                int[] powerArr = { power };

                Coefficient = coefficient;
                VariableName = variableNameArr;
                Power = powerArr;

                VariableCount = 1;
            }


            

            public Mononomial(int coefficient, char[] variableName, int power)
            {
            
                int[] powerArr = { power };

                VariableName = variableName;
                Coefficient = coefficient;
                Power = powerArr;
                VariableCount = 1;
            }
            public Mononomial(int coefficient, char variableName, int[] power)
            {
                char[] variableNameArr = { variableName };
                VariableName = variableNameArr;
                Coefficient = coefficient;
                Power = power;
                VariableCount = 1;
            }

            
            

            public void Print()
            {
                Console.Write($"{this.Coefficient} ");

                int i = 0;

                foreach(int element in this.VariableName)
                {
                    Console.Write($"*({VariableName[i]}^{Power[i]})");
                        i++;
                }

                Console.Write("\n");        
             }    


        }

        public Mononomial Create()
            {
                Console.WriteLine("Enter the coefficient");

                int coefficient = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the number of variables in the mononomial");

                int variableNumber = Convert.ToInt32(Console.ReadLine());


                char[] varName = new char[variableNumber];
                int[] power = new int[variableNumber];

                for (int i = 0; i < variableNumber; i++)
                {
                    Console.WriteLine($"Enter the variable #{i+1} out of {variableNumber}");
                    varName[i] = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine($"Enter the power #{i+1} out of {variableNumber}");
                    power[i] = Convert.ToInt32(Console.ReadLine());

                }

                Mononomial mononomial = new Mononomial(coefficient, varName, power);



                return mononomial;

            }

        public void AddMononomial(Mononomial mononomial)
            {
                if (mononomial != null)
                {
                    elements.Add(mononomial);
                    elementCount++;
                }

                else
                {
                    Console.WriteLine("No arguments were given to the AddMononomial Method");
                }

            }

        public static CPolynomial CalculateSum(CPolynomial sourcePolynomial)
        {

            CPolynomial sum = new CPolynomial();

            for (int x = 0; x < sourcePolynomial.elementCount; x++)
            {

                if (sum.elementCount > 0)
                {
                    for (int y = 0; y < sum.elementCount; y++)
                    {
                        if (sum.elements[y].VariableName.SequenceEqual(sourcePolynomial.elements[x].VariableName) & (sum.elements[y].Power.SequenceEqual(sourcePolynomial.elements[x].Power)))
                        {
                            sum.elements[y].Coefficient += sourcePolynomial.elements[x].Coefficient;



                            break;


                        }
                        if (y == sum.elementCount - 1)
                        {
                            sum.AddMononomial(sourcePolynomial.elements[x]);

                            break;
                        }
                        else continue;

                    }
                }
                else
                {
                    sum.AddMononomial(sourcePolynomial.elements[x]);

                }
            }
            return sum;

        }
        public static void CalculateProduct(Mononomial mononomialOne, Mononomial mononomialTwo)
        {
            

            List<char> varNames = new List<char>();
            List<int> powers = new List<int>();

            int coefficient = mononomialOne.Coefficient * mononomialTwo.Coefficient;

            bool elementJustFound = false;

            for (int i = 0; i < mononomialOne.VariableCount; i++)
            {
                if (varNames.Count == 0)
                {
                    varNames.Add(mononomialOne.VariableName[i]);
                    powers.Add(mononomialOne.Power[i]);
                    continue;
                }

                for(int j=0; j<varNames.Count; j++)
                {
                    if (mononomialOne.VariableName[i] == varNames[j])
                    {
                        powers[j] += mononomialOne.Power[i];
                        break;
                    }
                    if(j == varNames.Count - 1)
                    {
                        varNames.Add(mononomialOne.VariableName[i]);
                        powers.Add(mononomialOne.Power[i]);

                        break;
                    }
                }
            } // adding the elements of the first mononomial
            for (int i = 0; i < mononomialTwo.VariableCount; i++)
            {

                if (varNames.Count == 0)
                {
                    varNames.Add(mononomialTwo.VariableName[i]);
                    powers.Add(mononomialTwo.Power[i]);
                    continue;
                }

                for (int j = 0; j < varNames.Count; j++)
                {
                    if (mononomialTwo.VariableName[i] == varNames[j])
                    {
                        powers[j] += mononomialTwo.Power[i];
                        break;
                    }
                    if (varNames.Count == 0 || j == varNames.Count - 1)
                    {
                        varNames.Add(mononomialTwo.VariableName[i]);
                        powers.Add(mononomialTwo.Power[i]);

                        break;
                    }
                }
            } // adding the elements of the second mononomial

            char[] varNamesArr = varNames.ToArray();
            int[] powersArr = powers.ToArray();

            Mononomial result = new Mononomial(coefficient, varNamesArr, powersArr);
            result.Print();




        }
        public static void PrintCharArr(char[] charArr)
        {
            foreach(char element in charArr)
            {
                Console.Write($"{element} ");
            }
        }

        static void TestCPolynomial()
        {

        }

        static void TestSum()
        {
            CPolynomial cPolynomialOne = new CPolynomial();

            Console.WriteLine("Entering the first mononomial.");
            Mononomial MononomialOne = cPolynomialOne.Create();

            Console.WriteLine("Entering the second mononomial.");
            Mononomial MononomialTwo = cPolynomialOne.Create();

            cPolynomialOne.AddMononomial(MononomialOne);
            cPolynomialOne.AddMononomial(MononomialTwo);

            Console.WriteLine("Elements of the polynomial:");
            cPolynomialOne.Print();

            Console.WriteLine("Sum:");
            CPolynomial sum = CalculateSum(cPolynomialOne);
            sum.Print();
            
        }
        static void TestProduct()
        {
            CPolynomial cPolynomialOne = new CPolynomial();

            Console.WriteLine("Entering the first mononomial.");
            Mononomial MononomialOne = cPolynomialOne.Create();
            Console.WriteLine("First monomial:");
            MononomialOne.Print();

            Console.WriteLine("Entering the second mononomial.");
            Mononomial MononomialTwo = cPolynomialOne.Create();
            Console.WriteLine("Second monomial:");
            MononomialTwo.Print();

            Console.WriteLine("Calculating the product...");
            CalculateProduct(MononomialOne, MononomialTwo);

        }


        static void Main()
        {
            TestProduct();        
        }

        
    }
}

