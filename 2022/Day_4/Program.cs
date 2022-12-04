
string[] input = File.ReadAllLines(@"Append path....");



Console.WriteLine(Part1(input));
Console.WriteLine(Part2(input));


/* --- Part One --- */
static int Part1(string[] input)
{
    List<int[]> nums = ParseInput(input);
    int count = 0;

    for (int i = 0; i < nums.Count; i++)
    {
        if ((nums[i][0] >= nums[i][2] && nums[i][1] <= nums[i][3]) 
            || (nums[i][0] <= nums[i][2] && nums[i][1] >= nums[i][3]))
            count++;
    }
    return count;
}

static List<int[]> ParseInput(string[] input)
{
    List<int[]> result = new List<int[]>();
    for (int i = 0; i < input.Length; i++)
    {
        var nums = input[i].Split(new char[] { ',', '-' } ).
            Select(x => Convert.ToInt32(x)).ToArray();
        result.Add(nums);
    }
    return result;
}


/* --- Part Two --- */
static int Part2(string[] input)
{
    List<int[]> nums = ParseInput(input);
    int count = 0;

    for (int i = 0; i < nums.Count; i++)
    {
        if (IsOverlap(nums[i]))
            count++;
    }
    return count;
}

static bool IsOverlap(int[] pair)
{
    if (pair[1] >= pair[3] && pair[0] <= pair[3])
        return true;
    if (pair[3] >= pair[1] && pair[2] <= pair[1])
        return true;
    return false;
}