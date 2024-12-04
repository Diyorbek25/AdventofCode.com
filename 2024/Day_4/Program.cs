
var lines = File.ReadAllLines("input.txt")
    .Select(line => line.ToCharArray())
    .ToArray();

System.Console.WriteLine(PartOne(lines));
System.Console.WriteLine(PartTwo(lines));

static int PartOne(char[][] words)
{
    string word = "XMAS";
    int wordCount = 0;

    var directions = new (int deltaColumn, int deltaRow)[]
    {
        (0, 1), // Horizontal to right
        (0, -1), // Horizontal to left
        (1, 0), // Vertical to bottom
        (-1, 0), // Vertical to top
        (1, 1), // Diagonal to bottom right
        (-1, -1), // Diagonal to top left
        (1, -1), // Diagonal to bottom left
        (-1, 1) // Diagonal to top right
    };

    for (int columnIndex = 0; columnIndex < words.Length; columnIndex++)
    {
        for (int rowIndex = 0; rowIndex < words[0].Length; rowIndex++)
        {
            foreach (var direction in directions)
            {
                if (words[columnIndex][rowIndex] == 'X')
                    if (Search(words, (columnIndex, rowIndex), direction, word))
                        wordCount++;
            }
        }
    }

    return wordCount;
}

static bool Search(char[][] words, (int startIndex, int endIndex) target, (int deltaColumn, int deltaRow) direction, string word)
{
    var chars = new char[word.Length];
    int columnIndex = target.startIndex, rowIndex = target.endIndex;

    for (int i = 0; i < word.Length; i++)
    {
        if (columnIndex < words.Length && rowIndex < words[0].Length && columnIndex >= 0 && rowIndex >= 0)
            chars[i] = words[columnIndex][rowIndex];

        columnIndex += direction.deltaColumn;
        rowIndex += direction.deltaRow;
    }

    return new string(chars) == word;
}


static int PartTwo(char[][] words)
{
    string word = "XMAS";
    int wordCount = 0;

    for (int columnIndex = 0; columnIndex < words.Length; columnIndex++)
    {
        for (int rowIndex = 0; rowIndex < words[0].Length; rowIndex++)
        {
            if (words[columnIndex][rowIndex] == 'A' && SearchTwo(words, (columnIndex, rowIndex)))
                wordCount++;
        }
    }

    return wordCount;
}

static bool SearchTwo(char[][] words, (int columnIndex, int rowIndex) target)
{
    var diagonalDirections = new (int columnOffset, int rowOffset)[]
    {
        (1, 1), // Diagonal to bottom right
        (-1, -1), // Diagonal to top left
        (1, -1), // Diagonal to bottom left
        (-1, 1) // Diagonal to top right
    };

    string word = "MAS";
    string reverseWord = "SAM";

    foreach (var direction in diagonalDirections)
    {
        if (!IsWithinBounds(words, target.columnIndex + direction.columnOffset, target.rowIndex + direction.rowOffset))
            return false;
    }

    for (int i = 0; i < 4;)
    {
        int bottomColumnIndex = target.columnIndex + diagonalDirections[i].columnOffset;
        int bottomRowIndex = target.rowIndex + diagonalDirections[i].rowOffset;
        i++;
        int topColumnIndex = target.columnIndex + diagonalDirections[i].columnOffset;
        int topRowIndex = target.rowIndex + diagonalDirections[i].rowOffset;
        i++;

        var wordDiodanal = new string(new char[]
        {
            words[bottomColumnIndex][bottomRowIndex],
            words[target.columnIndex][target.rowIndex],
            words[topColumnIndex][topRowIndex],
        });

        if (wordDiodanal != word && wordDiodanal != reverseWord)
            return false;
    }

    return true;
}

static bool IsWithinBounds(char[][] chars, int columnIndex, int rowIndex) => 
    columnIndex < chars.Length && rowIndex < chars[0].Length && columnIndex >= 0 && rowIndex >= 0;
