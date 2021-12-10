var input = File.ReadAllLines("input.txt");
var errroScore = 0;
foreach (var line in input)
{
    var brackets = new Stack<char>();
    for (int i = 0; i < line.Length; i++)
    {
        if(line[i] == '(' || line[i] == '[' || line[i] == '{' || line[i] == '<') brackets.Push(line[i]);
        else
        {
            var charOnStack = brackets.Pop();
            if (charOnStack != GetOpening(line[i]))
            {
                errroScore += GetScore(line[i]);
                break;
            }
        }
    }
}

Console.WriteLine($"Result: {errroScore}");

int GetScore(char c)
{
    switch (c)
    {
        case ')': return 3; 
        case ']': return 57;
        case '}': return 1197;
        case '>': return 25137;
    }

    return 0;
}

char GetOpening(char c)
{
    switch (c)
    {
        case ')': return '(';
        case ']': return '[';
        case '}': return '{';
        case '>': return '<';
    }

    return ' ';
}