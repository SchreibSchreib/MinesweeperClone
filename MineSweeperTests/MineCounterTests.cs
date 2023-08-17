using NUnit.Framework;
using Minesweeper.data.classes;

namespace MineSweeperTests;

[TestFixture]
public class MineCounterTests
{
    [TestCase("0 0")]
    [TestCase("10 8")]
    [TestCase("4 4")]
    [TestCase("3 7")]
    public void MineCounter_Initialization_ShouldSetPropertysCorrectly(string currentButton, int xAxis = 10, int yAxis = 10)
    {
        //Arrange
        Dictionary<string, bool> gameField = new FieldGenerator(xAxis, yAxis).PlayGround;
        List<bool> foundMines = new List<bool>();
        MineCounter mineCounter = new MineCounter(currentButton, gameField);

        //Act
        int[] searchScope = ScopeFinder.GetSearchScope(currentButton);
        for (int xPoint = searchScope[0]; xPoint <= searchScope[2]; xPoint++)
        {
            for (int yPoint = searchScope[1]; yPoint <= searchScope[3]; yPoint++)
            {
                string nameOfButton = xPoint + " " + yPoint;
                if (gameField.ContainsKey(nameOfButton) &&
                    nameOfButton != currentButton &&
                    gameField[nameOfButton] == true)
                {
                    foundMines.Add(true);
                }
            }
        }

        //Assert
        Assert.IsTrue(foundMines.Count == mineCounter.Count);
    }
}

