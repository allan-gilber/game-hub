using static System.Console;
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Controllers.GameHubController;
using static GameHub.Views.BoardViewer;

namespace GameHub.Controllers.Tic_tac_toe
{
    internal static class TicTacToeController
    {
        public static string[,] GameStatus { get; set; } = new string[3, 3];
        private static int NumberPositionToIndexConverter = 1;
        private static int AvaibleMoves = 9;

        // Loop controllers
        private static bool _EndOfGameLoopController = true;
        private static bool _ChooseYourMoveMenuLoopController = true;
        private static bool _RedPiecesround = false;
        private static bool _NewGameLoopController = true;
        private static bool _AskForNewGameLoopController = true;

        public static void InitiateTictacToeGame() {
            Clear();
            WriteTicTacToeWelcomeMessage();
            ReadKey();
            ChooseYourOpponent();
            Clear();
            WriteTicTacToeGameplayersNames(FirstPlayer!.PersonName, SecondPlayer!.PersonName);
            ReadLine();
            Clear();
            while (_NewGameLoopController) { 
            PoPulateArray(3);
                while (_EndOfGameLoopController)
                {
                    while (_ChooseYourMoveMenuLoopController)
                    {
                        string? userInput;
                        string userSymbol = _RedPiecesround ? "O" : "X";
                        string userName = _RedPiecesround ? FirstPlayer.PersonName : SecondPlayer.PersonName;
                        string teamName = _RedPiecesround ? "Reds \"O\"" : "Whites \"X\"";

                        PrintTicTacToeBoard();
                        WriteChooseYourMovementMensage(_RedPiecesround ? "Red O" : "White X");
                        userInput = ReadLine();

                        if (!CheckIfIsAnValidLocation(userInput)) { WriteInvalidMovePosition(); continue; }
                        int letter, number;

                        letter = (int) ConvertLetterToPosition(Char.ToUpper(userInput[0]));
                        WriteLine((int)Char.GetNumericValue(userInput[1]));
                        WriteLine((int)Char.GetNumericValue(userInput[1]) - NumberPositionToIndexConverter);
                        number = (int)Char.GetNumericValue(userInput[1]) - NumberPositionToIndexConverter;

                        GameStatus[letter, number] = userSymbol;
                        AvaibleMoves--;
                        

                        if (CheckIfAUserHasWon())
                        {
                            Clear();
                            PrintTicTacToeBoard();
                            WriteTicTacToeWinMessage(teamName, userName);
                            ReadKey();

                            _ChooseYourMoveMenuLoopController = false;
                            _EndOfGameLoopController = false;
                        }

                        if (AvaibleMoves == 1)
                        {
                            Clear();
                            PrintTicTacToeBoard();
                            WriteTicTacToeDrawResultMessage();
                            ReadKey();

                            _ChooseYourMoveMenuLoopController = false;
                            _EndOfGameLoopController = false;
                        }

                        _RedPiecesround = !_RedPiecesround;
                    }
                }
                while (_AskForNewGameLoopController)
                {
                    Clear();
                    WriteTicTacToePlayAgainMessage();
                    string userInput = ReadLine();
                    if (userInput.Equals("yes"))
                    {
                        _EndOfGameLoopController = true;
                        _ChooseYourMoveMenuLoopController = true;
                        _RedPiecesround = false;
                        _AskForNewGameLoopController = false;
                        AvaibleMoves = 9;
                        continue;
                    }

                    if (userInput.Equals("no")) {
                        WriteReturningToMainMenu();
                        ReadKey();
                        _NewGameLoopController = false;
                        _AskForNewGameLoopController = false;
                        continue;
                    }
                    WriteInvalidOptionForPlayAgainConfirmationMessage();
                    ReadKey();
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
            for (int index = 0; index < 3; index++)
            {
                if(CheckForVerticalWin(index) || CheckForHorizontalWin(index)) return true;
            }

            return CheckForDiagonalWin();
        }

        private static bool CheckForVerticalWin(int columnIndex) {
            string symbol;

            if (GameStatus[columnIndex, 0] == " ") return false;
            symbol = GameStatus[columnIndex, 0];

            for (int rowNumber = 0; rowNumber < 3; rowNumber++)
            {
                if (!GameStatus[columnIndex, rowNumber].Equals(symbol)) return false;
            }

            return true;
        }

        private static bool CheckForHorizontalWin(int numberIndex){
            string symbol;

            if (GameStatus[0, numberIndex] == " ") return false;
            symbol = GameStatus[0, numberIndex];

            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                if(!GameStatus[columnIndex, numberIndex].Equals(symbol)) return false;
            }

            return true;
        }

        private static bool CheckForDiagonalWin()
        {
            return CheckLeftToRightDiagonalWin() || CheckRightToLeftDiagonalWin();
        }

        private static bool CheckLeftToRightDiagonalWin()
        {
            string symbol;

            if (GameStatus[0, 0] == " ") return false;
            symbol = GameStatus[0, 0];

            for (int index = 1; index < 3; index++)
            {
                if (GameStatus[index, index] != symbol) return false;
            }

            return true;
        }

        private static bool CheckRightToLeftDiagonalWin()
        {
            string symbol;

            if (GameStatus[2, 0] == " ") return false;
            symbol = GameStatus[2, 0];

            int columnIndex = 1;

            for (int letterIndex = 1; letterIndex > 0; letterIndex--)
            {
                if (!GameStatus[columnIndex, letterIndex].Equals(symbol)) return false;
                columnIndex++;
            }

            return true;
        }

        private static bool CheckIfIsAnValidLocation(string? userInput) {
            if (string.IsNullOrEmpty(userInput) || userInput.Length != 2) return false;

            char letter = Char.ToUpper(userInput[0]);
            int? letterNumber = ConvertLetterToPosition(letter);
            int positionNumber = (int) Char.GetNumericValue(userInput[1]) - NumberPositionToIndexConverter;

            WriteLine(!GameStatus[(int)letterNumber, positionNumber].Equals(" "));
            if(letterNumber == null) return false;
            if (letterNumber > 3 || letterNumber < 0) return false;
            if (positionNumber > 3 || positionNumber < 0) return false;
            if (!GameStatus[(int) letterNumber, positionNumber].Equals(" ")) { return false; }
            
            return true;
        }
    }
}
