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
                LoadDataFromExcel(path);
            }
        }
        catch (Exception e)
        {
            _logger.Error($"Ошибка при удалении строки с id {dataId} из листа {sheetName} в файле {path}: {e.Message}");
            Console.WriteLine(
                $"Ошибка при удалении строки с id {dataId} из листа {sheetName} в файле {path}: {e.Message}");
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

    public static int GetColumnCount(string path, string sheetName)
    {
        Workbook workbook = new Workbook(path);
        Worksheet worksheet = workbook.Worksheets[sheetName];
        return worksheet.Cells.MaxDataColumn + 1;
    }

    public void UpdateRowById(string path, string sheetName, int dataId, List<string> data)
    {
        try
        {
            _logger.Info($"Обновление строки с id {dataId} в листе {sheetName} в файле {path}");
            Console.WriteLine($"Обновление строки с id {dataId} в листе {sheetName} в файле {path}");

            using (var workbook = new Workbook(path))
            {
                var worksheet = workbook.Worksheets[sheetName];
                var rowToUpdate = worksheet.Cells.Rows
                    .Cast<Row>()
                    .Skip(1)
                    .FirstOrDefault(row => row.GetCellOrNull(0)?.IntValue == dataId);

                if (rowToUpdate != null)
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        rowToUpdate.GetCellOrNull(i).PutValue(data[i]);
                    }
                }
                else
                {
                    _logger.Warning($"Строка с id {dataId} не найдена в листе {sheetName} в файле {path}");
                    Console.WriteLine($"Строка с id {dataId} не найдена в листе {sheetName} в файле {path}");
                    return;
                }

                _logger.Info($"Строка с id {dataId} успешно изменена в листе {sheetName} в файле {path}");
                Console.WriteLine($"Строка с id {dataId} успешно изменена в листе {sheetName} в файле {path}");
                workbook.Save(path);
                LoadDataFromExcel(path);
            }
        }
        catch (Exception e)
        {
            _logger.Error(
                $"Ошибка при обновлении строки с id {dataId} в листе {sheetName} в файле {path}: {e.Message}");
            Console.WriteLine(
                $"Ошибка при обновлении строки с id {dataId} в листе {sheetName} в файле {path}: {e.Message}");
        }
    }

    public void AddRow(string path, string sheetName, List<string> data)
    {
        try
        {
            _logger.Info($"Добавление новой строки в лист {sheetName} в файле {path}");
            Console.WriteLine($"Добавление новой строки в лист {sheetName} в файле {path}");

            using (var workbook = new Workbook(path))
            {
                var worksheet = workbook.Worksheets[sheetName];
                var rows = worksheet.Cells.Rows.Cast<Row>()
                    .Skip(1)
                    .ToList();

                int maxId = rows.Max(row => row.GetCellOrNull(0)?.IntValue ?? 0);
                int newId = maxId + 1;

                int newRowIdx = worksheet.Cells.MaxDataRow + 1;
                data.Insert(0, newRowIdx.ToString());

                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[newRowIdx, i].PutValue(data[i]);
                }

                _logger.Info($"Новая строка с id {newId} успешно добавлена в лист {sheetName} в файле {path}");
                Console.WriteLine($"Новая строка с id {newId} успешно добавлена в лист {sheetName} в файле {path}");
                workbook.Save(path);
                LoadDataFromExcel(path);
            }
        }
        catch (Exception e)
        {
            _logger.Error($"Ошибка при добавлении новой строки в лист {sheetName} в файле {path}: {e.Message}");
            Console.WriteLine($"Ошибка при добавлении новой строки в лист {sheetName} в файле {path}: {e.Message}");
        }
    }

    public int Query1()
    {
        // Сколько водителей младше 30 лет и со стажем вождения менее 5 лет?
        _logger.Info("Сколько водителей младше 30 лет и со стажем вождения менее 5 лет?");

        var youngDriversCount = _drivers
            .Count(driver => driver.Age < 30 && driver.DrivingExperience < 5);
        _logger.Info($"Ответ: {youngDriversCount}");

        return youngDriversCount;
    }

    public int Query2()
    {
        // какое количество рейсов было совершено (началось и закончилось) в 2023 году на
        // автомобилях марки «Toyota», выпущенных после 2005 года? Ответ 7

        // var toyotaIds = _cars
        //     .Where(car => car.Brand == "Toyota" && car.Year > 2005)
        //     .Select(car => car.Id)
        //     .ToList();
        // var tripsCount = _trips
        //     .Count(trip => toyotaIds.Contains(trip.CarId) && trip.StartDate.Year == 2023 && trip.EndDate.Year == 2023);
        _logger.Info(
            "Какое количество рейсов было совершено (началось и закончилось) в 2023 году на автомобилях марки «Toyota», выпущенных после 2005 года?");

        var tripsCount = _trips
            .Count(trip => _cars
                               .Any(car => car.Id == trip.CarId && car.Brand.ToLower() == "toyota" && car.Year > 2005)
                           && trip.StartDate.Year == 2023
                           && trip.EndDate.Year == 2023);

        _logger.Info($"Ответ: {tripsCount}");

        return tripsCount;
    }

    public void Query3()
    {
        // Вывести информацию о поездках, где марка автомобиля «Toyota» или «Alfa Romeo» и возраст водителя больше 55 лет

        _logger.Info(
            "Информация о поездках, где марка автомобиля «Toyota» или «Alfa Romeo» и возраст водителя больше 55 лет");
        var result = from trip in _trips
            join car in _cars on trip.CarId equals car.Id
            join driver in _drivers on trip.DriverId equals driver.Id
            where (car.Brand == "Toyota" || car.Brand == "Alfa Romeo") && driver.Age > 55
            select new
            {
                TripId = trip.Id,
                CarBrand = car.Brand,
                DriverName = driver.Name,
                DriverAge = driver.Age,
                trip.StartDate,
                trip.EndDate
            };

        foreach (var trip in result)
        {
            Console.WriteLine(
                $"TripId: {trip.TripId}, CarBrand: {trip.CarBrand}, DriverName: {trip.DriverName}, DriverAge: {trip.DriverAge}, StartDate: {trip.StartDate:dd-MM-yyyy}, EndDate: {trip.EndDate:dd-MM-yyyy}");
            _logger.Info(
                $"TripId: {trip.TripId}, CarBrand: {trip.CarBrand}, DriverName: {trip.DriverName}, DriverAge: {trip.DriverAge}, StartDate: {trip.StartDate:dd-MM-yyyy}, EndDate: {trip.EndDate:dd-MM-yyyy}");
        }
    }

    public void Query4()
    {
        //Найти топ-5 самых опытных водителей (по стажу), которые совершали рейсы на автомобилях,
        // выпущенных после 2010 года, и при этом средняя стоимость рейсов превышала 5000.
        var topDrivers = (from trip in _trips
            join car in _cars on trip.CarId equals car.Id
            join driver in _drivers on trip.DriverId equals driver.Id
            where car.Year > 2010
            group new
                {
                    trip,
                    driver
                }
                by driver into driverGroup
            let averageCost = driverGroup.Average(x => x.trip.Cost)
            where averageCost > 5000
            orderby driverGroup.Key.DrivingExperience descending
            select new
            {
                DriverName = driverGroup.Key.Name,
                DrivingExperience = driverGroup.Key.DrivingExperience,
                AverageTripCost = averageCost
            }).Take(5);

        foreach (var driver in topDrivers)
        {
            Console.WriteLine($"DriverName: {driver.DriverName}, DrivingExperience: {driver.DrivingExperience}, AverageTripCost: {driver.AverageTripCost}");
        }
    }
}
