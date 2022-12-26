namespace Day11
{
    internal class Monkey
    {
        public int MonkeyNumber { get; }
        //private List<int> startingItems;
        public Queue<ulong> itemsQueue = new Queue<ulong>();
        private string operationLine;
        public int DivisibleNumber { get; }
        public int MonkeyTrueNumber { get; }
        public int MonkeyFalseNumber { get; }
        public int InspectedItems { get; set; } = 0;

        public Monkey(string monkeyNumberLine, string startingItemsLine, string operationLineString, string divisableNumLine, string throwMonkeyTrueLine, string throwMonkeyFalseLine)
        {
            MonkeyNumber = int.Parse(monkeyNumberLine[7].ToString());
            //itemsQueue = SetStartingItemsList(startingItemsLine);
            SetStartingItemsList(startingItemsLine);
            operationLine = operationLineString;
            DivisibleNumber = GetLastNumber(divisableNumLine).Value;
            MonkeyTrueNumber = (int)GetLastNumber(throwMonkeyTrueLine).Value;
            MonkeyFalseNumber = (int)GetLastNumber(throwMonkeyFalseLine).Value;
        }

        private void SetStartingItemsList(string startingItemsLine)
        {
            List<ulong>? startingItems = startingItemsLine.Remove(0, 17)
                                                        .Split(',', StringSplitOptions.TrimEntries)
                                                        .Select(ulong.Parse)
                                                        .ToList();

            startingItems.ForEach(x => itemsQueue.Enqueue(x));
        }

        public ulong RunOperation(ulong valueOne)
        {
            string[]? splitString = operationLine.Trim().Split(' ');
            string? operatorString = splitString[4];
            string? valueTwoString = splitString[5];

            ulong valueTwo;

            if (valueTwoString == "old")
            {
                valueTwo = valueOne;
            }
            else
            {
                valueTwo = ulong.Parse(valueTwoString);
            }

            if (operatorString == "*")
            {
                return valueOne * valueTwo;
            }
            else if (operatorString == "+")
            {
                return valueOne + valueTwo;
            }

            throw new NotImplementedException();
            return 0;
        }

        private int? GetLastNumber(string divisableNumLine)
        {
            var lastString = divisableNumLine.Split(' ').Last();

            int.TryParse(lastString, out int result);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public ulong GetNewItem()
        {
            ulong item = itemsQueue.Dequeue();
            InspectedItems++;
            return item;
        }

    }
}
