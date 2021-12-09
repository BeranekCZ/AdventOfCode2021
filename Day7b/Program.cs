//BRUTAL FORCE :)

var input = File.ReadAllText("input.txt");
var positions = input.Split(',').Select(x => int.Parse(x)).OrderBy(x => x).ToList();
Dictionary<int,int> targetAndCost = new Dictionary<int,int>();



for (int i = positions.First(); i < positions.Last(); i++)
{
    targetAndCost.Add(i,GetFuelCost(positions, i));
}

//no prutal force version
//var avg = positions.Average(x => x);
//var cost = GetFuelCost(positions, (int)avg);

Console.WriteLine($"Result: {targetAndCost.Values.Min()}");


//functions
int GetFuelCost(List<int> input, int targetPosition)
{
    return (int)positions.Sum(x => (1 + Math.Abs(x - targetPosition)) * (Math.Abs(x - targetPosition) / 2.0));
}
