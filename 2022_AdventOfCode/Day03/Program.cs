//Part 01: 35min
string path = "../../../input/input.txt";

string[]? dataLines = File.ReadAllLines(path);

int resultPartOne = 0;
int resultPartTwo = 0;

foreach (string line in dataLines)
{
    int length = line.Length;
    var segmentOne = line.Substring(0, (length / 2)).ToCharArray();
    var segmentTwo = line.Substring(length / 2).ToCharArray();

    char duplicate = segmentOne.Intersect(segmentTwo).FirstOrDefault();

    resultPartOne += GetValueByChar(duplicate);
}

Console.WriteLine("Part 1: " + resultPartOne);

int GetValueByChar(char character)
{
    int result = 0;

    if ((byte)character >= 97 && (byte)character <= 122)
    {
        result = ((byte)character) - 96;
    }
    else
    {
        result = ((byte)character) - 64 + 26;
    }
    return result;
}


// Part 2: 15min
var groupNum = dataLines.Length;

for (int i = 0; i < groupNum; i += 3)
{
    string lineOne = dataLines[i];
    string lineTwo = dataLines[i+1];
    string lineThree = dataLines[i+2];

    char resultingChar = lineOne.Intersect(lineTwo).Intersect(lineThree).FirstOrDefault();
    resultPartTwo += GetValueByChar(resultingChar);
}

Console.WriteLine("Part 2: " + resultPartTwo);