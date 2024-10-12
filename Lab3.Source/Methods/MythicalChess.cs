using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Source.Methods
{
    public class MythicalChess
    {
        // Size of chess board
        private const byte boardSize = 9;

        // Knight moves
        private static readonly sbyte[] knightMovesX = { 2, 2, 1, 1, -2, -2, -1, -1 };
        private static readonly sbyte[] knightMovesY = { 1, -1, 2, -2, 1, -1, 2, -2 };

        // Bishop moves
        private static readonly sbyte[] bishopMovesX = { 1, 1, -1, -1};
        private static readonly sbyte[] bishopMovesY = { 1, -1, 1, -1};

        private static byte GetCellColor(byte x, byte y)
        {
            return (byte)((x + y) % 2);
        }

        private static bool IsWithinBoard(byte x, byte y)
        {
            return x >= 0 && y >= 0 && x < boardSize && y < boardSize ? true : false;
        }

        public static sbyte SearchMinSteps(Tuple<byte, byte> startCell, Tuple<byte, byte> endCell)
        {
            if (startCell.Equals(endCell)) 
                return 0;
            if (GetCellColor(startCell.Item1, startCell.Item2) == 0 
                && GetCellColor(endCell.Item1, endCell.Item2) == 1)
                return -1;
            if (GetCellColor(startCell.Item1, startCell.Item2) == 1
                && GetCellColor(endCell.Item1, endCell.Item2) == 1)
                return -1;

            // Queue for BFS Algorithm
            Queue<(Tuple<byte, byte>, byte)> queue = new Queue<(Tuple<byte, byte>, byte)>();
            // Matrix to avoid repeating cells checking
            bool[,] visitedMatrix = new bool[boardSize, boardSize];

            queue.Enqueue((startCell, 0));
            visitedMatrix[startCell.Item1, startCell.Item2] = true;

            while (queue.Count > 0)
            {
                var (currentCell, movesCount) = queue.Dequeue();
                byte x = currentCell.Item1;
                byte y = currentCell.Item2;

                if(currentCell.Equals(endCell))
                    return (sbyte)movesCount;
                
                byte cellColor = GetCellColor(currentCell.Item1, currentCell.Item2);
                if(cellColor == 0) // black
                {
                    for (byte i = 0; i < bishopMovesX.Length; i++)
                    {
                        for (byte m = 1; m < boardSize; m++)
                        {
                            byte newX = (byte)(x + bishopMovesX[i] * m);
                            byte newY = (byte)(y + bishopMovesY[i] * m);

                            if (IsWithinBoard(newX, newY) && !visitedMatrix[newX, newY])
                            {
                                queue.Enqueue((new Tuple<byte, byte>(newX, newY), (byte)(movesCount + 1)));
                                visitedMatrix[newX, newY] = true;
                            }
                        }
                    }
                }
                else // white
                {
                    for (byte i = 0; i < knightMovesX.Length; i++)
                    {
                        byte newX = (byte)(x + knightMovesX[i]);
                        byte newY = (byte)(y + knightMovesY[i]);

                        if (IsWithinBoard(newX, newY) && !visitedMatrix[newX, newY])
                        {
                            queue.Enqueue((new Tuple<byte, byte>(newX, newY), (byte)(movesCount + 1)));
                            visitedMatrix[newX, newY] = true;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
