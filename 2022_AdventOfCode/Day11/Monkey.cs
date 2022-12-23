using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class Monkey
    {
        private List<int> startingItems;
        private string operationLine;


        public Monkey(string startingItemsLine, string operationLine, int dividableNum = 0, int throwMonkeyTrue = 0, int throwMonkeyFalse = 0)
        {
            SetStartingItemsList(startingItemsLine);
            operationLine = operationLine;
        }

        private void SetStartingItemsList(string startingItemsLine)
        {
            var startingItems = startingItemsLine.Remove(0, 17).Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private int? RunOperation(int valueOne)
        {
            string[]? splitString = operationLine.Trim().Split(' ');
            string? operatorString = splitString[4];
            string? valueTwoString = splitString[5];

            int valueTwo;

            if(valueTwoString == "old")
            {
                valueTwo = valueOne;
            }
            else
            {
                valueTwo = int.Parse(valueTwoString);
            }

            if(operatorString == "*")
            {
                return valueOne * valueTwo;
            }
            else if(operatorString == "+")
            {
                return valueOne + valueTwo;
            }
            return null;
        }

    }
}
