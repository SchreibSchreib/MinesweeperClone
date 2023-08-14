using NUnit.Framework;
using Minesweeper.data.classes;

namespace MineSweeperTests;

[TestFixture]
public class FieldGeneratorTests
{
    [TestCase(10, 10)]
    [TestCase(27, 27)]
    [TestCase(13, 70)]
    [TestCase(1, 1)]
    public void CheckLogic_NoMinesAround_ReturnsUnchangedDictionary(int xAxis, int yAxis)
    {
        //Arrange
        Dictionary<string, bool> dictrionaryAllValuesFalse = new FieldGenerator(xAxis, yAxis).PlayGround;

        foreach (string key in dictrionaryAllValuesFalse.Keys)
        {
            dictrionaryAllValuesFalse[key] = false;
        }

        //Act
        LogicCheckup checkDictionary = new LogicCheckup(dictrionaryAllValuesFalse);
        Dictionary<string, bool> result = checkDictionary.GetPlaygroundDictionary;

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

    [TestCase(37, 37)]
    [TestCase(45, 45)]
    [TestCase(50, 27)]
    [TestCase(1, 1)]
    public void CheckLogic_MinesAround_ReturnsChangedDictionary(int xAxis, int yAxis)
    {
        //Arrange
        Dictionary<string, bool> dictionaryPlayground = new FieldGenerator(xAxis, yAxis).PlayGround;

        //Act
        LogicCheckup checkDictionary = new LogicCheckup(dictionaryPlayground);
        Dictionary<string,bool> result = checkDictionary.GetPlaygroundDictionary;

        //Assert
        bool areAnyKeyValuesDifferent = false;

        foreach (KeyValuePair<string, bool> kvp in result)
        {
            if (!result[kvp.Key] != kvp.Value)
            {
                areAnyKeyValuesDifferent = true;
                break;
            }
        }
        Assert.IsTrue(areAnyKeyValuesDifferent);
    }
}
