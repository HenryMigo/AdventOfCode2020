using AdventOfCode.Main.DayThree;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeUnitTests
{
    public class DayThree_UnitTests
    {
        private const string fileLocation = "D:\\adventOfCode\\2020\\daythree.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var dayThree = new DayThree();
            var lines = dayThree.ReadFile(fileLocation);

            // Act
            var result = dayThree.Solve(lines, 3, 1);

            // Assert
            result.Should().BeOfType(typeof(int));
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var dayThree = new DayThree();
            var lines = dayThree.ReadFile(fileLocation);

            // Act
            var result1 = dayThree.Solve(lines, 1, 1);
            var result2 = dayThree.Solve(lines, 3, 1);
            var result3 = dayThree.Solve(lines, 5, 1);
            var result4 = dayThree.Solve(lines, 7, 1);
            var result5 = dayThree.Solve(lines, 1, 2);

            long result = result1 * result2;
            result *= result3;
            result *= result4;
            result *= result5;

            // Assert
            result1.Should().BeOfType(typeof(int));
            result2.Should().BeOfType(typeof(int));
            result3.Should().BeOfType(typeof(int));
            result4.Should().BeOfType(typeof(int));
            result5.Should().BeOfType(typeof(int));
            result.Should().BeOfType(typeof(long));
        }
    }
}
