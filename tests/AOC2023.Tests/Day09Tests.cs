using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
	[TestClass]
	public class Day09Tests
	{
		private readonly Day09 _day;

		public Day09Tests()
		{
			_day = new Day09();
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
			Assert.AreEqual(3, result.Count(), "3 lines should be read");
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
			Assert.AreEqual(200, result.Count(), "200 lines should be read");
		}

		[TestMethod]
		public async Task TestSolvePartOneExample()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput("example.txt"));
			Assert.AreEqual(114, result, "SolvePartOne should return 114");

		}

		[TestMethod]
		public async Task TestSolvePartTwoExample()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput("example.txt"));
			Assert.AreEqual(2, result, "SolvePartTwo should return 2");
		}

		[TestMethod]
		public async Task TestSolvePartOneActual()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput());
			Assert.AreEqual(2075724761, result, "SolvePartOne should return 2075724761");
		}

		[TestMethod]
		public async Task TestSolvePartTwoActual()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput());
			Assert.AreEqual(1072, result, "SolvePartTwo should return 1072");
		}
	}
}
