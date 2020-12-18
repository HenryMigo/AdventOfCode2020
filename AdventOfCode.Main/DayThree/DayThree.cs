using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Main.DayThree
{
    public class DayThree
    {
        public IEnumerable<string> ReadFile(string fileLocation)
        {
            var text = File.ReadAllLines(fileLocation);

            return text.ToList();
        }

        public int Solve(IEnumerable<string> input, int posX, int posY)
        {
            var treesHit = 0;
            var map = ConstructMap(input);

            var x = 0;
            var y = 0;

            while (y < 323)
            {
                var chatAt = map[y, x];

                if (chatAt == '#')
                {
                    treesHit++;
                }

                x = (x + posX) % 31;
                y += posY;
            }

            return treesHit;
        }

        private static char[,] ConstructMap(IEnumerable<string> input)
        {
            var map = new char[323, 31];

            var inputList = input.ToList();

            for (int i = 0; i < 323; i++)
            {
                var line = inputList[i];
                var chars = line.ToCharArray();

                for (var j = 0; j < chars.Length; j++)
                {
                    var value = chars[j];
                    map[i, j] = value;
                }
            }

            return map;
        }
    }
}
