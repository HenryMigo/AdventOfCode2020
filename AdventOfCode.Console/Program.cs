using AdventOfCode.Main.DayFour;
using System;

namespace AdventOfCode.ConsoleApp
{
    class Program
    {
        private const string fileLocation = "D:\\adventOfCode\\2020\\dayfour.txt";

        static void Main(string[] args)
        {
            var dayFour = new DayFour();
            var passports = dayFour.ReadFile(fileLocation);

            var result = dayFour.Solve(passports);

            foreach(var isPassportValid in result.Item2)
            {
                Console.WriteLine(isPassportValid);
            }

            Console.ReadLine();
        }
    }
}
