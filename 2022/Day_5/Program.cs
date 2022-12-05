
string[] input = File.ReadAllLines(@"Append Path...");

var res1 = Parse(input);
var table1 = res1.Item1;
var commands1 = res1.Item2;

Console.WriteLine(Part1(table1, commands1));

var res2 = Parse(input);
var table2 = res2.Item1;
var commands2 = res2.Item2;

Console.WriteLine(Part2(table2, commands2));

/* --- Part two --- **/
static string Part2(Dictionary<int, Stack<string>> table, List<string> commands)
{
	for (int i = 0; i < commands.Count; i++)
	{
        var command = commands[i].Split().Select(x => int.Parse(x)).ToArray();
		var temp = new List<string>();

		for (int j = 0; j < command[0]; j++)
		{
			temp.Add(table[command[1]].Pop());
        }
		for (int j = temp.Count - 1; j >= 0; j--)
		{
			table[command[2]].Push(temp[j]);
		}
    }
    string res = "";
    foreach (var item in table)
    {   
		res += item.Value.Peek()[1];
    }
	return res;
}

/* --- Part One --- **/
static string Part1(Dictionary<int, Stack<string>> table, List<string> commands)
{
	for (int i = 0; i < commands.Count; i++)
	{
		var command = commands[i].Split().Select(x => int.Parse(x)).ToArray();
		for (int j = 0; j < command[0]; j++)
		{
			var item = table[command[1]].Pop();
			table[command[2]].Push(item);
		}
	}
	string res = "";
	foreach (var item in table)
	{
		res += item.Value.Peek()[1];
	}

    return res;
}

/*  Input Convert **/

static (Dictionary<int, Stack<string>>, List<string>) Parse(string[] input)
{
	var table = new Dictionary<int, Stack<string>>();
	var commands = new List<string>();
	int emptyLine = 0;

	for (int i = 0; !string.IsNullOrEmpty(input[i]); i++)
	{
		emptyLine = i + 1;
	}
	var numLine = StringToList(input[emptyLine - 1]);
	for (int i = 0; i < numLine.Count; i++)
	{
		table.Add(int.Parse(numLine[i]), new Stack<string>());
	}

    for (int i = emptyLine - 2; i >= 0; i--)
	{
		var lineList = StringToList(input[i]);
        for (int j = 0; j < lineList.Count; j++)
		{
			if (!string.IsNullOrEmpty(lineList[j]))
				table[j + 1].Push(lineList[j]);
		}
	}

	for (int i = emptyLine + 1; i < input.Length; i++)
	{
		var line = input[i].Split();
		commands.Add($"{line[1]} {line[3]} {line[5]}");
	}
	return (table, commands);
}

static List<string> StringToList(string line)
{
	var list = new List<string>();
    for (int j = 0; j < line.Length; j += 4)
    {
        string subStr = line.Substring(j, 3).Trim();
		list.Add(subStr);
    }
	return list;
}