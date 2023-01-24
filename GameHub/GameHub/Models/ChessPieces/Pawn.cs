
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
        public int[] ActualPiecePositionIntegerArray { get; private set; }
        private int _BaseNumberModifier { get; set; } = 1;
        private string _MovementPosition{ get; set; }

        public Pawn(string piecePosition, bool movingUpward, int[] piecePositionIntegerArray)
        {
            PiecePosition = piecePosition;
            SetActualPiecePositionIntegerArray(piecePositionIntegerArray); 
            setMovingUpwardBaseModifier(movingUpward);
        }

        public bool MovementLogic(string? positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions, int[] enemyGraveyard)
        {
            if(positionToMove == null) return false;
            int[] positionToMoveArray = new int[2] { (int) Char.GetNumericValue(positionToMove[1]) - 1 , (int)ConvertLetterToPosition(positionToMove[0])! };
            Console.WriteLine(ConvertLetterToPosition(positionToMove[0]));
            Console.WriteLine(Char.GetNumericValue(positionToMove[1]) - 1);
            Console.ReadKey();
            if (!TryMoveAction(positionToMoveArray, myPiecesPositions, enemyPiecesPositions)) { WriteWrongMovePosition(PieceName, PiecePosition); return false; }

            // Check for attack move
            if (positionToMoveArray[1] != ActualPiecePositionIntegerArray[1])
            { return CheckForDiagonalAttackMovePossibility(myPiecesPositions, positionToMoveArray, enemyPiecesPositions, enemyGraveyard); }
            if (enemyPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] != 0) enemyPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = 0;
            myPiecesPositions[ActualPiecePositionIntegerArray[0], ActualPiecePositionIntegerArray[1]] = 0;
            myPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = PieceCode;

            return true;
        }

        private void setMovingUpwardBaseModifier (bool movingUpwards){ 
            if (movingUpwards) _BaseNumberModifier = -1; 
        }

        private bool TryMoveAction(int[] movePositionArray, int[,] myPiecesPositions, int[,] enemyPiecesPositions)
        {
            // Out of bounds check
            if(movePositionArray[0] > 8 || movePositionArray[0] < 0) { return false; }

            // Impossible move check
            if (
                   Math.Abs(ActualPiecePositionIntegerArray[0] - movePositionArray[0])  > 1
                || Math.Abs(ActualPiecePositionIntegerArray[1] - movePositionArray[1]) > 1
                || Math.Abs(ActualPiecePositionIntegerArray[1] - movePositionArray[1]) < 0) 
                 { return false; }

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

        public bool CheckForDiagonalAttackMovePossibility(int[,] myPiecesPositions, int[] movePositionArray, int[,] enemyPiecesPositions, int[] enemyGraveyard)
        {
            if (movePositionArray[0] != (ActualPiecePositionIntegerArray[0] + _BaseNumberModifier)) return false;
            if (enemyPiecesPositions[movePositionArray[0], movePositionArray[1]] == 0) return false;

            myPiecesPositions[ActualPiecePositionIntegerArray[0], ActualPiecePositionIntegerArray[1]] = 0;
            myPiecesPositions[movePositionArray[0], movePositionArray[1]] = PieceCode;
            enemyPiecesPositions[movePositionArray[0], movePositionArray[1]] = 0;
            enemyGraveyard[PieceCode]++;

            return true;
        }

        public void SetActualPiecePositionIntegerArray(int[] piecePositionIntegerArray) {
            ActualPiecePositionIntegerArray = new int[2] { piecePositionIntegerArray[0], piecePositionIntegerArray[1] };
        }
    }
}