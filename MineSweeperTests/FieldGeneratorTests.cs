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
        LogicChecker logicChecker = new LogicChecker();
        Dictionary<string, bool> dictrionaryAllValuesFalse = new FieldGenerator().GenerateFieldMap(xAxis, yAxis);
        foreach (string key in dictrionaryAllValuesFalse.Keys)
        {
            dictrionaryAllValuesFalse[key] = false;
        }

        //Act
        Dictionary<string, bool> result = logicChecker.CheckLogic(dictrionaryAllValuesFalse);

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
        LogicChecker logicChecker = new LogicChecker();
        Dictionary<string, bool> dictionaryPlayground = new FieldGenerator().GenerateFieldMap(xAxis, yAxis);

        //Act
        Dictionary<string, bool> result = logicChecker.CheckLogic(dictionaryPlayground);

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
