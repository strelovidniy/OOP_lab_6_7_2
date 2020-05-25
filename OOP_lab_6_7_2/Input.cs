using System;
using System.IO;

namespace OOP_lab_6_7_2
{
    class Input
    {
        private static Work _work = new Work();

        public static void Read()
        {
            ReadBase();
            ReadKey();
        }

        public static void ReadBase()
        {
            StreamReader file = new StreamReader("base.txt");

            string[] tempStr = file.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            _work.InitialiseBase(tempStr.Length / 5);

            for (int i = 0; i < tempStr.Length; i += 5)
            {
                Program.doctors[i / 5] = new Reception(tempStr[i], tempStr[i + 1], tempStr[i + 2], tempStr[i + 3], int.Parse(tempStr[i + 4]));
            }

            file.Close();
        }

        private static void ReadKey()
        {
            
        Start:

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Загальна кiлькiсть вiдвiдувачiв: A");
            Console.WriteLine("Прийом з мiнiмальною кiлькiстю вiдвiдувачiв: M");
            Console.WriteLine("Довжина прiзвища: L");
            Console.WriteLine("Вихiд: Esc");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.OemPlus:
                    _work.Add();
                    goto Start;

                case ConsoleKey.E:
                    _work.Edit();
                    goto Start;

                case ConsoleKey.A:
                    _work.Sum();
                    goto Start;

                case ConsoleKey.M:
                    _work.Minimum();
                    goto Start;

                case ConsoleKey.L:
                    _work.Length();
                    goto Start;

                case ConsoleKey.OemMinus:
                    _work.Remove();
                    goto Start;

                case ConsoleKey.Enter:
                    Output.Write();
                    goto Start;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine();
                    goto Start;
            }
        }
    }
}
