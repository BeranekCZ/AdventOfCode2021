var allLines = File.ReadAllLines("input.txt");

string line = string.Empty;

int result = 0;

for (int i = 0; i < allLines.Length; i++)
{
    if (i + 3 >= allLines.Length) break;

    var group1Sum = int.Parse(allLines[i]) + int.Parse(allLines[i+1]) + int.Parse(allLines[i+2]);
    var group2Sum = int.Parse(allLines[i+1]) + int.Parse(allLines[i+2]) + int.Parse(allLines[i+3]);
    if (group2Sum > group1Sum) result++;
}

Console.WriteLine($"Result: {result}");


