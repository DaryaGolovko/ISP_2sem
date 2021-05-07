using System;
using System.Collections.Generic;

namespace lab6
{
    class Program
    {
        static void Main()
        {
            GenericInput<string> input1 = new GenericInput<string>();
            input1.Input("Ввод информации о 3 спортсменах.");
            //Console.WriteLine("Ввод информации о 3 спортсменах.");
            Console.WriteLine("Виды спорта: прыжки, плавание, бег");

            Console.WriteLine("Введите гендер прыгуна: ");
            string gender = Console.ReadLine();

            Console.WriteLine("Введите имя прыгуна: ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию прыгуна: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите возраст прыгуна: ");
            string input = Console.ReadLine();
            int age;
            while (!Int32.TryParse(input, out age))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите рост прыгуна: ");
            input = Console.ReadLine();
            int height;
            while (!Int32.TryParse(input, out height))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите вес прыгуна: ");
            input = Console.ReadLine();
            int weight;
            while (!Int32.TryParse(input, out weight))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Jumping jumpmen = new Jumping(gender, name, surname, age, height, weight);
            jumpmen.ShowInfo();

            Console.WriteLine("Введите гендер пловца: ");
            gender = Console.ReadLine();

            Console.WriteLine("Введите имя пловца: ");
            name = Console.ReadLine();

            Console.WriteLine("Введите фамилию пловца: ");
            surname = Console.ReadLine();

            Console.WriteLine("Введите возраст пловца: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out age))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите рост пловца: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out height))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите вес пловца: ");
            input = Console.ReadLine();          
            while (!Int32.TryParse(input, out weight))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Swimming swimmen = new Swimming(gender, name, surname, age, height, weight);
            swimmen.ShowInfo();

            Console.WriteLine("Введите гендер бегуна: ");
            gender = Console.ReadLine();

            Console.WriteLine("Введите имя бегуна: ");
            name = Console.ReadLine();

            Console.WriteLine("Введите фамилию бегуна: ");
            surname = Console.ReadLine();

            Console.WriteLine("Введите возраст бегуна: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out age))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите рост бегуна: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out height))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите вес бегуна: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out weight))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Running runmen = new Running(gender, name, surname, age, height, weight);
            runmen.ShowInfo();

            Console.WriteLine("Желаете получить информацию одного из полей?");
            input = Console.ReadLine();
            while (input != "yes" && input != "no")
            {
                Console.WriteLine("Некорректный ввод. Введите еще раз.");
                input = Console.ReadLine();
            }

            if (input == "yes")
            {
                Console.WriteLine("Введите вид спорта выбранного спортсмена: 1-прыжки, 2-плавание, 3-бег");
                input = Console.ReadLine();
                int temp;
                while (!Int32.TryParse(input, out temp) && temp < 1 && temp > 3)
                {
                    Console.WriteLine("Введите еще раз");
                    input = Console.ReadLine();
                }
                        
                Console.WriteLine("Введите номер поля");
                input = Console.ReadLine();
                Int32.TryParse(input, out int number);

                switch (temp)
                {
                    case 1:
                        Console.WriteLine(jumpmen[number]);
                        break;
                    case 2:
                        Console.WriteLine(swimmen[number]);
                        break;
                    case 3:
                        Console.WriteLine(runmen[number]);
                        break;
                }
            }

            Console.WriteLine("Над каким спортсменов вы хотите проводить действия? 1-прыжки, 2-плавание, 3-бег");
            input = Console.ReadLine();
            int choice;
            while (!Int32.TryParse(input, out choice) && choice < 1 && choice > 3)
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }
            switch (choice)
            {
                case 1:
                    jumpmen.CheckChanges();
                    jumpmen.DoAction();
                    ICheckDoping checkJumpmen = jumpmen;
                    checkJumpmen.Check();
                    break;
                case 2:
                    swimmen.CheckChanges();
                    swimmen.DoAction();
                    ICheckDoping checkSwimmen = swimmen;
                    checkSwimmen.Check();
                    break;
                case 3:
                    runmen.CheckChanges();
                    ICheckDoping checkRunmen = runmen;
                    checkRunmen.Check();
                    break;
            }

            List<Sportsmen> people = new List<Sportsmen>() { jumpmen, swimmen, runmen };

            people.Sort();

            Console.WriteLine("Сортировка спортсменов по возрасту:");

            foreach (Sportsmen i in people)
            {
                Console.WriteLine(i);
            }
        }
    }
}
