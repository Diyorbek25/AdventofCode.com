
var lines = File.ReadAllLines(@"Append path...")
    .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val))
    .ToArray());


/* --- Part One --- **/
Console.WriteLine(PartOne(lines));

/* --- Part Two --- **/
Console.WriteLine(PartTwo(lines));

static int PartOne(IEnumerable<int[]> lines)
{
    var leftQueue = new PriorityQueue<int, int>();
    var rightQueue = new PriorityQueue<int, int>();
    int distance = 0;

    foreach (var line in lines)
    {
        leftQueue.Enqueue(line[0], line[0]);
        rightQueue.Enqueue(line[1], line[1]);
    }

    while (leftQueue.Count > 0 && rightQueue.Count > 0)
    {
        var left = leftQueue.Dequeue();
        var right = rightQueue.Dequeue();

        distance += Math.Abs(left - right);
    }

    return distance;
}


static int PartTwo(IEnumerable<int[]> lines)
{
    var dictionary = new Dictionary<int, int>();

    foreach (var right in lines.Select(line => line[1]))
    {
        if (dictionary.ContainsKey(right))
            dictionary[right]++;
        else
            dictionary.Add(right, 1);
    }

    int result = 0;

    foreach (var left in lines.Select(line => line[0]))
    {
        if (dictionary.TryGetValue(left, out int simlerNumber))
            result += (simlerNumber * left);
    }

    return result;
}