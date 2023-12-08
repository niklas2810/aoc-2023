using AOC2023.Logic.Days;

namespace AOC2023.Tests
{
	[TestClass]
	public class Day08Tests
	{
		private readonly Day08 _day;

		public Day08Tests()
		{
			_day = new Day08();
		}

		[TestMethod]
		public void TestFileExample1()
		{
			// Arrange
			var filename = "example1.txt";
			Assert.IsTrue(File.Exists(_day.GenerateFilePath(filename)), "File path should exist");

			// Act
			var result = _day.GenerateInput(filename);

			// Assert
			Assert.AreEqual(5, result.Count(), "5 lines should be read");
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
			Assert.AreEqual(760, result.Count(), "760 lines should be read");
		}

		[TestMethod]
		public async Task TestSolvePartOneExample()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput("example1.txt"));
			Assert.AreEqual(6, result, "SolvePartOne should return 6");

		}

		[TestMethod]
		public async Task TestSolvePartTwoExample()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput("example2.txt"));
			Assert.AreEqual(6, result, "SolvePartTwo should return 6");
		}

		[TestMethod]
		public async Task TestSolvePartOneActual()
		{
			var result = await _day.SolvePartOne(_day.GenerateInput());
			Assert.AreEqual(18023, result, "SolvePartOne should return 18023");
		}

		[Ignore] // Execution time is too long
		[TestMethod]
		public async Task TestSolvePartTwoActual()
		{
			var result = await _day.SolvePartTwo(_day.GenerateInput());
			Assert.AreEqual(14449445933179, result, "SolvePartTwo should return 14449445933179");
		}
	}
}
