using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
	[TestClass]
	public class Day05Tests
	{
		private readonly Day05 _day;

		public Day05Tests()
		{
			_day = new Day05();
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
			Assert.AreEqual(33, result.Count(), "33 lines should be read");
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
			Assert.AreEqual(172, result.Count(), "172 lines should be read");
		}

		[TestMethod]
		public async Task TestSolvePartOneExample()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput("example.txt"));
			Assert.AreEqual(35, result, "SolvePartOne should return 35");

		}

		[TestMethod]
		public async Task TestSolvePartTwoExample()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput("example.txt"));
			Assert.AreEqual(46, result, "SolvePartTwo should return 46");
		}

		[TestMethod]
		public async Task TestSolvePartOneActual()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput());
			Assert.AreEqual(825516882, result, "SolvePartOne should return 825516882");
		}

		[Ignore] // Execution time is too long
		[TestMethod]
		public async Task TestSolvePartTwoActual()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput());
			Assert.AreEqual(136096660, result, "SolvePartTwo should return 136096660");
		}
	}
}
