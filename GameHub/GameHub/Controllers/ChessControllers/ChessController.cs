using GameHub.Models;
using GameHub.Models.ChessPieces;
using GameHub.Models.ChessPieces.ChessPieces;
using GameHub.Views;
using static GameHub.Controllers.GameHubController;
using static System.Console;
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Views.ChessBoardViewer;


namespace GameHub.Controllers.ChessControllers
{
    internal static class ChessController
    {
        private static int[,] _WhitePiecesPositions = new int[8 , 8];
        private static int[,] _BlackPiecesPositions = new int[8 , 8];
        private static int[] _WhitePiecesGraveyard { get; set; } = new int[6];
        private static int[] _BlackPiecesGraveyard { get; set; } = new int[6];
        private static int[] _SelectedChessPieceLocation = new int[2];
        private static string _SelectedChessPieceName = "";
        private static bool _BlackPiecesround = false;

        // Loop controllers
        private static bool _ShouldContinue = true;
        private static bool _ChooseYourMoveMenuLoopController = true;
        private static bool _ChooseYourMovePositionLoopMenuController = true;
        

        public static void InitiateChessGame()
        {
            Clear();
            WriteChessWelcomeMessage();
            ReadKey();
            ChooseYourOpponent();
            PopulateChessBoard();
            Clear();

            while (_ShouldContinue) { 
                while (_ChooseYourMoveMenuLoopController) {
                    int[,] myPiecesArrayPositions, ememyPiecesArrayPositions;
                    string? userInput;
                    string movePositionCode = null;

                    ChessBoardViewer.PrintBoardActualStatus(8,8, _WhitePiecesPositions, _BlackPiecesPositions, _WhitePiecesGraveyard, _BlackPiecesGraveyard);
                    
                    WriteChooseThePieceYouWannaMoveMessage(_BlackPiecesround ? "Black" : "White");
                    userInput = ReadLine();

                    if (_BlackPiecesround) { myPiecesArrayPositions = _BlackPiecesPositions; ememyPiecesArrayPositions = _WhitePiecesPositions; }
                    else { myPiecesArrayPositions = _WhitePiecesPositions; ememyPiecesArrayPositions = _BlackPiecesPositions; }

                    if (!CheckIfUserHasAPieceOnTheIndicatedPosition(userInput, myPiecesArrayPositions)) continue;
                    var pieceObject = CreateChessPieceObject(myPiecesArrayPositions[_SelectedChessPieceLocation[0], _SelectedChessPieceLocation[1]], userInput!, !_BlackPiecesround, _SelectedChessPieceLocation);

                    _ChooseYourMovePositionLoopMenuController = true;

                    while (_ChooseYourMovePositionLoopMenuController) {
                        WriteChooseYourMovementMessage(_SelectedChessPieceName, userInput![0], userInput[1]);
                        movePositionCode = ReadLine();
                        if (movePositionCode == null) continue;

                        pieceObject.MovementLogic(movePositionCode, myPiecesArrayPositions, ememyPiecesArrayPositions, _BlackPiecesround ? _BlackPiecesGraveyard : _WhitePiecesGraveyard);

                        ReadKey();
                        _ChooseYourMovePositionLoopMenuController = false;
                    }

                }
            }
            _ShouldContinue = true;
        }

        public static bool CheckIfUserHasAPieceOnTheIndicatedPosition(string? userInput, int[,] PiecePositions)
        {
            int positionNumber;
            int? convertedPositionLetter;

            if (userInput == null || userInput.Length != 2) { WriteWrongPiecePosition(); return false; }
            convertedPositionLetter = ConvertLetterToPosition(userInput[0]);
            if (!int.TryParse(userInput[1].ToString(), out positionNumber)) { WriteWrongPiecePosition(); return false; }
            --positionNumber;
            if (convertedPositionLetter == null || 0 > positionNumber && positionNumber > 8) { WriteWrongPiecePosition(); return false; }
            if (PiecePositions[positionNumber,(int) convertedPositionLetter] == 0) { WriteWrongPiecePosition();  return false; }

            _SelectedChessPieceLocation = new int[] { positionNumber, (int) convertedPositionLetter};
            _SelectedChessPieceName = ConvertPieceNumberToUnicodeSymbol(PiecePositions[positionNumber, (int)convertedPositionLetter])[1];

            return true;
        }

       public static IChessPieceModel CreateChessPieceObject(int chessPieceCode, string piecePosition, bool movingUpward, int[] piecePositionIntegerArray)
        {
            switch (chessPieceCode)
            {
                case 1:  return new King(piecePosition, piecePositionIntegerArray); 
                case 2: return new Queen();
                case 3: return new Bishop();
                case 4: return new Knight();
                case 5: return new Rook();
                case 6: return new Pawn(piecePosition, movingUpward, piecePositionIntegerArray);
                default: return new Pawn(piecePosition, movingUpward,  piecePositionIntegerArray);
            }
        }

        public static int? ConvertLetterToPosition(char letter)
        {
            letter = Char.ToUpper(letter);
            switch (letter)
            {
                case 'A': return 0;
                case 'B': return 1;
                case 'C': return 2;
                case 'D': return 3;
                case 'E': return 4;
                case 'F': return 5;
                case 'G': return 6;
                case 'H': return 7;
                default: return null;
            }
        }

        public static int? ConvertPositionToLetter(int letter)
        {

            switch (letter)
            {
                case 0: return 'A';
                case 1: return 'B';
                case 2: return 'C';
                case 3: return 'D';
                case 4: return 'E';
                case 5: return 'F';
                case 6: return 'G';
                case 7: return 'H';
                default: return null;
            }
        }

        public static void PopulateChessBoard()
        {
            // King
            _BlackPiecesPositions[0, 4] = 1;
            _WhitePiecesPositions[7, 4] = 1;

            // Queen
            _BlackPiecesPositions[0, 3] = 2;
            _WhitePiecesPositions[7, 3] = 2;
            
            // Bishops
            _BlackPiecesPositions[0, 2] = 3;

            _BlackPiecesPositions[0, 5] = 3;
            _WhitePiecesPositions[7, 2] = 3;
            _WhitePiecesPositions[7, 5] = 3;
            
            // Knights
            _BlackPiecesPositions[0, 1] = 4;
            _BlackPiecesPositions[0, 6] = 4;
            _WhitePiecesPositions[7, 1] = 4;
            _WhitePiecesPositions[7, 6] = 4;

            // Rooks
            _BlackPiecesPositions[0, 0] = 5;
            _BlackPiecesPositions[0, 7] = 5;
            _WhitePiecesPositions[7, 0] = 5;
            _WhitePiecesPositions[7, 7] = 5;

            // Pawns
            for(int i = 0; i < 8; i++)
            {
                _BlackPiecesPositions[1, i] = 6;
                _WhitePiecesPositions[6, i] = 6;
            }
            _WhitePiecesPositions[2, 1] = 6;

        }
    }
}
