using static System.Console;
using static GameHub.Controllers.ConsolePrinterController;
using static GameHub.Controllers.GameHubController;
using static GameHub.Views.BoardViewer;

namespace GameHub.Controllers.NavalBattleController
{ }
    // To-do
/*
internal static class NavalBattleController
{
private static int[,] _FirstPlayerPositions = new int[7, 7];
private static int[,] _FirstPlayerShots = new int[7, 7];
private static int[,] _SecondPlayerPositions = new int[7, 7];
private static int[,] _SecondPlayerShots = new int[7, 7];
private static int _FirstPlayerPoints = 0;
private static int _SecondPlayerPoints = 0;

// Loop controllers
private static bool _EndOfGameLoopController = true;
private static bool _ChooseYourMoveMenuLoopController = true;
private static bool _FirstPlayerRound = false;
private static bool _NewGameLoopController = true;
private static bool _AskForNewGameLoopController = true;

public static void InitiateTictacToeGame()
{
Clear();
WriteBattleshipWelcomeMessage();
ReadKey();
ChooseYourOpponent();
Clear();
WriteBattleshipGameplayersNames(FirstPlayer!.PersonName, SecondPlayer!.PersonName);
ReadLine();
Clear();
while (_NewGameLoopController)
{
// PoPulateArray();
while (_EndOfGameLoopController)
{
while (_ChooseYourMoveMenuLoopController)
{
  string? userInput;
  string userName = _FirstPlayerRound ? FirstPlayer.PersonName : SecondPlayer.PersonName;
  string teamName = _FirstPlayerRound ? "Red Armada" : "White Armada";

  if (_FirstPlayerRound) PrintBattleshipGameBoard(7, 7, _FirstPlayerPositions, _SecondPlayerPositions, false);
  else PrintBattleshipGameBoard(7, 7, _SecondPlayerPositions, _FirstPlayerPositions, true);

  WriteChooseYourMovementMensage(_FirstPlayerRound ? "Red O" : "White X");
  userInput = ReadLine();

  if (!CheckIfIsAnValidLocation(userInput)) { WriteInvalidPositionTargetMessage(); continue; }
  int letter, number;


  if (CheckIfAUserHasWon())
  {
      Clear();
      PrintTicTacToeBoard();
      WriteTicTacToeWinMessage(teamName, userName);
      ReadKey();

      _ChooseYourMoveMenuLoopController = false;
      _EndOfGameLoopController = false;
  }

  if (AvaibleMoves == 1)
  {
      Clear();
      PrintTicTacToeBoard();
      WriteTicTacToeDrawResultMessage();
      ReadKey();

      _ChooseYourMoveMenuLoopController = false;
      _EndOfGameLoopController = false;
  }

  _FirstPlayerRound = !_FirstPlayerRound;
}
}
while (_AskForNewGameLoopController)
{
Clear();
WriteTicTacToePlayAgainMessage();
string userInput = ReadLine();
if (userInput.Equals("yes"))
{
  _EndOfGameLoopController = true;
  _ChooseYourMoveMenuLoopController = true;
  _FirstPlayerRound = false;
  _AskForNewGameLoopController = false;
  AvaibleMoves = 9;
  continue;
}

if (userInput.Equals("no"))
{
  WriteReturningToMainMenu();
  ReadKey();
  _NewGameLoopController = false;
}
WriteInvalidOptionForPlayAgainConfirmationMessage();
ReadKey();
}

}
}

// To-do

public static bool CheckIfIsAnValidLocation(string shootPosition)
{
int[,] shipPositions;

}



private static void PoPulateArray()
{
_FirstPlayerPositions = new int[7,7] {
{ 1,0,0,0,0,0,0 }, 
{ 1,0,0,0,0,0,0 },
{ 1,0,2,2,2,0,0 },
{ 1,0,0,0,0,0,0 },
{ 1,0,0,4,0,3,0 },
{ 0,0,0,4,0,3,0 },
{ 0,5,5,4,0,3,0 }
};

_SecondPlayerPositions = new int[7, 7] {
{ 0,0,1,1,1,1,1 },
{ 0,0,2,0,0,0,0 },
{ 0,0,2,0,0,0,0 },
{ 0,0,2,0,0,0,0 },
{ 0,0,2,0,0,0,0 },
{ 5,0,0,0,4,4,4 },
{ 5,0,3,3,3,0,0 }
};
}
}
}
*/
