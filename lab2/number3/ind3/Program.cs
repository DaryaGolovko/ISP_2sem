using System;

namespace Lab
{
    class Program
    {
        static void Main()
        {
            int number1=CheckInput();
            int number2=CheckInput();
            int count = Count(number1, number2);

            Console.WriteLine("Степень двойки:\n"+count);
            Console.ReadKey();
        }
        static int CheckInput()
        {
            string strInput;
            int number;
            Console.WriteLine("Введите число:");
            strInput = Console.ReadLine();

            while (!Int32.TryParse(strInput, out number))
            {
                strInput = Console.ReadLine();
            }

            return number;
        }

        static int Count(int number1, int number2)
        {
            long multiplyNumbers = 1;
            for (long i = number1; i < number2; i++)
            {
                multiplyNumbers *= i + 1;
            }

            int count = 0;
            while (multiplyNumbers % 2 == 0)
            {
                count++;
                multiplyNumbers /= 2;
            }

            return count;
        }
    }
}
