﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Game2048
{
    public class BoardEvaluator
    {
        public double Evaluate(Board board)
        {

            Dictionary<int, int> values = new Dictionary<int, int>();
            double sum = 128;
            var tilesWithBorders = getWithBorders(board.Cells);
            //check if tiles that can be merged are adjacent
            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    List<int> neighbours = new List<int>();
                    neighbours.Add(tilesWithBorders[i - 1, j]);
                    neighbours.Add(tilesWithBorders[i, j - 1]);
                    neighbours.Add(tilesWithBorders[i, j + 1]);
                    neighbours.Add(tilesWithBorders[i + 1, j]);
                    foreach (var neighbour in neighbours)
                    {
                        if (neighbour == -1)
                        {
                            continue;
                        }
                        else
                            if (neighbour == tilesWithBorders[i, j])
                        {
                            sum += 2;
                        }
                        else
                            if (neighbour / 2 == tilesWithBorders[i, j])
                        {
                            sum += 0.001 * tilesWithBorders[i, j];
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (values.ContainsKey(board.Cells[i, j]))
                    {
                        values[board.Cells[i, j]] += 1;
                    }
                    else
                    {
                        values.Add(board.Cells[i, j], 1);
                    }
                }
            }
            //loose state
            if (!values.Keys.Contains(0))
            {
                sum = double.NegativeInfinity;
            }
            else
            //win state
                if (values.Keys.Contains(2048))
            {
                sum = double.PositiveInfinity;
            }
            else
            {
                //add points to empty cells 
                foreach (var key in values.Keys.ToList().OrderByDescending(x => x))
                {
                    sum += (long)(key * values[key] * (multiplicationFactor(key)));
                    if (key == 0)
                    {
                        sum += values[key] * 128;
                    }
                    else
                    {
                        sum += Math.Log(key) * 4;
                    }
                }
            }

            return sum;
        }
        static int multiplicationFactor(int number)
        {
            int count = 0;
            while (number != 1 && number != 0)
            {
                number /= 4;
                count++;
            }
            return count;
        }
        int[,] getWithBorders(int[,] tiles)
        {
            int[,] tilesWithBorders = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i == 0 || j == 0 || i == 5 || j == 5)
                    {
                        tilesWithBorders[i, j] = -1;
                    }
                    else
                    {
                        tilesWithBorders[i, j] = tiles[i - 1, j - 1];
                    }
                }
            }
            return tilesWithBorders;
        }
    }
}
