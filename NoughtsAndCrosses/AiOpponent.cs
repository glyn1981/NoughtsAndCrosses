

namespace NoughtsAndCrosses
{
    class AiOpponent : IAiOpponent
    {

        public void MakeMove(Grid grid, string player)
        {
            if (grid.SquareValues == null || grid.Squares == null)
                return;

            string opponent = player == "X" ? "O" : "X";
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

            // Try to block opponent's win
            foreach (var combo in winningCombinations)
            {
                int opponentCount = 0;
                int emptyIndex = -1;
                foreach (var idx in combo)
                {
                    if (grid.SquareValues[idx] == opponent)
                        opponentCount++;
                    else if (grid.SquareValues[idx] == " ")
                        emptyIndex = idx;
                }
                if (opponentCount == 2 && emptyIndex != -1)
                {
                    grid.SquareValues[emptyIndex] = player;
                    grid.RenderGrid();
                    return;
                }
            }

            // Otherwise, pick the first available square
            for (int i = 0; i < grid.SquareValues.Count; i++)
            {
                if (grid.SquareValues[i] == " ")
                {
                    grid.SquareValues[i] = player;
                    grid.RenderGrid();
                    return;
                }
            }
        }

    }
}
