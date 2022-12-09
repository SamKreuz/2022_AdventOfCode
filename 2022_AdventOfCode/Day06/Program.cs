//Part 01 + 02 45min

string path = "../../../input/input.txt";
var data = File.ReadAllText(path);

int numberOfUniqueChars = 14;


for(int i = numberOfUniqueChars -1; i < data.Length; i++)
{
    var dataArray = new char[numberOfUniqueChars];

    for(int j = 0; j < numberOfUniqueChars; j++)
    {
        dataArray[j] = data[i - j];
    }

    if(dataArray.Distinct().Count() == numberOfUniqueChars)
    {
        Console.WriteLine("First Unique: " + (i + 1));
        break;
    }
}