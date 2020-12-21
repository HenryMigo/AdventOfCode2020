using AdventOfCode.Main.DaySeven;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeUnitTests
{
    public class DaySeven_UnitTests
    {
        private const string fileLocation = "D:\\adventOfCode\\2020\\inputs\\dayseven.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var daySeven = new DaySeven(fileLocation);

            // Act
            var result = daySeven.Solve1();

            // Assert
            result.Should().BeGreaterThan(0).And.Be(151);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var daySeven = new DaySeven(fileLocation);

            // Act
            var result = daySeven.Solve2();

            // Assert
            result.Should().BeGreaterThan(0).And.Be(41559);
        }
    }
}
