namespace GameHub.Models.ChessPieces
{
    public interface IChessPieceModel
    {

        string PieceName { get; }
        static int PieceCode { get; }
        string PiecePosition { get; set; }
        bool MovementLogic(string positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions, int[] enemyGraveyard);
        void SetActualPiecePositionIntegerArray(int[] piecePositionIntegerArray);
    }
}
