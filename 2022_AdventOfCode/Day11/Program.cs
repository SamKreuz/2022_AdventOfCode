// Part 1: 2h
// Part 2: min. 4h https://www.cs.cornell.edu/andru/mathclub/handouts/Divisibility#:~:text=For%20big%20numbers%2C%20alternately%20add,so%20is%20the%20whole%20number.
using Day11;

string path = "../../../input/inputdata.txt";
string[] rows = File.ReadAllLines(path);
//ulong moduloValue = 23 * 19 * 13 * 17;
ulong moduloValue = 2 * 13 * 3 * 17 * 19 * 7 * 11 * 5;
List<Monkey> monkeys = new List<Monkey>();

//var testmonkey = new Monkey(rows[0], rows[1], rows[2], rows[3], rows[4], rows[5]);

for(int i = 0; i < rows.Length; i++)
{
    if (rows[i].StartsWith("Monkey"))
    {
        monkeys.Add(new Monkey(rows[i], rows[i + 1], rows[i + 2], rows[i + 3], rows[i + 4], rows[i + 5]));
    }
}

//int rounds = 20;
//for (int i = 0; i < rounds; i++)
//{
//    foreach (Monkey monkey in monkeys)
//    {
//        while (monkey.itemsQueue.Any())
//        {
//            int currentItem = monkey.GetNewItem();
//            int mulitpliedValue = monkey.RunOperation(currentItem);
//            int rounded = DivideByThreeAndRound(mulitpliedValue);
//            bool divisable = DivisibleBy(monkey.DivisableNumber, rounded);
//            if (divisable)
//            {
//                GetMonkey(monkey.MonkeyTrueNumber).itemsQueue.Enqueue(rounded);
//            }
//            else
//            {
//                GetMonkey(monkey.MonkeyFalseNumber).itemsQueue.Enqueue(rounded);
//            }
//        }
//    }
//}

int rounds = 10000;
for (int i = 0; i < rounds; i++)
{
    foreach (Monkey monkey in monkeys)
    {
        while (monkey.itemsQueue.Any())
        {
            ulong currentItem = monkey.GetNewItem();
            ulong mulitpliedValue = monkey.RunOperation(currentItem);
            //int rounded = DivideByThreeAndRound(mulitpliedValue);
            ulong downScaled = mulitpliedValue % moduloValue;
            bool divisable = DivisibleBy(monkey.DivisibleNumber, downScaled);
            if (divisable)
            {
                GetMonkey(monkey.MonkeyTrueNumber).itemsQueue.Enqueue(downScaled);
            }
            else
            {
                GetMonkey(monkey.MonkeyFalseNumber).itemsQueue.Enqueue(downScaled);
            }
        }
    }
}

Console.WriteLine("Test");

List<ulong>? resultingValues = monkeys.OrderByDescending(x => x.InspectedItems).Take(2).Select(x => (ulong)x.InspectedItems).ToList();
var result = resultingValues[0] * resultingValues[1];
Console.WriteLine("Result = " + result);


int DivideByThreeAndRound(int input)
{
    double divided = input / 3;
    int rounded = (int)Math.Floor(divided);

    return rounded;
}

bool DivisibleBy(int divisableBy, ulong value)
{
    bool result = value % (ulong)divisableBy == 0;
    return result;
}


//2, 3, 5, 7, 11, 13, 17, 19
//bool DivisibleByAdvances(int divisableBy, int value)
//{
//    switch (divisableBy)
//    {
//        case 2:
//            return (value % 10) % 2 == 0;   // Is last digit divisable by 2
//            break;
//        case 3:

//            return 
//    }

//    bool result = value % divisableBy == 0;
//    return result;
//}

Monkey GetMonkey(int number)
{
    return monkeys.FirstOrDefault(x => x.MonkeyNumber == number);
}

Console.WriteLine("Test");