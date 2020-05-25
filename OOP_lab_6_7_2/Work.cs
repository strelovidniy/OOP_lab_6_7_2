using System;
using System.IO;

namespace OOP_lab_6_7_2
{
    class Work : IWork
    {
        public void Add()
        {
            StreamWriter file = new StreamWriter("base.txt", true);

            Console.WriteLine("\nВведiть новi данi");

            Console.Write("Прiзище: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Фах: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("День: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Змiна: ");

            file.WriteLine(Console.ReadLine());

            Retry:
            Console.Write("Кiлькiсть вiдвiдувачiв: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");
                
                goto Retry;
            }

            file.Close();

            Input.ReadBase();
        }

        public void Remove()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для видалення: ");

            bool[] remove = new bool[Program.doctors.Length];

            for (int i = 0; i < remove.Length; ++i)
            {
                remove[i] = false;
            }

            try
            {
                remove[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (!remove[i])
                {
                    file.WriteLine(Program.doctors[i].Surename);
                    file.WriteLine(Program.doctors[i].Profession);
                    file.WriteLine(Program.doctors[i].Day);
                    file.WriteLine(Program.doctors[i].Shift);
                    file.WriteLine(Program.doctors[i].VisitorsCount);
                }
            }

            Console.Write("Видалено.\n");

            file.Close();

            Input.ReadBase();
        }

        public void Edit()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для редагування: ");

            bool[] edit = new bool[Program.doctors.Length];

            for (int i = 0; i < edit.Length; ++i)
            {
                edit[i] = false;
            }

            try
            {
                edit[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (edit[i])
                {
                    Console.WriteLine("Введiть новi данi");

                    Console.Write("Прiзище: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Фах: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("День: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Змiна: ");

                    file.WriteLine(Console.ReadLine());

                Retry:
                    Console.Write("Кiлькiсть вiдвiдувачiв: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");

                        goto Retry;
                    }
                }
                else
                {
                    file.WriteLine(Program.doctors[i].Surename);
                    file.WriteLine(Program.doctors[i].Profession);
                    file.WriteLine(Program.doctors[i].Day);
                    file.WriteLine(Program.doctors[i].Shift);
                    file.WriteLine(Program.doctors[i].VisitorsCount);
                }
            }

            Console.Write("Змiни внесено.\n");

            file.Close();

            Input.ReadBase();
        }

        public void InitialiseBase(int n)
        {
            Program.doctors = new Reception[n];
        }

        public void Sum()
        {
            int sum = 0;

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                sum += Program.doctors[i].VisitorsCount;
            }

            Console.WriteLine("\nЗагальна кiлькiсть вiдвiдувачiв: {0}.", sum);
        }

        public void Minimum()
        {
            int minIndex = 0;

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (Program.doctors[minIndex].VisitorsCount >= Program.doctors[i].VisitorsCount)
                {
                    minIndex = i;
                }
            }

            Console.WriteLine("Загальна кiлькiсть вiдвiдувачiв:");
            Console.WriteLine(Output.Format, "Прiзище", "Фах", "День", "Змiна", "Кiлькiсть вiдвiдувачiв");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (Program.doctors[minIndex].VisitorsCount == Program.doctors[i].VisitorsCount)
                {
                    Console.WriteLine(Output.Format, Program.doctors[i].Surename, Program.doctors[i].Profession, Program.doctors[i].Day, Program.doctors[i].Shift, Program.doctors[i].VisitorsCount);
                }
            }
        }

        public void Length()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для визначення довжини прiзвища лiкаря: ");

            Console.WriteLine(new Doctor().Length(int.Parse(Console.ReadLine())));
        }
    }
}
