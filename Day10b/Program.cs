var input = File.ReadAllLines("input.txt");
var incompleteLines = new List<string>();

var repairScores = new List<long>();
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
                break;
            }
        }

        if(i== line.Length - 1)
        {
            incompleteLines.Add(line);
            var score = 0L;
            for (int n = 0; n < brackets.Count; i++)
            {
                score = (5L * score) + GetScore(GetClosing(brackets.Pop()));
            }
            repairScores.Add(score);
        }
    }
}
repairScores.Sort();

Console.WriteLine($"Result: {repairScores.ElementAt((int)repairScores.Count/2)}");

int GetScore(char c)
{
    switch (c)
    {
        case ')': return 1; 
        case ']': return 2;
        case '}': return 3;
        case '>': return 4;
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

char GetClosing(char c)
{
    switch (c)
    {
        case '(': return ')';
        case '[': return ']';
        case '{': return '}';
        case '<': return '>';
    }

    return ' ';
}