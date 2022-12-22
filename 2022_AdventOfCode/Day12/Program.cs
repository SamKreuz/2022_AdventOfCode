// Part 1: 3-5h?, Part 2: 1h
string path = "../../../input/input.txt";
string[] input = File.ReadAllLines(path);

int[,] array = CreateArray(input);

char startChar = 'S';
char targetChar = 'E';

(int, int) startingNode = (0,0);
(int, int) targetNode = (0, 0);

int lengthX = array.GetLength(0);
int lengthY = array.GetLength(1);
int length = lengthX * lengthY;

List<(int, int)> startingPositions= new List<(int, int)> ();

for(int x = 0; x < lengthX; x++)
{
    for (int y = 0; y < lengthY; y++)
    {
        //visitedNodes[(x, y)] = false;

        if (array[x, y] == startChar)
        {
            array[x, y] = 'a';
            startingNode = (x, y);
        }

        if (array[x, y] == targetChar)
        {
            array[x, y] = 'z';
            targetNode = (x, y);
        }

        if(array[x, y] == 'a')
        {
            startingPositions.Add((x, y));
        }
    }
}

//array[startingNode.Item1, startingNode.Item2] = 'a';
//array[targetNode.Item1, targetNode.Item2] = 'z';

List<int> pathSteps = new List<int> ();
foreach((int, int) start in startingPositions)
{
    int? steps = GetBFSSteps(start, targetNode);

    if(steps != null)
    {
        pathSteps.Add(steps.Value);
    }
}

pathSteps.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));

Console.WriteLine(GetBFSSteps(startingNode, targetNode)); 

int? GetBFSSteps((int, int) start, (int, int) end)
{
    var visitedNodes = new List<(int, int)>();
    var parentNode = new Dictionary<(int, int), (int parentX, int parentY)>();
    Queue<(int, int)> processingQueue = new Queue<(int, int)>();
    processingQueue.Enqueue(start);

    bool found = false;
    while (!found && processingQueue.Any())
    {
        var currentNode = processingQueue.Dequeue();
        visitedNodes.Add(currentNode);

        if (currentNode != end)
        {
            var adj = GetAdjacent(currentNode);
            adj.ForEach(adjNode =>
            {
                if (!visitedNodes.Contains(adjNode)
                && !processingQueue.Contains(adjNode)
                && (array[adjNode.Item1, adjNode.Item2] <= array[currentNode.Item1, currentNode.Item2] + 1)
                && !found)
                {
                    processingQueue.Enqueue(adjNode);
                    if (!parentNode.ContainsKey(adjNode))
                    {
                        parentNode.Add(adjNode, currentNode);
                        if (adjNode == end)
                        {
                            found = true;
                        }
                    }
                }
            });
        }
    }

    int? steps = null;

    if (found)
    {
        steps = 0;
        GetPreviousNode(parentNode.Last().Key);

        void GetPreviousNode((int, int) node)
        {
            //Console.WriteLine(node);
            if (parentNode.ContainsKey(node))
            {
                var previous = parentNode[node];
                steps++;
                GetPreviousNode(previous);
            }
        }
    }

    return steps;
}

//Console.WriteLine(steps);


List<(int, int)> GetAdjacent((int x, int y) node)
{
    var adjacentNodes = new List<(int, int)>();

    var left = node.x - 1;
    var right = node.x + 1;
    var up = node.y - 1;
    var down = node.y + 1;

    if(left >= 0)
        adjacentNodes.Add((node.x - 1, node.y));
    if(right <= lengthX-1)
        adjacentNodes.Add((node.x + 1, node.y)); 
    if(up >= 0)
        adjacentNodes.Add((node.x, node.y - 1)); 
    if(down <= lengthY-1)
        adjacentNodes.Add((node.x, node.y + 1));

    return adjacentNodes;
}





int[,] CreateArray(string[] input)
{
    int columns = input[0].Length;
    int lines = input.Length;

    int[,] map = new int[columns, lines];

    for (int i = 0; i < lines; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            char letter = input[i][j];
            int letterNum = (int)letter;
            map[j, i] = letterNum;

        }
    }
    return map;
}

