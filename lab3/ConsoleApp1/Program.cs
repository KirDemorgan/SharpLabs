namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите задание:");
        int taskChoice = int.Parse(Console.ReadLine());
        switch (taskChoice)
        {
            case 1:
                try
                {
                    Console.WriteLine("Task 1.1");
                    Console.Write("Введите n размерность массива: ");
                    int n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        throw new ArgumentException();
                    }

                    Console.Write("Введите m размерность массива: ");
                    int m = int.Parse(Console.ReadLine());
                    if (m <= 0)
                    {
                        throw new ArgumentException();
                    }

                    var task123 = new Task123(n, m);
                    Console.WriteLine("\n" + task123);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Неправильный ввод. Попробуйте еще раз.");
                }

                // Task 1.22
                try
                {
                    Console.WriteLine("\nTask 1.2");
                    Console.Write("Введите n размерность массива: ");
                    int n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        throw new ArgumentException();
                    }

                    var task123 = new Task123(n);
                    Console.WriteLine(task123);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Неправильный ввод. Попробуйте еще раз.");
                }

                // Task 1.3
                try
                {
                    Console.WriteLine("\nTask 1.3");
                    Console.Write("Введите n размерность массива: ");
                    int n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        throw new ArgumentException();
                    }

                    var task123 = new Task123(n, "3");
                    Console.WriteLine(task123);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неправильный ввод. Попробуйте еще раз.");
                }

                break;

            case 2:
                // Task 2
                try
                {
                    double[,] debts =
                    {
                        { 0, 10, 2 }, // 0 - банк должен 1-му банку 10, 1-му банку 2
                        { 5, 0, 15 }, // 1 - банк должен 0-му банку 5, 2-му банку 15
                        { 10, 5, 0 } // 2 - банк должен 0-му банку 10, 1-му банку 5
                    };
                    Console.WriteLine("\nTask 2");
                    var task2 = new Task123(debts);
                    Console.WriteLine(task2);
                    Console.WriteLine("Банк с максимальным долгом: " + task2.GetBankWithMaxDebt());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неправильный ввод. Попробуйте еще раз.");
                }

                break;

            case 3:
                // Task 3
                try
                {
                    Console.WriteLine("\nTask 3");
                    double[,] aData =
                    {
                        { 1, 2, 3 },
                        { 4, 5, 6 },
                        { 7, 8, 9 }
                    };
                    var a = new Task123(aData);

                    double[,] bData =
                    {
                        { 9, 8, 7 },
                        { 6, 5, 4 },
                        { 3, 2, 1 }
                    };
                    var b = new Task123(bData);

                    double[,] cData =
                    {
                        { 3, 5, 6 },
                        { 7, 5, 4 },
                        { 2, 8, 1 }
                    };
                    var c = new Task123(cData);

                    Console.WriteLine("2*A-Bt*C");
                    Console.WriteLine(2 * a - b.Transpose() * c);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неправильный ввод. Попробуйте еще раз.");
                }

                break;

            case 4:
                try
                {
                    Task48.WriteRandomNumbers("task4.bin", 100);
                    Console.WriteLine("Task 4. Количество противоположных пар: " +
                                      Task48.CountOppositePairs("task4.bin"));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }

                // Task 4
                break;

            case 5:
                try
                {
                    // Task 5
                    List<Baggage> baggageList = new List<Baggage>
                    {
                        new Baggage { Name = "Bag1", Weight = 10 },
                        new Baggage { Name = "Bag2", Weight = 20 },
                        new Baggage { Name = "Bag3", Weight = 30 }
                    };
                    Task48.WriteBaggageData("baggageData", baggageList);
                    double diff = Task48.CalculateBaggageWeightDifference("baggageData");
                    Console.WriteLine("Task 5. Разница веса багажа: " + diff);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }

                break;
            case 6:
                try
                {
                    string filePath = "task6.txt";
                    Task48.WriteRandomNumbersToFile(filePath, 100);
                    bool result = Task48.FileContainsZero(filePath);
                    Console.WriteLine("Файл не содержит нуля: " + result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }

                break;
            case 7:
                try
                {
                    string filePath = "task7.txt";
                    Task48.WriteRandomNumbersToFile(filePath, 10, 5);
                    int max = Task48.FindMaxInFile(filePath);
                    Console.WriteLine("Task 7. Максимальный элемент: " + max);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                break;
            case 8:
                try
                {
                    string inputFilePath = "input.txt";
                    string outputFilePath = "output.txt";
                    Console.WriteLine("Введите символ:");
                    char endingChar = Console.ReadLine()[0];
                    Task48.CopyLinesEndingWithChar(inputFilePath, outputFilePath, endingChar);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                break;
        }
    }
}
