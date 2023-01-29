using GameHub.Models;
using GameHub.Models.ChessPieces;
using GameHub.Models.ChessPieces.ChessPieces;
using GameHub.Views;
using static System.Console;
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Controllers.GameHubController;
using static GameHub.Views.ChessBoardViewer;

namespace GameHub.Controllers.Tic_tac_toe
{
    internal class TicTacToeController
    {
        public void InitiateTictacToeGame() {
            Clear();
            WriteTicTacToeWelcomeMessage();
            ReadKey();
            ChooseYourOpponent();
            Clear();
        }
    }
}
