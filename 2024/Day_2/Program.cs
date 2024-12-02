

var reports = File.ReadAllLines("input.txt")
    .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList());


System.Console.WriteLine(reports.Count());


System.Console.WriteLine(PartOne(reports));
System.Console.WriteLine(PartTwo(reports));





static int PartOne(IEnumerable<List<int>> reports)
{
    var safeReportCount = 0;

    foreach (var report in reports)
    {
        var res = IsSafe(report);

        if (res.isSafe)
            safeReportCount++;
    }

    return safeReportCount;
}

static int PartTwo(IEnumerable<List<int>> reports)
{
    var safeReportCount = 0;

    foreach (var report in reports)
    {
        var res = IsSafe(report);

        if (res.isSafe)
        {
            safeReportCount++;
        }
        else
        {
            for (int i = 0; i < report.Count; i++)
            {
                var temp = report.AsEnumerable().ToList();
                temp.RemoveAt(i);

                var res2 = IsSafe(temp);
                if (res2.isSafe)
                {
                    safeReportCount++;
                    break;
                }
            }
        }
    }

    return safeReportCount;
}


static (bool isSafe, int leftIndex, int rightIndex) IsSafe(IList<int> numbers)
{
    bool isSafe = true;
    bool isIncrease = numbers[0] < numbers[1];

    for (int i = 1; i < numbers.Count; i++)
    {
        var different = numbers[i] - numbers[i - 1];
        var postiveDiff = Math.Abs(different);

        if (isIncrease && different < 0)
        {
            return (false, i - 1, i);
        }

        if (!isIncrease && different > 0)
        {
            return (false, i - 1, i);
        }

        if (postiveDiff < 1 || postiveDiff > 3)
        {
            return (false, i - 1, i);
        }
    }

    return (true, -1, -1);
}
