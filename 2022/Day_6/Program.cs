
string input = File.ReadAllText(@"Append path...");

 /* --- Part One --- **/
Console.WriteLine(Part(input, 4));

/* --- Part Two --- **/
Console.WriteLine(Part(input, 14));




static int Part(string input, int markerLen)
{
	for (int i = 0; i <= input.Length - markerLen; i++)
	{
		string str = input.Substring(i, markerLen);
		if (CheckMarker(str))
			return i + markerLen;
	}
	return -1;
}

static bool CheckMarker(string str)
{
	HashSet<char> set = new HashSet<char>();
	for (int i = 0; i < str.Length; i++)
	{
		set.Add(str[i]);
	}
	return set.Count == str.Length;
}