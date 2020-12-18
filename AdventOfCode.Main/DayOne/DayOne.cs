using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Main.DayOne
{
    public class DayOne
    {
        public IEnumerable<int> ReadFile(string fileLocation)
        {
            var text = File.ReadAllLines(fileLocation);
            var numbers = new List<int>();

            foreach (var number in text)
            {
                numbers.Add(int.Parse(number));
            }

            return numbers;
        }

        // TODO: This wont return void and will take in a model.
        public int Calculate2020Two(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                foreach (var num in numbers)
                {
                    if (number != num && number + num == 2020)
                    {
                        return number * num;
                    }
                }
            }

            return 0;
        }

        public int Calculate2020Three(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                foreach (var num in numbers)
                {
                    foreach (var n in numbers)
                    {
                        if (number != num && num != n && n != number && number + num + n == 2020)
                        {
                            return number * num * n;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
