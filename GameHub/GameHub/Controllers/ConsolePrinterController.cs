using System;
using static System.Console;

namespace GameHub.Controllers
{
    public static class ConsolePrinterController
    {
        public static string InvalidLoginMessage { get; } = "Failed to login: incorrect login and/or password.";
        public static string ReturnToMainMenuMessage { get; } = "Returning to main menu...";
        private static string _ReturnToLoginMenuMessage { get; } = "Returning to login menu...";

        public static void WriteInvalidOptionMessage() { 
            WriteLine("Invalid option. Please type a valid number from the menu below:"); 
        } 

        public static void WriteMessage(string Message)
        {
            WriteLine(Message);
        }

        public static void WriteLoginMenu()
        {
            Clear();
            WriteLine("1 - Login");
            WriteLine("2 - Create Account");
            WriteLine("0 - Shutdown System");
            Write("Type your option: ");
        }


        public static void WriteInternalMainMenu()
        {
            Clear();
            WriteLine("1 - Play Chess");
            WriteLine("2 - Play Tic-Tac-Toe");
            WriteLine("3 - Play Another Game");
            WriteLine("4 - See Global Scoreboard");
            WriteLine("0 - Logout");
            Write("Type your option: ");
        }

        public static void WriteInvalidLogin()
        {
            WriteLine("Invalid login!\n{0}", _ReturnToLoginMenuMessage);
        }

        public static void WriteAccountAlreadyExists()
        {
            WriteLine("Account login already exists! {0}", _ReturnToLoginMenuMessage);
        }

        public static void WriteInvalidPassword()
        {
            Console.WriteLine("invalid/null Password!\n{0}", _ReturnToLoginMenuMessage);
        }

        public static void WriteInvalidName()
        {
            Console.WriteLine("Invalid name!\n{0}", _ReturnToLoginMenuMessage);
        }

        public static void WriteInvalidAccount() {
            Console.WriteLine("invalid/null account");
        }

        public static void WriteAccountNotFound()
        {
            WriteLine("Account not found");
        }


        public static void WriteAccountCreationSuccesful()
        {
            WriteLine("Account successfully created! {0}", _ReturnToLoginMenuMessage);
        }

        public static void WriteInsertSecondPlayerAccount()
        {
            WriteLine("Insert second player account: ");
        }

        public static void WriteReturningToMainMenu()
        {
            WriteLine(ReturnToMainMenuMessage);
        }

        // Specific Chess Game Messages

        public static void WriteChessWelcomeMessage()
        {
            WriteLine("Welcome to C# Chess 1.0!");
            WriteLine("Hope you have a good fun.");
        }
        public static void WriteChessGameplayersNames(string firstPlayerName, string secondPlayerName) {
            WriteLine("The match will be:\n{0} (white) vs {1} (black)", firstPlayerName, secondPlayerName);
            WriteLine("Lets begin the match!");
        }

        public static void WriteChooseThePieceYouWannaMoveMessage(string playerColor)
        {
            Console.WriteLine("{0} pieces round. Type the letter and the number of the piece you want to move:", playerColor);
        }

        public static void WriteChooseYourMovementMensage(string playerColor)
        {
            Console.WriteLine("{0} round. Type the letter and the number of the square you want to mark:", playerColor);
        }

        public static void WriteChooseYourMovementMessage(string pieceName, char letter, char number)
        {
            Console.WriteLine("You have choose the {0} at {1}{2} position.Now type a valid location position (letter and number) that you want it to move:", pieceName, Char.ToUpper(letter), number);
        }

        public static void WriteWrongPiecePosition()
        {
            WriteLine("Wrong/Invalid piece position! Please, type the correct position of the piece you want to move. Ex: 'C2'");
            ReadKey();
            Clear();
        }

        public static void WriteWrongMovePosition(string pieceName, string piecePosition)
        {
            WriteLine("Wrong/Invalid move position! Please, type a valid move position for {0} located in {1}", pieceName, piecePosition);
            ReadKey();
            Clear();
        }

        public static void WriteInvalidMovePosition()
        {
            WriteLine("Invalid position. Please, type a new position.");
            ReadKey();
        }

        // Specific Tic-Tac-Toe messages

        public static void WriteTicTacToeWelcomeMessage()
        {
            WriteLine("Welcome to C# Tic-Tac-Toe 1.0!");
            WriteLine("Hope you have a good fun.");
        }

        public static void WriteTicTacToeGameplayersNames(string firstPlayerName, string secondPlayerName)
        {
            WriteLine("The match will be:\n{0} (White \"X\") vs {1} (Reds \"O\")", firstPlayerName, secondPlayerName);
            WriteLine("Lets begin the match!");
            ReadKey();
        }

        public static void WriteTicTacToeWinMessage(string teamName, string userName)
        {
            WriteLine("Victory! The team of the {0} won! The user {1} won this match.", teamName, userName);
        }

        public static void WriteTicTacToePlayAgainMessage()
        {
            WriteLine("Do you wanna play Tic-Tac-Toe again? type: \"yes\" or \"no\"");
        }

        public static void WriteTicTacToeDrawResultMessage()
        {
            WriteLine("The game is a draw! Nobody wins. =/");
        }

        public static void WriteInvalidOptionForPlayAgainConfirmationMessage()
        {
            WriteLine("Invalid option!");
        }

        // Specific Battleship Game Messages

        public static void WriteBattleshipWelcomeMessage()
        {
            WriteLine("Welcome to C# Battleship 1.0!");
            WriteLine("Hope you have a good fun.");
        }

        public static void WriteBattleshipGameplayersNames(string firstPlayerName, string secondPlayerName)
        {
            WriteLine("The match will be:\n{0} as FirstPlayer vs {1} as SecondPlayer", firstPlayerName, secondPlayerName);
            WriteLine("Lets begin the match!");
            ReadKey();
        }

        public static void WriteInvalidPositionTargetMessage()
        {
            WriteLine("Invalid position to shoot. Please, type a new position.");
            ReadKey();
        }
    }
}
