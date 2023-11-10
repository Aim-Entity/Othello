using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class SimulateMove: GameLogic
    {
        public SimulateMove(int[,] boardArr, Player currentPlayer, int x, int y) : base(boardArr, currentPlayer, y, x) { }

        private bool isVertFlank(int pieceY,  int pieceX, int colSize)
        {
            // The Target piece is already the opposite piece. Check if adjacent hs curretn piece ID's
            int pieceId = CurrentPlayer.ID;
            bool isFlank = false;
            if(pieceY == 0 || pieceY == colSize - 1)
            {
                isFlank = false;
            } else if ((BoardArr[pieceY - 1, pieceX] == pieceId) && (BoardArr[pieceY + 1, pieceX] == pieceId))
            {
                isFlank = true;
            }

            return isFlank;
        }

        private bool isHorizontalFlank(int pieceY, int pieceX, int rowSize)
        {
            int pieceId = CurrentPlayer.ID;
            bool isFlank = false;
            if(pieceX == 0 || pieceX == rowSize - 1)
            {
                isFlank = false;
            } else if((BoardArr[pieceY, pieceX - 1] == pieceId) && (BoardArr[pieceY, pieceX + 1] == pieceId))
            {
                isFlank = true;
            }

            return isFlank;
        }

        private bool isDiagFlank(int pieceY, int pieceX, int colSize, int rowSize)
        {
            int pieceId = CurrentPlayer.ID;
            bool isFlank = false;
            if (pieceX == 0 || pieceX == rowSize - 1 || pieceY == 0 || pieceY == colSize - 1)
            {
                isFlank = false;
            }
            else if ((BoardArr[pieceY - 1, pieceX - 1] == pieceId) && (BoardArr[pieceY + 1, pieceX + 1] == pieceId))
            {
                isFlank = true;
            } else if ((BoardArr[pieceY + 1, pieceX - 1] == pieceId) && (BoardArr[pieceY - 1, pieceX + 1] == pieceId))
            {
                isFlank = true;
            }

            return isFlank;
        }

        /*
        private void generateInternalSimulation(int x, int y, int horDisplacement, int vertDisplacement)
        {
            IllegalMove illegalMove = new IllegalMove(BoardArr, CurrentPlayer, x, y);

            if (illegalMove.checkAllSides() == false)
            {
                SimulateMove flankSimulate = new SimulateMove(BoardArr, CurrentPlayer, x + horDisplacement, y + vertDisplacement);
                flankSimulate.updateBoard();
                BoardArr = flankSimulate.BoardArr;
            }
        }
        */

        // CLEEEEEEEEEEEAN
        public void updateAllFlankPieces(int rowSize, int colSize)
        {
            int oppositePlayerId = getOppositeId(CurrentPlayer.ID);

            for (int y = 0; y < rowSize - 1; y++)
            {
                for(int x = 0; x < colSize - 1; x++)
                {
                    if (BoardArr[y, x] == oppositePlayerId)
                    {
                        /*
                        if(isVertFlank(y, x, colSize))
                        {
                            BoardArr[y, x] = CurrentPlayer.ID;
                            //MessageBox.Show("Vert Flank");
                        } 
                        else if(isHorizontalFlank(y, x, rowSize))
                        {
                            BoardArr[y, x] = CurrentPlayer.ID;
                            //MessageBox.Show("Horizontal Flank");
                        } 
                        else if(isDiagFlank(y, x, colSize, rowSize)) {
                            if((BoardArr[y - 1, x - 1] == oppositePlayerId) && (BoardArr[y + 1, x + 1] == oppositePlayerId))
                            {
                                BoardArr[y, x] = CurrentPlayer.ID;
                                //MessageBox.Show("Diag Flank 1");
                            } else if((BoardArr[y + 1, x - 1] == oppositePlayerId) && (BoardArr[y - 1, x + 1] == oppositePlayerId))
                            {
                                BoardArr[y, x] = CurrentPlayer.ID;
                                //MessageBox.Show("Diag Flank 2");
                            }
                        }
                        */
                        // After each move is made, it will check if another flank is created elsewhere on the board

                        // X and Y is +1. Look at gameTileClick method in Form1.cs to see as to why.
                        //generateInternalSimulation(x + 1, y + 1, -1, 0); // Left
                        //generateInternalSimulation(x + 1, y + 1, 1, 0); // Right
                        //generateInternalSimulation(x + 1, y + 1, 0, -1); // Top
                        //generateInternalSimulation(x + 1, y + 1, 0, 1); // Bottom
                        //generateInternalSimulation(x + 1, y + 1, -1, -1); // topLeft
                        //generateInternalSimulation(x + 1, y + 1, 1, -1); // topRight
                        //generateInternalSimulation(x + 1, y + 1, -1, 1); // bottomLeft
                        //generateInternalSimulation(x + 1, y + 1, 1, 1); // bottomRight
                    }
                }
            }
        }
        private int[,] updateXPiecesOnBoard(int[,] boardClone, int direction) // -1 for left & up | 1 for right and down
        {
            int horizontalDisplacement = 0;
            int currentPieceId = this.CurrentPlayer.ID;
            int oppositePieceId = getOppositeId(currentPieceId);

            int yIndex = Y - 1;
            int xIndex = X - 1;
            while (true)
            {
                horizontalDisplacement = horizontalDisplacement + direction;
                int newXIndex = xIndex + horizontalDisplacement;
                if
                    (
                    newXIndex < 1 ||
                    newXIndex > 7 ||
                    (BoardArr[yIndex, newXIndex] == currentPieceId && horizontalDisplacement == 1 * direction) ||
                    BoardArr[yIndex, newXIndex] == 10
                    )
                {
                    boardClone = BoardArr;
                    break;
                }
                else if (BoardArr[yIndex, newXIndex] == oppositePieceId)
                {
                    boardClone[yIndex, newXIndex] = currentPieceId;
                }
                else if (BoardArr[yIndex, newXIndex] == currentPieceId && horizontalDisplacement != 1 * direction)
                {
                    break;
                }
            }

            return boardClone;
        }

        private int[,] updateYPiecesOnBoard(int[,] boardClone, int direction) // -1 for left & up | 1 for right and down
        {
            int verticalDisplacement = 0;
            int currentPieceId = this.CurrentPlayer.ID;
            int oppositePieceId = getOppositeId(currentPieceId);

            int yIndex = Y - 1;
            int xIndex = X - 1;

            while (true)
            {
                verticalDisplacement = verticalDisplacement + direction;
                int newYIndex = yIndex + verticalDisplacement;
                if
                    (
                    newYIndex < 1 ||
                    newYIndex > 7 ||
                    (BoardArr[newYIndex, xIndex] == currentPieceId && verticalDisplacement == 1 * direction) ||
                    BoardArr[newYIndex, xIndex] == 10
                    )
                {
                    boardClone = BoardArr;
                    break;
                }
                else if (BoardArr[newYIndex, xIndex] == oppositePieceId)
                {
                    boardClone[newYIndex, xIndex] = currentPieceId;
                }
                else if (BoardArr[newYIndex, xIndex] == currentPieceId && verticalDisplacement != 1 * direction)
                {
                    break;
                }
            }

            return boardClone;
        }

        private int[,] updateDiagPiecesOnBoard(int[,] boardClone, int directionY, int directionX) // -1 for left & up | 1 for right and down
        {
            int verticalDisplacement = 0;
            int horizontalDisplacement = 0;
            int currentPieceId = this.CurrentPlayer.ID;
            int oppositePieceId = getOppositeId(currentPieceId);

            int yIndex = Y - 1;
            int xIndex = X - 1;

            while (true)
            {
                verticalDisplacement = verticalDisplacement + directionY;
                horizontalDisplacement = horizontalDisplacement + directionX;
                int newYIndex = yIndex + verticalDisplacement;
                int newXIndex = xIndex + horizontalDisplacement;
                if
                    (
                    newYIndex < 0 ||
                    newYIndex > 7 ||
                    newXIndex < 0 ||
                    newXIndex > 7 ||

                    (BoardArr[newYIndex, newXIndex] == currentPieceId && verticalDisplacement == 1 * directionX) ||
                    (BoardArr[newYIndex, newXIndex] == currentPieceId && verticalDisplacement == 1 * directionY) ||
                    BoardArr[newYIndex, newXIndex] == 10)
                {
                    boardClone = BoardArr;
                    break;
                }
                else if (BoardArr[newYIndex, newXIndex] == oppositePieceId)
                {
                    boardClone[newYIndex, newXIndex] = currentPieceId;
                }
                else if (BoardArr[newYIndex, newXIndex] == currentPieceId && verticalDisplacement != 1 * directionY && horizontalDisplacement != 1 * directionX)
                {
                    break;
                }
            }

            return boardClone;
        }

        // CLEEEEEEEEEEEAN
        public void updateBoard(int placedX, int placedY)
        {

            /*
            1. Find which axis that board can be updated
            2. Switch the pieces between the head and tail to the current Player Piece ID.
                2.1 Create a placeholder board
                2.2 Update the placeholder board, if there is a gap or edge then revert the board back and mirror the loop
                2.3 If pieces updated successfully, return the updated board
            */

            IllegalMove illegalMove = new IllegalMove(BoardArr, CurrentPlayer, X, Y);
            bool isHorizontalIllegal = illegalMove.HorizontalCheck();
            bool isVerticalIllegal = illegalMove.VerticalCheck();
            bool isDiagIllegal = illegalMove.DiagCheck();

            if(!isHorizontalIllegal || !isVerticalIllegal || !isDiagIllegal)
            {
                BoardArr[placedY, placedX] = CurrentPlayer.ID;
            }

            if(isHorizontalIllegal == false)
            {
                int[,] boardClone = BoardArr;
                int[,] boardClone2 = BoardArr;

                boardClone = updateXPiecesOnBoard(boardClone, 1); // This updates the right side of placed piece

                boardClone2 = boardClone;

                boardClone2 = updateXPiecesOnBoard(boardClone2, -1); // This updates the left side of placed piece, hence -1

                BoardArr = boardClone2;
            }
            if (isVerticalIllegal == false)
            {
                int[,] boardClone = BoardArr;
                int[,] boardClone2 = BoardArr;

                boardClone = updateYPiecesOnBoard(boardClone, 1); // This updates the right side of placed piece

                boardClone2 = boardClone;

                boardClone2 = updateYPiecesOnBoard(boardClone2, -1); // This updates the left side of placed piece, hence -1

                BoardArr = boardClone2;
            }
            if (isDiagIllegal == false)
            {
                int[,] boardClone = BoardArr;
                int[,] boardClone2 = BoardArr;
                int[,] boardClone3 = BoardArr;
                int[,] boardClone4 = BoardArr;

                // Params = arr, Y, X
                boardClone = updateDiagPiecesOnBoard(boardClone, 1, 1); // bottom right

                boardClone2 = boardClone; // BC2 becomes BC. Data from BC is passed to BC2. 
                boardClone2 = updateDiagPiecesOnBoard(boardClone2, 1, -1); // bottom left

                boardClone3 = boardClone2;
                boardClone3 = updateDiagPiecesOnBoard(boardClone3, -1, 1); // top right

                boardClone4 = boardClone3;
                boardClone4 = updateDiagPiecesOnBoard(boardClone4, -1, -1); // top left

                BoardArr = boardClone2;
            }
        }
    }
}
