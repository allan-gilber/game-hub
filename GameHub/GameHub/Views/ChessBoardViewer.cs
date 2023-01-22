using System;
using static System.Console;

namespace GameHub.Views
{
    public static class ChessBoardViewer
    {
        private static char[] LettersArray = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
        public static void PrintBoardActualStatus(int numberOfRows, int numberOfColumns, int[,] firstPiecesArray, int[,] secondPiecesArray)
        {
            Clear();
            PrintColumnNumbers(numberOfColumns);
            for(int index = 0; index < numberOfRows; index++)
            {
                PrintHorizontalLine(numberOfColumns);
                PrintVerticalLine(numberOfColumns, index, firstPiecesArray, secondPiecesArray);
                if(index == 7) PrintHorizontalLine(numberOfColumns);
            }
        }

        private static void PrintHorizontalLine(int numberOfColumns)
        {
            Write("     +————+");
            for (int columnIndex = 1; columnIndex < numberOfColumns - 1; columnIndex++)
            {
                Write("————+");
            }
            WriteLine("————+");

        }

        private static void PrintColumnNumbers(int numberOfColumns)
        {
            Write("       {0}  ", LettersArray[0]);
            for (int columnIndex = 1; columnIndex < numberOfColumns - 1; columnIndex++)
            {
                Write("  {0}  ", LettersArray[columnIndex]);
            }
            Write("  {0}  \n", LettersArray[numberOfColumns - 1]);
        }
        private static void PrintVerticalLine(int numberOfColumns, int rowNumber, int[,] firstPiecesArray, int[,] secondPiecesArray)
        {

            ForegroundColor = ConsoleColor.White;
            Write("  {0}  |",rowNumber + 1);
            for (int columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
            {
                string[] squareFiller = CheckIfSquareHasPieceOnIt(columnIndex, rowNumber, firstPiecesArray, secondPiecesArray);
                Write(" {0}", squareFiller);
                ForegroundColor = ConsoleColor.White;
                if (columnIndex == numberOfColumns - 1) { Write(" |\n"); continue; }
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
    }
}
