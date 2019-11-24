using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleArray.Util;

namespace SampleArray.Test
{
    [TestClass]
    public class HelperTest
    {
        readonly string[] uniqueArray1 = { "The", "Clean", "Coder" };
        readonly string[] uniqueArray2 = { "Book", "Of", "Genreral", "Ignorance" };
        readonly string[] duplicateArray1 = { "Head", "First", "Head", "Hunter" };
        readonly string[] duplicateArray2 = { "Freeman", "and", "Freeman" };

        IArrayAction arrayAction = null;

        [TestInitialize]
        public void Init()
        {
            arrayAction = new ArrayAction();
        }

        public void Setup() { }

        [TestMethod]
        public void JoinTwoUniqueArrayAndSortByAscendingTest()
        {
            string[] expectedResult = { "Book", "Clean", "Coder", "Genreral", "Ignorance", "Of", "The" };
            var actualResult = arrayAction.JoinAndSort(SortOrder.AtoZ, uniqueArray1, uniqueArray2);

            CollectionAssert.AreEqual(expectedResult, actualResult.UniqueArray);

            Assert.AreEqual(0, actualResult.DuplicateValues.Length);
        }

        [TestMethod]
        public void JoinTwoUniqueArrayAndSortByDescendingTest()
        {
            string[] expectedResult = { "The", "Of", "Ignorance", "Genreral", "Coder", "Clean", "Book" };
            var actualResult = arrayAction.JoinAndSort(SortOrder.ZtoA, uniqueArray1, uniqueArray2);

            CollectionAssert.AreEqual(expectedResult, actualResult.UniqueArray);
            Assert.AreEqual(0, actualResult.DuplicateValues.Length);
        }

        [TestMethod]
        public void JoinMixTypeArraysAndSortByAscendingTest()
        {
            string[] expectedResult = { "Clean", "Coder", "First", "Head", "Hunter", "The" };
            string[] expectedDuplicates = { "Head" };
            var actualResult = arrayAction.JoinAndSort(SortOrder.AtoZ, uniqueArray1, duplicateArray1);

            CollectionAssert.AreEqual(expectedResult, actualResult.UniqueArray);
            CollectionAssert.AreEqual(expectedDuplicates, actualResult.DuplicateValues);
        }

        [TestMethod]
        public void JoinMixTypeArraysAndSortByDescendingTest()
        {
            string[] expectedResult = { "The", "Hunter", "Head", "First", "Coder", "Clean" };
            string[] expectedDuplicates = { "Head" };
            var actualResult = arrayAction.JoinAndSort(SortOrder.ZtoA, uniqueArray1, duplicateArray1);

            CollectionAssert.AreEqual(expectedResult, actualResult.UniqueArray);
            CollectionAssert.AreEqual(expectedDuplicates, actualResult.DuplicateValues);
        }

        [TestMethod]
        public void JoinTwoDuplicateArraysAndSortByAscendingTest()
        {
            string[] expectedResult = { "and", "First", "Freeman", "Head", "Hunter" };
            string[] expectedDuplicates = { "Head", "Freeman" };
            var actualResult = arrayAction.JoinAndSort(SortOrder.AtoZ, duplicateArray1, duplicateArray2);

            CollectionAssert.AreEqual(expectedResult, actualResult.UniqueArray);
            CollectionAssert.AreEqual(expectedDuplicates, actualResult.DuplicateValues);
        }

        [TestMethod]
        public void JoinTwoDuplicateArraysAndSortByDescendingTest()
        {
            string[] expectedResult = { "Hunter", "Head", "Freeman", "First", "and" };
            string[] expectedDuplicates = { "Head", "Freeman" };
            var actualResult = arrayAction.JoinAndSort(SortOrder.ZtoA, duplicateArray1, duplicateArray2);

            CollectionAssert.AreEqual(expectedResult, actualResult.UniqueArray);
            CollectionAssert.AreEqual(expectedDuplicates, actualResult.DuplicateValues);
        }

        [TestMethod]
        public void JoinThreeArrayAndSortByDescendingTest()
        {
            string[] expectedResult = { "The", "Hunter", "Head", "Freeman", "First", "Coder", "Clean", "and" };
            string[] expectedDuplicates = { "Head", "Freeman" };
            var actualResult = arrayAction.JoinAndSort(SortOrder.ZtoA, uniqueArray1, duplicateArray1, duplicateArray2);

            CollectionAssert.AreEqual(expectedResult, actualResult.UniqueArray);
            CollectionAssert.AreEqual(expectedDuplicates, actualResult.DuplicateValues);
        }
    }
}
