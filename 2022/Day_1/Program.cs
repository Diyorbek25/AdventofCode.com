
string[] input = File.ReadAllLines(@"Append path...");

List<int> calories = new List<int>();

int elfCal = 0;
for (int i = 0; i < input.Length; i++)
{
    if (string.IsNullOrEmpty(input[i]))
    {
        calories.Add(elfCal);
        elfCal = 0;
    }
    else
        elfCal += Convert.ToInt32(input[i]);
}

int result1 = TotalCalories(calories);
int result2 = TotalCaloriesOfTheTopThreeElves(calories);

Console.WriteLine($"Result 1: {result1}");
Console.WriteLine($"Result 2: {result2}");


/* -- Part One --- */
static int TotalCalories(List<int> calories)
{
    return calories.Max();
}

 /* -- Part Two --- */
static int TotalCaloriesOfTheTopThreeElves(List<int> calories)
{
    calories.Sort();
    int len = calories.Count();
    return calories[len - 3] + calories[len - 2] + calories[len - 1];
}
