using AdventOfCode.Main.DayTwo.DayTwo_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Main.DayTwo
{
    public class DayTwo
    {
        public IEnumerable<string> ReadFile(string fileLocation)
        {
            var text = File.ReadAllLines(fileLocation);

            return text.ToList();
        }

        public IEnumerable<DayTwoModel> ConvertToModel(IEnumerable<string> text)
        {
            var models = new List<DayTwoModel>();

            foreach (var line in text)
            {
                var noSpace = line.Split(' ');

                var minMax = noSpace[0];
                var minMaxArray = minMax.Split('-');
                var min = int.Parse(minMaxArray[0]);
                var max = int.Parse(minMaxArray[1]);

                var letter = noSpace[1];
                letter = letter.Replace(':', char.MinValue);

                var password = noSpace[2];

                models.Add(new DayTwoModel
                {
                    MinAmount = min,
                    MaxAmount = max,
                    Letter = Convert.ToChar(letter[0]),
                    Password = password
                });
            }

            return models;
        }

        public int DoTask(IEnumerable<DayTwoModel> models)
        {
            var validPasswords = 0;

            foreach(var model in models)
            {
                var count = 0;

                foreach(var letter in model.Password)
                {
                    if (letter == model.Letter)
                    {
                        count++;
                    }
                }

                if (model.MinAmount <= count && model.MaxAmount >= count)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        public int DoTaskPartTwo(IEnumerable<DayTwoModel> models)
        {
            var validPasswords = 0;

            foreach(var model in models)
            {
                var isValid = false;

                if (model.Password[model.MinAmount - 1] == model.Letter)
                {
                    isValid = true;
                }

                if(model.Password[model.MaxAmount - 1] == model.Letter)
                {
                    if (isValid)
                    {
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                    }
                }

                if(isValid)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }
    }
}
