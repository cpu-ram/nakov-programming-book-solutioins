using System;

namespace _06._02._00_ACycleALittleMoreComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            //assumptions: the enered numbers are going to be within the int-type-variable's range

            bool firstIteration = true;
            bool continueProgram= true;
            string restartExit;

            Console.WriteLine(
                "Hello! \nThis program will process the numbers you enter from the Console and display the biggest one " +
                "and the smallest one. \nTo finish the entry and see the results, enter 'finish' in the console (without the parenthyses)." +
                "\n______________________________________ \n");

             //initializing several variables for the main cycle code;
            int minVal = 0;
            int maxVal = 0;

            while (true)
            {
                if (!firstIteration)
                {
                    while (true) 
                    {
                        Console.WriteLine("Would you like to restart the program or exit it?" +
                            "\nEnter 'restart' or 'exit' in the console.");
                        restartExit = Console.ReadLine();

                        if (restartExit == "restart")
                        {
                            break;
                        }
                        if ((restartExit != "restart") && (restartExit != "exit"))
                        {
                            Console.WriteLine("Your entry is incorrect. Please try again.");
                        }
                        if (restartExit == "exit")
                        {
                            continueProgram = false;
                            break;
                        }
                        
                    }
                    if (continueProgram==false)
                    {
                       break;
                    }
                }


                int x = 0; // initializing the counter for the cycle;
                while (true)
                {
                    firstIteration = false;
                    Console.WriteLine("Enter a number (or a command):");
                    string entry = Console.ReadLine();
                    int num;
                    bool parse = Int32.TryParse(entry, out num);

                    if (!parse)
                    {
                        if (entry == "finish")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your entry is incorrect.");
                        }
                    }

                    else               // main cycle code;
                    {
                        if (x == 0)
                        {
                            minVal = num;
                            maxVal = num;
                        }
                        else
                        {
                            if (num > maxVal)
                            {
                                maxVal = num;
                            }

                            if (num < minVal)
                            {
                                minVal = num;
                            }
                        }


                    }
                    x++;
                }
            
                Console.WriteLine($"Maximum value = {maxVal}, minimum value = {minVal}");
            }
        }
    }
}
