namespace GameHub.Models.ChessPieces
{
    public interface IChessPieceModel
    {

        string PieceName { get; }
        string PiecePosition { get; set; }
        int[] PiecePositionIntegerArray { get; set; }
        static int PieceCode { get; }

        string MovementLogic(string positionCodeToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions);
        /* 
        string UpMovementLogic();
        string DownMovementLogic();
        string RightMovementLogic();
        string LeftMovementLogic();
        string UpperLeftMovementLogic? { get; }
        string DownLeftMovementLogic? { get; }
        string UpperRightMovementLogic? { get; }
        string DownRightMovementLogic? { get; }
        */
    }
}
