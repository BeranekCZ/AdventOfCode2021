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

int totalSum = 0;
for (int row = 0; row < input.Length; row++)
{
    for (int column = 0; column < input.First().Length; column++)
    {
        if (column + 1 < input.First().Length && map[column, row] >= map[column + 1, row]) continue;
        if (column - 1 >= 0 && map[column, row] >= map[column - 1, row]) continue;
        if (row + 1 < input.Length && map[column, row] >= map[column, row + 1]) continue;
        if (row - 1 >= 0 && map[column, row] >= map[column, row - 1]) continue;

        totalSum += map[column, row] + 1;
    }
    Console.WriteLine();
}

//debug print
//for (int row = 0; row < input.Length; row++)
//{
//    for (int column = 0; column < input.First().Length; column++)
//    {
//        Console.Write($"{map[column,row]}");
//    }
//    Console.WriteLine();
//}

Console.WriteLine($"Result: {totalSum}");



void FloodFill(int[,] map, int column,int row)
{
    Stack<(int,int)> pixels = new Stack<(int, int)>();
    var value = map[column,row];
    pixels.Push((column, row));

    while (pixels.Count > 0)
    {
        (int column, int row) a = pixels.Pop();
        if(a.column >= 0 && a.column < map.GetLength(0) && a.row >= 0 && a.row < map.GetLength(1))
        {
            if(map[a.column,a.row] < map[a.column - 1, a.row]) pixels.Push(new (a.column - 1, a.row));
            if (map[a.column, a.row] < map[a.column + 1, a.row]) pixels.Push(new (a.column + 1, a.row));
            if (map[a.column, a.row] < map[a.column , a.row - 1]) pixels.Push(new (a.column, a.row - 1));
            if (map[a.column, a.row] < map[a.column , a.row + 1]) pixels.Push(new (a.column, a.row + 1));
        }
    }
    return;
}