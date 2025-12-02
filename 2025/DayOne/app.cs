var input = File.ReadAllLines("input.txt")
    .Select(line => (line[0], int.Parse(line.Substring(1))))
    .ToArray();

Console.WriteLine(PartTwo(input));


static int PartOne((char, int)[] rotations)
{
    int startPoint = 50;
    int password = 0;
    
    foreach (var (direction, value) in rotations)
    {
        startPoint = direction switch
        {
            'R' => (startPoint + value) % 100,
            'L' => (startPoint - value + 100) % 100,
            _ => startPoint
        };
        
        if (startPoint == 0)
            password++;
    }

    return password;
}

static int PartTwo((char, int)[] rotations)
{
    int startPoint = 50;
    int password = 0;
    
    foreach (var (direction, value) in rotations)
    {
        for (int i = 0; i < value; i++)
        {
            startPoint = direction switch
            {
                'R' => (startPoint + 1) % 100,
                'L' => (startPoint - 1 + 100) % 100,
                _ => startPoint
            };
            
            if (startPoint == 0)
                password++;
        }
    }

    return password;
}