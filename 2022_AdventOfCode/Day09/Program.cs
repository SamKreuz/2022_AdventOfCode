//Part 1: 1h, Part 2: 1,5h
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
        switch (splitLine[0])
        {
            case "R":
                posHead = UpdatePositions(MovinDirection.Right, posHead);
                break;
            case "L":
                posHead = UpdatePositions(MovinDirection.Left, posHead);
                break;
            case "U":
                posHead = UpdatePositions(MovinDirection.Up, posHead);
                break;
            case "D":
                posHead = UpdatePositions(MovinDirection.Down, posHead);
                break;
        }
        
        for(int j = 0; j < posTails.Count; j++)
        {
            if(j == 0)
            {
                var direction = GetDirectionToMove(posHead, posTails[j]);
                posTails[j] = UpdatePositions(direction, posTails[j]);
            }
            else
            {
                var direction = GetDirectionToMove(posTails[j-1], posTails[j]);
                posTails[j] = UpdatePositions(direction, posTails[j]);
            }

            if(j == posTails.Count - 1)
            {
                if (!positionsList.Contains(posTails[j]))
                {
                    positionsList.Add(posTails[j]);
                }
            }
        }
        //var result = GetDirectionToMove();
        //posTail = UpdatePositions(result, posTail);
    }
}

Console.WriteLine(positionsList.Count());

(int x, int y) UpdatePositions(MovinDirection direction, (int x, int y) knot)
{
    switch (direction)
    {
        case MovinDirection.Right:
            knot.x += 1;
            break;
        case MovinDirection.Left:
            knot.x -= 1;
            break;
        case MovinDirection.Up:
            knot.y += 1;
            break;
        case MovinDirection.Down:
            knot.y -= 1;
            break;
        case MovinDirection.RightUp:
            knot.x += 1;
            knot.y += 1;
            break;
        case MovinDirection.RightDown:
            knot.x += 1;
            knot.y -= 1;
            break;
        case MovinDirection.LeftUp:
            knot.x -= 1;
            knot.y += 1;
            break;
        case MovinDirection.LeftDown:
            knot.x -= 1;
            knot.y -= 1;
            break;
    }
    return knot;
}

MovinDirection GetDirectionToMove((int x, int y) posHead, (int x, int y) posTail)
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
        || posTail.x + 1 == posHead.x && posTail.y + 2 == posHead.y
        || posTail.x + 2 == posHead.x && posTail.y + 2 == posHead.y)
    {
        return MovinDirection.RightUp;
    }

    if (posTail.x - 2 == posHead.x && posTail.y + 1 == posHead.y
    || posTail.x - 1 == posHead.x && posTail.y + 2 == posHead.y
    || posTail.x - 2 == posHead.x && posTail.y + 2 == posHead.y)
    {
        return MovinDirection.LeftUp;
    }

    if (posTail.x - 2 == posHead.x && posTail.y - 1 == posHead.y
    || posTail.x - 1 == posHead.x && posTail.y - 2 == posHead.y
    || posTail.x - 2 == posHead.x && posTail.y - 2 == posHead.y)
    {
        return MovinDirection.LeftDown;
    }

    if (posTail.x + 2 == posHead.x && posTail.y - 1 == posHead.y
    || posTail.x + 1 == posHead.x && posTail.y - 2 == posHead.y
    || posTail.x + 2 == posHead.x && posTail.y - 2 == posHead.y)
    {
        return MovinDirection.RightDown;
    }

    return MovinDirection.None;
}