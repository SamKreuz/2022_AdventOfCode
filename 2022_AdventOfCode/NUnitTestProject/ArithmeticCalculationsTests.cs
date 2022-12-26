using NUnit.Framework;
using Day11;

namespace NUnitTestProject
{
    public class ArithmeticCalculationsTests
    {
        [Test]
        public void DivisibleBySeven()
        {
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleBySeven(7));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleBySeven(14));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleBySeven(1369851));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleBySeven(483595));
            //Assert.AreEqual(false, ArithmeticHelper.DivisibleBySeven(1369852));
        }

        [Test]
        public void DivisibleByEleven()
        {
            //Assert.AreEqual(false, ArithmeticHelper.DivisibleByEleven(7));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleByEleven(11));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleByEleven(22));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleByEleven(99));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleByEleven(918082));
            //Assert.AreEqual(false, ArithmeticHelper.DivisibleByEleven(91808));
            //Assert.AreEqual(true, ArithmeticHelper.DivisibleByEleven(365167484));
        }

        [Test]
        public void DivisibleByThirteen()
        { 
            Assert.AreEqual(true, ArithmeticHelper.DivisibleByThirteen(13));
            Assert.AreEqual(false, ArithmeticHelper.DivisibleByThirteen(7));
            Assert.AreEqual(false, ArithmeticHelper.DivisibleByThirteen(14));
            Assert.AreEqual(true, ArithmeticHelper.DivisibleByThirteen(26));
            Assert.AreEqual(true, ArithmeticHelper.DivisibleByThirteen(637));
            Assert.AreEqual(true, ArithmeticHelper.DivisibleByThirteen(923));
            Assert.AreEqual(true, ArithmeticHelper.DivisibleByThirteen(2911272));
        }
    }
}