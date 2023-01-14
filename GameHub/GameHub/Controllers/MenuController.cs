using GameHub.Models;

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
                        LoginController.Login();
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
                ConsolePrinterController.WriteInternalMenu();
                string? userInput = Console.ReadLine();
                int choosedOption;
                if (!Int32.TryParse(userInput, out choosedOption)) { ConsolePrinterController.WriteInvalidOptionMessage(); continue; }

                switch (choosedOption)
                {
                    case 0:
                        LoginController.Logout();
                        break;
                    case 1:
                        LoginController.DeleteAccount();
                        break;
                    default:
                        ConsolePrinterController.WriteInvalidOptionMessage();
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
