using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class GameLogic
    {
        public GameLogic(int[,] boardArr, Player currentPlayer, int y, int x)
        {
            _boardArr = boardArr;
            _currentPlayer = currentPlayer;
            _y = y;
            _x = x;
        }

        protected int[,] _boardArr;
        public int[,] BoardArr
        {
            get => _boardArr;
        }

        protected Player _currentPlayer;
        public Player CurrentPlayer
        {
            get => _currentPlayer;
        }

        protected int _x;
        public int X
        {
            get => _x;
        }

        protected int _y;
        public int Y
        {
            get => _y;
        }

        protected int getOppositeId(int currentPieceId)
        {
            int oppositePieceId;

            if (currentPieceId == 0) oppositePieceId = 1;
            else oppositePieceId = 0;

            return oppositePieceId;
        }
    }
}
