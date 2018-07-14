
using System.Collections.Generic;
using System.Linq;

namespace Game2048
{
    public class DecisionAlgorithm
    {
        AlphaBetaPruningAlgorithm alphaBeta = new AlphaBetaPruningAlgorithm();

        public Movement? Decide(Board board, int depth)
        {
            Dictionary<Movement, double> keyValuePairs = new Dictionary<Movement, double>();
            var tempBoard = Move(board, Movement.Up);
            if (board != tempBoard)
                keyValuePairs.Add(Movement.Up, alphaBeta.Search(tempBoard, depth, double.NegativeInfinity, double.PositiveInfinity));

            tempBoard = Move(board, Movement.Right);
            if (board != tempBoard)
                keyValuePairs.Add(Movement.Right, alphaBeta.Search(tempBoard, depth, double.NegativeInfinity, double.PositiveInfinity));

            tempBoard = Move(board, Movement.Down);
            if (board != tempBoard)
                keyValuePairs.Add(Movement.Down, alphaBeta.Search(tempBoard, depth, double.NegativeInfinity, double.PositiveInfinity));

            tempBoard = Move(board, Movement.Left);
            if (board != tempBoard)
                keyValuePairs.Add(Movement.Left, alphaBeta.Search(tempBoard, depth, double.NegativeInfinity, double.PositiveInfinity));
            //return movement that have best children
            return keyValuePairs.ToList().OrderByDescending(c => c.Value).FirstOrDefault().Key;
        }
        public Board Move(Board board, Movement movement)
        {
            var tempBoard = board.Clone();
            if (movement == Movement.Up)
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
                 if (movement == Movement.Down)
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
                 if (movement == Movement.Right)
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
                 if (movement == Movement.Left)
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
        public enum Movement { Up, Right, Down, Left }
    }
}
