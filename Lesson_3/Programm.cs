//С помощью стэк инвертируйте порядок элементов списка
using System.Data.Common;
using System.Threading.Channels;

namespace Lesson_3;
internal class Programm
{
    private static void Main(string[] args)
    {
        int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
        };
        Console.WriteLine($"Количество выходов: {HasExit(3, 0, labirynth1)}"); 

    }

    private static void Task_01_Iterator()
    {
        foreach (var x in new CustomEmumerable())
        {
            Console.Write(x + " ");
        }
    }

    private static void Task_00_Reverse()
    {
        List<int> ints = [1, 2, 3, 4, 5];
        ReverseList(ints);
        ints.ForEach(value => Console.Write(value + " "));
        Console.WriteLine();
    }

    private static List<int> ReverseList(List<int> list)
    {
        Stack<int> stack = new(5);
        list.ForEach(item => stack.Push(item));
        list.Clear();
        while (stack.TryPop(out int topItem))
            list.Add(topItem);
        return list;
    }
    private static (int Row, int Column) FindPath(int[,] labyrint, int row, int column, Stack<Tuple<int, int>> stack, List<Tuple<int, int>> exits)
    {
        if (row < 0 || row >= labyrint.GetLength(0) || column < 0 || column >= labyrint.GetLength(1))
            return (-1, -1);

        if (labyrint[row, column] == 1 || stack.Contains(new Tuple<int, int>(row, column)))
            return (-1, -1);

        if (labyrint[row, column] == 2 && !exits.Contains(new Tuple<int, int>(row, column)))
        {
            exits.Add(new Tuple<int, int>(row, column));
            //return (row, column);
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
        static int HasExit(int startI, int startJ, int[,] l)
    {
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        List<Tuple<int, int>> exits = new List<Tuple<int, int>>();
        var result = FindPath(l, startI, startJ, stack, exits);
/*        foreach (var item in exits)
        {
            Console.Write($"({item.Item1}, {item.Item2})");
            Console.WriteLine();
        }*/
        return exits.Count;
    }
}