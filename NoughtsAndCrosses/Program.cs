
using NoughtsAndCrosses;

IInputOutput iO = new InputOutput();
IAiOpponent aiOpponent = new AiOpponent();
IWinChecker winChecker = new WinChecker();

Game game = new Game(iO,aiOpponent, winChecker);
try
{
    game.Play();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
