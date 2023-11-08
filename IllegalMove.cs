using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class IllegalMove: GameLogic
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

            int[] displacementFromEdge = { nextRow, nextCol, prevRow, prevCol };
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
            //int[,] oppositeAdjacentPieces = new int[9, 2]; // 9 Rows with 2 columns. col 1 = y | col 2 = x
            int[,] oppositeAdjacentPieces = 
                {
                    {-1, -1},
                    {-1, -1},
                    {-1, -1},
                    {-1, -1},
                    {-1, -1},
                    {-1, -1},
                    {-1, -1},
                    {-1, -1},
                    {-1, -1}
                };
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
            Illegal = true;
            // Gets all enemy pieces that is touching the new piece and places it in a 9 by 2 array
            int[,] oppositeAdjacentPieces = adjacencyCheck(8, 8);
            // If the first index of the array is -1 (range is 0-7) then there is no pieces touching the new piece.
            if (oppositeAdjacentPieces[0, 0] == -1)
            {
                Illegal = true;
            }
            else
            {
                int xIndex = X - 1; // Example xIndex = 3
                int yIndex = Y - 1; // example yIndex = 5 [5, 3]
                int currentPieceId = this.CurrentPlayer.ID;
                int oppositePieceId = getOppositeId(currentPieceId);

                int[] leftCoordIndexes = { -1, -1 }; // (y, x) coord
                int[] rightCoordIndexes = { -1, -1 }; // (y, x) coord
                for (int y = 0; y < 9; y++)
                {
                    //MessageBox.Show($"{oppositeAdjacentPieces[y, 0]} | {oppositeAdjacentPieces[y, 1]} | {yIndex} | {xIndex}");
                    // xIndex == oppositeAdjacentPieces[y, 1] is to prevent assigning left & right coords on diagonals
                    if (oppositeAdjacentPieces[y, 1] == xIndex - 1 && yIndex == oppositeAdjacentPieces[y, 0])
                    {
                        leftCoordIndexes[0] = yIndex;
                        leftCoordIndexes[1] = xIndex - 1;
                    }
                    else if (oppositeAdjacentPieces[y, 1] == xIndex + 1 && yIndex == oppositeAdjacentPieces[y, 0])
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

                if (leftCoordIndexes[0] != -1)
                {
                    while (true)
                    {
                        Illegal = true;
                        currentXCoordOnLeft--;
                        // Checks if the left is an edge or empty token
                        if ((currentXCoordOnLeft == -1 || BoardArr[leftCoordIndexes[0], currentXCoordOnLeft] == 10) && Illegal)
                        {
                            Illegal = true;
                            break;
                        }
                        else if (BoardArr[leftCoordIndexes[0], currentXCoordOnLeft] == currentPieceId)
                        {
                            Illegal = false;
                            break;
                        }

                    }
                }

                //Looping through the right
                if (rightCoordIndexes[0] != -1)
                {
                    while (true)
                    {
                        Illegal = true;
                        currentXCoordOnRight++;
                        //MessageBox.Show($"{rightCoordIndexes[0]},{currentXCoordOnRight} | {(currentXCoordOnRight == 8 || BoardArr[rightCoordIndexes[0], currentXCoordOnRight] == 10)}");
                        //MessageBox.Show($"{BoardArr[rightCoordIndexes[0], currentXCoordOnRight]}");
                        // Checks if the left is an edge or empty token
                        if ((currentXCoordOnRight == 8 || BoardArr[rightCoordIndexes[0], currentXCoordOnRight] == 10) && Illegal)
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

        public bool VerticalCheck()
        {
            Illegal = true;
            // Gets all enemy pieces that is touching the new piece and places it in a 9 by 2 array
            int[,] oppositeAdjacentPieces = adjacencyCheck(8, 8);
            // If the first index of the array is -1 (range is 0-7) then there is no pieces touching the new piece.
            if (oppositeAdjacentPieces[0, 0] == -1)
            {
                Illegal = true;
            }
            else
            {
                int xIndex = X - 1; // Example xIndex = 3
                int yIndex = Y - 1; // example yIndex = 5 [5, 3]
                int currentPieceId = this.CurrentPlayer.ID;
                int oppositePieceId = getOppositeId(currentPieceId);

                int[] topCoordIndexes = { -1, -1 }; // (y, x) coord
                int[] bottomCoordIndexes = { -1, -1 }; // (y, x) coord
                for (int y = 0; y < 9; y++)
                {
                    //MessageBox.Show($"{oppositeAdjacentPieces[y, 0]} | {oppositeAdjacentPieces[y, 1]} | {yIndex} | {xIndex}");
                    // xIndex == oppositeAdjacentPieces[y, 1] is to prevent assigning left & right coords on diagonals
                    if (oppositeAdjacentPieces[y, 1] == xIndex && yIndex - 1 == oppositeAdjacentPieces[y, 0])
                    {
                        topCoordIndexes[0] = yIndex - 1;
                        topCoordIndexes[1] = xIndex;
                    }
                    else if (oppositeAdjacentPieces[y, 1] == xIndex && yIndex + 1 == oppositeAdjacentPieces[y, 0])
                    {
                        bottomCoordIndexes[0] = yIndex + 1;
                        bottomCoordIndexes[1] = xIndex;
                    }
                }

                int currentYCoordOnTop = topCoordIndexes[0];
                int currentYCoordOnBottom = bottomCoordIndexes[0];

                //Looping through the top
                if (topCoordIndexes[0] == -1 && bottomCoordIndexes[0] == -1)
                {
                    Illegal = true;
                }

                if (topCoordIndexes[0] != -1)
                {
                    while (true)
                    {
                        Illegal = true;
                        currentYCoordOnTop--;
                        // Checks if the left is an edge or empty token
                        if ((currentYCoordOnTop == -1 || BoardArr[currentYCoordOnTop, topCoordIndexes[1]] == 10) && Illegal)
                        {
                            Illegal = true;
                            break;
                        }
                        else if (BoardArr[currentYCoordOnTop, topCoordIndexes[1]] == currentPieceId)
                        {
                            Illegal = false;
                            break;
                        }

                    }
                }

                //Looping through the bottom
                if (bottomCoordIndexes[0] != -1)
                {
                    while (true)
                    {
                        Illegal = true;
                        currentYCoordOnBottom++;
                        // Checks if the left is an edge or empty token
                        //MessageBox.Show($"{BoardArr[bottomCoordIndexes[0], bottomCoordIndexes[1]]} | {currentYCoordOnBottom},{bottomCoordIndexes[0]}");
                        if ((currentYCoordOnBottom == 8 || BoardArr[currentYCoordOnBottom, bottomCoordIndexes[1]] == 10) && Illegal)
                        {
                            Illegal = true;
                            break;
                        }
                        else if (BoardArr[currentYCoordOnBottom, bottomCoordIndexes[1]] == currentPieceId)
                        {
                            Illegal = false;
                            break;
                        }

                    }
                }
            }
            return Illegal; // If false is returned, move is not illegal.
        }

        public bool DiagCheck()
        {
            Illegal = true;
            // Gets all enemy pieces that is touching the new piece and places it in a 9 by 2 array
            int[,] oppositeAdjacentPieces = adjacencyCheck(8, 8);
            // If the first index of the array is -1 (range is 0-7) then there is no pieces touching the new piece.
            if (oppositeAdjacentPieces[0, 0] == -1)
            {
                Illegal = true;
            }
            else
            {
                int xIndex = X - 1; // Example xIndex = 3
                int yIndex = Y - 1; // example yIndex = 5 [5, 3]
                int currentPieceId = this.CurrentPlayer.ID;
                int oppositePieceId = getOppositeId(currentPieceId);

                //int[] topRight = { yIndex - 1, xIndex + 1 }; // (y, x) coord
                //int[] topLeft = { yIndex - 1, xIndex - 1 }; // (y, x) coord
                //int[] bottomRight = { yIndex + 1, xIndex + 1 }; // (y, x) coord
                //int[] bottomLeft = { yIndex + 1, xIndex - 1 }; // (y, x) coord
                int[,] corners =
                    {
                    { yIndex - 1, xIndex + 1 }, // Top Right
                    { yIndex - 1, xIndex - 1 }, // Top Left
                    { yIndex + 1, xIndex + 1 }, // Bottom Right
                    { yIndex + 1, xIndex - 1 }  // Bottom Left
                    };

                // Only stores adjacent diag pieces of opposite colour
                int[,] adjacentDiagPieces = { {-1, -1}, {-1, -1}, {-1, -1}, {-1, -1} };
                int loopCounter = 0;

                for (int i = 0; i < 4; i++)
                {
                    if ((corners[i, 0] < 8 && corners[i, 1] < 8) && (corners[i, 0] > -1 && corners[i, 1] > -1))
                    {
                        if (BoardArr[corners[i, 0], corners[i, 1]] == oppositePieceId)
                        {
                            adjacentDiagPieces[loopCounter, 0] = corners[i, 0];
                            adjacentDiagPieces[loopCounter, 1] = corners[i, 1];

                            loopCounter++;
                        }
                    }
                }
                //MessageBox.Show($"{adjacentDiagPieces[0, 0]} | {adjacentDiagPieces[0, 1]} | {adjacentDiagPieces[1, 0]} | {adjacentDiagPieces[1, 1]}");
                
                /*
                 
                1. Loop through each adjacent diagonal piece.
                2. If the current iteration doesn't have a coordinate of (-1, -1), then there is a diagonal piece
                3. Displacement is the 
                
                */
                for(int i = 0; i < 4; i++)
                {
                    if(adjacentDiagPieces[i, 0] != -1)
                    {
                        int displacementY = adjacentDiagPieces[0, 0] - yIndex;
                        int displacementX = adjacentDiagPieces[0, 1] - xIndex;
                        int currentIteration = 1;

                        while (true)
                        {
                            Illegal = true;
                            currentIteration++;
                            // if displacement == 1 => 1, 2, 3, 4, 5... | if displacement == -1 => -1, -2, -3, -4...
                            int ChangeOfDisplacementY = displacementY * currentIteration;
                            int ChangeOfDisplacementX = displacementX * currentIteration;

                            int newYCoord = yIndex + ChangeOfDisplacementY;
                            int newXCoord = xIndex + ChangeOfDisplacementX;

                            //MessageBox.Show($"{newYCoord}, {newXCoord} | {BoardArr[newYCoord, newXCoord]}");
                            if(newYCoord == -1 || newYCoord == 8 || newXCoord == -1 || newXCoord == 8)
                            {
                                break;
                            } else if(BoardArr[newYCoord, newXCoord] == 10)
                            {
                                break;
                            } else if(BoardArr[newYCoord, newXCoord] == currentPieceId)
                            {
                                Illegal = false;
                                break;
                            }
                        }
                    } 
                }
            }
            return Illegal; // If false is returned, move is not illegal.
        }

        public bool checkAllSides()
        {
            bool vert = VerticalCheck();
            bool hor = HorizontalCheck();
            bool diag = DiagCheck();

            if (!vert || !hor || !diag)
            {
                Illegal = false;
            } else
            {
                Illegal = true;
            }

            return Illegal;
        }
    }
}
