var inputStream = File.OpenRead("input.txt");

var reader = new StreamReader(inputStream);
string line = string.Empty;

int aim=0, horizontal = 0, depth = 0;

while ((line = reader.ReadLine()) != null)
{
    var  lineParts = line.Split(' ');
    switch (lineParts[0])
    {
        case "forward":
            horizontal += int.Parse(lineParts[1]); 
            depth += aim * int.Parse(lineParts[1]);
            break;
        case "up":
            aim -= int.Parse(lineParts[1]);
            break;
        case "down":
            aim += int.Parse(lineParts[1]);
            break;
    }
}

Console.WriteLine($"Result: {horizontal * depth}");


