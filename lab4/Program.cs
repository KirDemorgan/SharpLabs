using System.Text;

namespace lab4;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Task 1");
        List<int> list = new List<int> { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Список чисел:");
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.Write("Введите e: ");
        try
        {
            int e = int.Parse(Console.ReadLine());
            if (!list.Contains(e))
            {
                throw new Exception("Элемент не найден в списке.");
            }
            Tasks.FirstTask(list, e);
            Console.WriteLine("Результат:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------

        Console.WriteLine();
        Console.WriteLine("\nTask 2");
        LinkedList<int> list2 = new LinkedList<int>([1, 2, 3, 4, 5, 1]);

        bool result = Tasks.SecondTask(list2);

        Console.WriteLine(result
            ? "В списке есть элемент равный следующему."
            : "В списке нет элемента равного следующему.");

        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------

        Console.WriteLine("\nTask 3");

        List<HashSet<string>> touristsData =
        [
            new HashSet<string> { "Kazakhstan", "India", "Italy" },
            new HashSet<string> { "Kazakhstan", "Japan", "Italy" },
            new HashSet<string> { "Kazakhstan", "India", "Japan" }
        ];

        HashSet<string> countries = ["India", "Kazakhstan", "Italy", "Japan", "Russia"];

        Tasks.ThirdTask(touristsData, countries);

        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------

        Console.WriteLine("\nTask 4");
        const string filePath = "task4.txt";
        Tasks.FourthTask(filePath);

        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------------------------------
        Console.WriteLine();
        Console.WriteLine("\nTask 5");
        const string filePath5 = "task5.xml";
        Tasks.ReadApplicantsFromInput(filePath5);
        Tasks.FifthTask(filePath5);

    }
}