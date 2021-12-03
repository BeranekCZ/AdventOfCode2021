// See https://aka.ms/new-console-template for more information

var inputStream = File.OpenRead("input.txt");

var reader = new StreamReader(inputStream);
string line = string.Empty;

int prevNumber, result = 0;
prevNumber = int.Parse(reader.ReadLine());


while ((line = reader.ReadLine()) != null)
{
    var number = int.Parse(line);
    if (number > prevNumber) result++;
    prevNumber = number;
}

Console.WriteLine($"Result: {result}");


