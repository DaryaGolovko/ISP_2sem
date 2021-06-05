using System;

namespace Sport
{
    class Jumping : Sportsmen, ICheckDoping
    {
        public Jumping(string Gender, string Name, string Surname, int Age, int Height, int Weight)
        {
            this.Gender = Gender;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Height = Height;
            this.Weight = Weight;
        }


        public delegate void Output();
        public event Output Notify;

        public void Action()
        {
            Notify += delegate ()
            {
                Console.WriteLine("Выбран прыгун");
            };
            Notify += () => CheckChanges();
            Notify += () => DoAction();
            Notify();
        }

        public void Check()
        {
            Random luck = new Random();
            int doping = luck.Next(-1, 1);

            try
            {
                if (doping == 0)
                    throw new Exception();
                else
                    Console.WriteLine("У вас не нашли допинг! Поздравляем!");
            }
            catch
            {
                Console.WriteLine("У вас нашли допинг!Вы исключены из ближайшего сорвнования");
            }
        }
        public override void MassCounter()
        {
            base.MassCounter();
            Console.WriteLine("Для увеличения дальности прыжка вам стоит сохранять ИМТ не более 27");
        }

        override public void DoAction()
        {
            int choice = ChooseAction();

            switch (choice)
            {
                case (int)Actions.Exercizes:
                    Console.WriteLine("Развитие физических качеств: выносливости, силовых и координационных возможностей.");
                    break;
                case (int)Actions.Recomendations:
                    AskHours();
                    break;
                case (int)Actions.MassCounter:
                    MassCounter();
                    break;
                case (int)Actions.ShowRecords:
                    Console.WriteLine("Майк Пауэлл, 8.95m");
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
