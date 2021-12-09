var input = File.ReadAllLines("input.txt");

var inputSignals = new List<string>();
var outputSignals = new List<string>();

foreach (var line in input)
{
    var inputOutput = line.Split('|');
    inputSignals.Add(inputOutput[0]);
    outputSignals.Add(inputOutput[1]);
}
var result = outputSignals.SelectMany(x => x.Trim().Split(' ')).Where(x => x.Length == 2 || x.Length == 4 || x.Length == 3 || x.Length == 7).Count();

Console.WriteLine($"Result: {result}");
