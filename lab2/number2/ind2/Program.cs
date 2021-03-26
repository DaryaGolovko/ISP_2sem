using System;

namespace lab2
{
    class Lab
    {
        static void Main()
        {
            DateTime localTime = DateTime.Now;

            string str = localTime.ToString();
            int[] countNumbers = new int[10];

            ShowInfo(localTime);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == i + '0')
                    {
                        countNumbers[i]++;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Количество " + i + " = " + countNumbers[i]);
            }

            Console.ReadKey();
        }

        static void ShowInfo(DateTime localTime)
        {
            Console.WriteLine("Дата и время в разных форматах:");
            Console.WriteLine("1." + localTime.ToString("D"));
            Console.WriteLine("2." + localTime.ToString("d"));
            Console.WriteLine("3." + localTime.ToString("f"));
            Console.WriteLine("4." + localTime.ToString("M"));
        }
    }
}
