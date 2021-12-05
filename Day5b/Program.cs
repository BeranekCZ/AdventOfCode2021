var inputStream = File.OpenRead("input.txt");
var reader = new StreamReader(inputStream);

string line = string.Empty;
string numbersLine = string.Empty;

var map = new int[1000, 1000];

while ((line = reader.ReadLine()) != null)
{
    var coordinates = line.Split("->");
    var firstCoords = coordinates[0].Split(",").Select(x => Convert.ToInt32(x)).ToArray();
    var secondCoords = coordinates[1].Split(",").Select(x => Convert.ToInt32(x)).ToArray();

    //vertical line
    if (firstCoords[0] == secondCoords[0])
    {
        int startVal = firstCoords[1] <= secondCoords[1] ? firstCoords[1] : secondCoords[1];

        for (int y1 = startVal; y1 <= startVal + Math.Abs(firstCoords[1] - secondCoords[1]); y1++)
        {
            map[firstCoords[0], y1]++;
        }

        continue;
    }

    //horizontal line
    if (firstCoords[1] == secondCoords[1])
    {
        int startVal = firstCoords[0] <= secondCoords[0] ? firstCoords[0] : secondCoords[0];

        for (int x = startVal; x <= startVal + Math.Abs(firstCoords[0] - secondCoords[0]); x++)
        {
            map[x, firstCoords[1]]++;
        }
        continue;
    }

    //diagonal line
    int startX = firstCoords[0] <= secondCoords[0] ? firstCoords[0] : secondCoords[0];
    var dx = firstCoords[0] - secondCoords[0];
    var dy = firstCoords[1] - secondCoords[1];
    int y = 0;
    for (int i = 0; i <= Math.Abs(dx); i++)
    {
        map[firstCoords[0] + (dx / Math.Abs(dx) * (-1)) * i, firstCoords[1] + (dy / Math.Abs(dy) * (-1)) * i]++;
    }


}

//PrintMap();

var a = (from int val in map select val).Count(x => x >= 2);


Console.WriteLine($"Result: {a}");

//debug print
void PrintMap()
{
    for (int y = 0; y < map.GetLength(0); y++)
    {
        for (int x = 0; x < map.GetLength(1); x++)
        {
            if (map[x, y] >= 2) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.Write(map[x, y]==0? ".": map[x, y]);
        }
        Console.WriteLine();
    }
}




