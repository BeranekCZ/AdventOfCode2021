var input = File.ReadAllText("input.txt");
var positions = input.Split(',').Select(x => int.Parse(x)).ToList();

var median = positions.OrderBy(x=>x).ElementAt(positions.Count/2);

var totalFuel = positions.Sum(x => Math.Abs(x - median));

Console.WriteLine($"Result: {totalFuel}");



