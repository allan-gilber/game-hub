using static System.Console;

namespace GameHub.Views
{
    public static class ChessBoardViewer
    {
        public static void PrintBoardActualStatus(int NumberOfRows, int NumberOfColumns, int[] firstPiecesArray, int[] secondPiecesArray)
        {
            int QuantityOfRowsController = 0;
            Clear();
            while (NumberOfRows > QuantityOfRowsController)
            {
                PrintHorizontalLine(NumberOfColumns);
                PrintVerticalLine(NumberOfRows, QuantityOfRowsController);
                QuantityOfRowsController++;
            }
            PrintHorizontalLine(NumberOfColumns);
        }
        
        private static void PrintHorizontalLine(int NumberOfColumns)
        {
            int NumberOfColumnsLoopControler = 0;
            Write("+———+");
            while (NumberOfColumnsLoopControler < NumberOfColumns - 2)
            {
                Write("———+");
                NumberOfColumnsLoopControler++;
            }
            WriteLine("———+");

        }

        private static void PrintVerticalLine(int NumberOfRows, int RowNumber)
        {
            int NumberOfRowsLoopControler = 0;

            Write("|   |");
            while (NumberOfRowsLoopControler < NumberOfRows - 2)
            {
                Write("   |");
                NumberOfRowsLoopControler++;
            }
            Write("   |\n");
        }
    }
}
