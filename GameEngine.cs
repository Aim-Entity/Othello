using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class GameEngine
    {
        protected int[,] _boardArray;
        protected Player _p1;
        protected Player _p2;
        protected Player _currentPlayer;
        protected bool _gameOver;
        
        public int[,] BoardArray
        {
            get => _boardArray;
            set
            {
                _boardArray = value;
            }
        }
        public Player P1 { get => _p1; set { _p1 = value; } }
        public Player P2 { get => _p2; set { _p2 = value; } }
        public Player CurrentPlayer { get => _currentPlayer; set { _currentPlayer = value; } }
        public bool GameOver { get => _gameOver; set { _gameOver = value; } }

        public GameEngine()
        {
            _gameOver = false;
        }

        /// <summary>
        /// Checks for illegal moves, valid moves and simulates the moves before migrating the changes to main board array
        /// </summary>
        public void UpdateBoard()
        {
            // _boardArray will be updated
            // Illegal Move, Valid Move and Simulate move objects will be created and check if correct move is made in this function
        }

        public void UpdateCurrentPlayer()
        {
            if (_currentPlayer == _p1)
            {
                _currentPlayer = _p2;
            } else
            {
                _currentPlayer = _p1;
            }
        }

        public bool EndGame()
        {
            if (_gameOver)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
