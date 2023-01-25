namespace GameHub.Models.ChessPieces
{
    public interface IChessPieceModel
    {

        string PieceName { get; }
        static int PieceCode { get; }
        bool MovementLogic(string positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions, int[] enemyGraveyard);
    }
}
