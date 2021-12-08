var input = File.ReadAllText("input.txt");

var fishStates = input.Split(',').Select(x => int.Parse(x)).ToList();

var r = fishStates.GroupBy(x => x).Select(g => (state: g.Key, count: fishStates.Count(y => y == g.Key))).OrderByDescending(w => w.state).ToList();

var fishes = new int[9];

int numberOfDays = 18;

foreach (var item in r)
{
    fishes[item.state] = item.count;
}


for (int i = 0; i < numberOfDays; i++)
{

    var tempFishes = new int[9];

    for (int s = 0; s < fishes.Length; s++)
    {
        if (s == 0)
        {
            tempFishes[6] += fishes[s];
            tempFishes[8] += fishes[s];
        }
        else
        {
            tempFishes[s - 1] += fishes[s];
            //if (s == 8) fishes[s] = 0;

        }
    }


    tempFishes.CopyTo(fishes, 0);
    
    //fishes[s - 1] = fishes[s];
    #region debug print
    foreach (var item in fishes)
    {
        Console.Write($"{item} , ");
    }
    Console.WriteLine($"-after");
    #endregion
}

Console.WriteLine($"Result: {fishes.Sum(x => x)}");




