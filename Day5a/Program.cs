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

    //only consider horizontal and vertical lines 
    if (firstCoords[0] != secondCoords[0] && firstCoords[1] != secondCoords[1]) continue;

    //vertical line
    if (firstCoords[0] == secondCoords[0])
    {
        int startVal = firstCoords[1] <= secondCoords[1] ? firstCoords[1] : secondCoords[1];

        for (int y = startVal; y <= startVal + Math.Abs(firstCoords[1] - secondCoords[1]); y++)
        {
            map[firstCoords[0], y]++;
        }
    }

    //horizontal line
    if (firstCoords[1] == secondCoords[1])
    {
        int startVal = firstCoords[0] <= secondCoords[0] ? firstCoords[0] : secondCoords[0];

        for (int x = startVal; x <= startVal + Math.Abs(firstCoords[0] - secondCoords[0]); x++)
        {
            map[x, firstCoords[1]]++;
        }
    }

}

var a = (from int val in map select val).Count(x => x >= 2);


Console.WriteLine($"Result: {a}");




