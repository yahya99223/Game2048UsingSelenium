using Game2048;
using System.Threading;
using Shared.Core;

namespace Game2048UsingSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueRunning = true;
            Game2048Page gamePage = new Game2048Page();
            DecisionAlgorithm algo = new DecisionAlgorithm();
            while (continueRunning)
            {
                Thread.Sleep(200);
                var board = gamePage.GetBoard();
                var movement = algo.DecideBestMove(board, 2);
                if (movement != null)
                    gamePage.MoveTo((MovementDirection)movement);
                else
                    continueRunning = false;
            }
        }
    }
}
