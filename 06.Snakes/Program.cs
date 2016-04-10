namespace _06.Snakes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Snake
    {
        static readonly char[,] Matrix = new char[30, 30];
        static readonly StringBuilder CurrentSnake = new StringBuilder();
        static readonly HashSet<string> AllSnakes = new HashSet<string>();

        static void Main()
        {
            var snakeSize = int.Parse(Console.ReadLine());
            Matrix[14, 14] = 'x';
            CurrentSnake.Append('S');
            ExtendSnake(14, 15, snakeSize - 1, 'R');

            foreach (var allSnake in AllSnakes)
            {
                Console.WriteLine(string.Join(", ", allSnake));
            }

            Console.WriteLine("Snakes count = {0}", AllSnakes.Count);
        }

        static void ExtendSnake(int row, int col, int snakeSize, char dir)
        {
            if (row < 0 || col < 0)
            {
                return;
            }

            if (snakeSize == CurrentSnake.Length - 1)
            {
                AddSnake(CurrentSnake);
                return;
            }

            if (Matrix[row, col] != '\0')
            {
                return;
            }

            CurrentSnake.Append(dir);
            Matrix[row, col] = 'x';

            ExtendSnake(row, col + 1, snakeSize, 'R');
            ExtendSnake(row + 1, col, snakeSize, 'D');
            ExtendSnake(row, col - 1, snakeSize, 'L');
            ExtendSnake(row - 1, col, snakeSize, 'U');

            Matrix[row, col] = default(char);
            CurrentSnake.Remove(CurrentSnake.Length - 1, 1);
        }

        private static void AddSnake(StringBuilder snake)
        {
            var b = snake;

            for (var i = 0; i < 4; i++)
            {
                b = Rorate(b);
                if (AllSnakes.Contains(b.ToString()))
                {
                    return;
                }
            }

            b = Swap(b);

            for (var i = 0; i < 4; i++)
            {
                b = Rorate(b);
                if (AllSnakes.Contains(b.ToString()))
                {
                    return;
                }
            }

            b = Reverse(snake);

            for (var i = 0; i < 4; i++)
            {
                b = Rorate(b);
                if (AllSnakes.Contains(b.ToString()))
                {
                    return;
                }
            }

            b = Swap(b);

            for (var i = 0; i < 4; i++)
            {
                b = Rorate(b);
                if (AllSnakes.Contains(b.ToString()))
                {
                    return;
                }
            }

            AllSnakes.Add(snake.ToString());
        }

        static StringBuilder Rorate(StringBuilder a)
        {
            var b = new StringBuilder();
            for (var i = 0; i < a.Length; i++)
            {
                var ch = a[i];
                switch (ch)
                {
                    case 'R':
                        b.Append('D');
                        break;
                    case 'D':
                        b.Append('L');
                        break;
                    case 'L':
                        b.Append('U');
                        break;
                    case 'U':
                        b.Append('R');
                        break;
                    default:
                        b.Append('S');
                        break;
                }
            }

            return b;
        }

        static StringBuilder Swap(StringBuilder a)
        {
            var b = new StringBuilder();
            for (var i = 0; i < a.Length; i++)
            {
                var ch = a[i];
                switch (ch)
                {
                    case 'R':
                        b.Append('L');
                        break;
                    case 'D':
                        b.Append('D');
                        break;
                    case 'L':
                        b.Append('R');
                        break;
                    case 'U':
                        b.Append('U');
                        break;
                    default:
                        b.Append('S');
                        break;
                }
            }

            return b;
        }

        static StringBuilder Reverse(StringBuilder a)
        {
            var b = new StringBuilder();
            b.Append(a.ToString().Reverse().ToArray());
            b.Insert(0, 'S');
            b.Remove(b.Length - 1, 1);
            return b;
        }
    }
}