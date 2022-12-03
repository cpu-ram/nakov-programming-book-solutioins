using System;

namespace _06._17_Printing_a_matrix
{
    class Program
    {
        static int HalfStep() { return 0; }
        static int ReverseSign(int i) 
        { 
            i = -i;
            //Console.WriteLine("New step value={0} \n", i);
            return i;

        }
        static bool ReverseBool(bool i)
        {
            i = !i;
            return i;
        }
        
        
        static void Main(string[] args)
        {
            int sideLength = 4;
            int matrixSize = sideLength-1;
            int[,] matrix = new int[4,4];
            

            int num = 1;
            int xDim = 0;
            int yDim = 0;
            matrix[0, 0] = num;

            int limit = matrixSize;
            bool xAxis = true;

            int iterationCounter = 0;
            int lineCounter = 0;
            int step = 1;
            
            


            //Console.WriteLine($"Line counter={lineCounter}, coordinates=[{yDim},{xDim}]");
            //Console.WriteLine("Assigning cell [0,0]=1\n");


            for(int i = 0; i < limit; i++)
            {
                //Console.WriteLine($"Iteration #{iterationCounter}");
                //Console.WriteLine($"i={i}");
                //Console.WriteLine($"lineCounter={lineCounter}");
                //Console.WriteLine($"Step={step}");
                //Console.WriteLine($"Pre-iteration coordinates=[{yDim},{xDim}]");
                //Console.WriteLine(xAxis ? ("Axis=x") : ("Axis=y"));
                
                if (xAxis) { xDim += step; }
                else { yDim += step; }

                num++;
                matrix[yDim, xDim] = num;


                

                Console.WriteLine($"New coordinates=[{yDim},{xDim}]");
                Console.WriteLine($"[{yDim},{xDim}] is assigned value of '{num}'");
                Console.WriteLine();
                iterationCounter += 1;

                if(i==limit-1)
                {
                    
                    lineCounter++;
                    xAxis = ReverseBool(xAxis);
                    i = -1;
                    Console.WriteLine("End of the line reached.\n");
                        //"\nReassigning the 'i' counter, reversing the axis, " +
                        //$"\nassigning i=0, xAxis={xAxis}\n");

                    if ((lineCounter>1) & (lineCounter % 2 == 0))
                    {
                        //Console.WriteLine($"Counter 'i' is even. Reversing the step value.");
                        step = ReverseSign(step);
                    }

                    if((lineCounter>2) & (lineCounter % 2 == 1)) 
                    {
                        limit--;
                    }

                }
                if (lineCounter == 7)
                {
                    break;
                }


                
                

            }
            for (int m = 0; m <= 3; m++)
            {
                
                for (int n = 0; n <= 3; n++)
                {
                    Console.Write("{0,10}",matrix[m,n]);
                }
                Console.WriteLine();
            }



        }
    }
}
