using AOC2023.Days;

namespace AOC2023.Tests
{

    [TestClass]
    public class Day01Tests
    {
        private readonly Day01 _day01;

        public Day01Tests()
        {
            _day01 = new Day01();
        }

        [TestMethod]
        public void TestFileExample()
        {
            // Arrange
            var filePath = @"Inputs\01\example.txt";
            Assert.IsTrue(File.Exists(filePath), "File path should exist");

            // Act
            var result = _day01.GenerateInput(filePath);

            // Assert
            Assert.AreEqual(4, result.Count(), "4 lines should be read");
        }

        [TestMethod]
        public void TestFileExample2()
        {
            // Arrange
            var filePath = @"Inputs\01\example2.txt";
            Assert.IsTrue(File.Exists(filePath), "File path should exist");

            // Act
            var result = _day01.GenerateInput(filePath);

            // Assert
            Assert.AreEqual(7, result.Count(), "7 lines should be read");
        }

        [TestMethod]
        public void TestFileInput()
        {
            // Arrange
            var filePath = @"Inputs\01\input.txt";
            Assert.IsTrue(File.Exists(filePath), "File path should exist");

            // Act
            var result = _day01.GenerateInput(filePath);

            // Assert
            Assert.AreEqual(1000, result.Count(), "1000 lines should be read");
        }

        [TestMethod]
        public void TestSolvePartOneExample()
        {
            var result = _day01.SolvePartOne(_day01.GenerateInput(@"Inputs\01\example.txt"));
            Assert.AreEqual(142, result);
        }

        [TestMethod]
        public void TestSolvePartTwoExaple()
        {
            var result = _day01.SolvePartTwo(_day01.GenerateInput(@"Inputs\01\example2.txt"));
            Assert.AreEqual(281, result);
        }

        [TestMethod]
        public void TestSolvePartOneActual()
        {
            var result = _day01.SolvePartOne(_day01.GenerateInput());
            Assert.AreEqual(53651, result);
        }

        [TestMethod]
        public void TestSolvePartTwoActual()
        {
            var result = _day01.SolvePartTwo(_day01.GenerateInput());
            Assert.AreEqual(53894, result);
        }
        
    }
}