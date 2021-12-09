var input = File.ReadAllLines("input.txt");

var map = new int[input.First().Length, input.Length];
//load data into array
for (int row = 0; row < input.Length; row++)
{
    for (int column = 0; column < input.First().Length; column++)
    {
        map[column, row] = Convert.ToInt32(input[row][column]) - Convert.ToInt32('0');
    }

}

var basisSizes = new List<int>();
int totalSum = 0;
for (int row = 0; row < input.Length; row++)
{
    for (int column = 0; column < input.First().Length; column++)
    {
        if (column + 1 < input.First().Length && map[column, row] >= map[column + 1, row]) continue;
        if (column - 1 >= 0 && map[column, row] >= map[column - 1, row]) continue;
        if (row + 1 < input.Length && map[column, row] >= map[column, row + 1]) continue;
        if (row - 1 >= 0 && map[column, row] >= map[column, row - 1]) continue;

        var size = FloodFill(map, column, row);
        basisSizes.Add(size);
    }
}

basisSizes.Sort();
basisSizes.Reverse();

Console.WriteLine($"Result: {basisSizes[0] * basisSizes[1] * basisSizes[2]}");

int FloodFill(int[,] map, int column, int row)
{
    Stack<(int, int)> pixels = new Stack<(int, int)>();
    var value = map[column, row];
    pixels.Push((column, row));
    var totalCount = 0;
    var memory = new List<(int, int)>();

    while (pixels.Count > 0)
    {
        (int column, int row) a = pixels.Pop();
        //check if item was added in past
        if (memory.Contains(a)) continue;
        else memory.Add(a);
        //ignore number 9
        if (map[a.column, a.row] == 9)
        {
            continue;
        }
       
        if (a.column >= 0 && a.column < map.GetLength(0) && a.row >= 0 && a.row < map.GetLength(1))
        {
            if (a.column - 1 >= 0 && map[a.column, a.row] < map[a.column - 1, a.row]) pixels.Push(new(a.column - 1, a.row));
            if (a.column + 1 < map.GetLength(0) && map[a.column, a.row] < map[a.column + 1, a.row]) pixels.Push(new(a.column + 1, a.row));
            if (a.row - 1 >= 0 && map[a.column, a.row] < map[a.column, a.row - 1]) pixels.Push(new(a.column, a.row - 1));
            if (a.row + 1 < map.GetLength(1) && map[a.column, a.row] < map[a.column, a.row + 1]) pixels.Push(new(a.column, a.row + 1));
        }
        totalCount++;
    }
   
    return totalCount;
}