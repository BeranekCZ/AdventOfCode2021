var inputStream = File.OpenRead("input.txt");

var reader = new StreamReader(inputStream);
string line = string.Empty;

int[] bitSums = null;

while ((line = reader.ReadLine()) != null)
{
    if (bitSums is null) bitSums = new int[line.Length];

    var number = Convert.ToInt32(line, 2);
    for (int i = 0; i < bitSums.Length; i++)
    {
        bitSums[i] += GetBitValue(number, i);
    }
}

int gamma = 0;
int epsilon = 0;

for (int i = bitSums.Length - 1; i >= 0; i--)
{
    gamma += bitSums[i] > 0 ? 1 : 0;
    epsilon += bitSums[i] > 0 ? 0 : 1;
    
    if (i != 0)
    {
        gamma = gamma << 1;
        epsilon = epsilon << 1;

    }
}

Console.WriteLine($"Result: {gamma * epsilon}");
int GetBitValue(int number, int position)
{
    var x = number & (0b00001 << position);
    if (x == 0) return -1;
    else return 1;
}
