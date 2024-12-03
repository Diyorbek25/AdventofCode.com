
using System.Text;
using System.Text.RegularExpressions;

string corruptedMemory = File.ReadAllText("input.txt");

Console.WriteLine(PartOne(corruptedMemory));
Console.WriteLine(PartTwo(corruptedMemory));

static int PartOne(string corruptedMemory)
{
    string pattern = @"mul\((\d+),(\d+)\)";
    var matches = Regex.Matches(corruptedMemory, pattern);

    int totalSum = CalculateMulSum(matches);

    return totalSum;
}

static int PartTwo(string corruptedMemory)
{
    string pattern = @"mul\((\d+),(\d+)\)";
    string doPattern = @"do\(\)";
    string dontPattern = @"don't\(\)";

    MatchCollection doMatches = Regex.Matches(corruptedMemory, doPattern);
    MatchCollection dontMatches = Regex.Matches(corruptedMemory, dontPattern);

    var builder = new StringBuilder(corruptedMemory);

    var list = new List<(int startIndex, int lastIndex)>();

    foreach (Match dontMatch in dontMatches)
    {
        var dontIndex = dontMatch.Index;
        var firstDoMatch = doMatches.FirstOrDefault(i => i.Index > dontIndex);
        var lastIndex = firstDoMatch?.Index ?? builder.Length - 1;

        list.Add((dontIndex, lastIndex));

        if (firstDoMatch is null)
            break;
    }

    list = list.GroupBy(x => x.lastIndex)
        .Select(gr => gr.OrderBy(x => x.startIndex).First())
        .ToList();

    var builder2 = new StringBuilder();

    foreach (var (startIndex, lastIndex) in list)
    {
        builder2.Append(builder.ToString(startIndex, lastIndex - startIndex + 1));
    }

    MatchCollection matches = Regex.Matches(builder.ToString(), pattern);
    int totalSum = CalculateMulSum(matches);

    matches = Regex.Matches(builder2.ToString(), pattern);
    int totalSum2 = CalculateMulSum(matches);

    return totalSum - totalSum2;
}

static int CalculateMulSum(MatchCollection matches)
{
    int totalSum = 0;

    foreach (Match match in matches)
    {
        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);
        totalSum += x * y;
    }

    return totalSum;
}