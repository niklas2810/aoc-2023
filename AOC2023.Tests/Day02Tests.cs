using AOC2023.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    [TestClass]
    public class Day02Tests
    {
        private readonly Day02 _day02;

        public Day02Tests()
        {
            _day02 = new Day02();
        }

        [TestMethod]
        public void TestFileExample()
        {
            // Arrange
            var filePath = @"Inputs\02\example.txt";
            Assert.IsTrue(File.Exists(filePath), "File path should exist");

            // Act
            var result = _day02.GenerateInput(filePath);

            // Assert
            Assert.AreEqual(5, result.Count(), "5 games should be read");
        }

        [TestMethod]
        public void TestFileInput()
        {
            // Arrange
            var filePath = @"Inputs\02\input.txt";
            Assert.IsTrue(File.Exists(filePath), "File path should exist");

            // Act
            var result = _day02.GenerateInput(filePath);

            // Assert
            Assert.AreEqual(100, result.Count(), "100 games should be read");
        }

        [TestMethod]
        public void TestSolvePartOneExample()
        {
            var games = _day02.GenerateInput(@"Inputs\02\example.txt");
            var result = _day02.SolvePartOne(games);
            Assert.AreEqual(8, result, "SolvePartOne should return 8");
        }

        [TestMethod]
        public void TestSolvePartTwoExample()
        {
            var games = _day02.GenerateInput(@"Inputs\02\example.txt");
            var result = _day02.SolvePartTwo(games);
            Assert.AreEqual(2286, result, "SolvePartTwo should return 2286");
        }

        [TestMethod]
        public void TestSolvePartOneActual()
        {
            var games = _day02.GenerateInput();
            var result = _day02.SolvePartOne(games);
            Assert.AreEqual(2239, result, "SolvePartOne should return 2239");
        }

        [TestMethod]
        public void TestSolvePartTwoActual()
        {
            var games = _day02.GenerateInput();
            var result = _day02.SolvePartTwo(games);
            Assert.AreEqual(83435, result, "SolvePartTwo should return 83435");
        }
    }
}
