
namespace NoughtsAndCrosses
{


    class Grid : IGrid
    {
        public List<string>? Squares;
        public List<string>? SquareValues; 
        public void InitializeSquares()
        {
            Squares = new List<string> { "A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3" };
            SquareValues = Enumerable.Repeat(" ", 9).ToList();
        }

        public void RenderGrid()
        {
            Console.WriteLine("   A   B   C");
            for (int row = 0; row < 3; row++)
            {
                Console.Write($"{row + 1} ");
                for (int col = 0; col < 3; col++)
                {
                    int idx = row * 3 + col;

                    if (SquareValues != null)
                    {
                        Console.Write($" {SquareValues[idx]} ");
                    }

                    if (col < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (row < 2) Console.WriteLine("  ---+---+---");
            }
        }
    }
}
