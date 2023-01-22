namespace GameHub.Models.ChessPieces
{
    internal interface IChessPieceModel
    {
        static int PieceCode { get; }
        static string PieceName { get; }
        static string piecePosition { get; set; }

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
