using System.ComponentModel;
using System.Linq;
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
        private static bool _BlackPiecesround = false;
        private static bool _ChooseYourMoveMenuLoopController = true;

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

            for (int i = 0; i < WhitePiecesPositions.GetLength(0); i++)
            {
                for (int j = 0; j < WhitePiecesPositions.GetLength(1); j++)
                {
                    Console.Write(WhitePiecesPositions[i, j] + "\t");
                }
                Console.WriteLine();
            }

            WriteLine("test: " + ChessBoardViewer.ConvertPieceNumberToUnicodeSymbol(1));
            ReadKey();

            while (_ShouldContinue) { 
                ChessBoardViewer.PrintBoardActualStatus(8,8, BlackPiecesPositions, WhitePiecesPositions);
                while (_ChooseYourMoveMenuLoopController) {
                    WriteChooseYourMoveMessage(_BlackPiecesround ? "White" : "Black");
                    string? userInput = Console.ReadLine();
                    WriteLine(userInput);

                    if(!CheckIfChoosenPiecePositionIsRight(userInput, _BlackPiecesround ? WhitePiecesPositions : BlackPiecesPositions)) continue;

                    WriteLine(string.Equals(userInput, "1"));
                    if (string.Equals(userInput, "1")) _ShouldContinue = false;
                }
            }
            _ShouldContinue = true;
        }

        public static bool CheckIfChoosenPiecePositionIsRight(string? userInput, int[,] PiecePositions)
        {
            if (userInput == null || userInput.Length != 2) { WriteWrongPiecePosition(); return false; }

            int positionNumber, convertedPositionLetter;
            if(!int.TryParse(userInput[1].ToString(), out positionNumber)) { WriteWrongPiecePosition(); return false; };

            if (ConvertLetterToPosition != null || 0 < positionNumber && positionNumber < 9) { WriteWrongPiecePosition(); return false; }
            if (ConvertLetterToPosition(userInput[0].ToString()) != null) { convertedPositionLetter = (int)ConvertLetterToPosition(userInput[0].ToString())!; }
            else { return false; }
            if (PiecePositions[convertedPositionLetter, positionNumber] == 0) { WriteWrongPiecePosition();  return false; };

            return true;
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

        public static int? ConvertLetterToPosition(string Letter)
        {
            switch (Letter)
            {
                case "a": return 1;
                case "b": return 2;
                case "c": return 3;
                case "d": return 4;
                case "e": return 5;
                case "f": return 6;
                case "g": return 7;
                case "h": return 8;
                default: return null;
            }
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
            WhitePiecesPositions[5, 7] = 3;
            BlackPiecesPositions[2, 0] = 3;
            BlackPiecesPositions[5, 0] = 3;
            
            // Knights
            WhitePiecesPositions[1, 7] = 4;
            WhitePiecesPositions[6, 7] = 4;
            BlackPiecesPositions[1, 0] = 4;
            BlackPiecesPositions[6, 0] = 4;

            // Rooks
            WhitePiecesPositions[0, 7] = 5;
            WhitePiecesPositions[7, 7] = 5;
            BlackPiecesPositions[0, 0] = 5;
            BlackPiecesPositions[7, 0] = 5;

            // Pawns
            for(int i = 0; i < 8; i++)
            {
                WhitePiecesPositions[i, 6] = 6;
                BlackPiecesPositions[i, 1] = 6;
            }
        }
    }
}
