var input = File.ReadAllLines("input.txt")
    .SelectMany(line => line.Split(",", StringSplitOptions.RemoveEmptyEntries))
    .Select(part => part.Split("-", StringSplitOptions.RemoveEmptyEntries))
    .Select(range => (firstId: long.Parse(range[0]), lastId: long.Parse(range[1])))
    .ToList();

Console.WriteLine($"Part one: {PartTwo(input)}");

static long PartOne(List<(long firstId, long lastId)> ranges)
{
    long sum = 0;
    foreach (var (firstId, lastId) in ranges)
    {
        for (long id = firstId; id <= lastId; id++)
        {
            if (IsMadeOnlyOfSomeSequenceOfDigitsRepetedTwice(id))
                sum += id;
        }
    }

    return sum;
}

static bool IsMadeOnlyOfSomeSequenceOfDigitsRepetedTwice(long id)
{
    long countOfDigits = (long)Math.Log10(id) + 1;

    if (countOfDigits % 2 != 0)
        return false;
    
    long divisor = (long)Math.Pow(10, countOfDigits / 2);
    long firstHalf = id / divisor;
    long secondHalf = id % divisor;

    return firstHalf == secondHalf;
}

static long PartTwo(List<(long firstId, long lastId)> ranges)
{
    long sum = 0;
    foreach (var (firstId, lastId) in ranges)
    {
        for (long id = firstId; id <= lastId; id++)
        {
            if (IsMadeOnlyOfSomeSequenceOfDigitsRepetedAtLeastTwice(id))
                sum += id;
        }
    }

    return sum;
}

static bool IsMadeOnlyOfSomeSequenceOfDigitsRepetedAtLeastTwice(long id)
{
    long countOfDigits = (long)Math.Log10(id) + 1;
    
    string idStr = id.ToString();
    
    for (int repeatedCount = 2; repeatedCount <= 19; repeatedCount++)
    {
        if (countOfDigits % repeatedCount != 0)
            continue;
        
        int partLength = (int)(countOfDigits / repeatedCount);
        HashSet<string> parts = SplitToParts(idStr, partLength);
        
        if (parts.Count == 1)
            return true;
    }

    return false;
}

static HashSet<string> SplitToParts(string str, int partLength)
{
    HashSet<string> parts = [];

    for (int i = 0; i < str.Length; i += partLength)
    {
        if (i + partLength <= str.Length)
            parts.Add(str.Substring(i, partLength));
    }

    return parts;
}