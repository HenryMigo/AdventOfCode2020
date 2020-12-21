using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Main.DaySeven
{
    public class DaySeven
    {
        Dictionary<string, Dictionary<string, int>> bags = new Dictionary<string, Dictionary<string, int>>();

        public DaySeven(string fileLocation)
        {
            foreach(var line in File.ReadLines(fileLocation))
            {
                var matches = Regex.Match(line, @"(\w+ \w+) bags contain (.+)");
                var colour = matches.Groups[1].Value;
                var contents = new Dictionary<string, int>();

                foreach(var content in matches.Groups[2].Value.Split(','))
                {
                    if (content.StartsWith("no")) continue;

                    var contentMatch = Regex.Match(content, @"(\d+) (\w+ \w+)");
                    contents.Add(contentMatch.Groups[2].Value, int.Parse(contentMatch.Groups[1].Value));
                }

                bags.Add(colour, contents);
            }
        }

        public int Solve1()
        {
            return bags.Count(x => CanContainGold(x.Key));
        }

        public long Solve2()
        {
            return BagCount("shiny gold");
        }

        public long BagCount(string colour)
        {
            var bag = bags[colour];
            long runningCount = 0;

            if (bag.Any(x => x.Key.StartsWith("no")))
            {
                return runningCount;
            }

            foreach(var content in bag)
            {
                runningCount += content.Value;
                for (var i = 0; i < content.Value; i++)
                {
                    runningCount += BagCount(content.Key);
                }
            }

            return runningCount;
        }

        public bool CanContainGold(string colour)
        {
            var bag = bags[colour];

            if (bag.Any(x => x.Key == "shiny gold"))
            {
                return true;
            }

            if (bag.Any(x => x.Key.StartsWith("no")))
            {
                return false;
            }

            foreach (var content in bag)
            {
                if (CanContainGold(content.Key))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class DaySevenModel
    {
        public string Bag { get; set; }

        public int Amount { get; set; }

        public List<DaySevenModel> BagsCanHold { get; set; }
    }
}
