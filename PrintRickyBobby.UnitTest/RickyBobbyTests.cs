using Newtonsoft.Json.Linq;
using PrintRickyBobby.Models;

namespace PrintRickyBobby.UnitTest
{
    [TestClass]
    public class RickyBobbyTests
    {
        RickyBobby rickyBobby = new RickyBobby();
        RickyBobbyArgument argument = new RickyBobbyArgument();

        [TestInitialize]
        public void StartUp()
        {
            rickyBobby = new RickyBobby();
            argument = new RickyBobbyArgument();
        }


        [TestMethod]
        public void UpperBoundLessThanPagingInfo_ThrowsException()
        {
            argument.UpperBound= 1;
            argument.Page = 1;
            argument.PageCount = 2;

            var expectedMessage = 
                $"The {nameof(argument.UpperBound)} argument must be greater than the {nameof(argument.Page)} * {nameof(argument.PageCount)} value. (Parameter 'args')";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rickyBobby.PrintRickyBobby(argument));
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestMethod]
        public void CountOfModNumPairs_Equal_1_ThrowsException()
        {
            argument.ModNamePairs.Add("string1", 3);

            var expectedMessage = $"Number of arguments must be 2. (Parameter 'ModNamePairs')";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rickyBobby.PrintRickyBobby(argument));
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestMethod]
        public void CountOfModNumPairs_Equal_3_ThrowsException()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.ModNamePairs.Add("string3", 5);

            var expectedMessage = $"Number of arguments must be 2. (Parameter 'ModNamePairs')";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rickyBobby.PrintRickyBobby(argument));
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestMethod]
        public void UpperBound_GT_MaximumUpperBoundAllowed_ThrowsException()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = argument.MaximumUpperBoundAllowed + 1;

            var expectedMessage = $"The UpperBound cannot be greater than {argument.MaximumUpperBoundAllowed}. (Parameter 'UpperBound')";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rickyBobby.PrintRickyBobby(argument));
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestMethod]
        public void UpperBound_LT_0_ThrowsException()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = -1;

            var expectedMessage = $"The UpperBound cannot be less than 0. (Parameter 'UpperBound')";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rickyBobby.PrintRickyBobby(argument));
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestMethod]
        public void Page_LT_0_ThrowsException()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = 100;
            argument.Page = -1;
            argument.PageCount = 100;

            var expectedMessage = $"The Page cannot be less than 0. (Parameter 'Page')";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rickyBobby.PrintRickyBobby(argument));
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestMethod]
        public void PageCount_LT_0_ThrowsException()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = 100;
            argument.Page = 1;
            argument.PageCount = -100;

            var expectedMessage = $"The PageCount cannot be less than 0. (Parameter 'PageCount')";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rickyBobby.PrintRickyBobby(argument));
            Assert.AreEqual(ex.Message, expectedMessage);
        }

        [TestMethod]
        public void UpperBound_Eq_100_And_Page_Default_Returns_Count_Eq_100()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = 100;

            var result = rickyBobby.PrintRickyBobby(argument);

            Assert.IsTrue(result.Count == 100);
        }

        [TestMethod]
        public void UpperBound_Eq_500_Page_Eq_1_PageCount_Eq_100_Returns_Count_Eq_100()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = 500;
            argument.Page = 1;
            argument.PageCount = 100;

            var result = rickyBobby.PrintRickyBobby(argument);

            Assert.IsTrue(result.FirstOrDefault() == "1");
            Assert.IsTrue(result.Skip(2).Take(1).FirstOrDefault() == "string1");
            Assert.IsTrue(result.Skip(3).Take(1).FirstOrDefault() == "string2");
            Assert.IsTrue(result.Count == 100);
        }

        [TestMethod]
        public void UpperBound_Eq_500_Page_Eq_2_PageCount_Eq_100_Returns_Count_Eq_100()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = 500;
            argument.Page = 2;
            argument.PageCount = 100;

            var result = rickyBobby.PrintRickyBobby(argument);

            Assert.IsTrue(result.FirstOrDefault() == "101");
            Assert.IsTrue(result.Last() == "string2");
            Assert.IsTrue(result.Skip(7).Take(1).FirstOrDefault() == "string1 string2");
            Assert.IsTrue(result.Skip(4).Take(1).FirstOrDefault() == "string1");
            Assert.IsTrue(result.Skip(11).Take(1).FirstOrDefault() == "string2");
            Assert.IsTrue(result.Count == 100);
        }

        [TestMethod]
        public void UpperBound_Eq_250000_Page_Eq_25_PageCount_Eq_1000_Returns_Count_Eq_1000()
        {
            argument.ModNamePairs.Add("string1", 3);
            argument.ModNamePairs.Add("string2", 4);
            argument.UpperBound = 250000;
            argument.Page = 25;
            argument.PageCount = 1000;

            var result = rickyBobby.PrintRickyBobby(argument);

            Assert.IsTrue(result.FirstOrDefault() == "24001");
            Assert.IsTrue(result.Last() == "string2");
            Assert.IsTrue(result.Skip(11).Take(1).FirstOrDefault() == "string1 string2");
            Assert.IsTrue(result.Skip(2).Take(1).FirstOrDefault() == "string1");
            Assert.IsTrue(result.Skip(3).Take(1).FirstOrDefault() == "string2");
            Assert.IsTrue(result.Count == 1000);
        }
    }
}