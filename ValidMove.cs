using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class ValidMove: GameLogic
    {
        protected bool _valid = false;
        public bool Valid
        {
            get => _valid; set => _valid = value;
        }
        public ValidMove(int[,] boardArr, Player currentPlayer, int x, int y) : base(boardArr, currentPlayer, y, x)
        {
            Valid = false; //Invalid by default
        }

        public bool checkForAnyValidMoves(int BoardRow, int BoardCol)
        {
            int num = 0;
            for(int y = 0; y <  BoardRow; y++)
            {
                for(int x = 0; x < BoardCol; x++)
                {
                    //MessageBox.Show($"}");
                    IllegalMove illegalCheck = new IllegalMove(BoardArr, CurrentPlayer, x + 1, y + 1);
                    bool isLegal = illegalCheck.checkAllSides();
                    if(isLegal == false)
                    {
                        Valid = true; // If there is one valid move, then player can play move
                    }
                }
            }
            return Valid;
        }
    }
}
