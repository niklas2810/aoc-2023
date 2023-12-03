using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
    [TestClass]
    public class Day03Tests
    {
        private readonly Day03 _day;

        public Day03Tests()
        {
            _day = new Day03();
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
            Assert.AreEqual(10, result.Count(), "10 lines should be read");
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
            Assert.AreEqual(140, result.Count(), "140 lines should be read");
        }

        [TestMethod]
        public async Task TestSolvePartOneExample()
        {
            var result = await _day.SolvePartOne(_day.GenerateInput("example.txt"));
            Assert.AreEqual(4361, result, "SolvePartOne should return 4361");

		}

        [TestMethod]
        public async Task TestSolvePartTwoExample()
        {
            var result = await _day.SolvePartTwo(_day.GenerateInput("example.txt"));
            Assert.AreEqual(467835, result, "SolvePartTwo should return 467835");
        }

        [TestMethod]
        public async Task TestSolvePartOneActual()
        {
            var result = await _day.SolvePartOne(_day.GenerateInput());
            Assert.AreEqual(525181, result, "SolvePartOne should return 525181");
        }

        [TestMethod]
        public async Task TestSolvePartTwoActual()
        {
            var result = await _day.SolvePartTwo(_day.GenerateInput());
            Assert.AreEqual(84289137, result, "SolvePartTwo should return 84289137");
        }
    }
}
