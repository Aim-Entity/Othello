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
            Illegal = true;
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
        private int[,] adjacencyCheck(int rowCount, int colCount)
        {
            int xIndex = X - 1;
            int yIndex = Y - 1;

            //List<int[]> oppositeAdjacentPieces = new List<int[]>();
            int[,] oppositeAdjacentPieces = new int[9, 2]; // 9 Rows with 2 columns. col 1 = y | col 2 = x
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
                //MessageBox.Show("T1");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + nextCol;
                arrIndex++;
            }
            // Checks left
            if (BoardArr[yIndex, xIndex + prevCol] == oppositePieceId)
            {
                //MessageBox.Show("T2");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + prevCol;
                arrIndex++;
            }
            // Checks top
            if (BoardArr[yIndex + prevRow, xIndex] == oppositePieceId)
            {
                //MessageBox.Show("T3");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + prevRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex;
                arrIndex++;
            }
            // Checks bottom
            if (BoardArr[yIndex + nextRow, xIndex] == oppositePieceId)
            {
                //MessageBox.Show("T4");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + nextRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex;
                arrIndex++;
            }
            // Checks top right
            if (BoardArr[yIndex + prevRow, xIndex + nextCol] == oppositePieceId)
            {
                //MessageBox.Show("T5");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + prevRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + nextCol;
                arrIndex++;
            }
            // Checks top left
            if (BoardArr[yIndex + prevRow, xIndex + prevCol] == oppositePieceId)
            {
                //MessageBox.Show("T6");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + prevRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + prevCol;
                arrIndex++;
            }
            // Checks bottom left
            if (BoardArr[yIndex + nextRow, xIndex + prevCol] == oppositePieceId)
            {
                //MessageBox.Show("T7");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + nextRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + prevCol;
                arrIndex++;
            }
            // Checks bottom right
            if (BoardArr[yIndex + nextRow, xIndex + nextCol] == oppositePieceId)
            {
                //MessageBox.Show("T8");
                oppositeAdjacentPieces[arrIndex, 0] = yIndex + nextRow;
                oppositeAdjacentPieces[arrIndex, 1] = xIndex + nextCol;
                arrIndex++;
            }

            return oppositeAdjacentPieces;
        }

        public bool HorizontalCheck()
        {
            // Gets all enemy pieces that is touching the new piece and places it in a 9 by 2 array
            int[,] oppositeAdjacentPieces = adjacencyCheck(8, 8);
            // If the first index of the array is 0 (range is 1-8) then there is no pieces touching the new piece.
            if (oppositeAdjacentPieces[0, 0] == 0)
            {
                Illegal = true;
            } else
            {
                int xIndex = X - 1; // Example xIndex = 3
                int yIndex = Y - 1; // example yIndex = 5 [5, 3]
                int currentPieceId = this.CurrentPlayer.ID;
                int oppositePieceId = getOppositeId(currentPieceId);

                int[] leftCoordIndexes = {-1, -1}; // (y, x) coord
                int[] rightCoordIndexes = { -1, -1 }; // (y, x) coord
                for (int y = 0; y < 9; y++)
                {
                    //MessageBox.Show($"{oppositeAdjacentPieces[y, 0]} | {oppositeAdjacentPieces[y, 1]} | {yIndex} | {xIndex}");
                    // xIndex == oppositeAdjacentPieces[y, 1] is to prevent assigning left & right coords on diagonals
                    if (oppositeAdjacentPieces[y, 1] == xIndex - 1 && yIndex == oppositeAdjacentPieces[y, 0])
                    {
                        leftCoordIndexes[0] = yIndex;
                        leftCoordIndexes[1] = xIndex - 1;
                    } else if(oppositeAdjacentPieces[y, 1] == xIndex + 1 && yIndex == oppositeAdjacentPieces[y, 0])
                    {
                        rightCoordIndexes[0] = yIndex;
                        rightCoordIndexes[1] = xIndex + 1;
                    }
                }

                int currentXCoordOnLeft = leftCoordIndexes[1];
                int currentXCoordOnRight = rightCoordIndexes[1];

                //Looping through the left
                if (leftCoordIndexes[0] == -1 && rightCoordIndexes[0] == -1)
                {
                    Illegal = true;
                }
                
                if(leftCoordIndexes[0] != -1)
                {
                    while(true)
                    {
                        currentXCoordOnLeft--;
                        // Checks if the left is an edge or empty token
                        if ((currentXCoordOnLeft == -1 || BoardArr[leftCoordIndexes[0], leftCoordIndexes[1]] == 10) && Illegal)
                        {
                            Illegal = true;
                            break;
                        } else if(BoardArr[leftCoordIndexes[0], currentXCoordOnLeft] == currentPieceId)
                        {
                            Illegal = false;
                            break;
                        }

                    }
                }

                //Looping through the right
                if(rightCoordIndexes[0] != -1)
                {
                    while (true)
                    {
                        currentXCoordOnRight++;
                        MessageBox.Show($"{BoardArr[rightCoordIndexes[0], currentXCoordOnRight]}");
                        // Checks if the left is an edge or empty token
                        if ((currentXCoordOnRight == 8 || BoardArr[rightCoordIndexes[0], rightCoordIndexes[1]] == 10) && Illegal)
                        {
                            Illegal = true;
                            break;
                        }
                        else if (BoardArr[rightCoordIndexes[0], currentXCoordOnRight] == currentPieceId)
                        {
                            Illegal = false;
                            break;
                        }

                    }
                }
            }
            return Illegal; // If false is returned, move is not illegal.
        }
    }
}
