using Aspose.Cells;

namespace lab5;

public class DBWorker
{
    private List<Car> _cars;
    private List<Driver> _drivers;
    private List<TripData> _trips;
    private Logger _logger;

    public DBWorker(Logger logger)
    {
        _cars = new List<Car>();
        _drivers = new List<Driver>();
        _trips = new List<TripData>();
        _logger = logger;
    }

    public void LoadDataFromExcel(string path)
    {
        try
        {
            _logger.Info($"Загрузка данных из Excel файла: {path}");

            // Load first sheet with cars
            Worksheet carSheet = new Workbook(path).Worksheets[0];
            _cars = carSheet.Cells.Rows.Cast<Row>()
                .Skip(1)
                .Select(row => new Car(
                    int.Parse(row.GetCellOrNull(0).Value.ToString()),
                    row.GetCellOrNull(1).Value.ToString(),
                    row.GetCellOrNull(2).Value.ToString(),
                    int.Parse(row.GetCellOrNull(3).Value.ToString())))
                .ToList();
            _logger.Info($"Загружено {_cars.Count} автомобилей");

            // Load second sheet with drivers
            Worksheet driverSheet = new Workbook(path).Worksheets[1];
            _drivers = driverSheet.Cells.Rows.Cast<Row>()
                .Skip(1)
                .Select(row => new Driver(
                    int.Parse(row.GetCellOrNull(0).Value.ToString()),
                    row.GetCellOrNull(1).Value.ToString(),
                    int.Parse(row.GetCellOrNull(2).Value.ToString()),
                    int.Parse(row.GetCellOrNull(3).Value.ToString())))
                .ToList();
            _logger.Info($"Загружено {_drivers.Count} водителей");

            // Load third sheet with trips
            Worksheet tripSheet = new Workbook(path).Worksheets[2];
            _trips = tripSheet.Cells.Rows.Cast<Row>()
                .Skip(1)
                .Select(row => new TripData(
                    int.Parse(row.GetCellOrNull(0).Value.ToString()),
                    int.Parse(row.GetCellOrNull(1).Value.ToString()),
                    int.Parse(row.GetCellOrNull(2).Value.ToString()),
                    DateTime.Parse(row.GetCellOrNull(3).Value.ToString()).Date,
                    DateTime.Parse(row.GetCellOrNull(4).Value.ToString()).Date,
                    double.Parse(row.GetCellOrNull(5).Value.ToString()),
                    decimal.Parse(row.GetCellOrNull(6).Value.ToString())))
                .ToList();
            _logger.Info($"Загружено {_trips.Count} поездок");

            _logger.Info("Все данные успешно загружены");
        }
        catch (Exception e)
        {
            _logger.Error($"Ошибка при загрузке данных из Excel файла: {e.Message}");
            Console.WriteLine($"Ошибка при загрузке данных из Excel файла: {e.Message}");
        }
    }

    public void PrintData()
    {
        _logger.Info("Вывод данных в консоль");
        Console.WriteLine("====================================");
        Console.WriteLine("Автомобили:");
        _logger.Info("Вывод автомобилей в консоль");
        _cars.ForEach(car => Console.WriteLine(car.ToString()));

        Console.WriteLine("====================================");
        Console.WriteLine("Водители:");
        _logger.Info("Вывод водителей в консоль");
        _drivers.ForEach(driver => Console.WriteLine(driver.ToString()));

        Console.WriteLine("====================================");
        Console.WriteLine("Поездки:");
        _logger.Info("Вывод поездок в консоль");
        _trips.ForEach(trip => Console.WriteLine(trip.ToString()));
    }

    public void DeleteRowById(string path, string sheetName, int dataId)
    {
        try
        {
            _logger.Info($"Удаление строки с id {dataId} из листа {sheetName} в файле {path}");
            Console.WriteLine($"Удаление строки с id {dataId} из листа {sheetName} в файле {path}");

            using (var workbook = new Workbook(path))
            {
                var worksheet = workbook.Worksheets[sheetName];
                var rowToDelete = worksheet.Cells.Rows
                    .Cast<Row>()
                    .FirstOrDefault(row => row.GetCellOrNull(0)?.IntValue == dataId);

                if (rowToDelete != null)
                {
                    worksheet.Cells.DeleteRow(rowToDelete.Index);
                }
                else
                {
                    _logger.Warning($"Строка с id {dataId} не найдена в листе {sheetName} в файле {path}");
                    Console.WriteLine($"Строка с id {dataId} не найдена в листе {sheetName} в файле {path}");
                    return;
                }

                _logger.Info($"Строка с id {dataId} успешно удалена из листа {sheetName} в файле {path}");
                Console.WriteLine($"Строка с id {dataId} успешно удалена из листа {sheetName} в файле {path}");
                workbook.Save(path);
            }
        }
        catch (Exception e)
        {
            _logger.Error($"Ошибка при удалении строки с id {dataId} из листа {sheetName} в файле {path}: {e.Message}");
            Console.WriteLine($"Ошибка при удалении строки с id {dataId} из листа {sheetName} в файле {path}: {e.Message}");
        }
    }

    public static string[] GetSheetNames(string path)
    {
        Workbook workbook = new Workbook(path);
        int sheetCount = workbook.Worksheets.Count;
        string[] sheetNames = new string[sheetCount];

        for (int i = 0; i < sheetCount; i++)
        {
            sheetNames[i] = workbook.Worksheets[i].Name;
        }
        return sheetNames;
    }
}