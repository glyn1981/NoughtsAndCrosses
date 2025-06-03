

namespace NoughtsAndCrosses
{
    class WinChecker : IWinChecker
    {

        public bool CheckForWin(Grid grid)
        {

            grid.SquareValues ??= new List<string>();
            var winningCombinations = new List<List<int>>
            {
                new List<int> { 0, 1, 2 }, // Row 1
                new List<int> { 3, 4, 5 }, // Row 2
                new List<int> { 6, 7, 8 }, // Row 3
                new List<int> { 0, 3, 6 }, // Column A
                new List<int> { 1, 4, 7 }, // Column B
                new List<int> { 2, 5, 8 }, // Column C
                new List<int> { 0, 4, 8 }, // Diagonal \
                new List<int> { 2, 4, 6 }  // Diagonal /
            };
            foreach (var combination in winningCombinations)
            {
                if (grid.SquareValues[combination[0]] != " " &&
                    grid.SquareValues[combination[0]] == grid.SquareValues[combination[1]] &&
                    grid.SquareValues[combination[1]] == grid.SquareValues[combination[2]])
                {
                    return true; // Win found
                }
            }
            return false; // No win found
        }

    }
}
