namespace GameHub.Models.ChessPieces
{
    internal class Knight : IChessPieceModel
    {
        public static readonly int PieceCode = 2;

        public string PieceName => throw new NotImplementedException();

        public bool MovementLogic(string positionToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions, int[] enemyGraveyard)
        {
            throw new NotImplementedException();
        }
    }
}