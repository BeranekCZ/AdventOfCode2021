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
