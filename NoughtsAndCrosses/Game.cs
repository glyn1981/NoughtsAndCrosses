

namespace NoughtsAndCrosses
{
    class Game
    {

        private IInputOutput _IO;
        private IAiOpponent _AiOpponent; 
        private IWinChecker _WinChecker;
        public Game(IInputOutput Io, IAiOpponent aiOpponent, IWinChecker winChecker)
        {
            _IO = Io;
            _AiOpponent =  aiOpponent; 
            _WinChecker = winChecker;
        }
        /// <summary>
        /// Play the game of Noughts and Crosses (Tic Tac Toe).
        /// </summary>
        public void Play()
        {

            Grid grid = new Grid();
            grid.InitializeSquares();
            grid.RenderGrid();
   
 

            while (!GameOver(grid))
            {
                string player = "X"; // or "O" based on turn logic
                string input = _IO.GatherInput($"Player {player}, enter your move (e.g., A1): ");

                if (grid.Squares != null && grid.SquareValues!=null)
                {
                    if (grid.Squares.Contains(input) && grid.SquareValues[grid.Squares.IndexOf(input)] == " ")
                    {
                        grid.SquareValues[grid.Squares.IndexOf(input)] = player;
                        grid.RenderGrid();
                    }
                    else
                    {
                        _IO.RenderOutput("Invalid move, try again.");
                    }
                }

                _AiOpponent.MakeMove(grid, player == "X" ? "O" : "X"); // AI makes a move for the other player
                // Switch player logic would go here
            }


        }
        /// <summary>
        /// Check if the game is over.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Boolean GameOver(Grid grid)
        {

            if (_WinChecker.CheckForWin(grid))
            {
                _IO.RenderOutput("We have a winner!");
                return true;
            }

            if (grid.SquareValues != null && grid.SquareValues.All(s => s != " "))
            {
                _IO.RenderOutput("It's a draw!");
                return true;
            }
            return false;

        }


    }
}
