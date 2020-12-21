using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Main.DaySix
{
    public class DaySix
    {
        public DaySixGroupsModel ReadFile(string fileLocation)
        {
            var text = File.ReadAllText(fileLocation);

            var firstPass = text.Split(new string[] { "\n\n" },
                               StringSplitOptions.RemoveEmptyEntries);

            var groups = new DaySixGroupsModel();

            foreach (var pass in firstPass)
            {
                var value = pass.Split('\n');
                var daySixAnswers = new DaySixAnswersModel();
                daySixAnswers.Answers.AddRange(value);

                groups.Groups.Add(daySixAnswers);
            }

            return groups;
        }

        public int SolvePartOne(DaySixGroupsModel groups)
        {
            var result = 0;

            for (var i = 0; i < groups.Groups.Count(); i++)
            {
                var group = groups.Groups[i];
                var hashSet = new HashSet<char>();

                for (var j = 0; j < group.Answers.Count(); j++)
                {
                    var personsAnswers = group.Answers[j];

                    for (var k = 0; k < personsAnswers.Length; k++)
                    {
                        hashSet.Add(personsAnswers[k]);
                    }
                }

                result += hashSet.Count;
            }

            return result;
        }

        public int SolvePartTwo(DaySixGroupsModel groups)
        {
            var result = 0;
            var first = true;

            for (var i = 0; i < groups.Groups.Count(); i++)
            {
                var group = groups.Groups[i];
                var hashSet = new HashSet<char>();
                first = true;

                for (var j = 0; j < group.Answers.Count(); j++)
                {
                    var personsAnswers = group.Answers[j];
                    if (first)
                    {
                        for (var k = 0; k < personsAnswers.Length; k++)
                        {

                            hashSet.Add(personsAnswers[k]);
                        }
                    }
                    else
                    {
                        for (var k = hashSet.Count() - 1; k >= 0; k--)
                        {
                            var value = hashSet.ElementAt(k);
                            var contains = false;

                            foreach (var value2 in personsAnswers)
                            {
                                if (value == value2)
                                {
                                    contains = true;
                                    break;
                                }
                            }

                            if (!contains)
                            {
                                hashSet.Remove(value);
                            }
                        }
                    }

                    first = false;
                }

                result += hashSet.Count;
            }

            return result;
        }
    }

    public class DaySixGroupsModel
    {
        public DaySixGroupsModel()
        {
            Groups = new List<DaySixAnswersModel>();
        }

        public List<DaySixAnswersModel> Groups { get; set; }
    }

    public class DaySixAnswersModel
    {
        public DaySixAnswersModel()
        {
            Answers = new List<string>();
        }

        public List<string> Answers { get; set; }
    }
}
