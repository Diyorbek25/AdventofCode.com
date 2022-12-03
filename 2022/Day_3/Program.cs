/* 
 * Lowercase item types a through z have priorities 1 through 26.
 * Uppercase item types A through Z have priorities 27 through 52.
 * **/

string[] input = File.ReadAllLines(@"C:\Users\hp\Desktop\AdventofCode.com\2022\Day_3\Input.txt");


Console.WriteLine("Part 1: " + SumOfPriorities1(input));
Console.WriteLine("Part 2: " + SumOfPriorities2(input));



/* --- Part One --- */
static int SumOfPriorities1(string[] input)
{
    var set = new HashSet<char>();
	int sum = 0;

	for (int i = 0; i < input.Length; i++)
	{
		int mid = input[i].Length / 2;
		string str = input[i];

		for (int j = 0; j < str.Length; j++)
		{
			if (j < mid)
				set.Add(str[j]);
			else if (set.Contains(str[j]))
			{
				sum += (char.IsLower(str[j]) ? str[j] - 96 : str[j] - 38);
				break;
			}
		}
		set.Clear();
	}

	return sum;
}

/* --- Part One --- */
static int SumOfPriorities2(string[] input)
{
	var map = new Dictionary<char, int>();
	int sum = 0;

	for (int i = 2; i < input.Length; i += 3)
	{
		string str1 = input[i - 2];
		string str2 = input[i - 1];
		string str3 = input[i];

		for (int j = 0; j < str1.Length; j++)
		{
			if (!map.ContainsKey(str1[j]))
				map.Add(str1[j], 1);
		}
		for (int j = 0; j < str2.Length; j++)
		{
			if (map.ContainsKey(str2[j]) is true && map[str2[j]] == 1)
				map[str2[j]]++;
		}
		for (int j = 0; j < str3.Length; j++)
		{
			if (map.ContainsKey(str3[j]) && map[str3[j]] == 2)
			{
				sum += (char.IsLower(str3[j]) ? str3[j] - 96 : str3[j] - 38);
				break;
			}
		}
		map.Clear();
	}
	return sum;
}

