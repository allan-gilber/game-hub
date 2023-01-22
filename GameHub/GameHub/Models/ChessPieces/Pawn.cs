
using static GameHub.Models.ChessPieces.IChessPieceModel;

namespace GameHub.Models.ChessPieces
{
    internal class Pawn : IChessPieceModel
    {
        public string PieceName { get; } = "Pawn";
        public string PiecePosition { get; set; }
        public int[] PiecePositionIntegerArray { get; private set; }

        public Pawn(string piecePosition, bool movingUpward, int[] piecePositionIntegerArray)
        {
            PiecePosition = piecePosition;
            SetPiecePositionIntegerArray(PiecePositionIntegerArray); 
            movingUpward = movingUpward;
        }

        public string MovementLogic(string positionCodeToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions)
        {
            throw new NotImplementedException();
        }

        public void SetPiecePositionIntegerArray(int[] piecePositionIntegerArray) {
            PiecePositionIntegerArray = new int[2] { piecePositionIntegerArray[0], piecePositionIntegerArray[1] };
        }
    }
}