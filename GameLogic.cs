using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    }

    class IllegalMove: GameLogic
    {
        protected bool _illegal = false;
        public bool Illegal
        {
            get => _illegal; set => _illegal = value;
        }
        public IllegalMove(int[,] boardArr, Player currentPlayer, int x, int y) : base(boardArr, currentPlayer, y, x)
        {
            Illegal = false;
        }

        private int getOppositeId(int currentPieceId)
        {
            int oppositePieceId;

            if (currentPieceId == 0) oppositePieceId = 1;
            else oppositePieceId = 0;

            return oppositePieceId;
        }

        // The next two methods are vile. Clean later. !IMPORTANT
        private int[] validateIfOnEdge(int rowCount, int colCount)
        {
            int xIndex = X - 1;
            int yIndex = Y - 1;

            int nextRow = 1;
            int prevRow = -1;
            int nextCol = 1;
            int prevCol = -1;

            /*
            {
            {-1, -1, -1, -1, -1, -1, -1, -1}, 
            {-1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1, -1}
            }

            */

            // Checks for bottom right edge
            if (xIndex + 1 == colCount && yIndex + 1 == rowCount)
            {
                nextRow = 0;
                nextCol = 0;
            }

            // Check for bottom left corner
            else if (yIndex + 1 == rowCount && xIndex + 1 == 1) // For 8X8 board, checks y == 8 and x == 1
            {
                nextRow = 0;
                prevCol = 0;
            }

            // Check for top left corner
            else if (yIndex + 1 == 1 && xIndex + 1 == 1) // For 8X8 board, checks y == 1 and x == 1
            {
                prevRow = 0;
                prevCol = 0;
            }

            // Check for top right corner
            else if (xIndex + 1 == colCount && yIndex + 1 == 1) // For 8X8 board, checks y == 1 and x == 8
            {
                prevRow = 0;
                nextCol = 0;
            }

            // Checks for top row, excluding corners
            else if (yIndex + 1 == 1 && (xIndex + 1 != 1 || xIndex + 1 != colCount))
            {
                prevRow = 0;
            }

            // Checks for right col, excluding corners
            else if (xIndex + 1 == colCount && (yIndex + 1 != 1 || yIndex + 1 != rowCount))
            {
                nextCol = 0;
            }

            // Checks for left col, excluding corners
            else if (xIndex + 1 == 1 && (yIndex + 1 != 1 || yIndex + 1 != rowCount))
            {
                prevCol = 0;
            }

            // Checks for bottom row, excluding corners
            else if (yIndex + 1 == rowCount && (xIndex + 1 != 1 || xIndex + 1 != colCount))
            {
                nextRow = 0;
            }

            int[] displacementFromEdge = {nextRow, nextCol, prevRow, prevCol};
            return displacementFromEdge;
        }

        /// <summary>
        /// Checks what piece the created piece is touching.
        /// If it is touching an opposing piece, it returns the coordinate of the opposing pieces.
        /// If it is not touching an opposing piece, it returns an empty list
        /// </summary>
        public int[,] adjacencyCheck(int rowCount, int colCount)
        {
            int xIndex = X - 1;
            int yIndex = Y - 1;

            //List<int[]> oppositeAdjacentPieces = new List<int[]>();
            int[,] oppositeAdjacentPieces = new int[9, 2];
            int arrIndex = 0;

            int currentPieceId = this.CurrentPlayer.ID;
            int oppositePieceId = getOppositeId(currentPieceId);

            int nextRow = validateIfOnEdge(rowCount, colCount)[0];
            int nextCol = validateIfOnEdge(rowCount, colCount)[1];
            int prevRow = validateIfOnEdge(rowCount, colCount)[2];
            int prevCol = validateIfOnEdge(rowCount, colCount)[3];

            // Checks the right
            if (BoardArr[yIndex, xIndex + nextCol] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + nextCol;
                arrIndex++;
            }
            // Checks left
            if (BoardArr[yIndex, xIndex + prevCol] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + prevCol;
                arrIndex++;
            }
            // Checks top
            if (BoardArr[yIndex + prevRow, xIndex] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + prevRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex;
                arrIndex++;
            }
            // Checks bottom
            if (BoardArr[yIndex + nextRow, xIndex] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + nextRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex;
                arrIndex++;
            }
            // Checks top right
            if (BoardArr[yIndex + prevRow, xIndex + nextCol] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + prevRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + nextCol;
                arrIndex++;
            }
            // Checks top left
            if (BoardArr[yIndex + prevRow, xIndex + prevCol] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + prevRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + prevCol;
                arrIndex++;
            }
            // Checks bottom left
            if (BoardArr[yIndex + nextRow, xIndex + prevCol] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + nextRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + prevCol;
                arrIndex++;
            }
            // Checks bottom right
            if (BoardArr[yIndex + nextRow, xIndex + nextCol] == oppositePieceId)
            {
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + nextRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + nextCol;
                arrIndex++;
            }

            return oppositeAdjacentPieces;
        }

        /*public bool VerticalCheck(int rowCount)
        {
            int xIndex = X - 1;
            int yIndex = Y - 1;
            int currentPieceId = this.CurrentPlayer.ID;

            bool isConnected = true;

            int step = 0;
            while(yIndex + step <= rowCount)
            {
                step += 1;
                if(currentPieceId == 1)
                {
                    
                }
            }
        }
        */
    }
}
