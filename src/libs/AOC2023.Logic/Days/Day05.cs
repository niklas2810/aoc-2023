using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Logic.Days
{
	public class Day05 : DayBase
	{
		public override string Name => "If You Give A Seed A Fertilizer";

		public override Task<long> SolvePartOne(IEnumerable<string> input)
		{
			var full = ParseMaps(input);
			var result = full.Seeds.Select(s => full.MapSeed(s)).Min();			

			return Task.FromResult(result);
		}

		public override Task<long> SolvePartTwo(IEnumerable<string> input)
		{
			var full = ParseMaps(input, true);
			// Form tuples of two seeds, then skip two seeds to get the next tuple
			var seedRanges = SimplifyRanges(full.Seeds.Zip(full.Seeds.Skip(1), (a, b) => (a, b)).Where((_, i) => i % 2 == 0));

			long result = long.MaxValue;

			for(int i = 0; i < seedRanges.Count(); ++i)
			{
				var v = seedRanges.ElementAt(i);
				Console.WriteLine($"[{i+1}/{seedRanges.Count()}] => {v.b} Elements");
				var res = full.RangeMapSeed(v).Min();
				if(res < result)
					result = res;
			}
			return Task.FromResult(result);
		}

		private IEnumerable<(long a, long b)> SimplifyRanges(IEnumerable<(long a, long b)> enumerable)
		{
			var ranges = enumerable.ToList();
			bool changed = false;
			do
			{
				changed = false;
				for(int i = 0; i < ranges.Count; ++i)
				{
					var v = ranges.ElementAt(i);
					for(int j = i + 1; j < ranges.Count; ++j)
					{
						var v2 = ranges.ElementAt(j);
						var merged = SimplifyRange(v, v2);
						if(merged.Item1 > 0)
						{
							ranges.RemoveAt(j);
							ranges.RemoveAt(i);
							ranges.Insert(i, merged);
							changed = true;
							break;
						}
					}
					if(changed)
						continue;
				}
			} while (changed);
			return ranges;
		}

		private (long, long) SimplifyRange((long start, long length) a, (long start, long length) b)
		{
            if (a.start > b.start)
            {
				var tmp = a;
				a = b;
				b = tmp;
            }

			// Option 1: a fully contains b
			if (a.start <= b.start && a.start + a.length >= b.start + b.length)
				return a;
			// Option 2: a overlaps b
			if (a.start <= b.start && a.start + a.length >= b.start)
				return (a.start, b.start + b.length - a.start);
			// Option 3: No overlap
			return (-1, -1);
        }

		private FullMap ParseMaps(IEnumerable<string> input, bool seedsAsRanges = false)
		{
			var seeds = new List<long>();
			var maps = new List<Map>();

			Map? currentMap = null;

			foreach (var line in input)
			{
				if (line.StartsWith("seeds: "))
				{
					seeds = line.Substring(7).Split(' ').Select(long.Parse).ToList();
				}
				else if (line.Contains(" map:"))
				{
					if (currentMap != null)
						throw new Exception("Invalid map definition");

					var srcName = line.Substring(0, line.IndexOf("-"));
					var destName = line.Split(' ')[0].Substring(line.LastIndexOf("-") + 1);
					currentMap = new Map { SourceName = srcName, DestName = destName };
				}
				else if (string.IsNullOrWhiteSpace(line))
				{
					if (currentMap == null)
					{
						if (maps.Count == 0)
							continue;
						throw new Exception("Invalid map definition");
					}
						
					maps.Add(currentMap);
					currentMap = null;
				}
				else if (line.Split(' ').Length == 3)
				{
					if (currentMap == null)
						throw new Exception("Invalid map definition");

					var parts = line.Split(' ');
					var valueStart = long.Parse(parts[0]);
					var srcStart = long.Parse(parts[1]);
					var length = long.Parse(parts[2]);

					currentMap.Mappings.Add(new SourceDestMapping { SrcStart = srcStart, ValueStart = valueStart, Length = length });
				}
				else
				{
					throw new ArgumentException($"Invalid map definition: {line}");
				}
			}
			if(currentMap == null)
				throw new Exception("Invalid map definition");
			maps.Add(currentMap);

			return new FullMap { Seeds = seeds, Maps = maps };
		}

		

	}
}

class FullMap
{
	private HashSet<long> visited = new();
	private Object visitedLock = new();

	public required List<long> Seeds { get; init; }

	public required List<Map> Maps { get; init; }

	public long MapSeed(long v)
	{
		foreach(var map in Maps)
		{
			v = map.MappingFor(v);
		}
		return v;
	}

	internal IEnumerable<long> RangeMapSeed((long start, long length) v)
	{
		var options = new List<long>();
		for(var i = 0; i < v.length; ++i)
		{
			options.Add(i + v.start);
		}
		return options.AsParallel().Select(MapSeed);
	}
}

class Map
{
	public required string SourceName { get; init; }

	public required string DestName { get; init; }

	public List<SourceDestMapping> Mappings { get; } = new();

	public long MappingFor(long value)
	{
		// Foreach mapping, if value is in range, return mapped value
		foreach(var mapping in Mappings)
			if (value >= mapping.SrcStart && value <= mapping.SrcStart + mapping.Length)
				return mapping.ValueStart + (value - mapping.SrcStart);
		return value;
	}
}

class SourceDestMapping
{
	public required long ValueStart { get; init; }

	public required long SrcStart { get; init; }

	public required long Length { get; init; }
}
