//20:45 Part 1: 30min
string path = "../../../input/input.txt";
var lines = File.ReadAllLines(path);

int registerX = 1;
int cycle = 0;
Dictionary<int, int> cycleValueStorage = new Dictionary<int, int>();
List<int> relevantCycles = new List<int> { 20, 60, 100, 140, 180, 220 };

foreach (var line in lines)
{
    var splitLine = line.Split(' ');

    if (splitLine[0] == "addx")
    {
        for (int i = 1; i <= 2; i++)
        {
            cycle++;

            cycleValueStorage.Add(cycle, registerX);

            if (i == 2)
            {
                int.TryParse(splitLine[1], out int value);
                registerX += value;
            }

        }
    }
    else if (splitLine[0] == "noop")
    {
        cycle++;
        cycleValueStorage.Add(cycle, registerX);
    }
}

var result = cycleValueStorage.Where(x => relevantCycles.Contains(x.Key)).Sum(x => x.Key * x.Value);

//Console.WriteLine(result);

// Part 2: 1,5h

for (int i = 1; i <= cycleValueStorage.Count; i++)
{
    int valueOne = 0;
    int valueTwo = 0;
    int valueThree = 0;

    cycleValueStorage.TryGetValue(i, out int position);

    int drawingPosition = i % 40;
    drawingPosition = drawingPosition == 0 ? 40 : drawingPosition;

    valueOne = position;
    valueTwo = position + 1;
    valueThree = position + 2;

    if (valueOne == drawingPosition || valueTwo == drawingPosition || valueThree == drawingPosition)
    {
        Console.Write("#");
    }
    else
    {
        Console.Write(".");
    }

    if (drawingPosition == 40)
    {
        Console.WriteLine();
    }
}