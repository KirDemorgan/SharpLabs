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
            _logger.Info($"Loading data from Excel file: {path}");

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

            _logger.Info("Data loaded successfully");
        }
        catch (Exception e)
        {
            _logger.Error($"Error loading data from Excel file: {e.Message}");
        }
    }

    public void PrintData()
    {
        _logger.Info("Printing data to console");
        Console.WriteLine("====================================");
        Console.WriteLine("Cars:");
        _logger.Info("Printing cars to console");
        _cars.ForEach(car => Console.WriteLine(car.ToString()));

        Console.WriteLine("====================================");
        Console.WriteLine("Drivers:");
        _logger.Info("Printing drivers to console");
        _drivers.ForEach(driver => Console.WriteLine(driver.ToString()));

        Console.WriteLine("====================================");
        Console.WriteLine("Trips:");
        _logger.Info("Printing trips to console");
        _trips.ForEach(trip => Console.WriteLine(trip.ToString()));
    }

}