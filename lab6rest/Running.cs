﻿using System;

namespace lab6
{
    class Running : Sportsmen, ICheckDoping
    {
        public Running(string Gender, string Name, string Surname, int Age, int Height, int Weight)
        {
            this.Gender = Gender;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Height = Height;
            this.Weight = Weight;
        }

        public void Check()
        {
            Random luck = new Random();
            int doping = luck.Next(-1, 1);

            if (doping == 1)
                Console.WriteLine("У вас нашли допинг!Вы исключены из ближайшего сорвнования");
            else
                Console.WriteLine("У вас не нашли допинг! Поздравляем!");
        }

        public override void MassCounter()
        {
            base.MassCounter();
            Console.WriteLine("Для увеличения дальности прыжка вам стоит сохранять ИМТ не более 32");
        }

        override
            public void DoAction()
        {
            int choice = ChooseAction();

            switch (choice)
            {
                case (int)Actions.Exercizes:
                    Console.WriteLine("Развитие физических качеств: выносливости, силы и быстроты.");
                    break;
                case (int)Actions.Recomendations:
                    AskHours();
                    break;
                case (int)Actions.MassCounter:
                    MassCounter();
                    break;
                case (int)Actions.ShowRecords:
                    Console.WriteLine("100 м	9,58 с	 Усэйн Болт");
                    Console.WriteLine("200 м	19,19 с	 Усэйн Болт");
                    Console.WriteLine("400 м	43,03 с	 Вайде ван Никерк");
                    Console.WriteLine("800 м	1.40,91 с	 Дэвид Рудиша");
                    break;
            }
        }

        public void AskHours()
        {
            Console.WriteLine("Сколько часов Вы занимаетесь в день?");
            string input = Console.ReadLine();
            int hours;
            while (!Int32.TryParse(input, out hours) && hours < 0 && hours > 18)
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            if (hours > 4 && hours < 6)
            {
                Recomendation();
            }
            else
            {
                Recomendation(hours);
            }
        }
    }
}
