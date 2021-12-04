string line = string.Empty;

var allLines = File.ReadAllLines("input.txt").ToList();
var oxygen = new List<string>(allLines);
var co2 = new List<string>(allLines);

oxygen = GetFilteredLinesRecursive(oxygen, true, 0);

co2 = GetFilteredLinesRecursive(co2, false, 0);

Console.WriteLine($"Result: {Convert.ToInt32(oxygen.First(), 2) * Convert.ToInt32(co2.First(), 2)} ");

List<string> GetFilteredLinesRecursive(IEnumerable<string> input, bool mostCommon, int position)
{
    if (input.Count() == 1) return input.ToList();

    string bitOfInterest = input.Count(x => x.ElementAt(position).Equals('1')) >= input.Count(x => x.ElementAt(position).Equals('0')) ? "1" : "0";
    if (!mostCommon)
    {
        bitOfInterest = bitOfInterest.Equals("1") ? "0" : "1";
    }

    var filteredLines = input.Where(x => x.ElementAt(position).Equals(bitOfInterest.ToCharArray()[0])).ToList();
    return GetFilteredLinesRecursive(filteredLines, mostCommon,position+1);
}

#region non recursive version
//for (int i = 0; i < oxygen.First().Length; i++)
//{
//    oxygen = GetFilteredLines(oxygen, true, i);
//    if (oxygen.Count == 1) break;
//}


//for (int i = 0; i < co2.First().Length; i++)
//{
//    co2 = GetFilteredLines(co2, false, i);
//    if (co2.Count == 1) break;
//}

//List<string> GetFilteredLines(IEnumerable<string> input, bool mostCommon, int position)
//{
//    string bitOfInterest = input.Count(x => x.ElementAt(position).Equals('1')) >= input.Count(x => x.ElementAt(position).Equals('0')) ? "1" : "0";
//    if (!mostCommon)
//    {
//        bitOfInterest = bitOfInterest.Equals("1") ? "0" : "1";
//    }

//    return input.Where(x => x.ElementAt(position).Equals(bitOfInterest.ToCharArray()[0])).ToList();
//}
#endregion