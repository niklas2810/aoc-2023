using AOC2023.Contracts;
using AOC2023.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    [TestClass]
    internal class DayBaseTests
    {

        [TestMethod]
        public void TestListFilesForEmptyFolder()
        {
            var day = new DummyDay26();
            var files = day.GetAvailableFiles();
            Assert.AreEqual(0, files.Count());
        }

        [TestMethod]
        public void TestListFilesForDay01()
        {
            var day = new Day01();
            var files = day.GetAvailableFiles().ToList();
            Assert.AreEqual(3, files.Count());
            Assert.AreEqual("example.txt", files[0]);
            Assert.AreEqual("example2.txt", files[1]);
            Assert.AreEqual("input.txt", files[2]);
        }
    }

    class DummyDay26 : DayBase
    {
        public override string Name => "Dummy";

        public override IEnumerable<string> GenerateInput(params object[] args)
        {
            throw new NotImplementedException();
        }

        public override long SolvePartOne(IEnumerable<string> input)
        {
            throw new NotImplementedException();
        }

        public override long SolvePartTwo(IEnumerable<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
