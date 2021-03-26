using System;

namespace numbers
{
    class Program
    {
        static int Main()
        {
            long number1, number2;
            
            Console.Write("Введите 1 число: ");
            string strNum1 = Console.ReadLine();
            while (!long.TryParse(strNum1, out number1) || (number1 <= 0))
            {
                Console.WriteLine("Введите еще раз");
                strNum1 = Console.ReadLine();
            }

            Console.Write("Введите 2 число: ");
            string strNum2 = Console.ReadLine();
            while (!long.TryParse(strNum2, out number2) || (number2 <= number1))
            {
                Console.WriteLine("Введите еще раз");
                strNum2 = Console.ReadLine();
            }

            long countNum1 = CountMultiply(number1 - 1);
            long countNum2 = CountMultiply(number2);

            Console.WriteLine("Степень двойки: " + (countNum2 - countNum1));

            Console.ReadKey(); 
            return 0;
        }

        static long CountMultiply(long number)
        {
            long countMultiply = 0;
            while (number > 0)
            {
                number /= 2;
                countMultiply += number;
            }
            return countMultiply;
        }
    }
}
