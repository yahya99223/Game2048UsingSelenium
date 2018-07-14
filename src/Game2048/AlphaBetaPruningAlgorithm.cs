using System;

namespace Game2048
{
    public class AlphaBetaPruningAlgorithm
    {
        BoardEvaluator evaluator = new BoardEvaluator();
        public double Search(Board board, int depth, double alpha, double beta)
        {
            if (depth == 0)
            {
                return evaluator.Evaluate(board);
            }
            else
            {
                var children = board.GetChildren();
                if (children.Count == 0)
                    return evaluator.Evaluate(board);
                foreach (var child in children)
                {
                    var movements = child.GetOpponentMovements();
                    foreach (var movement in movements)
                    {
                        alpha = Math.Max(alpha, -Search(child, depth - 1, -beta, -alpha));
                        if (alpha >= beta)
                            return alpha;
                    }
                }
                return alpha;
            }
        }
    }
}
