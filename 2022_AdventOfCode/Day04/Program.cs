// Part 1: 40min

string path = "../../../input/input.txt";

string[]? lines = File.ReadAllLines(path);

int containedPairs = 0;
int overlappingPairs = 0;

foreach (string line in lines)
{
    var numberCombos = line.Split(',');

    var listOne = GetAllNumbers(numberCombos[0]);
    var listTwo = GetAllNumbers(numberCombos[1]);
    var intersections = listOne.Intersect(listTwo).ToList();

    if (listOne.Count >= listTwo.Count)
    {
        var inters = listTwo.Except(listOne);
        if (!inters.Any())
        {
            containedPairs++;
        }
    }
    else if(listOne.Count <= listTwo.Count)
    {
        var inters = listOne.Except(listTwo);
        if (!inters.Any())
        {
            containedPairs++;
        }
    }

    //Part 2: 3min
    if (intersections.Any())
    {
        overlappingPairs++;
    }
}

Console.WriteLine("Part 1: " + containedPairs);
Console.WriteLine("Part 2: " + overlappingPairs);

List<int> GetAllNumbers(string fromToNumbers)
{
    List<int> numbers = new List<int>();

    int.TryParse(fromToNumbers.Split('-')[0], out int firstNum);
    int.TryParse(fromToNumbers.Split('-')[1], out int secondNum);

    if(firstNum != null && secondNum != null)
    {
        for(int i = firstNum; i <= secondNum; i++)
        {
            numbers.Add(i);
        }
    }

    return numbers;
}