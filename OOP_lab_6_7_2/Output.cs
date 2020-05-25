using System;

namespace OOP_lab_6_7_2
{
    class Output
    {
        public const string Format = "{0, -20} {1, -25} {2, -10} {3, -10} {4, -25}";

        public static void Write()
        {
            Console.WriteLine(Format, "Прiзище", "Фах", "День", "Змiна", "Кiлькiсть вiдвiдувачiв");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                Console.WriteLine(Format, Program.doctors[i].Surename, Program.doctors[i].Profession, Program.doctors[i].Day, Program.doctors[i].Shift, Program.doctors[i].VisitorsCount);
            }
        }
    }
}
