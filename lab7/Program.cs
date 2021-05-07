using System;

namespace lab7
{
    class Program
    {
        static void Main()
        {
            Rational number1 = new Rational(4, 9);
            Rational number2 = new Rational(2, 5);
            Rational number3 = Rational.ToRationalConverter("12/27");
            Rational number4 = Rational.ToRationalConverter("15/8");

            Console.WriteLine(number1.ToString());
            Console.WriteLine(number2.ToString());

            Console.WriteLine($"Сумма: {number1 + number2}");
            Console.WriteLine($"Разность: {number1 - number2}");
            Console.WriteLine($"Произведение:  {number1 * number2}");
            Console.WriteLine($"Деление:  {number1 / number2}");
            Console.WriteLine();

            if (number2 == number3) Console.WriteLine($"{number2} = {number3}");
            if (number2 != number3) Console.WriteLine($"{number2} != {number3}");
            if (number1 > number2) Console.WriteLine($"{number1} > {number2}");
            if (number2 < number3) Console.WriteLine($"{number2} < {number3}");

            Console.WriteLine($"{number1} в double = {(double)number1}");
            Console.WriteLine($"{number2} в float = {(float)number2}");
            Console.WriteLine($"{number4} в int = {(int)number4}");
            Console.WriteLine($"{number4} в short = {(short)number4}");
            Console.WriteLine($"{number4} в long = {(int)number4}");

            ulong x = number1;
            Console.WriteLine($"Числитель 1 числа: {x}");
        }
    }
}
