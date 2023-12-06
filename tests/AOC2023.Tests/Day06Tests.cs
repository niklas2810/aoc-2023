using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
	[TestClass]
	public class Day06Tests
	{
		private readonly Day06 _day;

		public Day06Tests()
		{
			_day = new Day06();
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
			Assert.AreEqual(2, result.Count(), "2 lines should be read");
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
			Assert.AreEqual(2, result.Count(), "2 lines should be read");
		}

		[TestMethod]
		public async Task TestSolvePartOneExample()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput("example.txt"));
			Assert.AreEqual(288, result, "SolvePartOne should return 288");

		}

		[TestMethod]
		public async Task TestSolvePartTwoExample()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput("example.txt"));
			Assert.AreEqual(71503, result, "SolvePartTwo should return 71503");
		}

		[TestMethod]
		public async Task TestSolvePartOneActual()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput());
			Assert.AreEqual(1155175, result, "SolvePartOne should return 1155175");
		}

		[Ignore] // Execution time is too long
		[TestMethod]
		public async Task TestSolvePartTwoActual()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput());
			Assert.AreEqual(35961505, result, "SolvePartTwo should return 35961505");
		}
	}
}
