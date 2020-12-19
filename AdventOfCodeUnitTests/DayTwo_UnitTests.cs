using AdventOfCode.Main.DayTwo;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeUnitTests
{
    public class DayTwo_UnitTests
    {
        private const string fileLocationExample = "D:\\adventOfCode\\2020\\inputs\\daytwoexample.txt";
        private const string fileLocation = "D:\\adventOfCode\\2020\\inputs\\daytwo.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var dayTwo = new DayTwo();
            var text = dayTwo.ReadFile(fileLocationExample);
            var models = dayTwo.ConvertToModel(text);

            // Act
            var result = dayTwo.DoTask(models);

            // Assert
            result.Should().BeOfType(typeof(int));
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var dayTwo = new DayTwo();
            var text = dayTwo.ReadFile(fileLocation);
            var models = dayTwo.ConvertToModel(text);

            // Act
            var result = dayTwo.DoTask(models);

            // Assert
            result.Should().BeOfType(typeof(int));
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var dayTwo = new DayTwo();
            var text = dayTwo.ReadFile(fileLocation);
            var models = dayTwo.ConvertToModel(text);

            // Act
            var result = dayTwo.DoTaskPartTwo(models);

            // Assert
            result.Should().BeOfType(typeof(int));
        }
    }
}
