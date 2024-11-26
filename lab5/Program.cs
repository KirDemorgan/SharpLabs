using System.Text;

namespace lab5;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        const string path = "LR5-var4.xls";
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
        logger.Info($"Запуск программы в {DateTime.Now} от пользователя {Environment.UserName} на машине {Environment.MachineName} с OS {Environment.OSVersion} и {Environment.ProcessorCount} ядрами процессора");

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
                               5. Сколько водителей младше 30 лет и со стажем вождения менее 5 лет?
                               6. Какое количество рейсов было совершено (началось и закончилось) в 2023 году 
                                    на автомобилях марки «Toyota», выпущенных после 2005 года?
                               7. Информация о поездках, где марка автомобиля «Toyota» или «Alfa Romeo» 
                                    и возраст водителя больше 55 лет.
                               8. Найти топ-5 самых опытных водителей (по стажу), которые совершали рейсы на автомобилях, 
                                    выпущенных после 2010 года, и при этом средняя стоимость рейсов превышала 5000.
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
                    try
                    {
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
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка при обновлении строки: {e.Message}");
                        logger.Error($"Ошибка при обновлении строки: {e.Message}");
                    }
                    break;
                case "4":
                    try
                    {
                        Console.WriteLine("Введите имя листа в который будем добавлять: ");
                        sheetName = Console.ReadLine();

                        while (!sheetNames.Contains(sheetName))
                        {
                            Console.WriteLine("Неверное имя листа. Пожалуйста, введите существующее имя листа: ");
                            sheetName = Console.ReadLine();
                        }

                        var columns = DBWorker.GetColumnCount(path, sheetName!);
                        List<string> data = new List<string>();

                        Console.WriteLine("Введите новые данные для строки: ");
                        for (int i = 1; i < columns; i++)
                        {
                            Console.WriteLine($"Введите значение для столбца {i + 1}: ");
                            userInput = Console.ReadLine();
                            data.Add(userInput);
                        }
                        dbWorker.AddRow(path, sheetName!,data);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    break;
                case "5":
                    // Обращение в 1 таблицу
                    logger.Info("Инициализация запроса 1");
                    Console.WriteLine("\nСколько водителей младше 30 лет и со стажем вождения менее 5 лет?");
                    var drivers = dbWorker.Query1();
                    Console.WriteLine($"Ответ: {drivers}");
                    break;
                case "6":
                    // Обращение в 2 таблицы
                    logger.Info("Инициализация запроса 2");
                    Console.WriteLine(
                        "\nКакое количество рейсов было совершено (началось и закончилось) в 2023 году " +
                        "на автомобилях марки «Toyota», выпущенных после 2005 года?");
                    var trips = dbWorker.Query2();
                    Console.WriteLine($"Ответ: {trips}");
                    break;
                case "7":
                    // Обращение в 3 таблицы
                    logger.Info("Инициализация запроса 3");
                    Console.WriteLine(
                        "Информация о поездках, где марка автомобиля «Toyota» или «Alfa Romeo» и возраст водителя больше 55 лет.");
                    dbWorker.Query3();
                    break;
                case "8":
                    // Обращение в 3 таблицы
                    logger.Info("Инициализация запроса 4");
                    Console.WriteLine("Найти топ-5 самых опытных водителей (по стажу), которые совершали рейсы на автомобилях, " +
                                      "выпущенных после 2010 года, и при этом средняя стоимость рейсов превышала 5000.");
                    dbWorker.Query4();
                    break;
                case "0":
                    Console.WriteLine("Выход из программы.");
                    break;
            }
        } while (userChoice != "0");
    }
}