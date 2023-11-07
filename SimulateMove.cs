using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class SimulateMove: GameLogic
    {
        public SimulateMove(int[,] boardArr, Player currentPlayer, int x, int y) : base(boardArr, currentPlayer, y, x) { }

        public void updateBoard()
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

            if(isHorizontalIllegal == false)
            {
                int horizontalDisplacement = 0;
                int[,] boardClone = BoardArr;

                int currentPieceId = this.CurrentPlayer.ID;
                int oppositePieceId = getOppositeId(currentPieceId);

                int yIndex = Y - 1;
                int xIndex = X - 1;

                while(true)
                {
                    horizontalDisplacement++;
                    int newXIndex = xIndex + horizontalDisplacement;
                    MessageBox.Show($"{newXIndex}");
                    if
                        (
                        newXIndex < 1 || 
                        newXIndex > 8 || 
                        (BoardArr[yIndex, newXIndex] == currentPieceId && horizontalDisplacement == 1) ||
                        BoardArr[yIndex, newXIndex] == 10
                        )
                    {
                        boardClone = BoardArr;
                        break;
                    } else if(BoardArr[yIndex, newXIndex] == oppositePieceId)
                    {
                        boardClone[yIndex, newXIndex] = currentPieceId;
                    } else if(BoardArr[yIndex, newXIndex] == currentPieceId && horizontalDisplacement > 1)
                    {
                        break;
                    }
                }
            }
        }
    }
}
