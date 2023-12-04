using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
	[TestClass]
	public class Day04Tests
	{
		private readonly Day04 _day;

		public Day04Tests()
		{
			_day = new Day04();
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
			Assert.AreEqual(6, result.Count(), "6 lines should be read");
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
			Assert.AreEqual(219, result.Count(), "219 lines should be read");
		}

		[TestMethod]
		public async Task TestSolvePartOneExample()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput("example.txt"));
			Assert.AreEqual(13, result, "SolvePartOne should return 13");

		}

		[TestMethod]
		public async Task TestSolvePartTwoExample()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput("example.txt"));
			Assert.AreEqual(30, result, "SolvePartTwo should return 30");
		}

		[TestMethod]
		public async Task TestSolvePartOneActual()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput());
			Assert.AreEqual(33950, result, "SolvePartOne should return 33950");
		}

		[TestMethod]
		public async Task TestSolvePartTwoActual()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput());
			Assert.AreEqual(14814534, result, "SolvePartTwo should return 14814534");
		}
	}
}
