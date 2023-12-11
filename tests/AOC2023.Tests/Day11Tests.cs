using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
	[TestClass]
	public class Day11Tests
	{
		private readonly Day11 _day;

		public Day11Tests()
		{
			_day = new Day11();
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
			Assert.AreEqual(374, result, "SolvePartOne should return 374");

		}

		[TestMethod]
		public async Task TestSolvePartTwoExample()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput("example.txt"));
			Assert.AreEqual(82000210, result, "SolvePartTwo should return 82000210");
		}

		[TestMethod]
		public async Task TestSolvePartOneActual()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput());
			Assert.AreEqual(9543156, result, "SolvePartOne should return 9543156");
		}

		[TestMethod]
		public async Task TestSolvePartTwoActual()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput());
			Assert.AreEqual(625243292686, result, "SolvePartTwo should return 625243292686");
		}
	}
}
