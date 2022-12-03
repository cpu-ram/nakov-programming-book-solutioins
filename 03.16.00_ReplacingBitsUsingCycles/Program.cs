using System;

namespace _03._16._00_ReplacingBitsUsingCycles
{
    class Program
    {
        static void Mask(int num, int p, int q)
        {
            string s;
            string mask = "";
           

            int counter = 0; // ???

            

                for (int x = 31; x >= 0; x--)
            {
                if ((x <= 29) & ((x + 1) % 3 == 0))           // number order separators
                {
                    mask = mask + "'";
                }

                if ((x == p) | (x == q))                         // before-selection sign
                {
                    mask = mask + " >";
                }


                s = Convert.ToString((num >> x) & 1);
                mask = mask + s;
                
                if((x == p)|(x==q))                              // after-selection sign
                {
                    mask = mask + "< ";
                }

                


            }
            
            Console.Write("[" + mask + "]");

        }
        



                                                                                                    // Functional Method over, Main Method starts


        static void Main(string[] args)
        {
             /*
             * What are some presumptions I make for the sake of tre program's simplicity?
             * 
             */

            int orNum =63;                                // initial assignments start
            int num = orNum;

            int orP = 16;
            int orQ =0;
            int k = 10;

            int orPBit = (orNum >> orP) & 1;
            int orQBit = (orNum >> orQ) & 1;              // initial assignments end


            Console.WriteLine("The value of the original Number is " + orNum + ",");
            Console.Write("The mask of the original number is ");
            Mask(orNum, orP, orQ);
            Console.WriteLine("\n'p'=" + orP + ", 'q'=" + orQ + ", 'k'=" + k + "." );
            
            Console.WriteLine("pBit=" + orPBit + ", qBit=" + orQBit + "." + "\n ");  // original values message
            Console.WriteLine("Program's purpose is to replace p bits with q bits. \n Program starts \n _______________________________ \n"); // Program start declaration

            for (int n = 0; n <= (k - 1); n++)                        // 'for' cycle -- begins
            {
                Console.WriteLine("Iteration #" + n + " begins. \n");
                
                
                int p = orP + n;    // calculating p and q positions
                int q = orQ + n;

                int pBit = (num >> p) & 1;  // calculating the values of p and q
                int qBit = (num >> q) & 1;

                int qMask = 0;
                int pMask = 0;


                

                Console.WriteLine("num = " + num + ",");                              //pre-mask-application message
                Console.WriteLine("Before mask application, num is " + num + ",");    // post-mask application message;
              
                Console.Write("The mask of 'num' =");  // mask application message
                Mask(num, p, q);
                
                Console.WriteLine("\n p=" + p + ", q=" + q + ",");
                Console.WriteLine("pBit=" + pBit + ", qBit=" + qBit + ".\n");

                qMask = qBit==1?  ((qBit) << p) : ((1) << p);     // Mask calculation     
                num = qBit==1? (num | qMask) : (num & ~qMask);          // Mask application

                pMask = pBit == 1 ? ((pBit) << q) : ((1) << q);     // Mask calculation     
                num = pBit == 1 ? (num | pMask) : (num & ~pMask);          // Mask application

                Console.WriteLine("A qMask with a value of ");        // mask post-application alert
                Mask(qMask, 0, 0);
                Console.Write(" is applied!");

                Console.WriteLine("A pMask with a value of ");        // mask post-application alert
                Mask(pMask, 0, 0);
                Console.Write(" is applied!");



                Console.WriteLine("\n\n After mask application #" + n + ", num is " + num + ",");    // post-mask application message -- begins
                
                Console.Write("\n The mask of 'num' =");
                Mask(num, p, q);  
                Console.WriteLine("\n p=" + p + ", q=" + q + ",");
                Console.WriteLine("pBit=" + pBit + ", qBit=" + qBit + ".");                         // post-mask application message -- over
                Console.WriteLine("\n" +"Iteration #" + n + " is over \n\n\n\n___________________");                                                               
            }                                                                                       // for-cycle -- ends
            

            Console.WriteLine("\n The final adjusted num is " + num + ".");

        }
    }
}
