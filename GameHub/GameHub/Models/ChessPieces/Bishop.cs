namespace GameHub.Models.ChessPieces
{
    internal class Bishop : IChessPieceModel
    {
        public static readonly int PieceCode = 3;

        public string PieceName => throw new NotImplementedException();

        public bool MovementLogic(string positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions, int[] enemyGraveyard)
        {
            throw new NotImplementedException();
        }
    }
}