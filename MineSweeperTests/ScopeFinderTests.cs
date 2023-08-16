using Minesweeper.data.classes;
using NUnit.Framework;

namespace MineSweeperTests;


[TestFixture]
internal class ScopeFinderTests
{
    [TestCase("1 1", new[] { 0, 0, 2, 2 })]
    [TestCase("0 0", new[] { 0, 0, 1, 1 })]
    [TestCase("13 27", new[] { 12, 26, 14, 28})]
    [TestCase("10 10", new[] { 9, 9, 11, 11 })]
    [TestCase("320 320", new[] { 319, 319, 321, 321 })]
    public void GetSearchScope_ValidInput_ReturnsCorrectMatrix(string input, int[] expectedScope)
    {
        //Act
        int[] result = ScopeFinder.GetSearchScope(input);

        //Assert
        Assert.AreEqual(expectedScope, result);
    }
}

