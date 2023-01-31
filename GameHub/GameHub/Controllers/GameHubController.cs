using GameHub.Models;
using GameHub.Models.ChessPieces;
using GameHub.Models.ChessPieces.ChessPieces;
using GameHub.Views;
using static GameHub.Controllers.GameHubController;
using static System.Console;
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Views.BoardViewer;

namespace GameHub.Controllers
{
    public static class GameHubController
    {

        internal static readonly List<LoginData> SavedAccounts = new List<LoginData>();
        internal static LoginData? LoggedAccount { get; set; }
        internal static LoginData? SecondPlayer { get; set; }
        internal static LoginData? FirstPlayer { get; set; }


        public static void InitiateMenu()
        {
            MenuController.LoginMenu();
        }

        public static void ChooseYourOpponent()
        {
            bool ReceiveAccountNameLoopController = true;
            while (ReceiveAccountNameLoopController)
            {
                Clear();
                WriteInsertSecondPlayerAccount();
                string? userInput = ReadLine();

                if (userInput == null || userInput == "") { WriteInvalidAccount(); ReadKey(); continue; }
                int indexOfTheAccount = GameHubController.SavedAccounts.FindIndex(account => account.Login == userInput);
                if (indexOfTheAccount == -1) { WriteAccountNotFound(); ReadKey(); continue; }
                ReceiveAccountNameLoopController = false;
                SecondPlayer = GameHubController.SavedAccounts[indexOfTheAccount];
                FirstPlayer = GameHubController.LoggedAccount;
            }
            
        }

    }
}
