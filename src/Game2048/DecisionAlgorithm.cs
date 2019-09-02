
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
                var tempBoard = Play(board, direction);
                if (!board.Equals(tempBoard))
                    movementsScores.Add(direction, alphaBeta.Search(tempBoard, depth, double.NegativeInfinity, double.PositiveInfinity));
            }
            //return movement that has best score
            return movementsScores.ToList().OrderByDescending(c => c.Value).FirstOrDefault().Key;
        }
        public Board Play(Board board, MovementDirection movement)
        {
            var tempBoard = board.Clone();
            if (movement == MovementDirection.Up)
            {
                for (int j = 0; j < 4; j++)
                {
                    int latestIndex = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (tempBoard.Cells[i, j] != 0)
                        {
                            if (latestIndex != i)
                            {
                                if (tempBoard.Cells[i, j] == tempBoard.Cells[latestIndex, j])
                                {
                                    tempBoard.Cells[latestIndex, j] *= 2;
                                    tempBoard.Cells[i, j] = 0;
                                }
                                else
                                if (tempBoard.Cells[latestIndex, j] == 0)
                                {
                                    tempBoard.Cells[latestIndex, j] = tempBoard.Cells[i, j];
                                    tempBoard.Cells[i, j] = 0;
                                }

                                else
                                {
                                    tempBoard.Cells[latestIndex + 1, j] = tempBoard.Cells[i, j];
                                    if (latestIndex + 1 != i)
                                        tempBoard.Cells[i, j] = 0;
                                    latestIndex = latestIndex + 1;
                                }
                            }
                        }
                    }
                }
            }
            else
                 if (movement == MovementDirection.Down)
            {
                for (int j = 0; j < 4; j++)
                {
                    int latestIndex = 3;
                    for (int i = 3; i >= 0; i--)
                    {
                        if (tempBoard.Cells[i, j] != 0)
                        {
                            if (latestIndex != i)
                            {
                                if (tempBoard.Cells[i, j] == tempBoard.Cells[latestIndex, j])
                                {
                                    tempBoard.Cells[latestIndex, j] *= 2;
                                    tempBoard.Cells[i, j] = 0;
                                }
                                else
                                if (tempBoard.Cells[latestIndex, j] == 0)
                                {
                                    tempBoard.Cells[latestIndex, j] = tempBoard.Cells[i, j];
                                    tempBoard.Cells[i, j] = 0;
                                }

                                else
                                {
                                    tempBoard.Cells[latestIndex - 1, j] = tempBoard.Cells[i, j];
                                    if (latestIndex - 1 != i)
                                        tempBoard.Cells[i, j] = 0;
                                    latestIndex = latestIndex - 1;
                                }
                            }
                        }
                    }
                }
            }
            else
                 if (movement == MovementDirection.Right)
            {
                for (int i = 0; i < 4; i++)
                {
                    int latestIndex = 3;
                    for (int j = 3; j >= 0; j--)
                    {
                        if (tempBoard.Cells[i, j] != 0)
                        {
                            if (latestIndex != j)
                            {
                                if (tempBoard.Cells[i, j] == tempBoard.Cells[i, latestIndex])
                                {
                                    tempBoard.Cells[i, latestIndex] *= 2;
                                    tempBoard.Cells[i, j] = 0;
                                }
                                else
                                if (tempBoard.Cells[i, latestIndex] == 0)
                                {
                                    tempBoard.Cells[i, latestIndex] = tempBoard.Cells[i, j];
                                    tempBoard.Cells[i, j] = 0;
                                }

                                else
                                {
                                    tempBoard.Cells[i, latestIndex - 1] = tempBoard.Cells[i, j];
                                    if (latestIndex - 1 != j)
                                        tempBoard.Cells[i, j] = 0;
                                    latestIndex = latestIndex - 1;
                                }
                            }
                        }
                    }
                }
            }
            else
                 if (movement == MovementDirection.Left)
            {
                for (int i = 0; i < 4; i++)
                {
                    int latestIndex = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (tempBoard.Cells[i, j] != 0)
                        {
                            if (latestIndex != j)
                            {
                                if (tempBoard.Cells[i, j] == tempBoard.Cells[i, latestIndex])
                                {
                                    tempBoard.Cells[i, latestIndex] *= 2;
                                    tempBoard.Cells[i, j] = 0;
                                }
                                else
                                if (tempBoard.Cells[i, latestIndex] == 0)
                                {
                                    tempBoard.Cells[i, latestIndex] = tempBoard.Cells[i, j];
                                    tempBoard.Cells[i, j] = 0;
                                }

                                else
                                {
                                    tempBoard.Cells[i, latestIndex + 1] = tempBoard.Cells[i, j];
                                    if (latestIndex + 1 != j)
                                        tempBoard.Cells[i, j] = 0;
                                    latestIndex = latestIndex + 1;
                                }
                            }
                        }
                    }
                }
            }
            return tempBoard;
        }
    }
}
