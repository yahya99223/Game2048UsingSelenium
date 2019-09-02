
using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Core;

namespace Game2048
{
    public class DecisionAlgorithm
    {
        AlphaBetaPruningAlgorithm alphaBeta = new AlphaBetaPruningAlgorithm();

        public MovementDirection? DecideBestMove(Board board, int depth)
        {
            Dictionary<MovementDirection, double> movementsScores = new Dictionary<MovementDirection, double>();
            foreach (MovementDirection direction in (MovementDirection[])Enum.GetValues(typeof(MovementDirection)))
            {
                var tempBoard = board.Play(direction);
                if (!board.Equals(tempBoard))
                    movementsScores.Add(direction, alphaBeta.Search(tempBoard, depth, double.NegativeInfinity, double.PositiveInfinity));
            }
            //return movement that has best score
            return movementsScores.ToList().OrderByDescending(c => c.Value).FirstOrDefault().Key;
        }

    }
}
