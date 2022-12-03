
string[] input = File.ReadAllLines(@"Append path...");
/*
 * A, (X - 1 ball) - Rock
 * B, (Y - 2 ball) - Paper
 * C, (Z - 3 ball) - Scissors
 * */

/*
 * 0 ball if you lost
 * 3 ball if the round was a draw
 * 6 ball if you won
 * */

Console.WriteLine("Part 1: " + TotalScore1(input));
Console.WriteLine("Part 1: " + TotalScore2(input));

/* ---Part One --- */
static int TotalScore1(string[] input)
{
    Dictionary<string, int> score = new Dictionary<string, int>
    {
        {"A X", (1 + 3) }, // draw
        {"A Y", (2 + 6) }, // win
        {"A Z", (3 + 0) }, // lost
        {"B X", (1 + 0) }, // lost
        {"B Y", (2 + 3) }, // draw
        {"B Z", (3 + 6) }, // win
        {"C X", (1 + 6) }, // win
        {"C Y", (2 + 0) }, // lost
        {"C Z", (3 + 3) }  // draw
    };
    int totalScore = 0;

    for (int i = 0; i < input.Length; i++)
    {
        totalScore += score.ContainsKey(input[i]) ? score[input[i]] : 0;
    }
    return totalScore;
}

/* ---Part Two --- */
static int TotalScore2(string[] input)
{
    Dictionary<string, int> score = new Dictionary<string, int>
    {
        {"A X", (3 + 0) }, // you need end in a lose, so you choose Scissors
        {"B X", (1 + 0) }, // you need end in a lose, so you choose Rock
        {"C X", (2 + 0) }, // you need end in a lose, so you choose Paper
        {"A Y", (1 + 3) }, // you need end in a draw, so you choose Rock
        {"B Y", (2 + 3) }, // you need end in a draw, so you choose Paper
        {"C Y", (3 + 3) }, // you need end in a draw, so you choose Scissors
        {"A Z", (2 + 6) }, // you need end in a win, so you choose Paper
        {"B Z", (3 + 6) }, // you need end in a win, so you choose Scissors
        {"C Z", (1 + 6) }, // you need end in a win, so you choose Rock
    };
    int totalScore = 0;

    for (int i = 0; i < input.Length; i++)
    {
        totalScore += score.ContainsKey(input[i]) ? score[input[i]] : 0;
    }
    return totalScore;
}