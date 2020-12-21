using AdventOfCode.Main.DaySix;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeUnitTests
{
    public class DaySix_UnitTests
    {
        private const string fileLocation = "D:\\adventOfCode\\2020\\inputs\\daysix.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var daySix = new DaySix();
            var groups = daySix.ReadFile(fileLocation);

            // Act
            var result = daySix.SolvePartOne(groups);

            // Assert
            result.Should().Be(6506);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var daySix = new DaySix();
            var groups = daySix.ReadFile(fileLocation);

            // Act
            var result = daySix.SolvePartTwo(groups);

            // Assert
            result.Should().NotBe(3243);
        }
    }
}
