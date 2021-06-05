using System;

namespace Sport
{
    abstract class Sportsmen : IComparable<Sportsmen>
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

        public int CompareTo(Sportsmen human)
        {
            if (Age == human.Age)
            {
                return 0;
            }
            else if (Age < human.Age)
            {
                return -1;
            }
            else
            {
                return 1;
            }
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
}
