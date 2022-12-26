// Part 1: 19:45-
// PArt 2: https://www.cs.cornell.edu/andru/mathclub/handouts/Divisibility#:~:text=For%20big%20numbers%2C%20alternately%20add,so%20is%20the%20whole%20number.
using Day11;

string path = "../../../input/inputdata.txt";
string[] rows = File.ReadAllLines(path);
List<Monkey> monkeys = new List<Monkey>();

//var testmonkey = new Monkey(rows[0], rows[1], rows[2], rows[3], rows[4], rows[5]);

for(int i = 0; i < rows.Length; i++)
{
    if (rows[i].StartsWith("Monkey"))
    {
        monkeys.Add(new Monkey(rows[i], rows[i + 1], rows[i + 2], rows[i + 3], rows[i + 4], rows[i + 5]));
    }
}

int rounds = 20;
for (int i = 0; i < rounds; i++)
{
    foreach (Monkey monkey in monkeys)
    {
        while (monkey.itemsQueue.Any())
        {
            int currentItem = monkey.GetNewItem();
            int mulitpliedValue = monkey.RunOperation(currentItem);
            int rounded = DivideByThreeAndRound(mulitpliedValue);
            bool divisable = DivisibleBy(monkey.DivisableNumber, rounded);
            if (divisable)
            {
                GetMonkey(monkey.MonkeyTrueNumber).itemsQueue.Enqueue(rounded);
            }
            else
            {
                GetMonkey(monkey.MonkeyFalseNumber).itemsQueue.Enqueue(rounded);
            }
        }
    }
}

Console.WriteLine("Test");

var resultingValues = monkeys.OrderByDescending(x => x.InspectedItems).Take(2).Select(x => x.InspectedItems).ToList();
var result = resultingValues[0] * resultingValues[1];
Console.WriteLine("Result = " + result);


int DivideByThreeAndRound(int input)
{
    double divided = input / 3;
    int rounded = (int)Math.Floor(divided);

    return rounded;
}

bool DivisibleBy(int divisableBy, int value)
{
    bool result = value % divisableBy == 0;
    return result;
}

Monkey GetMonkey(int number)
{
    return monkeys.FirstOrDefault(x => x.MonkeyNumber == number);
}

Console.WriteLine("Test");