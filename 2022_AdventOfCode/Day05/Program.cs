//Part 01: ca. 2h

using System.Text;

string path = "../../../input/input.txt";
string[]? allLines = File.ReadAllLines(path);
int verticalIndexOfNumeration = 8;


int numbersOfColumns = 0;

Dictionary<int, Stack<char>>? stacks = SetupData(verticalIndexOfNumeration);

var commandDataStartIndex = 10;
for(int i = commandDataStartIndex; i < allLines.Length; i++)
{
    string currentLine = allLines[i];
    string[]? splitString = currentLine.Split(' ');

    int elementsToMoveNum = int.Parse(splitString[1]);
    int fromStack = int.Parse(splitString[3]);
    int toStack = int.Parse(splitString[5]);

    // Part 01:
    //for(int j = 0; j < elementsToMove; j++)
    //{
    //    MoveStackElement(fromStack, toStack);
    //}

    //Part 02: ca 30min
    MoveMultipleStackElements(fromStack, toStack, elementsToMoveNum);
}

string? result = GetUppermostChars(stacks);
Console.WriteLine("Result: " + result);


void MoveStackElement(int fromStack, int toStack)
{
    Stack<char>? currentFromStack = stacks[fromStack];
    char character = currentFromStack.Pop();

    Stack<char>? currentToStack = stacks[toStack];
    currentToStack.Push(character);
}

void MoveMultipleStackElements(int fromStack, int toStack, int elementsNum)
{
    Stack<char> tempStack = new Stack<char>();

    Stack<char>? currentFromStack = stacks[fromStack];
    Stack<char>? currentToStack = stacks[toStack];

    for (int i = 0; i < elementsNum; i++)
    {
        tempStack.Push(currentFromStack.Pop());
    }

    for (int i = 0; i < elementsNum; i++)
    {
        currentToStack.Push(tempStack.Pop());
    }
}


Dictionary<int, Stack<char>> SetupData(int verticalIndexOfNumeration)
{
    Dictionary<int, Stack<char>> stackDictionary = new Dictionary<int, Stack<char>>();

    char lastChar = allLines[verticalIndexOfNumeration].Trim().LastOrDefault();
    numbersOfColumns = (int)Char.GetNumericValue(lastChar);

    for (int i = 1; i <= numbersOfColumns; i++)
    {
        string manualChar = Convert.ToString(i);
        int numRowIndex = allLines[verticalIndexOfNumeration].IndexOf(manualChar);

        stackDictionary.Add(i, new Stack<char>());

        for (int j = verticalIndexOfNumeration-1; j >= 0; j--)
        {
            char letter = allLines[j][numRowIndex];
            if(letter != ' ')
            {
                stackDictionary[i].Push(letter);
            }
        }
    }

    return stackDictionary;
}

string GetUppermostChars(Dictionary<int, Stack<char>>? stacks)
{
    StringBuilder upperMostChars = new StringBuilder();

    foreach(var stack in stacks)
    {
        Stack<char>? currentStack = stack.Value;
        char upmostChar = currentStack.Peek();
        upperMostChars.Append(upmostChar);
    }

    return upperMostChars.ToString();
}