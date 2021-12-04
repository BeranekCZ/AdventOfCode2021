var inputStream = File.OpenRead("input.txt");
var reader = new StreamReader(inputStream);

string line = string.Empty;
string numbersLine = string.Empty;

numbersLine = reader.ReadLine();

var tickets = new List<List<TicketNumber[]>>();

List<TicketNumber[]> currentTicket = null;

while ((line = reader.ReadLine()) != null)
{
    if (string.IsNullOrEmpty(line))
    {
        currentTicket = new List<TicketNumber[]>();
        tickets.Add(currentTicket);
        continue;
    }

    var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    currentTicket.Add(numbers.Select(x => new TicketNumber(x)).ToArray());
}

int result = 0;

foreach (var drawnNumber in numbersLine.Split(","))
{
    for (int i = 0; i < tickets.Count; i++)
    {
        List<TicketNumber[]> ticket = tickets[i];
        MarkNumbers(ticket, drawnNumber);

        if (CheckBingo(ticket))
        {
            if (tickets.Count > 1)
            {
                tickets.RemoveAt(i);
                i--;
            }
            else
            {
                result = ticket.SelectMany(x => x.Where(y => !y.IsMarked)).Sum(y => int.Parse(y.Number)) * int.Parse(drawnNumber);
                break;
            }
        };
    }
    if (result != 0) break;
}

Console.WriteLine($"Result: {result}  ");


void MarkNumbers(List<TicketNumber[]> ticket, string number)
{
    foreach (TicketNumber[] row in ticket)
    {
        for (int i = 0; i < row.Length; i++)
        {
            TicketNumber item = row[i];
            if (item.Number.Equals(number))
                item.IsMarked = true;
        }
    }
}

bool CheckBingo(List<TicketNumber[]> ticket)
{
    //check row bingo
    foreach (var row in ticket)
    {
        if (row.Count(x => x.IsMarked == true) == 5) return true;
    }

    //check column bingo
    for (int cIndex = 0; cIndex < ticket.First().Length; cIndex++)
    {
        if (ticket.Select(x => x.ElementAt(cIndex)).Count(x => x.IsMarked == true) == 5) return true;
    }

    return false;
}

public class TicketNumber
{
    public string Number { get; set; }
    public bool IsMarked { get; set; } = false;

    public TicketNumber(string number)
    {
        Number = number;
    }
}

