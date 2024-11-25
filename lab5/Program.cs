using System.Text;

namespace lab5;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string path = "LR5-var4.xls";
        string[] sheetNames = DBWorker.GetSheetNames(path);
        string userInput;
        string userChoice;

        do
        {
            Console.WriteLine("Настройки логирования:");
            Console.WriteLine("Создать новый файл или дописывать в существующий? ([Н]овый / [Д]обавить): ");
            userInput = Console.ReadLine();
        } while (userInput?.ToLower() != "н" && userInput?.ToLower() != "д");

        bool append = userInput?.ToLower() == "д";
        var logger = new Logger("log.txt", append);

        var dbWorker = new DBWorker(logger);

        dbWorker.LoadDataFromExcel(path);

        do
        {
            Console.WriteLine();
            Console.WriteLine($"""
                               Приложение для работы с Excel-файлом.
                               
                               На данный момент загружен файл {path}.
                               Файл содержит следующие листы:
                               {string.Join(", ", sheetNames)}
                               
                               -----------------------------------------
                               
                               Доступный функционал:
                               1. Вывод содержимого базы данных.
                               2. Удаление строки из базы данных.
                               3. Обновление строки в базе данных.
                               4. Добавление строки в базу данных.
                               5. //TODO Запрос 1
                               6. //TODO Запрос 2
                               7. //TODO Запрос 3
                               8. //TODO Запрос 4
                               0. Выход из программы.
                               
                               -----------------------------------------
                               """);

            do
            {
                Console.WriteLine("Выберите действие: ");
                userChoice = Console.ReadLine();
            } while (int.TryParse(userInput, out int number) && number >= 0 && number <= 8);

            switch (userChoice)
            {
                case "1":
                    dbWorker.PrintData();
                    break;
                case "2":
                    Console.WriteLine("Введите имя листа из которого будет происходить удаление: ");
                    string sheetName = Console.ReadLine();

                    while (!sheetNames.Contains(sheetName))
                    {
                        Console.WriteLine("Неверное имя листа. Пожалуйста, введите существующее имя листа: ");
                        sheetName = Console.ReadLine();
                    }

                    Console.WriteLine("Введите ID строки, которую хотите удалить: ");
                    string idInput = Console.ReadLine();
                    int id;

                    while (!int.TryParse(idInput, out id) || id < 0)
                    {
                        Console.WriteLine("Неверный ID. Пожалуйста, введите положительное целое число: ");
                        idInput = Console.ReadLine();
                    }

                    dbWorker.DeleteRowById(path, sheetName!, id);
                    break;
                case "3":
                    Console.WriteLine("Введите имя листа который будем обновлять: ");
                    sheetName = Console.ReadLine();

                    while (!sheetNames.Contains(sheetName))
                    {
                        Console.WriteLine("Неверное имя листа. Пожалуйста, введите существующее имя листа: ");
                        sheetName = Console.ReadLine();
                    }

                    Console.WriteLine("Введите ID строки, которую хотите обновить: ");
                    idInput = Console.ReadLine();

                    while (!int.TryParse(idInput, out id) || id < 0)
                    {
                        Console.WriteLine("Неверный ID. Пожалуйста, введите положительное целое число: ");
                        idInput = Console.ReadLine();
                    }

                    var columns = DBWorker.GetColumnCount(path, sheetName!);
                    List<string> data = new List<string>();
                    data.Add(idInput);
                    Console.WriteLine("Введите новые данные для строки: ");
                    for (int i = 1; i < columns; i++)
                    {
                        Console.WriteLine($"Введите значение для столбца {i + 1}: ");
                        userInput = Console.ReadLine();
                        data.Add(userInput);
                    }

                    dbWorker.UpdateRowById(path, sheetName!, id, data);
                    break;
                case "4":
                    // Call method to add row
                    break;
                case "5":
                    // TODO: Implement query 1
                    break;
                case "6":
                    // TODO: Implement query 2
                    break;
                case "7":
                    // TODO: Implement query 3
                    break;
                case "8":
                    // TODO: Implement query 4
                    break;
                case "0":
                    Console.WriteLine("Выход из программы.");
                    break;
            }
        } while (userChoice != "0");
    }
}