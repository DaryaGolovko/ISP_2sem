using System;

namespace Sport
{
    class Swimming : Sportsmen, ICheckDoping
    {
        public Swimming(string Gender, string Name, string Surname, int Age, int Height, int Weight)
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
                Console.WriteLine("Выбран пловец");
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
            Console.WriteLine("Для увеличения дальности прыжка вам стоит сохранять ИМТ не более 30");
        }

        override public void DoAction()
        {
            int choice = ChooseAction();

            switch (choice)
            {
                case (int)Actions.Exercizes:
                    Console.WriteLine("Развитие физических качеств: выносливости, силы гребка, скорости плавания");
                    break;
                case (int)Actions.Recomendations:
                    AskHours();
                    break;
                case (int)Actions.MassCounter:
                    MassCounter();
                    break;
                case (int)Actions.ShowRecords:
                    Console.WriteLine("50м вольный 20,91 Сезар Сьелу");
                    Console.WriteLine("50м на спине 24,00 Климент Колесников");
                    Console.WriteLine("50м брасс 25,95 Адам Пити");
                    Console.WriteLine("50м баттерфляй 22,27 Андрей Говоров");
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
