using AOC2023.Logic.Days;
using AOC2023.Logic.Days.Day10;

namespace AOC2023.Tests
{
	[TestClass]
	public class Day10Tests
	{
		private readonly Day10 _day;

		public Day10Tests()
		{
			_day = new Day10();
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
		public async Task TestSolvePartOneActual()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput());
			Assert.AreEqual(7107, result, "SolvePartOne should return 7107");
		}

		[TestMethod]
		public async Task TestSolvePartTwoActual()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput());
			Assert.AreEqual(281, result, "SolvePartTwo should return 281");
		}
	}
}
