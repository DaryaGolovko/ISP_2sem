using System;
using System.Runtime.InteropServices;

namespace task2
{
    static class Lib
    {
        [DllImport("‪‪C:\\Users\\Admin\\Desktop\\С#\\lab4\\task2\\task2\\lab4.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int recursion(int number, int value);
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the number: ");
            string Input = Console.ReadLine();
            int number;
            while (!Int32.TryParse(Input, out number))
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
            }

            int result = Lib.recursion(number, 1);
            Console.WriteLine(result);
        }
    }
}
