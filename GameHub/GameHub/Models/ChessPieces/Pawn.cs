
using static GameHub.Models.ChessPieces.IChessPieceModel;
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Controllers.ChessControllers.ChessController;

namespace GameHub.Models.ChessPieces
{
    internal class Pawn : IChessPieceModel
    {
        public string PieceName { get; } = "Pawn";
        public int PieceCode { get; } = 6;
        public string PiecePosition { get; set; }
        public int[] PiecePositionIntegerArray { get; private set; }
        private int _BaseNumberModifier { get; set; } = -2;
        private string _MovementPosition{ get; set; }

        public Pawn(string piecePosition, string movementPosition, bool movingUpward, int[] piecePositionIntegerArray)
        {
            PiecePosition = piecePosition;
            SetPiecePositionIntegerArray(piecePositionIntegerArray); 
            MovingUpward(movingUpward);
            _MovementPosition = movementPosition;
        }
       
        private void MovingUpward (bool movingUpwards){ 
            if (movingUpwards) _BaseNumberModifier = 2; 
        }

        public bool MovementLogic(string? positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions)
        {
            int[] movePositionArray = new int[2] {(int) positionToMove[0]!, positionToMove[1] };
            int[] actualPositionArray = new int[2] { (int) ConvertLetterToPosition(positionToMove[0])!, positionToMove[1] };
            
            if (movePositionArray[0] == null || movePositionArray[1] == null) { WriteWrongMovePosition(PieceName, PiecePosition); return false; }
            if (CheckIfMoveIsPossible(movePositionArray, actualPositionArray, myPiecesPositions)){ WriteWrongMovePosition(PieceName, PiecePosition); return false; }
            myPiecesPositions[movePositionArray[0], movePositionArray[1]] = 0;
            enemyPiecesPositions[actualPositionArray[0], actualPositionArray[1]] = 0;

            return true;
        }

        private bool CheckIfMoveIsPossible(int[] movePositionArray, int[] actualPositionArray, int[,] myPiecesPositions)
        {
            // Impossible move check
            if ((movePositionArray[1] - actualPositionArray[1]) < 0 || (movePositionArray[1] + actualPositionArray[1]) < 7) return false;
            // Out of range move check
            if (movePositionArray[1] < (actualPositionArray[1] + _BaseNumberModifier) || movePositionArray[1] > (actualPositionArray[1] - _BaseNumberModifier)) return false;
            // Occupied by allied piece check
            if (myPiecesPositions[(int) movePositionArray[0]!, (int) movePositionArray[1]!] != 0) return false;

            return true;
        }
        
        public void SetPiecePositionIntegerArray(int[] piecePositionIntegerArray) {
            PiecePositionIntegerArray = new int[2] { piecePositionIntegerArray[0], piecePositionIntegerArray[1] };
        }
    }
}