
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Views.BoardViewer;

namespace GameHub.Models.ChessPieces.ChessPieces
{
    internal class King : IChessPieceModel
    {
        public string PieceName { get; } = "King";
        public int PieceCode { get; } = 1;
        public string PiecePosition { get; private set; }
        private int[] ActualPiecePositionIntegerArray { get; set; }
        private int _BaseNumberModifier { get; set; } = 1;


        public King(string piecePosition, int[] piecePositionIntegerArray)
        {
            PiecePosition = piecePosition;
            SetActualPiecePositionIntegerArray(piecePositionIntegerArray);
            ActualPiecePositionIntegerArray = new int[2] { piecePositionIntegerArray[0], piecePositionIntegerArray[1] };
        }

        public bool MovementLogic(string? positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions, int[] enemyGraveyard)
        {
            if (positionToMove == null) return false;
            int[] positionToMoveArray = new int[2] { (int)Char.GetNumericValue(positionToMove[1]) - 1, (int)ConvertLetterToPosition(positionToMove[0])! };
            Console.WriteLine(ConvertLetterToPosition(positionToMove[0]));
            Console.WriteLine(Char.GetNumericValue(positionToMove[1]) - 1);
            Console.ReadKey();
            if (!TryMoveAction(positionToMoveArray, myPiecesPositions)) { WriteWrongMovePosition(PieceName, PiecePosition); return false; }

            // Check for attack move
            if (enemyPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] != 0) enemyPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = 0;
            myPiecesPositions[ActualPiecePositionIntegerArray[0], ActualPiecePositionIntegerArray[1]] = 0;
            myPiecesPositions[positionToMoveArray[0], positionToMoveArray[1]] = PieceCode;

            return true;
        }


        private bool TryMoveAction(int[] movePositionArray, int[,] myPiecesPositions)
        {
            // Out of bounds check
            if (movePositionArray[0] > 8 || movePositionArray[0] < 0) { return false; }

            // Impossible move check
            if (
                   Math.Abs(ActualPiecePositionIntegerArray[0] - movePositionArray[0]) > 1
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

        private void SetActualPiecePositionIntegerArray(int[] piecePositionIntegerArray)
        {
            ActualPiecePositionIntegerArray = new int[2] { piecePositionIntegerArray[0], piecePositionIntegerArray[1] };
        }
    }
}