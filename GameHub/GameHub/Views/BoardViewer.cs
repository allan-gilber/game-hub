using System;
using System.Reflection;
using static System.Console;
using static GameHub.Controllers.Tic_tac_toe.TicTacToeController;

namespace GameHub.Views
{
    public static class BoardViewer
    {
        private static char[] LettersArray = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
        public static void PrintChessBoard(int numberOfRows, int numberOfColumns, int[,] firstPiecesArray, int[,] secondPiecesArray, int[] whitePiecesGraveyard, int[] blackPiecesGraveyard)
        {
            Clear();
            PrintColumnLetters(numberOfColumns);
            for (int index = 0; index < numberOfRows; index++)
            {
                PrintHorizontalLine(numberOfColumns);
                PrintVerticalLine(numberOfColumns, index, firstPiecesArray, secondPiecesArray);

                if (index == 0) { WriteLine("  Black Pieces Graveyard"); continue; }
                if (index == 1) { PrintGraveyardStatus(blackPiecesGraveyard); continue; }
                if (index == 6) { WriteLine("  White Pieces Graveyard"); continue; }
                if (index == 7) { PrintGraveyardStatus(whitePiecesGraveyard); PrintHorizontalLine(numberOfColumns); }
                Write("\n");
            }
        }

        public static void PrintTicTacToeBoard()
        {
            Clear();
            PrintColumnLetters(3);
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                PrintTicTacToeVerticalLine(rowIndex);

                Write("\n");
                if (rowIndex == 2) continue;
                PrintHorizontalLine(3);
            }
        }

        private static void PrintTicTacToeVerticalLine(int rowIndex)
        {
            int indexToRowNumberConverter = rowIndex + 1;

            Write("  {0}  ", indexToRowNumberConverter);

            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                if (columnIndex == 0) Write(" ");
                Write("  ");

                string squareSymbol = GameStatus[rowIndex, columnIndex];
                if(squareSymbol == "O") ForegroundColor = ConsoleColor.Red;

                Write("{0}", squareSymbol);

                ForegroundColor = ConsoleColor.White;
                if (columnIndex == 2) continue;
                Write("  |");
            }
        }

        private static void PrintGraveyardStatus(int[] piecesGraveYard)
        {
            int positionToIndexConverter = 1;
            for (int i = 1; i < 6; i++)
            {
                Write("  {0}: {1}  ", ConvertPieceNumberToUnicodeSymbol(i)[0], piecesGraveYard[i - positionToIndexConverter]);
            }
            WriteLine("  {0}: {1}  ", ConvertPieceNumberToUnicodeSymbol(6)[0], piecesGraveYard[5]);
        }

        private static void PrintHorizontalLine(int numberOfColumns)
        {
            Write("     +—————+");
            for (int columnIndex = 1; columnIndex < numberOfColumns - 1; columnIndex++)
            {
                Write("—————+");
            }
            WriteLine("—————+");

        }

        private static void PrintColumnLetters(int numberOfColumns)
        {
            Write("        {0}  ", LettersArray[0]);
            for (int columnIndex = 1; columnIndex < numberOfColumns - 1; columnIndex++)
            {
                Write("   {0}  ", LettersArray[columnIndex]);
            }
            Write("   {0}  \n\n", LettersArray[numberOfColumns - 1]);
        }
        private static void PrintVerticalLine(int numberOfColumns, int rowNumber, int[,] firstPiecesArray, int[,] secondPiecesArray)
        {

            ForegroundColor = ConsoleColor.White;
            int indexToRowNumberConverter = + 1;
            Write("  {0}  |", indexToRowNumberConverter);

            for (int columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
            {
                string[] squareFiller = CheckIfSquareHasPieceOnIt(columnIndex, rowNumber, firstPiecesArray, secondPiecesArray);
                Write(" {0}", squareFiller);
                ForegroundColor = ConsoleColor.White;
                Write(" |");
            }
        }

        private static string[] CheckIfSquareHasPieceOnIt(int columnIndex, int rowNumber,int[,] firstPiecesArray, int[,] secondPiecesArray)
        {
            if (
                firstPiecesArray[rowNumber, columnIndex] == secondPiecesArray[rowNumber, columnIndex] && 
                (firstPiecesArray[rowNumber, columnIndex] != 0 && secondPiecesArray[rowNumber, columnIndex] != 0)
                ) return ConvertPieceNumberToUnicodeSymbol(null);
            if (firstPiecesArray[rowNumber, columnIndex] != 0) return ConvertPieceNumberToUnicodeSymbol(firstPiecesArray[rowNumber, columnIndex]);
            if (secondPiecesArray[rowNumber, columnIndex] != 0) { 
                ForegroundColor = ConsoleColor.Red; 
                return ConvertPieceNumberToUnicodeSymbol(secondPiecesArray[rowNumber, columnIndex]); 
            }
            return ConvertPieceNumberToUnicodeSymbol(0);
        }

        public static string[] ConvertPieceNumberToUnicodeSymbol(int? symbolNumber)
        {
            switch (symbolNumber)
            {
                case 0:
                    return new string[] { "  ", "" };
                case 1:
                    // return "\u2654";
                    return new string[] { "KI", "King" };
                case 2:
                    // return "\u2654";
                    return new string[] { "QU", "Queen" };
                case 3:
                    // return "\u2654";
                    return new string[] { "BI", "Bishop" };
                case 4:
                    // return "\u2654";
                    return new string[] { "KN", "Knight" };
                                    
                case 5:
                    // return "\u2654";
                    return new string[] { "RO", "Rook" };
                                    
                case 6:
                    // return "\u2654";
                    return new string[] { "PW", "Pawn" };
                default: return new string[] { "??", "ERROR" };
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
    }
}
