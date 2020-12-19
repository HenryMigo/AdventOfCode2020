using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Main.DayFive
{
    public class DayFive
    {
        public IEnumerable<string> ReadFile(string fileLocation)
        {
            return File.ReadAllLines(fileLocation);
        }

        public Tuple<double, double?> Solve(IEnumerable<string> example)
        {
            var rowCol = new List<double>();

            foreach (var exam in example)
            {
                double row = 0;
                double col = 0;

                for (var i = 0; i < 7; i++)
                {
                    if (exam[i] == 'B')
                    {
                        row += Math.Pow(2, 6 - i);
                    }
                }

                for (var i = 7; i < 10; i++)
                {
                    if (exam[i] == 'R')
                    {
                        col += Math.Pow(2, 9 - i);
                    }
                }

                var rowId = (row * 8) + col;

                rowCol.Add(rowId);
            }

            rowCol = rowCol.OrderBy(x => x).ToList();

            var maxModel = rowCol.Select(x => x).Last();
            double? lastId = -1;

            foreach(double? item in rowCol)
            {
                if (lastId != -1 && item - lastId == 2)
                {
                    return Tuple.Create(maxModel, item);
                }

                lastId = item;
            }

            return Tuple.Create(maxModel, (double?)null);
        }
    }
}
