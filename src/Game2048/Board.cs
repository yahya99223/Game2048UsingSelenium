
using System.Collections.Generic;
using Shared.Core;

namespace Game2048
{
    public class Board
    {
        public int[,] Cells = new int[4, 4];
        public List<Board> GetOpponentMovements()
        {
            List<Board> movements = new List<Board>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(this.Cells[i,j]==0)
                    {
                        var tempBoard = this.Clone();
                        tempBoard.Cells[i, j] = 2;
                        var tempBoard2 = this.Clone();
                        tempBoard.Cells[i, j] = 4;
                        movements.Add(tempBoard);
                        movements.Add(tempBoard2);
                    }
                }
            }
                    return movements;
        }
        public List<Board> GetChildren()
        {
            var tempBoard = this.Clone();
            var children = new List<Board>();
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
            if (tempBoard != this)
                children.Add(tempBoard);
            var downBoard = this.Clone();
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
            if (downBoard != this)
                children.Add(downBoard);
            var rightBoard = this.Clone();
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
            if (rightBoard != this)
                children.Add(rightBoard);
            var leftBoard = this.Clone();
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
            if (leftBoard != this)
                children.Add(leftBoard);
            return children;
        }
        public Board Play(MovementDirection movement)
        {
            var tempBoard = this.Clone();
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
        public Board Clone()
        {
            return new Board() { Cells = (int[,])this.Cells.Clone() };
        }
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                var board1 = (Board)obj;
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (board1.Cells[row, col] != this.Cells[row, col])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return base.Equals(obj);
        }
    }
}
