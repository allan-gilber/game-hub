using System.Diagnostics.Metrics;
using GameHub.Models;
using GameHub.Models.ChessPieces;
using GameHub.Models.ChessPieces.ChessPieces;
using GameHub.Views;
using static System.Console;
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Controllers.GameHubController;
using static GameHub.Views.BoardViewer;

namespace GameHub.Controllers.Tic_tac_toe
{
    internal static class TicTacToeController
    {
        public static string[,] GameStatus { get; set; } = new string[3, 3];

        // Loop controllers
        private static bool _EndOfGameLoopController = true;
        private static bool _ChooseYourMoveMenuLoopController = true;
        private static bool _RedPiecesround = false;
        private static int numberPositionToIndexConverter = 1;



        public static void InitiateTictacToeGame() {
            Clear();
            WriteTicTacToeWelcomeMessage();
            ReadKey();
            ChooseYourOpponent();
            Clear();
            PoPulateArray(3);
            while (_EndOfGameLoopController)
            {
                while (_ChooseYourMoveMenuLoopController)
                {
                    string? userInput;
                    string userSymbol = _RedPiecesround ? "O" : "X";
                    string userName = _RedPiecesround ? FirstPlayer.PersonName: SecondPlayer.PersonName;
                    string teamName = _RedPiecesround ? "Reds" : "Whites";

                    PrintTicTacToeBoard();
                    WriteChooseYourMovementMensage(_RedPiecesround ? "Red O" : "White X");
                    userInput = ReadLine();

                    if (!CheckIfIsAnValidLocation(userInput)) { WriteInvalidMovePosition(); continue; }
                    int letter, number;

                    letter = (int) ConvertLetterToPosition(Char.ToUpper(userInput![0]))!;
                    WriteLine((int)Char.GetNumericValue(userInput[1]));
                    WriteLine((int) Char.GetNumericValue(userInput[1]) - numberPositionToIndexConverter);
                    number = (int) Char.GetNumericValue(userInput[1]) - numberPositionToIndexConverter;
                    
                    GameStatus[ number, letter] = userSymbol;

                    if (CheckIfAUserHasWon()) {
                        WriteTicTacToeWinMessage(userName, teamName);
                        ReadKey();

                        _ChooseYourMoveMenuLoopController = false;
                    }

                    _RedPiecesround= !_RedPiecesround;
                }
            }
        }

        private static void PoPulateArray(int boardLength) {
            for(int letterIndex = 0; letterIndex < boardLength; letterIndex++)
            {
                for(int numberIndex = 0; numberIndex < boardLength; numberIndex++)
                {
                    GameStatus[letterIndex, numberIndex] = " ";
                }
            }
        }

        private static bool CheckIfAUserHasWon()
        {
            if (GameStatus[0, 0] != null)
            {
                string symbol = GameStatus[0, 0];

                for (int index = 0; index < 3; index++)
                {
                    if(CheckForHorizontalWin(index, symbol)) break;
                    if(CheckForVerticalWin(index, symbol)) break;

                }
            
                return false;
            }
            
            return true;
        }

        private static bool CheckForVerticalWin(int letterNumber, string symbol) {
            for (int i = 0; i < 3; i++)
            {
                if (GameStatus[letterNumber, i] != symbol) return false;
            }

            return true;
        }
        private static bool CheckForHorizontalWin(int numberPosition, string symbol){
            for (int i = 0; i < 3; i++)
            {
                if(GameStatus[i, numberPosition] != symbol) return false;
            }

            return true;
        }
            
        
        private static bool CheckIfIsAnValidLocation(string? userInput) {
            if (string.IsNullOrEmpty(userInput) || userInput.Length != 2) return false;
            WriteLine(string.IsNullOrEmpty(userInput));
            WriteLine(userInput.Length != 2);
            WriteLine(userInput.Length);

            char letter = Char.ToUpper(userInput[0]);
            int? letterNumber = ConvertLetterToPosition(letter);
            int positionNumber = (int) Char.GetNumericValue(userInput[1]) - numberPositionToIndexConverter;

            if(letterNumber == null) return false;
            if (letterNumber > 3 || letterNumber < 0) return false;
            if (positionNumber > 3 || positionNumber < 0) return false;
            if (!GameStatus[(int) letterNumber, positionNumber].Equals(" ")) { return false; }
            
            return true;
        }
    }
}
