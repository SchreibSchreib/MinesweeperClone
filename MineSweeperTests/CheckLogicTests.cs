using NUnit.Framework;
using Minesweeper.data.classes;

namespace MineSweeperTests;

[TestFixture]
public class CheckLogicTests
{
    [TestCase(10, 10, 3)]
    [TestCase(27, 27, 1)]
    [TestCase(13, 70, 4)]
    [TestCase(100, 100, 2)]
    public void CheckLogic_NoMinesAround_ReturnsUnchangedDictionary(int xAxis, int yAxis, int maxMines)
    {
        //Arrange
        Dictionary<string, bool> dictrionaryAllValuesFalse = new FieldGenerator(xAxis, yAxis).PlayGround;

        foreach (string key in dictrionaryAllValuesFalse.Keys)
        {
            dictrionaryAllValuesFalse[key] = false;
        }

        //Act
        Dictionary<string, bool> result = LogicCheckup.Check(dictrionaryAllValuesFalse, maxMines);

        //Assert
        bool areAnyKeyValuesDifferent = false;

        foreach (KeyValuePair<string, bool> kvp in result)
        {
            if (result[kvp.Key] != kvp.Value)
            {
                areAnyKeyValuesDifferent = true;
                break;
            }
        }
        Assert.IsFalse(areAnyKeyValuesDifferent);
    }

    [TestCase(37, 37, 2)]
    [TestCase(45, 45, 4)]
    [TestCase(50, 27, 3)]
    [TestCase(100, 100, 4)]
    public void CheckLogic_MinesAround_ReturnsChangedDictionary(int xAxis, int yAxis, int maxMines)
    {
        //Arrange
        Dictionary<string, bool> dictionaryPlayground = new FieldGenerator(xAxis, yAxis).PlayGround;
        Dictionary<string, bool> result = new Dictionary<string, bool>();

        //Act
        foreach (KeyValuePair<string, bool> kvp in dictionaryPlayground)
        {
            result.Add(kvp.Key, kvp.Value);
        }
        result = LogicCheckup.Check(result, maxMines);

        //Assert
        bool areAnyKeyValuesDifferent = false;

        foreach (KeyValuePair<string, bool> kvp in result)
        {
            if (dictionaryPlayground[kvp.Key] != kvp.Value)
            {
                areAnyKeyValuesDifferent = true;
                break;
            }
        }
        Assert.IsTrue(areAnyKeyValuesDifferent);
    }

    [TestCase(1, 1, 1)]
    public void CheckLogic_OnlyOneMineAround_ReturnsUnchangedDictionary(int xAxis, int yAxis, int maxMines)
    {
        //Arrange
        Dictionary<string, bool> dictrionaryOnlyOneMine = new FieldGenerator(xAxis, yAxis).PlayGround;

        //Act
        Dictionary<string, bool> result = LogicCheckup.Check(dictrionaryOnlyOneMine, maxMines);

        //Assert
        bool areAnyKeyValuesDifferent = false;

        foreach (KeyValuePair<string, bool> kvp in result)
        {
            if (result[kvp.Key] != kvp.Value)
            {
                areAnyKeyValuesDifferent = true;
                break;
            }
        }
        Assert.IsFalse(areAnyKeyValuesDifferent);
    }
}
