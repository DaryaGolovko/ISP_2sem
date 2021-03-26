using System;
using System.Text;

namespace ind1
{
    class Program
    {
        static void Main()
        {     
            StringBuilder strAuto = new StringBuilder();
            StringBuilder strOutput = new StringBuilder();

            Random rand = new Random();
            int randNum = rand.Next(0, 8);
            
            for (int i = 0, letter=0; i<256 ; i++)
            {
                   
                if(letter == 0)
                {
                    strAuto.Append("a");
                    letter++;
                }
                else if (letter == 1)
                {
                    strAuto.Append("b");
                    letter++;
                }
                else if (letter == 2)
                {
                    strAuto.Append("c");
                    letter -= 2;
                }
            }
            
            for (int i = 0, counter = 0; counter < 31; i++, counter++ )
            {
                strOutput.Append(strAuto[i+randNum]);
                strOutput.Append(' ');
            }
            
            for (int i =  strOutput.Length-1; i>0; i--)
            {
                Console.Write(strOutput[i]);
            }

            Console.ReadKey();
        }
    }
}
