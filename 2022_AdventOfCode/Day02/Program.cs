//Part 1: 30min

List<string>? lines = File.ReadAllLines("../../../input/input.txt").ToList();

int? finalScorePartOne = 0;
int? finalScorePartTwo = 0;

foreach (var line in lines)
{
    var chars = line.Split(' ');
    var charOne = char.Parse(chars[0]);
    var charTwo = char.Parse(chars[1]);

    //Part 1:
    var charValue = GetValue(charTwo);
    var winningValue = GetScoreByMine(charOne, charTwo);

    finalScorePartOne += charValue + winningValue;

    //Part 2:
    var winningCharVal = GetResultScore(charOne);
    var winningValueTwo = GetScoreByWinning(charOne, charTwo);

    finalScorePartTwo += winningCharVal + winningValueTwo;
}

int? GetValue(char mine)
{
    switch (mine)
    {
        case 'X':
            return 1;
            break;
        case 'Y':
            return 2;
            break;
        case 'Z':
            return 3;
            break;
    }

    return null;
}

int? GetResultScore(char mine)
{
    switch (mine)
    {
        case 'X':
            return 0;
            break;
        case 'Y':
            return 3;
            break;
        case 'Z':
            return 6;
            break;
    }

    return null;
}

int? GetScoreByMine(char opponent, char mine)
{
    switch (opponent)
    {
        case 'A':   //Rock
            if (mine == 'X')    // Rock
                return 3;   //draw
            if (mine == 'Y') //Paper
                return 6;   //win
            if (mine == 'Z') // Scissors
                return 0;   //lost
            break;
        case 'B':   //Paper
            if (mine == 'X')    // Rock
                return 0;
            if (mine == 'Y') //Paper
                return 3;
            if (mine == 'Z') // Scissors
                return 6;
            break;
        case 'C':   //Scissors
            if (mine == 'X')    // Rock
                return 6;
            if (mine == 'Y') //Paper
                return 0;
            if (mine == 'Z') // Scissors
                return 3;
            break;
        default:
            new System.Exception();
            break;
    }
    return null;
}

// Part 2: 20min

// X == lose
// Y == draw
// Z == win

// Rock == 1
// Paper == 2
// Scissors == 3

int? GetScoreByWinning(char opponent, char winning)
{
    switch (opponent)
    {
        case 'A':   //Rock
            if (winning == 'X') // Lose
                return 3;
            if (winning == 'Y') // Draw
                return 1;
            if (winning == 'Z') // Win
                return 2;
            break;
        case 'B':   //Paper
            if (winning == 'X') // Lose
                return 1;
            if (winning == 'Y') // Draw
                return 2;
            if (winning == 'Z') // Win
                return 3;
            break;
        case 'C':   //Scissors
            if (winning == 'X') // Lose
                return 2;
            if (winning == 'Y') // Draw
                return 3;
            if (winning == 'Z') // Win
                return 1;
            break;
        default:
            new System.Exception();
            break;
    }
    return null;
}

Console.WriteLine("Part 1: " + finalScorePartOne);
Console.WriteLine("Part 2: " + finalScorePartTwo);