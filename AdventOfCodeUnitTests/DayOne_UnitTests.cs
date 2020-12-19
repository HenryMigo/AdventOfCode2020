using AdventOfCode.Main.DayOne;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeUnitTests
{
    public class DayOne_UnitTests
    {
        private const string fileLocation = "D:\\adventOfCode\\2020\\inputs\\dayone.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var dayOne = new DayOne();
            var numbers = dayOne.ReadFile(fileLocation);

            // Act
            var result = dayOne.Calculate2020Two(numbers);

            // Assert
            result.Should().BeOfType(typeof(int));
            result.Should().NotBe(0);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var dayOne = new DayOne();
            var numbers = dayOne.ReadFile(fileLocation);

            // Act
            var result = dayOne.Calculate2020Three(numbers);

            // Assert
            result.Should().BeOfType(typeof(int));
            result.Should().NotBe(0);
        }
    }
}
