//С помощью стэк инвертируйте порядок элементов списка
namespace Lesson_3;
internal class Programm
{
    private static void Main(string[] args)
    {
        //Task_00_Reverse();
        //Task_01_Iterator();
        Task_03 task_03 = new();
        var coords = task_03.FindExit(3, 0);
        if (coords.Count == 0)
            Console.WriteLine("Путь не найден");
        else
            Console.WriteLine($"Количество выходов: {coords.Count}");
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
}