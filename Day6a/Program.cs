var input = File.ReadAllText("input.txt");

var fishStates = input.Split(',').Select(x => int.Parse(x)).OrderBy(x => x).ToList();
int numberOfDays = 80;

for (int i = 0; i < numberOfDays; i++)
{
    #region debug print
    //fishStates.ForEach(x =>
    //{
    //    Console.Write($"{x} , ");
    //});
    //Console.WriteLine($"-IN");
    #endregion

    var countOfMums = fishStates.Count(x => x == 0);
    fishStates.AddRange(Enumerable.Repeat(9, countOfMums).ToArray());
    fishStates = fishStates.Select(x => x == 0 ? 6 : x - 1).ToList();
}


Console.WriteLine($"Result: {fishStates.Count}"); //345793


