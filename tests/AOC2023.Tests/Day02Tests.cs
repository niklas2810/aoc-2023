﻿using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
    [TestClass]
    public class Day02Tests
    {
        private readonly Day02 _day;

        public Day02Tests()
        {
            _day = new Day02();
        }

        [TestMethod]
        public void TestFileExample()
        {
            // Arrange
            var filename = "example.txt";
            Assert.IsTrue(File.Exists(_day.GenerateFilePath(filename)), "File path should exist");

            // Act
            var result = _day.GenerateInput(filename);

            // Assert
            Assert.AreEqual(5, result.Count(), "5 games should be read");
        }

        [TestMethod]
        public void TestFileInput()
        {
            // Arrange
            var filename = "input.txt";
            Assert.IsTrue(File.Exists(_day.GenerateFilePath(filename)), "File path should exist");

            // Act
            var result = _day.GenerateInput(filename);

            // Assert
            Assert.AreEqual(100, result.Count(), "100 games should be read");
        }

        [TestMethod]
        public async Task TestSolvePartOneExample()
        {
            var result = await _day.SolvePartOne(_day.GenerateInput("example.txt"));
            Assert.AreEqual(8, result, "SolvePartOne should return 8");
        }

        [TestMethod]
        public async Task TestSolvePartTwoExample()
        {
            var result = await _day.SolvePartTwo(_day.GenerateInput("example.txt"));
            Assert.AreEqual(2286, result, "SolvePartTwo should return 2286");
        }

        [TestMethod]
        public async Task TestSolvePartOneActual()
        {
            var result = await _day.SolvePartOne(_day.GenerateInput());
            Assert.AreEqual(2239, result, "SolvePartOne should return 2239");
        }

        [TestMethod]
        public async Task TestSolvePartTwoActual()
        {
            var result = await _day.SolvePartTwo(_day.GenerateInput());
            Assert.AreEqual(83435, result, "SolvePartTwo should return 83435");
        }
    }
}
