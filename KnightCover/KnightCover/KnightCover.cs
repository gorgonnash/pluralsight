using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace KnightCover
{
    class KnightCover
    {
        static void Main(string[] args)
        {            
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: KnightCover.exe <BoardSize>");
                return;
            }

            var size = int.Parse(args[0]);
            if (size <= 0)
            {
                Console.WriteLine("Board size has to be a positive integer.");
                return;
            }

            var timer = Stopwatch.StartNew();
            Solve(size);

            Console.WriteLine("Done. Took {0} ms.", timer.ElapsedMilliseconds);
            Console.Read();
        }

        private static void Solve(int n)
        {
            var board = new Board(n);
            var best = FindSolution(board, 0, 0);
            Console.WriteLine(board);
            Console.WriteLine("Initial solution: N = {0}, Knights placed: {1}", n, best.Count);

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var currentBoard = new Board(n);
                    var current = FindSolution(currentBoard, i, j);
                    if (current.Count < best.Count)
                    {
                        currentBoard.Validate();
                        best = current;
                        Console.WriteLine(currentBoard);
                        Console.WriteLine("Current best solution: N = {0}, Knights placed: {1}", n, best.Count);
                    }
                }
            }
        }

        private static Stack<Tuple<int, int>> FindSolution(Board bd, int initX, int initY)
        {
            var result = new Stack<Tuple<int, int>>();

            result.Push(new Tuple<int, int>(initX, initY));
            bd.PlaceKnight(initX, initY);

            var nextCell = bd.FindNextEmptyCellAfter(initX, initY);
            while (nextCell != null)
            {
                var x = nextCell.Item1;
                var y = nextCell.Item2;
                result.Push(nextCell);
                bd.PlaceKnight(x, y);
                nextCell = bd.FindNextEmptyCellAfter(x, y);
            }

            return result;
        }

        private class Board
        {
            private const string KnightSymbol = "K";
            private const string EmptySymbol = "";
            private const string AttackedSymbol = "A";

            private readonly int size;
            private string[,] cells;

            public Board(int size)
            {
                if (size <= 0) throw new ArgumentException("size");

                this.size = size;
                cells = new string[size, size];
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        cells[i, j] = string.Empty;
                    }
                }
            }

            public override string ToString()
            {
                var buffer = new StringBuilder();
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        buffer.Append(cells[i, j]);
                    }

                    buffer.AppendLine();
                }

                return buffer.ToString();
            }

            public void PlaceKnight(int x, int y)
            {
                if (cells[x, y] == KnightSymbol)
                {
                    var msg = string.Format("Cell ({0},{1}) is already occupied!");
                    throw new InvalidOperationException(msg);
                }

                MarkKnightAndAttacked(x, y);
            }

            public Tuple<int, int> FindNextEmptyCellAfter(int x, int y)
            {
                if (x < 0 || x > size - 1) throw new ArgumentException("x");

                if (y < 0 || y > size - 1) throw new ArgumentException("y");

                var searchedCellCount = 0;

                while (searchedCellCount < size * size - 1)
                {
                    y++;
                    if (y >= size)
                    {
                        y = 0;
                        x++;
                    }

                    // loop back to first row
                    if (x >= size)
                    {
                        x = 0;
                    }

                    if (cells[x, y] == EmptySymbol)
                    {
                        return new Tuple<int, int>(x, y);
                    }

                    searchedCellCount++;
                }

                // cannot find any empty cell after (x,y)
                return null;
            }

            public void Validate()
            {
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        if (cells[i, j] == EmptySymbol) throw new InvalidOperationException("Empty cell not allowed!");

                        if (cells[i, j] == KnightSymbol) continue;

                        if (cells[i, j] == AttackedSymbol && IsCellUnderAttack(i, j)) continue;

                        throw new InvalidOperationException("Invalid cell state!");
                    }
                }
            }

            private bool IsCellUnderAttack(int x, int y)
            {
                return
                    IsKnightCell(x - 1, y - 2) ||
                    IsKnightCell(x - 1, y + 2) ||
                    IsKnightCell(x + 1, y - 2) ||
                    IsKnightCell(x + 1, y + 2) ||
                    IsKnightCell(x - 2, y - 1) ||
                    IsKnightCell(x - 2, y + 1) ||
                    IsKnightCell(x + 2, y - 1) ||
                    IsKnightCell(x + 2, y + 1);
            }

            private bool IsValidCell(int x, int y)
            {
                return 0 <= x && x <= size - 1 && 0 <= y && y <= size - 1;
            }

            private bool IsKnightCell(int x, int y)
            {
                return IsValidCell(x, y) && cells[x, y] == KnightSymbol;
            }

            private void MarkKnightAndAttacked(int x, int y)
            {
                cells[x, y] = KnightSymbol;

                MarkAttacked(x - 1, y - 2);
                MarkAttacked(x - 1, y + 2);
                MarkAttacked(x + 1, y - 2);
                MarkAttacked(x + 1, y + 2);

                MarkAttacked(x - 2, y - 1);
                MarkAttacked(x - 2, y + 1);
                MarkAttacked(x + 2, y - 1);
                MarkAttacked(x + 2, y + 1);
            }

            private void MarkAttacked(int x, int y)
            {
                // ignore out-of-bound (x,y)
                if (!IsValidCell(x, y)) return;

                // no-op on occupied or already attacked cell
                if (cells[x, y] != EmptySymbol) return;

                cells[x, y] = AttackedSymbol;
            }
        }
    }
}
