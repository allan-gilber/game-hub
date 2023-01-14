using GameHub.Models;
using GameHub.Views;
using static System.Console;
using static GameHub.Controllers.ConsolePrinterController;


namespace GameHub.Controllers.ChessControllers
{
    internal static class ChessController
    {
        private static int[,] WhitePiecesPositions = new int[8 , 8];

        private static int[,] BlackPiecesPositions = new int[8 , 8];

        internal static LoginData? FirstPlayer { get; set; } = GameHubController.LoggedAccount;
        internal static LoginData? SecondPlayer { get; set; }

        private static bool _ShouldContinue = true;

        public static void InitiateChessGame()
        {
            Clear();
            WriteChessWelcomeMessage();
            ReadKey();
           // ChooseYourOpponent();
            PopulateChessBoard();
            Clear();
            for (int i = 0; i < BlackPiecesPositions.GetLength(0); i++)
            {
                for (int j = 0; j < BlackPiecesPositions.GetLength(1); j++)
                {
                    Console.Write(BlackPiecesPositions[i, j] + "\t");
                }
                Console.WriteLine();
            }

            ReadKey();

            while (_ShouldContinue) { 
                ChessBoardViewer.PrintBoardActualStatus(8,8);
                string? useInput = Console.ReadLine();
                WriteLine(useInput);
                WriteLine(string.Equals(useInput, "1"));
                if (string.Equals(useInput, "1")) _ShouldContinue = false;
            }
            _ShouldContinue = true;
        }

        public static void ChooseYourOpponent()
        {
            bool ReceiveAccountNameLoopController = true;
            while (ReceiveAccountNameLoopController) { 
                Clear();
                WriteInsertSecondPlayerAccount();
                string? userInput = ReadLine();

                if (userInput == null || userInput == "") { WriteInvalidAccount(); ReadKey(); continue; }
                int indexOfTheAccount = GameHubController.SavedAccounts.FindIndex(account => account.Login == userInput);
                if (indexOfTheAccount == -1) { WriteAccountNotFound(); ReadKey(); continue; }
                ReceiveAccountNameLoopController = false;
                SecondPlayer = GameHubController.SavedAccounts[indexOfTheAccount];
            }
            Clear();
            WriteGameplayersNames(FirstPlayer!.PersonName, SecondPlayer!.PersonName);
            ReadLine();
        }

        public static void PopulateChessBoard()
        {
            // King
            WhitePiecesPositions[3, 7] = 1;
            BlackPiecesPositions[3, 0] = 1;

            // Queen
            WhitePiecesPositions[4, 7] = 2;
            BlackPiecesPositions[4, 0] = 2;
            
            // Bishops
            WhitePiecesPositions[2, 7] = 3;
            WhitePiecesPositions[6, 7] = 3;
            BlackPiecesPositions[2, 0] = 3;
            BlackPiecesPositions[6, 0] = 3;
            
            // Knights
            WhitePiecesPositions[1, 7] = 4;
            WhitePiecesPositions[7, 7] = 4;
            BlackPiecesPositions[1, 0] = 4;
            BlackPiecesPositions[7, 0] = 4;

            // Rooks
            WhitePiecesPositions[0, 7] = 5;
            WhitePiecesPositions[7, 7] = 5;
            BlackPiecesPositions[7, 0] = 5;
            BlackPiecesPositions[0, 0] = 5;

            // Pawns
            for(int i = 0; i < 8; i++)
            {
                WhitePiecesPositions[i, 6] = 6;
            }

            for (int i = 0; i < 8; i++)
            {
                BlackPiecesPositions[i, 1] = 6;
            }
        }
    }
}
