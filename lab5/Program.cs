using System;

namespace lab5
{
    enum Actions
    {
        Exercizes = 1,
        Recomendations,
        MassCounter,
        ShowRecords
    }
    abstract class Sportsmen
    {
        private string _gender;
        private int _age;
        private int _height;
        private int _weight;
        protected string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                while (value != "male" && value != "female")
                {
                    Console.WriteLine("Введите пол еще раз");
                    value = Console.ReadLine();
                }
                _gender = value;
            }

        }
        protected string Name { get; set; }
        protected string Surname { get; set; }
        protected int Age
        {
            get
            {
                return _age;
            }
            set
            {
                while (value > 99 || value < 18)
                {
                    Console.WriteLine("Вы ввели некорректное число. Пожалуйста, введите возраст еще раз.");
                    string input = Console.ReadLine();
                    Int32.TryParse(input, out value);
                }
                _age = value;
            }

        }
        protected int Height
        {
            get
            {
                return _height;
            }
            set
            {
                while (value > 250 || value < 130)
                {
                    Console.WriteLine("Вы ввели некорректное число. Пожалуйста, введите рост еще раз.");
                    string input = Console.ReadLine();
                    Int32.TryParse(input, out value);
                }
                _height = value;
            }
        }
        protected int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                while (value > 250 || value < 40)
                {
                    Console.WriteLine("Вы ввели некорректное число. Пожалуйста, введите вес еще раз.");
                    string input = Console.ReadLine();
                    Int32.TryParse(input, out value);
                }
                _weight = value;
            }
        }

        protected int Id = CreateId();
        protected static int CreateId()
        {
            Random rand = new Random();

            int Id = rand.Next(99999, 999999);
            return Id;
        }

        abstract public void DoAction();

        public void ShowInfo()
        {
            Console.WriteLine($"1.Гендер: {Gender}");
            Console.WriteLine($"2.Имя: {Name}");
            Console.WriteLine($"3.Фамилия: {Surname}");
            Console.WriteLine($"4.Возраст: {Age}");
            Console.WriteLine($"5.Рост: {Height}");
            Console.WriteLine($"6.Вес: {Weight}");
            Console.WriteLine($"7.Вам присвоен ID: {Id}");
        }

        public void CheckChanges()
        {
            Console.WriteLine("Желаете изменить информацию?");
            string input = Console.ReadLine();

            while (input != "yes" && input != "no")
            {
                Console.WriteLine("Некорректный ввод. Введите еще раз.");
                input = Console.ReadLine();
            }

            if (input == "yes")
            {
                Console.WriteLine("Введите гендер: ");
                Gender = Console.ReadLine();

                Console.WriteLine("Введите имя: ");
                Name = Console.ReadLine();

                Console.WriteLine("Введите фамилию: ");
                Surname = Console.ReadLine();

                Console.WriteLine("Введите возраст: ");
                input = Console.ReadLine();
                int age;
                while (!Int32.TryParse(input, out age))
                {
                    Console.WriteLine("Введите еще раз");
                    input = Console.ReadLine();
                }
                Age = age;

                Console.WriteLine("Введите рост: ");
                input = Console.ReadLine();
                int height;
                while (!Int32.TryParse(input, out height))
                {
                    Console.WriteLine("Введите еще раз");
                    input = Console.ReadLine();
                }
                Height = height;

                Console.WriteLine("Введите вес: ");
                input = Console.ReadLine();
                int weight;
                while (!Int32.TryParse(input, out weight))
                {
                    Console.WriteLine("Введите еще раз");
                    input = Console.ReadLine();
                }
                Weight = weight;

                ShowInfo();
            }
        }

        public string this[int number]
        {
            get
            {
                switch (number)
                {
                    case 1: return Gender;
                    case 2: return Name;
                    case 3: return Surname;
                    case 4: return Convert.ToString(Age);
                    case 5: return Convert.ToString(Height);
                    case 6: return Convert.ToString(Weight);
                    case 7: return Convert.ToString(Id);
                    default: return "Нет такого поля";
                }
            }
        }

        public int ChooseAction()
        {
            Console.WriteLine("Выберите действие. 1-просмотр упражнений, 2- просмотр рекомендаций, 3-расчет индекса массы, 4-рекорды ващего спорта");
            string input = Console.ReadLine();
            int choice;
            while (!Int32.TryParse(input, out choice) && choice < 1 && choice > 4)
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            return choice;
        }

        public void Recomendation()
        {
            Console.WriteLine("Вы соблюдаете оптимальный режим тренировок.");
        }

        public void Recomendation(int hours)
        {
            Console.WriteLine("Вам стоит пересмотреть режим тренировок.");

            if (hours < 5)
            {
                Console.WriteLine("Вам стоит заниматься больше.");
            }
            else
            {
                Console.WriteLine("Вам стоит уменьшить нагрузку.");
            }
        }

        virtual public void MassCounter()
        {
            int massIndex = (Weight * 10000) / (Height * Height);
            Console.WriteLine(massIndex);
            Console.WriteLine($"Индекс массы тела :{massIndex}");

            if (massIndex < 19)
            {
                Console.WriteLine("Индекс массы тела слишком мал. Вам стоит уделить внимание питанию.");
            }
        }
    };

    class Jumping : Sportsmen
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
    class Swimming : Sportsmen
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
    class Running : Sportsmen
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

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите гендер: ");
            string gender = Console.ReadLine();

            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите возраст: ");
            string input = Console.ReadLine();
            int age;
            while (!Int32.TryParse(input, out age))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите рост: ");
            input = Console.ReadLine();
            int height;
            while (!Int32.TryParse(input, out height))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите вес: ");
            input = Console.ReadLine();
            int weight;
            while (!Int32.TryParse(input, out weight))
            {
                Console.WriteLine("Введите еще раз");
                input = Console.ReadLine();
            }

            Console.WriteLine("Введите вид спорта: 1-прыжки, 2-плавание, 3-бег");
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
                    Sportsmen jumpmen = new Jumping(gender, name, surname, age, height, weight);
                    jumpmen.ShowInfo();
                    jumpmen.CheckChanges();
                    jumpmen.DoAction();

                    Console.WriteLine("Желаете получить информацию одного из полей?");
                    input = Console.ReadLine();
                    while (input != "yes" && input != "no")
                    {
                        Console.WriteLine("Некорректный ввод. Введите еще раз.");
                        input = Console.ReadLine();
                    }

                    if (input == "yes")
                    {
                        Console.WriteLine("Введите номер поля");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out int number);
                        Console.WriteLine(jumpmen[number]);
                    }
                    break;
                case 2:
                    Sportsmen swimmen = new Swimming(gender, name, surname, age, height, weight);
                    swimmen.ShowInfo();
                    swimmen.CheckChanges();
                    swimmen.DoAction();

                    Console.WriteLine("Желаете получить информацию одного из полей?");
                    input = Console.ReadLine();
                    while (input != "yes" && input != "no")
                    {
                        Console.WriteLine("Некорректный ввод. Введите еще раз.");
                        input = Console.ReadLine();
                    }

                    if (input == "yes")
                    {
                        Console.WriteLine("Введите номер поля");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out int number);
                        Console.WriteLine(swimmen[number]);
                    }
                    break;
                case 3:
                    Sportsmen runmen = new Running(gender, name, surname, age, height, weight);
                    runmen.ShowInfo();
                    runmen.CheckChanges();
                    runmen.DoAction();

                    Console.WriteLine("Желаете получить информацию одного из полей?");
                    input = Console.ReadLine();
                    while (input != "yes" && input != "no")
                    {
                        Console.WriteLine("Некорректный ввод. Введите еще раз.");
                        input = Console.ReadLine();
                    }

                    if (input == "yes")
                    {
                        Console.WriteLine("Введите номер поля");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out int number);
                        Console.WriteLine(runmen[number]);
                    }
                    break;
            }
        }
    }
}
