using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal class FieldCoordsValidator
    {
        public FieldCoordsValidator(string positionOfField, Dictionary<string,bool> gameField)
        {
            _gameField = gameField;
            _pos = positionOfField;
            IsMineAndPositionOfField = IsMineAndAvailable(_pos);
        }
        public bool IsMineAndPositionOfField { get; private set; }
        private Dictionary<string,bool> _gameField;
        private  string _pos;


        private bool IsMineAndAvailable(string posInDictionary)
            => _gameField.ContainsKey(posInDictionary) && _gameField[posInDictionary] == true;
    }
}
