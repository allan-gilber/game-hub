using GameHub.Controllers.ChessControllers;
using GameHub.Controllers.Tic_tac_toe;
using GameHub.Models;
using static System.Console;

namespace GameHub.Controllers
{
    public static class MenuController
    {
        internal static bool MainLoopControler { get; set; } = true;
        internal static bool InternalMenuLoopControler { get; set; } = true;

        public static void LoginMenu()
        {
            while (MainLoopControler)
            {
                ConsolePrinterController.WriteLoginMenu();
                string? userInput = Console.ReadLine();
                int choosedOption;
                if (!Int32.TryParse(userInput, out choosedOption)) { ConsolePrinterController.WriteInvalidOptionMessage(); continue; }
                
                switch (choosedOption)
                {
                    case 0:
                        _AppShutdown();
                        break;
                    case 1:
                        if(LoginController.Login()) MenuController.MainMenu();
                        break;
                    case 2:
                        LoginController.CreateNewAccount();
                        break;
                    default:
                        ConsolePrinterController.WriteInvalidOptionMessage();
                        Console.ReadKey();
                        break;
                }
                InternalMenuLoopControler = true;
            }
        }

        public static void MainMenu()
        {
            while (InternalMenuLoopControler)
            {
                ConsolePrinterController.WriteInternalMainMenu();
                string? userInput = Console.ReadLine();
                int choosedOption;
                if (!Int32.TryParse(userInput, out choosedOption)) { ConsolePrinterController.WriteInvalidOptionMessage(); continue; }

                switch (choosedOption)
                {
                    case 0:
                        LoginController.Logout();
                        break;
                    case 1:
                        ChessController.InitiateChessGame();
                        break;
                    case 2:
                        TicTacToeController.InitiateTictacToeGame();
                        ReadKey();
                        break;
                    case 3:
                        WriteLine("Play another game");
                        ReadKey();
                        break;
                    case 4:
                        WriteLine("Global Scoreboard");
                        ReadKey();
                        break;
                    default:
                        ConsolePrinterController.WriteInvalidOptionMessage();
                        ReadKey();
                        break;
                }
            }
        }

        private static void _AppShutdown()
        {
            MainLoopControler = false;
        }

    }
}
