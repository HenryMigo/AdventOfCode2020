using AdventOfCode.Main.DayFive;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCodeUnitTests
{
    public class DayFive_UnitTests
    {
        private const string fileLocation = "D:\\adventOfCode\\2020\\dayfive.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            // B = 1
            // F = 0
            // R = 1
            // L = 0
            var example = new List<string>
            {
                "FBFBBFFRLR"
            };

            var dayFive = new DayFive();

            // Act
            var result = dayFive.Solve(example);

            // Assert
            result.Item1.Should().Be(357);
        }

        [Fact]
        public void Test2_WithInput_Part1()
        {
            var dayFive = new DayFive();
            var inputs = dayFive.ReadFile(fileLocation);

            // Act
            var result = dayFive.Solve(inputs);

            // Assert
            result.Item1.Should().Be(953);
        }

        [Fact]
        public void Test3_WithInput_Part2()
        {
            var dayFive = new DayFive();
            var inputs = dayFive.ReadFile(fileLocation);

            // Act
            var result = dayFive.Solve(inputs);

            // Assert
            result.Item2.Should().Be(615);
        }
    }
}
