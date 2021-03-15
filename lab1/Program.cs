﻿using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] ArrAuto = new int[8, 8];
            int[,] ArrUser = new int[8, 8];
            int[,] ArrShow = new int[8, 8];

            Console.WriteLine("\nПоле противника ");
            ShowArr(ArrAuto);
            Console.WriteLine("\nВаше поле");
            ShowArr(ArrUser);

            FillArrAuto(ArrAuto);
            FillArrUser(ArrUser);
            FillArrShow(ArrShow);

            Console.WriteLine("\nВаше поле");
            ShowArr(ArrUser);
            Console.WriteLine("\nПоле противника ");
            ShowArr(ArrShow);

            Play(ArrAuto, ArrUser,ArrShow);

            Console.ReadKey();
        }

        static void FillArrAuto(int[,] ArrAuto)
        {
            Random rand = new Random();
            int x1 = rand.Next(0, 2);
            int x2 = rand.Next(2, 4);
            int x3 = rand.Next(4, 6);
            int x4 = rand.Next(6, 8);

            int y1 = rand.Next(1, 8);
            int y2 = rand.Next(0, 7);
            int y3 = rand.Next(0, 6);
            int y4 = rand.Next(0, 5);

            ArrAuto[x1, y1] = 1;

            ArrAuto[x2, y2] = 1;
            ArrAuto[x2, y2 + 1] = 1;

            ArrAuto[x3, y3] = 1;
            ArrAuto[x3, y3 + 1] = 1;
            ArrAuto[x3, y3 + 2] = 1;

            ArrAuto[x4, y4] = 1;
            ArrAuto[x4, y4 + 1] = 1;
            ArrAuto[x4, y4 + 2] = 1;
            ArrAuto[x4, y4 + 3] = 1;
        }

        static void FillArrUser(int[,] ArrUser)
        {
            Console.WriteLine("Расстановка кораблей (1 клетка). Ввод клетки, с которой начинается корабль. Введите номер строки(от 1 до 8).");
            string Input = Console.ReadLine();
            int X1;
            while (!Int32.TryParse(Input, out X1) || X1 < 0 || X1 > 8)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
            }

            Console.WriteLine("Введите букву(от a до h)");
            Input = Console.ReadLine();
            bool temporary = Char.TryParse(Input, out char translate);
            int Y1 = ChangeLetter(translate);
            while (Y1 != 1 && Y1 != 2 && Y1 != 3 && Y1 != 4 && Y1 != 5 && Y1 != 6 && Y1 != 7 && Y1 != 8)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
                temporary = Char.TryParse(Input, out translate);
                Y1 = ChangeLetter(translate);
            }

            Console.WriteLine("Расстановка кораблей (2 клетки). Ввод клетки, с которой начинается корабль. Введите номер строки(от 1 до 8).");
            Input = Console.ReadLine();
            int X2;
            while (!Int32.TryParse(Input, out X2) || X2 < 0 || X2 > 8)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
            }

            Console.WriteLine("Введите букву(от a до g)");
            Input = Console.ReadLine();
            temporary = Char.TryParse(Input, out translate);
            int Y2 = ChangeLetter(translate);
            while (Y2 != 1 && Y2 != 2 && Y2 != 3 && Y2 != 4 && Y2 != 5 && Y2 != 6 && Y2 != 7)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
                temporary = Char.TryParse(Input, out translate);
                Y2 = ChangeLetter(translate);
            }

            Console.WriteLine("Расстановка кораблей (3 клетки). Ввод клетки, с которой начинается корабль. Введите номер строки(от 1 до 8).");
            Input = Console.ReadLine();
            int X3;
            while (!Int32.TryParse(Input, out X3) || X3 < 0 || X3 > 8)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
            }

            Console.WriteLine("Введите букву(от a до f)");
            Input = Console.ReadLine();
            temporary = Char.TryParse(Input, out translate);
            int Y3 = ChangeLetter(translate);
            while (Y3 != 1 && Y3 != 2 && Y3 != 3 && Y3 != 4 && Y3 != 5 && Y3 != 6)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
                temporary = Char.TryParse(Input, out translate);
                Y3 = ChangeLetter(translate);
            }

            Console.WriteLine("Расстановка кораблей (4 клетки). Ввод клетки, с которой начинается корабль. Введите номер строки(от 1 до 8).");
            Input = Console.ReadLine();
            int X4;
            while (!Int32.TryParse(Input, out X4) || X4 < 0 || X4 > 8)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
            }

            Console.WriteLine("Введите букву(от a до e)");
            Input = Console.ReadLine();
            temporary = Char.TryParse(Input, out translate);
            int Y4 = ChangeLetter(translate);
            while (Y4 != 1 && Y4 != 2 && Y4 != 3 && Y4 != 4 && Y4 != 5)
            {
                Console.WriteLine("Введите еще раз");
                Input = Console.ReadLine();
                temporary = Char.TryParse(Input, out translate);
                Y4 = ChangeLetter(translate);
            }

            ArrUser[X1 - 1, Y1 - 1] = 1;

            ArrUser[X2 - 1, Y2 - 1] = 1;
            ArrUser[X2 - 1, Y2] = 1;

            ArrUser[X3 - 1, Y3 - 1] = 1;
            ArrUser[X3 - 1, Y3] = 1;
            ArrUser[X3 - 1, Y3 + 1] = 1;

            ArrUser[X4 - 1, Y4 - 1] = 1;
            ArrUser[X4 - 1, Y4] = 1;
            ArrUser[X4 - 1, Y4 + 1] = 1;
            ArrUser[X4 - 1, Y4 + 2] = 1;
        }

        static void FillArrShow(int[,] ArrShow)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i + 1 + "  ");
                for (int j = 0; j < 8; j++)
                {
                   ArrShow[i, j]=0;
                }
            }
        }

        static void ShowArr(int[,] Arr)
        {
            Console.WriteLine("   a b c d e f g h");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i + 1 + "  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{Arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static int ChangeLetter(char letter)
        {
            int number = 0;
            switch (letter)
            {
                case 'a': number = 1; break;
                case 'b': number = 2; break;
                case 'c': number = 3; break;
                case 'd': number = 4; break;
                case 'e': number = 5; break;
                case 'f': number = 6; break;
                case 'g': number = 7; break;
                case 'h': number = 8; break;
                default: break;
            }
            return number;
        }

        static bool CheckWin(int[,] Arr)
        {
            bool flag=false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Arr[i,j]==1)
                    {
                        flag = true;
                        break;  
                    }
                }
            }
            return flag;
        }

        static void Play(int[,] ArrAuto, int[,] ArrUser, int[,] ArrShow )
        {
            while (CheckWin(ArrAuto) == true && CheckWin(ArrUser) == true)
            {
                int X = 0;
                int Y = 0;
                Console.WriteLine("Ваш ход. Введите номер строки выбранной клетки (от 1 до 8)");
                string Input = Console.ReadLine();
                while (!Int32.TryParse(Input, out X) || X < 0 || X > 8)
                {
                    Console.WriteLine("Введите еще раз");
                    Input = Console.ReadLine();
                }
                X--;

                Console.WriteLine("Введите букву(от a до h)");
                Input = Console.ReadLine();
                bool temporary = Char.TryParse(Input, out char translate);
                Y = ChangeLetter(translate) - 1;

                while (Y != 1 && Y != 2 && Y != 3 && Y != 4 && Y != 5 && Y != 6 && Y != 7 && Y != 0)
                {
                    Console.WriteLine("Введите еще раз");
                    Input = Console.ReadLine();
                    temporary = Char.TryParse(Input, out translate);
                    Y = ChangeLetter(translate) - 1;
                }

                if(ArrAuto[X, Y] == 1)
                {
                    ArrShow[X, Y] = 1;
                }
                else
                {
                    ArrShow[X, Y] = 3;
                }

                Console.WriteLine("\nПоле противника ");
                ShowArr(ArrShow);

                while (ArrAuto[X, Y] == 1)
                {
                    Console.WriteLine("Вы попали");
                    ArrAuto[X, Y] = 0;
                    Console.WriteLine("Ваш ход. Введите номер строки выбранной клетки (от 1 до 8)");
                    Input = Console.ReadLine();
                    while (!Int32.TryParse(Input, out X) || X < 0 || X > 8)
                    {
                        Console.WriteLine("Введите еще раз");
                        Input = Console.ReadLine();
                    }
                    X--;

                    Console.WriteLine("Введите букву(от a до h)");
                    Input = Console.ReadLine();
                    temporary = Char.TryParse(Input, out translate);
                    Y = ChangeLetter(translate) - 1;
                    while (Y != 1 && Y != 2 && Y != 3 && Y != 4 && Y != 5 && Y != 6 && Y != 7 && Y != 0)
                    {
                        Console.WriteLine("Введите еще раз");
                        Input = Console.ReadLine();
                        temporary = Char.TryParse(Input, out translate);
                        Y = ChangeLetter(translate) - 1;
                    }

                    if (ArrAuto[X, Y] == 1)
                    {
                        ArrShow[X, Y] = 1;
                    }
                    else
                    {
                        ArrShow[X, Y] = 3;
                    }

                    Console.WriteLine("\nПоле противника ");
                    ShowArr(ArrShow);
                }

                Random rand = new Random();
                int x = rand.Next(0, 8);
                int y = rand.Next(0, 8);

                while (ArrUser[x, y] == 1 && x < 8 && x > -1 && y < 8 && y > -1)
                {
                    ArrUser[x, y] = 0;
                    y++;
                }

                Console.WriteLine("\nПоле противника ");
                ShowArr(ArrShow);
                Console.WriteLine("\nВаше поле");
                ShowArr(ArrUser);
            }

            Console.WriteLine("Игра окончена!");
        }
    }
}
