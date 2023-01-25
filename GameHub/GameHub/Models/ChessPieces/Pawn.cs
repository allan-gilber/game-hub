
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Controllers.ChessControllers.ChessController;

namespace GameHub.Models.ChessPieces
{
    internal class Pawn : IChessPieceModel
    {
        public string PieceName { get; } = "Pawn";
        public int PieceCode { get; } = 6;
        public string PiecePosition { get; private set; }
        private int[] ActualPiecePositionIntegerArray { get; set; }
        private int _BaseNumberModifier { get; set; } = 1;

        public Pawn(string piecePosition, bool movingUpward, int[] piecePositionIntegerArray)
        {
            PiecePosition = piecePosition;
            SetActualPiecePositionIntegerArray(piecePositionIntegerArray); 
            SetMovingUpwardBaseModifier(movingUpward);
            ActualPiecePositionIntegerArray = new int[2] { piecePositionIntegerArray[0], piecePositionIntegerArray[1] };
        }

        public bool MovementLogic(string? positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions, int[] enemyGraveyard)
        {
            if(positionToMove == null) return false;
            int[] positionToMoveArray = new int[2] { (int) Char.GetNumericValue(positionToMove[1]) - 1 , (int)ConvertLetterToPosition(positionToMove[0])! };
            
            // Check for move possibility
            if (TryMoveAction(positionToMoveArray, myPiecesPositions)) { 
                WriteWrongMovePosition(PieceName, PiecePosition); 
                return false; 
            }

            // Check for attack move
            if (positionToMoveArray[1] != ActualPiecePositionIntegerArray[1] && CheckForDiagonalAttackMoveImpossibility(positionToMoveArray, enemyPiecesPositions))
            { 
                myPiecesPositions[ActualPiecePositionIntegerArray[0], ActualPiecePositionIntegerArray[1]] = 0;
                myPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = PieceCode;
                enemyPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = 0;
                
                return true;
            }
            if (enemyPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] != 0) {
                enemyPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = 0;
                enemyGraveyard[PieceCode - 1]++;
            }
            myPiecesPositions[ActualPiecePositionIntegerArray[0], ActualPiecePositionIntegerArray[1]] = 0;
            myPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = PieceCode;

            return true;
        }

        private void SetMovingUpwardBaseModifier (bool movingUpwards){ 
            if (movingUpwards) _BaseNumberModifier = -1; 
        }

        private bool TryMoveAction(int[] movePositionArray, int[,] myPiecesPositions)
        {
            // Out of bounds check
            if(movePositionArray[0] > 8 || movePositionArray[0] < 0) { return false; }

            // Impossible move check
            if (
                   Math.Abs(ActualPiecePositionIntegerArray[0] - movePositionArray[0])  > 1
                || Math.Abs(ActualPiecePositionIntegerArray[1] - movePositionArray[1]) > 1
                || Math.Abs(ActualPiecePositionIntegerArray[1] - movePositionArray[1]) < 0) 
                 { Console.WriteLine("loll"); return false; }

            // Out of range move check
            if (
                   movePositionArray[0] != (ActualPiecePositionIntegerArray[0] + _BaseNumberModifier) 
                || movePositionArray[1] > (ActualPiecePositionIntegerArray[1] + 1)
                || movePositionArray[1] < (ActualPiecePositionIntegerArray[1] - 1))
            { Console.WriteLine("Out of range of the piece move."); return false; }

            // Occupied by allied piece check
            if (myPiecesPositions[movePositionArray[0], movePositionArray[1]] != 0)
            { Console.WriteLine("Allied piece in the way."); return false; }
            
            return true;
        }

        public bool CheckForDiagonalAttackMoveImpossibility(int[] movePositionArray, int[,] enemyPiecesPositions)
        {
            // Check if theres a enemy on diagonal tile
            if (enemyPiecesPositions[movePositionArray[0], movePositionArray[1]] == 0) return true;

            return false;
        }

        private void SetActualPiecePositionIntegerArray(int[] piecePositionIntegerArray) {
            ActualPiecePositionIntegerArray = new int[2] { piecePositionIntegerArray[0], piecePositionIntegerArray[1] };
        }
    }
}