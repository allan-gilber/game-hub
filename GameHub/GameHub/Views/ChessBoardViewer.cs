using System;
using static System.Console;

namespace GameHub.Views
{
    public static class ChessBoardViewer
    {
        public static void PrintBoardActualStatus(int numberOfRows, int numberOfColumns, int[,] firstPiecesArray, int[,] secondPiecesArray)
        {
            Clear();
            for(int index = 0; index < numberOfRows; index++)
            {
                PrintHorizontalLine(numberOfColumns);
                PrintVerticalLine(numberOfColumns, index, firstPiecesArray, secondPiecesArray);
                if(index == 7) PrintHorizontalLine(numberOfColumns);
            }
        }

        private static void PrintHorizontalLine(int numberOfColumns)
        {
            for (int columnIndex=0; columnIndex < numberOfColumns; columnIndex++)
            {
                if (columnIndex == 0) { Write("+————+"); continue; }
                if (columnIndex == numberOfColumns - 1) { WriteLine("————+"); continue; }
                Write("————+");
            }

        }

        private static void PrintVerticalLine(int numberOfColumns, int rowNumber, int[,] firstPiecesArray, int[,] secondPiecesArray)
        {

            ForegroundColor = ConsoleColor.White;
            for (int columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
            {
                string squareFiller = CheckIfSquareHasPieceOnIt(columnIndex, rowNumber, firstPiecesArray, secondPiecesArray);
                if (columnIndex == 0) { Write("| {0} |", squareFiller); ForegroundColor = ConsoleColor.White; continue; }
                if (columnIndex == numberOfColumns - 1) { Write(" {0} |\n", squareFiller); ForegroundColor = ConsoleColor.White; continue; }
                Write(" {0} |", squareFiller);
                ForegroundColor = ConsoleColor.White;
            }
        }

        private static string CheckIfSquareHasPieceOnIt(int columnIndex, int rowNumber,int[,] firstPiecesArray, int[,] secondPiecesArray)
        {
            if (firstPiecesArray[rowNumber, columnIndex] == secondPiecesArray[rowNumber, columnIndex] && (firstPiecesArray[rowNumber, columnIndex] != 0 && secondPiecesArray[rowNumber, columnIndex] != 0)) return ConvertPieceNumberToUnicodeSymbol(null);
            if (firstPiecesArray[rowNumber, columnIndex] != 0) return ConvertPieceNumberToUnicodeSymbol(firstPiecesArray[rowNumber, columnIndex]);
            if (secondPiecesArray[rowNumber, columnIndex] != 0) { ForegroundColor = ConsoleColor.Red; return ConvertPieceNumberToUnicodeSymbol(secondPiecesArray[rowNumber, columnIndex]); }
            return ConvertPieceNumberToUnicodeSymbol(0);
        }

        public static string ConvertPieceNumberToUnicodeSymbol(int? symbolNumber)
        {
            switch (symbolNumber)
            {
                case 0:
                    return "  ";
                case 1:
                    // return "\u2654";
                    return "KI";
                case 2:
                    // return "\u2654";
                    return "QU";
                case 3:
                    // return "\u2654";
                    return "BI";
                case 4:
                    // return "\u2654";
                    return "KN";
                                    
                case 5:
                    // return "\u2654";
                    return "RO";
                                    
                case 6:
                    // return "\u2654";
                    return "PW";
                                    
                case 7:
                    // return "\u2654";                
                    return "  ";
                default: return "??";
            }
        }
    }
}
