namespace Lesson_3
{
    internal class Task_03
    {
        private int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 2 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 }
        };

        public List<Tuple<int, int>> FindExit(int Row, int Column)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            List<Tuple<int, int>> exits = new List<Tuple<int, int>>();
            var result = FindPath(labirynth1, Row, Column, stack, exits);

            if (labirynth1[Row, Column] != 0)
            {
                Console.WriteLine("Вы указали на стену. Путь не найден.");
                return exits;
            }

            else
            {
                Console.WriteLine("Выходы:");
                foreach (var item in exits)
                {
                    Console.Write($"({item.Item1}, {item.Item2})");
                    Console.WriteLine();
                }
                return exits;
            }
        }

        private (int Row, int Column) FindPath(int[,] labyrint, int row, int column, Stack<Tuple<int, int>> stack, List<Tuple<int, int>> exits)
        {
            if (row < 0 || row >= labyrint.GetLength(0) || column < 0 || column >= labyrint.GetLength(1))
                return (-1, -1);

            if (labyrint[row, column] == 1 || stack.Contains(new Tuple<int, int>(row, column)))
                return (-1, -1);

            if (labyrint[row, column] == 2)
            {
                exits.Add(new Tuple<int, int>(row, column));
                //  return (row, column);
            }

            stack.Push(new Tuple<int, int>(row, column));

            (int Row, int Column) result;

            result = FindPath(labyrint, row - 1, column, stack, exits);
            if (result != (-1, -1)) return result;

            result = FindPath(labyrint, row + 1, column, stack, exits);
            if (result != (-1, -1)) return result;

            result = FindPath(labyrint, row, column - 1, stack, exits);
            if (result != (-1, -1)) return result;

            result = FindPath(labyrint, row, column + 1, stack, exits);
            if (result != (-1, -1)) return result;

            stack.Pop();

            return (-1, -1);
        }
    }
}