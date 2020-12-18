﻿using AdventOfCode.Main.DayFour;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeUnitTests
{
    public class DayFour_UnitTests
    {
        private const string fileLocation = "D:\\adventOfCode\\2020\\dayfour.txt";
        private const string fileLocationValidExample = "D:\\adventOfCode\\2020\\dayfourvalidexample.txt";
        private const string fileLocationInvalidExample = "D:\\adventOfCode\\2020\\dayfourinvalidexample.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var dayFour = new DayFour();
            var passports = dayFour.ReadFile(fileLocation);

            // Act
            var result = dayFour.Solve(passports);

            // Assert
            result.Should().BeOfType(typeof(int)).And.BeGreaterThan(0);
        }

        [Fact]
        public void Test2_AllValid()
        {
            // Arrange
            var dayFour = new DayFour();
            var passports = dayFour.ReadExampleFile(fileLocationValidExample);

            // Act
            var result = dayFour.Solve(passports);

            // Assert
            result.Should().BeOfType(typeof(int)).And.Be(4);
        }

        [Fact]
        public void Test3_AllInvalid()
        {
            // Arrange
            var dayFour = new DayFour();
            var passports = dayFour.ReadExampleFile(fileLocationInvalidExample);

            // Act
            var result = dayFour.Solve(passports);

            // Assert
            result.Should().BeOfType(typeof(int)).And.Be(0);
        }
    }
}