//Part 1: 13:10-14:10
string path = "../../../input/input.txt";
var lines = File.ReadAllLines(path);

(int x, int y) posHead = (0, 0);
(int x, int y) posTail = (0, 0);

int numberOfKnots = 9;

List<(int x, int y)> posTails = new List<(int x, int y)>();
for(int i = 0; i < numberOfKnots; i++)
{
    posTails.Add((0, 0));
}

List<(int x, int y)> positionsList = new List<(int x, int y)>();

foreach(var line in lines)
{
    var splitLine = line.Split(' ');
    int.TryParse(splitLine[1], out int moveTimes);

    for (int i = 0; i < moveTimes; i++)
    {
        if (splitLine[0] == "R")
            posHead = UpdatePositions(MovinDirection.Right, posHead);
        else if (splitLine[0] == "L")
            posHead = UpdatePositions(MovinDirection.Left, posHead);
        else if (splitLine[0] == "U")
            posHead = UpdatePositions(MovinDirection.Up, posHead);
        else if (splitLine[0] == "D")
            posHead = UpdatePositions(MovinDirection.Down, posHead);

        var result = GetDirectionToMove();
        posTail = UpdatePositions(result, posTail);

        if (!positionsList.Contains(posTail))
        {
            positionsList.Add(posTail);
        }
    }
}

Console.WriteLine(positionsList.Count());

(int x, int y) UpdatePositions(MovinDirection direction, (int x, int y) end)
{
    switch (direction)
    {
        case MovinDirection.Right:
            end.x += 1;
            break;
        case MovinDirection.Left:
            end.x -= 1;
            break;
        case MovinDirection.Up:
            end.y += 1;
            break;
        case MovinDirection.Down:
            end.y -= 1;
            break;
        case MovinDirection.RightUp:
            end.x += 1;
            end.y += 1;
            break;
        case MovinDirection.RightDown:
            end.x += 1;
            end.y -= 1;
            break;
        case MovinDirection.LeftUp:
            end.x -= 1;
            end.y += 1;
            break;
        case MovinDirection.LeftDown:
            end.x -= 1;
            end.y -= 1;
            break;
    }
    return end;
}

MovinDirection GetDirectionToMove()
{
    if(posTail.x == posHead.x 
        && posTail.y + 2 == posHead.y)
    {
        return MovinDirection.Up;
    
    }else if(posTail.x + 2 == posHead.x 
        && posTail.y == posHead.y)
    {
        return MovinDirection.Right;
    
    }else if(posTail.x == posHead.x 
        && posTail.y - 2 == posHead.y)
    {
        return MovinDirection.Down;

    }else if(posTail.x - 2 == posHead.x 
        && posTail.y == posHead.y)
    {
        return MovinDirection.Left;
    }

    if(posTail.x + 2 == posHead.x && posTail.y + 1 == posHead.y 
        || posTail.x + 1 == posHead.x && posTail.y + 2 == posHead.y)
    {
        return MovinDirection.RightUp;
    }

    if (posTail.x - 2 == posHead.x && posTail.y + 1 == posHead.y
    || posTail.x - 1 == posHead.x && posTail.y + 2 == posHead.y)
    {
        return MovinDirection.LeftUp;
    }

    if (posTail.x - 2 == posHead.x && posTail.y - 1 == posHead.y
    || posTail.x - 1 == posHead.x && posTail.y - 2 == posHead.y)
    {
        return MovinDirection.LeftDown;
    }

    if (posTail.x + 2 == posHead.x && posTail.y - 1 == posHead.y
    || posTail.x + 1 == posHead.x && posTail.y - 2 == posHead.y)
    {
        return MovinDirection.RightDown;
    }

    return MovinDirection.None;
}