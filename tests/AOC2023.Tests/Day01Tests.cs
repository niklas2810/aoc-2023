using AOC2023.Logic.Days;

namespace AOC2023.Tests
{

    [TestClass]
    public class Day01Tests
    {
        private readonly Day01 _day;

        public Day01Tests()
        {
            _day = new Day01();
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
            Assert.AreEqual(4, result.Count(), "4 lines should be read");
        }

        [TestMethod]
        public void TestFileExample2()
        {
            // Arrange
            var filename = "example2.txt";
            Assert.IsTrue(File.Exists(_day.GenerateFilePath(filename)), "File path should exist");

            // Act
            var result = _day.GenerateInput(filename);

            // Assert
            Assert.AreEqual(7, result.Count(), "7 lines should be read");
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
            Assert.AreEqual(1000, result.Count(), "1000 lines should be read");
        }

        [TestMethod]
        public async Task TestSolvePartOneExample()
        {
            var result = await _day.SolvePartOne(_day.GenerateInput("example.txt"));
            Assert.AreEqual(142, result);
        }

        [TestMethod]
        public async Task TestSolvePartTwoExample()
        {
            var result = await _day.SolvePartTwo(_day.GenerateInput("example2.txt"));
            Assert.AreEqual(281, result);
        }

        [TestMethod]
        public async Task TestSolvePartOneActual()
        {
            var result = await _day.SolvePartOne(_day.GenerateInput());
            Assert.AreEqual(53651, result);
        }

        [TestMethod]
        public async Task TestSolvePartTwoActual()
        {
            var result = await _day.SolvePartTwo(_day.GenerateInput());
            Assert.AreEqual(53894, result);
        }
        
    }
}