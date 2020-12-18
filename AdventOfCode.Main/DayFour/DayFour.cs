using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Main.DayFour
{
    public class DayFour
    {
        private int ValidCount = 0;
        private List<string> EyeColours = new List<string>
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        public IEnumerable<string> ReadFile(string fileLocation)
        {
            var text = File.ReadAllText(fileLocation);

            var firstPass = text.Split(new string[] { "\n\n" },
                               StringSplitOptions.RemoveEmptyEntries);

            var passports = new List<string>();

            foreach (var pass in firstPass)
            {
                var value = pass.Replace("\n", " ");
                passports.Add(value);
            }

            return passports.ToList();
        }

        public IEnumerable<string> ReadExampleFile(string fileLocation)
        {
            var text = File.ReadAllText(fileLocation);

            var firstPass = text.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);

            var passports = new List<string>();

            foreach (var pass in firstPass)
            {
                var value = pass.Replace("\r\n", " ");
                passports.Add(value);
            }

            return passports.ToList();
        }

        public Tuple<int, List<bool>> Solve(IEnumerable<string> correctPassports)
        {
            var keyValuePairs = new Dictionary<string, string>();

            var listOfBool = new List<bool>();

            foreach (var passport in correctPassports)
            {
                var bits = passport.Split(' ');

                bits = bits.Except(new List<string> { string.Empty }).ToArray();

                keyValuePairs = bits.Select(value => value.Split(':')).ToDictionary(pair => pair[0], pair => pair[1]);

                if (keyValuePairs.ContainsKey("ecl") && keyValuePairs.ContainsKey("pid") &&
                    keyValuePairs.ContainsKey("eyr") && keyValuePairs.ContainsKey("hcl") &&
                    keyValuePairs.ContainsKey("byr") && keyValuePairs.ContainsKey("iyr") &&
                    keyValuePairs.ContainsKey("hgt"))
                {

                    var isValid = ValidateMembers(keyValuePairs);

                    listOfBool.Add(isValid);
                }
            }

            return new Tuple<int, List<bool>>(ValidCount, listOfBool);
        }

        private bool ValidateMembers(Dictionary<string, string> keyValuePairs)
        {
            keyValuePairs.TryGetValue("byr", out var birthYear);
            keyValuePairs.TryGetValue("iyr", out var issueYear);
            keyValuePairs.TryGetValue("eyr", out var expirationYear);
            keyValuePairs.TryGetValue("hgt", out var height);
            keyValuePairs.TryGetValue("hcl", out var hairColour);
            keyValuePairs.TryGetValue("ecl", out var eyeColour);
            keyValuePairs.TryGetValue("pid", out var passportId);

            var birthYearValid = ValidateYears(birthYear, 1920, 2002);
            var issueYearValid = ValidateYears(issueYear, 2010, 2020);
            var expirationYearValid = ValidateYears(expirationYear, 2020, 2030);
            var heightValid = ValidateHeight(height);
            var hairColourValid = ValidateRegex(hairColour, "(#[0-9a-f]{6})");
            var eyeColourValid = ValidateEyeColour(eyeColour);
            var passportIdValid = ValidateRegex(passportId, "([0-9]{9})");

            var list = new List<bool>
            {
                birthYearValid,
                issueYearValid,
                expirationYearValid,
                heightValid,
                hairColourValid,
                eyeColourValid,
                passportIdValid
            };

            if (!list.Contains(false))
            {
                ValidCount++;
                return true;
            }

            return false;
        }

        private bool ValidateEyeColour(string eyeColour)
        {
            if (EyeColours.Contains(eyeColour))
            {
                return true;
            }

            return false;
        }

        private bool ValidateRegex(string input, string regex)
        {
            var re = new Regex($@"{regex}");
            var result = re.Match(input);

            if (result.Success)
            {
                return true;
            }

            return false;
        }

        private bool ValidateHeight(string height)
        {
            var re = new Regex(@"(\d+)([a-zA-Z]{2})");
            var result = re.Match(height);

            if (result.Success)
            {
                var alphaPart = result.Groups[2].Value;
                var numberPart = result.Groups[1].Value;
                var didConvert = int.TryParse(numberPart, out var number);

                if (didConvert)
                {
                    if (alphaPart == "cm")
                    {
                        if (number >= 150 && number <= 193)
                        {
                            return true;
                        }
                    }

                    if (alphaPart == "in")
                    {
                        if (number >= 59 && number <= 76)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool ValidateYears(string year, int min, int max)
        {
            if (year.Count() == 4)
            {
                var wasSuccessful = int.TryParse(year, out int yearInt);

                if (wasSuccessful)
                {
                    if (yearInt >= min && yearInt <= max)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
