using static GameHub.Controllers.ConsolePrinterController;

namespace GameHub.Models.ChessPieces.ChessPieces
{
    internal class King : IChessPieceModel
    {
        public static int PieceCode { get; } = 1;
        public string PieceName { get; } = "KI";
        public string PiecePosition { get; set; }

        public string MovementLogic(string positionCodeToMove,int[,] myPiecesPositions, int[,] enemyPiecesPositions)
        {
            // 0 , 4
            int numberPosition = (int)positionCodeToMove[0];
            int letterPosition = (int)positionCodeToMove[1];

            if (myPiecesPositions[numberPosition, letterPosition] != 0){ WriteInvalidMovePosition(); return ""; }
            //if (enemyPiecesPositions[])

            return "";
        }
    }
}