//part 1 inkl setup: 40min
string dataString = File.ReadAllText("../../../input/input.txt");

var groups = dataString.Split("\n\n").ToList();

List<int> groupSum = new List<int>();

foreach(var group in groups)
{
    int result = 0;
    var elements = group.Split("\n").ToList();
    
    foreach(var element in elements)
    {
        if(element != "")
        {
            result += int.Parse(element.Trim());

        }
    }
    groupSum.Add (result);
}

var sortedGroup = groupSum.OrderByDescending(x => x).ToList();

Console.WriteLine("Answer part 01:" + sortedGroup.FirstOrDefault());

//sortedGroup.ForEach(x => Console.WriteLine(x));

// Part 2: 15min
int firstThreeGroups = 0;

for(int i = 0; i < 3; i++)
{
    firstThreeGroups += sortedGroup[i];
}

Console.WriteLine("Answer part 02:" + firstThreeGroups);
