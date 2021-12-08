var input = File.ReadAllText("input.txt");
var fishStates = input.Split(',').Select(x => int.Parse(x)).ToList();

var fishGroups = fishStates.GroupBy(x => x).Select(g => (state: g.Key, count: fishStates.Count(y => y == g.Key))).OrderByDescending(w => w.state).ToList();

var fishes = new long[9];

foreach (var item in fishGroups)
{
    fishes[item.state] = item.count;
}


int numberOfDays = 256;
for (int i = 0; i < numberOfDays; i++)
{
    long newBorn = 0;
    for (int s = 0; s < fishes.Length; s++)
    {
        if (s == 0)
        {
            fishes[7] += fishes[s];
            newBorn = fishes[s];
        }
        else
        {
            fishes[s - 1] = fishes[s];
            if (s == 8) fishes[s] = 0;
        }
    }
    fishes[8] += newBorn;

    #region debug print
    //foreach (var item in fishes)
    //{
    //    Console.Write($"{item} , ");
    //}
    //Console.WriteLine($"-after day {i+1}");
    #endregion
}

Console.WriteLine($"Result: {fishes.Sum(x => x)}");




