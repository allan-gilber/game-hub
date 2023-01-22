namespace GameHub.Models.ChessPieces
{
    public interface IChessPieceModel
    {

        string PieceName { get; }
        static int PieceCode { get; }
        string PiecePosition { get; set; }
        bool MovementLogic(string positionCodeToMove, int[,] myPiecesPositions, int[,] enemyPiecesPositions);
        void SetPiecePositionIntegerArray(int[] piecePositionIntegerArray);
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
